import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { ForeignCourseGOInfo } from "../../models/ForeignCourseGOInfo";
import { ForeignCourseGOInfoService } from "../../service/ForeignCourseGOInfo.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-foreigncoursegoinfo-list",
  templateUrl: "./foreigncoursegoinfo-list.component.html",
  styleUrls: ["./foreigncoursegoinfo-list.component.sass"],
})
export class ForeignCourseGOInfoListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ForeignCourseGOInfo[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "courseName",
    "durationFrom",
    "durationTo",
    "documentName",
    "fileUpload",
    "actions",
  ];
  dataSource: MatTableDataSource<ForeignCourseGOInfo> =
    new MatTableDataSource();

  selection = new SelectionModel<ForeignCourseGOInfo>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private ForeignCourseGOInfoService: ForeignCourseGOInfoService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getForeignCourseGOInfos();
  }

  getForeignCourseGOInfos() {
    this.isLoading = true;
    this.ForeignCourseGOInfoService.getForeignCourseGOInfos(
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
    this.getForeignCourseGOInfos();
  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getForeignCourseGOInfos();
  }

  deleteItem(row) {
    const id = row.foreignCourseGOInfoId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        if (result) {
          this.ForeignCourseGOInfoService.delete(id).subscribe(() => {
            this.getForeignCourseGOInfos();
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
