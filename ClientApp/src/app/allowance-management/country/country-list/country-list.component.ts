import { SelectionModel } from "@angular/cdk/collections";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { Country } from "../../models/country";
import { CountryService } from "../../service/country.service";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
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

  displayedColumns: string[] = [
    "sl",
    "countryName",
    "countryGroupId",
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
    this.searchText = searchText;
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
