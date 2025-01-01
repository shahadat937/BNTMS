import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BudgetType } from "../../models/budgettype";
import { BudgetTypeService } from "../../service/BudgetType.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-budgettype",
  templateUrl: "./budgettype-list.component.html",
  styleUrls: ["./budgettype-list.component.sass"],
})
export class BudgetTypeListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BudgetType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = ["ser", "budgetTypeName", "actions"];
  dataSource: MatTableDataSource<BudgetType> = new MatTableDataSource();

  selection = new SelectionModel<BudgetType>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private BudgetTypeService: BudgetTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getBudgetType();
  }

  getBudgetType() {
    this.isLoading = true;
    this.BudgetTypeService.getBudgetType(
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
    this.getBudgetType();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getBudgetType();
  }

  deleteItem(row) {
    const id = row.budgetTypeId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item")
      .subscribe((result) => {
        if (result) {
          this.BudgetTypeService.delete(id).subscribe(() => {
            this.getBudgetType();
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
