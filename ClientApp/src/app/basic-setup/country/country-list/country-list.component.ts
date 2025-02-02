
import { SelectionModel } from "@angular/cdk/collections";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Country } from "../../models/country";
import { CountryService } from "../../service/country.service";
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from "@angular/material/snack-bar";
import { Subject, Subscription } from "rxjs";
import { debounceTime, distinctUntilChanged } from "rxjs/operators";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-country-list",
  templateUrl: "./country-list.component.html",
  styleUrls: ["./country-list.component.sass"],
})
export class CountryListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Country[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [
    "sl",
    "shortName",
    "countryName",
    "isActive",
    "actions",
  ];
  dataSource: MatTableDataSource<Country> = new MatTableDataSource();

  selection = new SelectionModel<Country>(true, []);

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private countryService: CountryService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getCountries();

    this.searchSubscription = this.searchSubject
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe((searchText) => {
        this.applyFilter(searchText);
      });
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  getCountries() {
    this.isLoading = true;
    this.countryService
      .getCountries(
        this.paging.pageIndex,
        this.paging.pageSize,
        this.searchText
      )
      .subscribe((response) => {
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
    this.getCountries();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g, "");
    this.getCountries();
  }

  deleteItem(row) {
    const id = row.countryId;
    this.confirmService
      .confirm(
        "Confirm delete message",
        "Are You Sure Delete This Country Item"
      )
      .subscribe((result) => {
        if (result) {
          this.countryService.delete(id).subscribe(() => {
            this.getCountries();
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
