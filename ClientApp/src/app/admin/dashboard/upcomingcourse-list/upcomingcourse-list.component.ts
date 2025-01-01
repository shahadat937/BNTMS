import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BNAExamInstructorAssign } from "../../../exam-management/models/bnaexaminstructorassign";
import { BNAExamInstructorAssignService } from "../../../exam-management/service/bnaexaminstructorassign.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DatePipe } from "@angular/common";
import { dashboardService } from "../services/dashboard.service";
import { MasterData } from "../../../../assets/data/master-data";
import { Role } from "../../../core/models/role";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-upcomingcourse-list",
  templateUrl: "./upcomingcourse-list.component.html",
  styleUrls: ["./upcomingcourse-list.component.sass"],
})
export class UpcomingCourseListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  upcomingLocalCourses: any;
  upcomingForeignCourses: any;
  isLoading = false;
  baseSchoolNameId: any;
  courseNameId: any;
  courseTitle: string;
  courseTypeId: number;
  dbType: number;
  userRole = Role;
  role: any;

  groupArrays: { schoolName: string; courses: any }[];
  runningForeignCourses: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "schoolName",
    "course",
    "noOfCandidates",
    "professional",
    "nbcd",
    "durationFrom",
    "durationTo",
    "remark",
    "actions",
  ];
  displayedUpcomingForeignColumns: string[] = [
    "ser",
    "courseTitle",
    "courseName",
    "durationFrom",
    "durationTo",
    "country",
    "actions",
  ];
  constructor(
    private datepipe: DatePipe,
    private authService: AuthService,
    private dashboardService: dashboardService,
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
    this.role = this.authService.currentUserValue.role.trim();
    // var courseTypeId = this.route.snapshot.paramMap.get('courseTypeId');
    this.getSpCourseDurations(3);
  }

  // onModuleSelectionChangeGetsubjectList(){
  //   var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
  //   var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
  //   if(baseSchoolNameId != null && courseNameId !=null){
  //     this.BNAExamInstructorAssignService.getInstructorBySchoolAndCourse(baseSchoolNameId,courseNameId).subscribe(res=>{
  //       this.GetInstructorByParameters=res;
  //     });
  //   }
  // }

  inActiveItem(id) {
    this.courseTypeId = id;
    this.getSpCourseDurations(this.courseTypeId);
  }
  getSpCourseDurations(id: number) {
    this.isLoading = true;
    this.courseTypeId = id;
    let currentDateTime =
      this.datepipe.transform(new Date(), "MM/dd/yyyy") || "";
    if (this.courseTypeId == this.masterData.coursetype.LocalCourse) {
      this.dashboardService
        .getSpCourseDurationsByType(this.courseTypeId, currentDateTime)
        .subscribe((response) => {
          this.upcomingLocalCourses = response;

          // this gives an object with dates as keys
          const groups = this.upcomingLocalCourses.reduce((groups, courses) => {
            const schoolName = courses.schoolName;
            if (!groups[schoolName]) {
              groups[schoolName] = [];
            }
            groups[schoolName].push(courses);
            return groups;
          }, {});

          // Edit: to add it in the array format instead
          this.groupArrays = Object.keys(groups).map((schoolName) => {
            return {
              schoolName,
              courses: groups[schoolName],
            };
          });

          // this.upcomingLocalCourses=response;
        });
    } else if (this.courseTypeId === this.masterData.coursetype.ForeignCourse) {
      this.dashboardService
        .getSpForeignCourseDurationsByType(this.courseTypeId, currentDateTime)
        .subscribe((response) => {
          this.upcomingForeignCourses = response;
        });
    } else {
      this.dashboardService
        .getSpCourseDurationsByType(this.courseTypeId, currentDateTime)
        .subscribe((response) => {
          // this.dataSource.data=response;
        });
    }
  }

  getRemainingDays(getStartDate) {
    var date1 = new Date(getStartDate);
    var date2 = new Date();
    var Time = date1.getTime() - date2.getTime();
    var Days = Time / (1000 * 3600 * 24);
    var dayCount = Days + 1;
    return dayCount.toFixed(0);
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
