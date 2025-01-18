import { SelectionModel } from "@angular/cdk/collections";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { AllowancePercentage } from "../../models/allowancepercentage";
import { AllowancePercentageService } from "../../service/allowancepercentage.service";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-allowancepercentage-list",
  templateUrl: "./allowancepercentage-list.component.html",
  styleUrls: ["./allowancepercentage-list.component.sass"],
})
export class AllowancePercentageListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: AllowancePercentage[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "sl",
    "allowanceName",
    "percentage",
    "displayPriority",
    "actions",
  ];
  dataSource: MatTableDataSource<AllowancePercentage> =
    new MatTableDataSource();

  selection = new SelectionModel<AllowancePercentage>(true, []);

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private AllowancePercentageService: AllowancePercentageService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getAllowancePercentages();
  }

  getAllowancePercentages() {
    this.isLoading = true;
    this.AllowancePercentageService.getAllowancePercentages(
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
    this.getAllowancePercentages();
  }

  applyFilter(searchText: string) {
    this.searchText = searchText? searchText.trim() : searchText;
    this.getAllowancePercentages();
  }

  deleteItem(row) {
    const id = row.allowancePercentageId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        if (result) {
          this.AllowancePercentageService.delete(id).subscribe(() => {
            this.getAllowancePercentages();
            this.snackBar.open("Information Deleted Successfully ", "", {
              duration: 3000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }
}
