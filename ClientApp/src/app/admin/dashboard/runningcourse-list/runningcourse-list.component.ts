import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNAExamInstructorAssign } from '../../../exam-management/models/bnaexaminstructorassign';
import { BNAExamInstructorAssignService } from '../../../exam-management/service/bnaexaminstructorassign.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';

import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { dashboardService } from '../services/dashboard.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../src/app/core/models/role';
import { environment } from '../../../../../src/environments/environment';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { CourseDuration } from '../models/courseduration';
import { CourseDurationService } from '../services/courseduration.service';

@Component({
  selector: 'app-runningcourse-list',
  templateUrl: './runningcourse-list.component.html',
  styleUrls: ['./style.component.css']
})
export class RunningCourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  loading = false;

  userRole = Role;
  runningCourses: any;
  upcomingCourses: any;
  viewStatus: any;
  isLoading = false;
  baseSchoolNameId: any;
  courseNameId: any;
  courseTitle: string;
  courseListTitle: any;
  runningCourseType: number;
  dbType: number;
  courseTypeId: any;
  showHideDiv = false;
  groupArrays: { schoolName: string; courses: any; }[];
  runningForeignCourses: any;
  interServiceCourses: any;
  passOutStatus: any;
  fileUrl: any = environment.fileUrl;

  branchId: any;
  traineeId: any;
  role: any;


  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['ser', 'schoolName', 'course', 'noOfCandidates', 'professional', 'nbcd', 'durationFrom', 'durationTo', 'remark', 'actions'];
  displayedUpcomingForeignColumns: string[] = ['ser', 'courseTitle', 'courseName', 'durationFrom', 'durationTo', 'country', 'actions'];
  displayedUpcomingInterServiceColumns: string[] = ['ser', 'courseName', 'orgName', 'durationFrom', 'durationTo', 'actions'];
  selectedFilter: any;
  constructor(
    private datepipe: DatePipe,
    private authService: AuthService,
    private dashboardService: dashboardService,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private BNAExamInstructorAssignService: BNAExamInstructorAssignService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,
  ) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    this.courseTypeId = this.route.snapshot.paramMap.get('courseTypeId');
    this.getCoursesByViewType(1);


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


  getDateComparision(obj) {

    var currentDate = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var current = currentDate ? new Date(currentDate) : new Date();
    // var date1 = new Date(obj.durationFrom); 
    var date2 = new Date(obj.durationTo);


    if (current > date2) {
      this.passOutStatus = 1;
    } else {
      this.passOutStatus = 0;
    }
    // else if(current >= date1 && current <= date2){
    //   this.weekStatus = 2;
    // }else if(current < date1){
    //   this.weekStatus = 3;
    // }else{
    // }
  }
  getRemainingDays(getStartDate) {
    var date1 = new Date(getStartDate);
    var date2 = new Date();
    var Time = date1.getTime() - date2.getTime();
    var Days = Time / (1000 * 3600 * 24);
    var dayCount = Days + 1;
    return dayCount.toFixed(0);
  }
  getDaysfromDate(dateFrom: any, dateTo: any) {
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var date1 = new Date(dateFrom);
    var date2 = new Date(dateTo);
    var Time = date2.getTime() - date1.getTime();
    var Days = Time / (1000 * 3600 * 24);
    var dayCount = Days + 1;
    var totalWeeks = 0;
    for (var start = 0; start <= dayCount; start = start + 7) {
      totalWeeks += 1;
    }
    return totalWeeks;
  }
  getCoursesByViewType(viewStatus) {
    this.viewStatus = viewStatus;
    var courseTypeId = this.route.snapshot.paramMap.get('courseTypeId');
    if (viewStatus == 1) {
      this.isLoading
      this.courseListTitle = "Running";
      this.selectedFilter = viewStatus;
      this.masterData.coursetype.LocalCourse
      this.getSpRunningCourseDurations(courseTypeId, viewStatus)
    } else if (viewStatus == 2) {
      this.selectedFilter = viewStatus;
      this.courseListTitle = "Passing Out";
      this.getSpRunningCourseDurations(courseTypeId, viewStatus)
    } else if (viewStatus == 3) {
      this.selectedFilter = viewStatus;
      this.courseListTitle = "Upcomming";
      let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
      if(courseTypeId === this.masterData.coursetype.InterService.toString() || courseTypeId === this.masterData.coursetype.ForeignCourse.toString()){
        this.getSpRunningCourseDurations(courseTypeId, viewStatus)
      }
      else{
        // this.getSpRunningCourseDurations(courseTypeId,viewStatus)
      this.dashboardService.getUpcomingCourseListByBase(currentDateTime, 0).subscribe(response => {

        this.upcomingCourses = response;

        // this gives an object with dates as keys
        const groups = this.upcomingCourses.reduce((groups, courses) => {
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
            courses: groups[schoolName]
          };
        });
        this.isLoading=false
      })
      }
    }
  }

  getSpRunningCourseDurations(id, viewStatus) {
    this.isLoading = true;
    this.runningCourseType = id;
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy')??" ";
    this.dbType = 2;


    if (this.runningCourseType == this.masterData.coursetype.LocalCourse) {
      this.courseTitle = "Local ";
      this.dashboardService.getSpRunningCourseDurationsByType(this.runningCourseType, currentDateTime, viewStatus).subscribe(response => {
        this.runningCourses = response;

        // this gives an object with dates as keys
        const groups = this.runningCourses.reduce((groups, courses) => {
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
            courses: groups[schoolName]
          };
        });
        this.isLoading=false;

      })
    } else if (this.runningCourseType == this.masterData.coursetype.ForeignCourse) {
      this.courseTitle = "Foreign ";
      this.dashboardService.getCourseDurationsByCourseTypeId(1, 1000, '', this.runningCourseType,viewStatus).subscribe(response => {

        this.runningForeignCourses = response.items;
      })
      this.isLoading=false
    } else {
      this.courseTitle = "Inter Service ";
      this.dashboardService.getCourseDurationsByCourseTypeId(1, 1000, '', this.runningCourseType,viewStatus).subscribe(response => {

        this.interServiceCourses = response.items;
      })
      this.isLoading=false;
    }
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    // this.getCourseDurations();
    // getSpRunningCourseDurations();
  }



  print() {

    let printContents, popupWin;
    const printElement = document.getElementById('print-routine');
    printContents = printElement ? printElement.innerHTML : '';
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
    
      <html>
      
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                    .tbl-by-group tr .cl-mrk-rmrk {
                      display:none;
                    }
                    .tbl-by-group tr .btn-tbl-view {
                      display:none;
                    }
                    .tbl-by-group tr .btn-tbl-nomination {
                      display:none;
                    }

                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text, td{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Local Courses</h3>
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
        
        
      </html>`

    );
    popupWin.document.close();

  }


}
