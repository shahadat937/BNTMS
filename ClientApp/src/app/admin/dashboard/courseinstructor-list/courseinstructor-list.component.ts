import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CourseInstructor } from "../../../subject-management/models/courseinstructor";
import { CourseInstructorService } from "../../../subject-management/service/courseinstructor.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-courseinstructor-list",
  templateUrl: "./courseinstructor-list.component.html",
  styleUrls: ["./courseinstructor-list.component.sass"],
})
export class CourseInstructorListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseInstructor[] = [];
  isLoading = false;
  GetInstructorByParameters: CourseInstructor[];
  baseSchoolNameId: any;
  courseNameId: any;
  courseDurationId: any;
  traineeDb: any;
  traineeId: any;
  role: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = ["ser", "bnaSubjectName", "trainee"];
  sharedService: any;

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private route: ActivatedRoute,
    private CourseInstructorService: CourseInstructorService,
    private router: Router,
    private confirmService: ConfirmService
  ) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    const branchId = this.authService.currentUserValue.branchId.trim();
    this.traineeDb = 1;
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
    var bnaSubjectNameId = this.route.snapshot.paramMap.get("bnaSubjectNameId");
    var courseModuleId = this.route.snapshot.paramMap.get("courseModuleId");
    this.courseNameId = this.route.snapshot.paramMap.get("courseNameId");
    this.courseDurationId =
      this.route.snapshot.paramMap.get("courseDurationId");
    if (
      this.baseSchoolNameId != null &&
      bnaSubjectNameId != null &&
      courseModuleId != null &&
      this.courseNameId != null
    ) {
      this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(
        bnaSubjectNameId,
        this.courseDurationId,
        this.courseNameId
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
