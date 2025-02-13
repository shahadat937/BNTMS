import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BNAExamInstructorAssign } from "../../../exam-management/models/bnaexaminstructorassign";
import { BNAExamInstructorAssignService } from "../../../exam-management/service/bnaexaminstructorassign.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-examinstructor-list",
  templateUrl: "./examinstructor-list.component.html",
  styleUrls: ["./examinstructor-list.component.sass"],
})
export class ExamInstructorListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAExamInstructorAssign[] = [];
  isLoading = false;
  GetInstructorByParameters: BNAExamInstructorAssign[];
  baseSchoolNameId: any;
  courseNameId: any;
  courseTypeId: number;
  dbType: any;
  schooldash: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "trainee",
    "bnaSubjectName",
    "classRoutine",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private BNAExamInstructorAssignService: BNAExamInstructorAssignService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.onModuleSelectionChangeGetsubjectList();
  }

  // getCourseInstructors() {
  //   this.isLoading = true;
  //   this.CourseInstructorService.getCourseInstructors(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {

  //     this.dataSource.data = response.items;
  //     this.paging.length = response.totalItemsCount
  //     this.isLoading = false;
  //   })
  // }

  onModuleSelectionChangeGetsubjectList() {
    this.baseSchoolNameId =
      this.route.snapshot.paramMap.get("baseSchoolNameId");
    var courseNameId = this.route.snapshot.paramMap.get("courseNameId");
    this.courseTypeId = Number(
      this.route.snapshot.paramMap.get("courseTypeId")
    );
    this.schooldash = this.route.snapshot.paramMap.get("schooldash");
    this.dbType = this.route.snapshot.paramMap.get("dbType");
    if (this.baseSchoolNameId != null && courseNameId != null) {
      this.BNAExamInstructorAssignService.getInstructorBySchoolAndCourse(
        this.baseSchoolNameId,
        courseNameId
      ).subscribe((res) => {
        this.GetInstructorByParameters = res;
      });
    }
  }

  // pageChanged(event: PageEvent) {

  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getCourseInstructors();

  // }
  // applyFilter(searchText: any){
  //   this.searchText = searchText;
  //   this.getCourseInstructors();
  // }

  // deleteItem(row) {
  //   const id = row.courseInstructorId;
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
  //     if (result) {
  //       this.CourseInstructorService.delete(id).subscribe(() => {
  //         this.getCourseInstructors();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 3000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })

  // }
}
