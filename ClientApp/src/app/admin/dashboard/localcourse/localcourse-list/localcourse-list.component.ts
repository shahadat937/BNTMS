import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CourseDuration } from "../../models/courseduration";
import { CourseDurationService } from "../../services/courseduration.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../../assets/data/master-data";
import { ConfirmService } from "../../../../core/service/confirm.service";
import { SharedServiceService } from "../../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../../shared/UnsubscribeOnDestroyAdapter";


@Component({
  selector: "app-localcourse-list",
  templateUrl: "./localcourse-list.component.html",
  styleUrls: ["./localcourse-list.component.sass"],
})
export class LocalcourseListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  courseTypeId = 3;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "courseType",
    "courseName",
    "durationFrom",
    "durationTo",
  ];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();

  selection = new SelectionModel<CourseDuration>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private CourseDurationService: CourseDurationService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getCourseDurationsByCourseType();
  }
  getCourseDurationsByCourseType() {
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText,
      this.courseTypeId
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
    this.getCourseDurationsByCourseType();
  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getCourseDurationsByCourseType();
  }

  deleteItem(row) {
    const id = row.courseDurationId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item")
      .subscribe((result) => {
        if (result) {
          this.CourseDurationService.delete(id).subscribe(() => {
            this.getCourseDurationsByCourseType();
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
