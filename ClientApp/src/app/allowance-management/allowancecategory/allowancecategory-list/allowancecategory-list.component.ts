import { SelectionModel } from "@angular/cdk/collections";
import { Component, ElementRef, OnInit, ViewChild } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { AllowanceCategory } from "../../models/allowancecategory";
import { AllowanceCategoryService } from "../../service/allowancecategory.service";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { MasterData } from "../../../../assets/data/master-data";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
@Component({
  selector: "app-allowancecategory-list",
  templateUrl: "./allowancecategory-list.component.html",
  styleUrls: ["./allowancecategory-list.component.sass"],
})
export class AllowanceCategoryListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: AllowanceCategory[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "sl",
    "fromRank",
    "toRank",
    "countryGroup",
    "country",
    "currencyName",
    "allowancePercentage",
    "dailyPayment",
    "actions",
  ];
  dataSource: MatTableDataSource<AllowanceCategory> = new MatTableDataSource();

  selection = new SelectionModel<AllowanceCategory>(true, []);

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private AllowanceCategoryService: AllowanceCategoryService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getAllowanceCategories();
  }

  getAllowanceCategories() {
    this.isLoading = true;
    this.AllowanceCategoryService.getAllowanceCategories(
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
    this.getAllowanceCategories();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getAllowanceCategories();
  }

  deleteItem(row) {
    const id = row.allowanceCategoryId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        if (result) {
          this.AllowanceCategoryService.delete(id).subscribe(() => {
            this.getAllowanceCategories();
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
