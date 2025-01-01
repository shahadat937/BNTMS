import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BNAClassScheduleStatus } from "../../models/bnaclassschedulestatus";
import { BNAClassScheduleStatusService } from "../../service/bnaclassschedulestatus.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { Subject, Subscription } from "rxjs";
import { debounceTime, distinctUntilChanged } from "rxjs/operators";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-bnaclassschedulestatus",
  templateUrl: "./bnaclassschedulestatus-list.component.html",
  styleUrls: ["./bnaclassschedulestatus-list.component.sass"],
})
export class BNAClassScheduleStatusListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAClassScheduleStatus[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = ["ser", "name", "isActive", "actions"];
  dataSource: MatTableDataSource<BNAClassScheduleStatus> =
    new MatTableDataSource();

  selection = new SelectionModel<BNAClassScheduleStatus>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private BNAClassScheduleStatusService: BNAClassScheduleStatusService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getBNAClassScheduleStatus();
    this.searchSubscription = this.searchSubject
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe((searchText) => {
        this.applyFilter(searchText);
      });
  }

  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }

  getBNAClassScheduleStatus() {
    this.isLoading = true;
    this.BNAClassScheduleStatusService.getBNAClassScheduleStatus(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew() {}
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getBNAClassScheduleStatus();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g, "");
    this.getBNAClassScheduleStatus();
  }

  deleteItem(row) {
    const id = row.bnaClassScheduleStatusId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item")
      .subscribe((result) => {
        if (result) {
          this.BNAClassScheduleStatusService.delete(id).subscribe(() => {
            this.getBNAClassScheduleStatus();
            this.snackBar.open("Information Delete Successfully ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }
}
