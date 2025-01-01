import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BaseSchoolName } from "../../models/BaseSchoolName";
import { BaseSchoolNameService } from "../../service/BaseSchoolName.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";

import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-baseschoolname",
  templateUrl: "./baseschoolname-list.component.html",
  styleUrls: ["./baseschoolname-list.component.sass"],
})
export class BaseSchoolNameListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BaseSchoolName[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "schoolName",
    "shortName",
    "baseName",
    "schoolLogo",
    "actions",
  ];
  dataSource: MatTableDataSource<BaseSchoolName> = new MatTableDataSource();

  selection = new SelectionModel<BaseSchoolName>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private BaseSchoolNameService: BaseSchoolNameService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getBaseSchoolNames();
  }

  getBaseSchoolNames() {
    this.isLoading = true;
    this.BaseSchoolNameService.getBaseSchoolNames(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getBaseSchoolNames();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getBaseSchoolNames();
  }

  deleteItem(row) {
    const id = row.baseSchoolNameId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        if (result) {
          this.BaseSchoolNameService.delete(id).subscribe(() => {
            this.getBaseSchoolNames();
            this.snackBar.open("Information Deleted Successfully ", "", {
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
