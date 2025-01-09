import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CourseInstructor } from "../../../subject-management/models/courseinstructor";
import { CourseInstructorService } from "../../../subject-management/service/courseinstructor.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { DatePipe } from "@angular/common";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { Role } from "../../../core/models/role";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-courseweekbyduration-list",
  templateUrl: "./courseweekbyduration-list.component.html",
  styleUrls: ["./courseweekbyduration-list.component.sass"],
})
export class CourseWeekByDurationListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  userRole = Role;
  ELEMENT_DATA: CourseInstructor[] = [];
  isLoading = false;
  GetInstructorByParameters: any[];
  baseSchoolNameId: number;
  routingType: any;
  courseNameId: any;
  courseTypeId: any;
  showHideDiv = false;
  branchId: any;
  traineeId: any;
  role: any;
  currentDate: any;
  weekStatus: any;

  dbType: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  groupArrays: { courseModule: string; courses: any }[];

  displayedColumns: string[] = [
    "ser",
    "trainee",
    "bnaSubjectName",
    "courseName",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private datepipe: DatePipe,
    private authService: AuthService,
    private route: ActivatedRoute,
    private CourseInstructorService: CourseInstructorService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.currentDate = this.datepipe.transform(new Date(), "MM/dd/yyyy");

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    this.onModuleSelectionChangeGetsubjectList();
  }

  getDateComparision(obj) {
    this.currentDate = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    //Date dateTime11 = Convert.ToDateTime(dateFrom);
    var current = new Date(this.currentDate);
    var date1 = new Date(obj.dateFrom);
    var date2 = new Date(obj.dateTo);

    if (current > date2) {
      this.weekStatus = 1;
    } else if (current >= date1 && current <= date2) {
      this.weekStatus = 2;
    } else if (current < date1) {
      this.weekStatus = 3;
    } else {
    }
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
    var courseDurationId = this.route.snapshot.paramMap.get("courseDurationId");
    this.courseTypeId = this.route.snapshot.paramMap.get("courseTypeId");
    this.CourseInstructorService.getCourseWeekListByCourseDuration(
      courseDurationId
    ).subscribe((res) => {
      this.GetInstructorByParameters = res;

      // this gives an object with dates as keys
      const groups = this.GetInstructorByParameters.reduce(
        (groups, courses) => {
          const courseModule = courses.weekName;
          if (!groups[courseModule]) {
            groups[courseModule] = [];
          }
          groups[courseModule].push(courses);
          return groups;
        },
        {}
      );

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((courseModule) => {
        return {
          courseModule,
          courses: groups[courseModule],
        };
      });
    });
  }
}
