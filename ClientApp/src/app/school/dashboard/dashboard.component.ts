import { Component, HostListener, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SchoolDashboardService } from '../services/SchoolDashboard.service';
import { ActivatedRoute, Router } from '@angular/router';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexYAxis,
  ApexStroke,
  ApexLegend,
  ApexMarkers,
  ApexGrid,
  ApexFill,
  ApexTitleSubtitle,
  ApexNonAxisChartSeries,
  ApexResponsive,
} from 'ng-apexcharts';
import { MasterData } from 'src/assets/data/master-data';
import { environment } from 'src/environments/environment';
import { DatePipe } from '@angular/common';
import { scheduled } from 'rxjs';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { ReadingMaterialService } from '../../reading-materials/service/readingmaterial.service';
import { StudentDashboardService } from 'src/app/student/services/StudentDashboard.service';
import { BaseSchoolNameService } from 'src/app/basic-setup/service/BaseSchoolName.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ScrollService } from 'src/app/course-management/localcourse/scrole-restore/scrole-position.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

export type avgLecChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  stroke: ApexStroke;
  dataLabels: ApexDataLabels;
  markers: ApexMarkers;
  colors: string[];
  yaxis: ApexYAxis;
  grid: ApexGrid;
  tooltip: ApexTooltip;
  legend: ApexLegend;
  fill: ApexFill;
  title: ApexTitleSubtitle;
};

export type pieChartOptions = {
  series: ApexNonAxisChartSeries;
  chart: ApexChart;
  legend: ApexLegend;
  dataLabels: ApexDataLabels;
  responsive: ApexResponsive[];
  labels: any;
};

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'],
})



export class DashboardComponent implements OnInit {

  newStatus: string = "";
  newStatusCount: number = 0;
  

  @ViewChild('chart') chart: ChartComponent;
  public avgLecChartOptions: Partial<avgLecChartOptions>;
  public pieChartOptions: Partial<pieChartOptions>;
  masterData = MasterData;
  loading = false;
  userRole = Role;
  GetSchoolForm: FormGroup;
  isShown: boolean = false;
  paramBaseSchoolNameId: any;

  dataEnty: any = Role.DataEntry;
  fileUrl: any = environment.fileUrl;
  bulletinList: any;

  courseList: any;

  routineList: any;

  materialList: any;

  nomineeCount: number;
  foreignNomineeCount: number;
  runningOfficerCount: number;
  runningSailorCount: number;
  runningCivilCount: number;
  localCourseCount: number;
  UpcomingCourseCount: number;
  upcomingCourses: any;
  runningCourses: any;
  viewStatus: any;
  viewCourseTitle: any;
  RoutineBySchool: any;
  RoutineByCourse: any;
  PendingExamEvaluation: any;
  TraineeAbsentList: any;
  TodayRoutineList: any;
  TodayAttendanceList: any;
  ReadIngMaterialList: any;
  InstructorList: any;
  schoolId: any;
  schoolDb: any = 1;
  schoolName: any;
  userManual: any;
  dbType: any;
  passOutStatus: any;
  branchId: any;
  traineeId: any;
  role: any;
  userRoleFornotification: any;
  notificationCount: any;

  //For Restoring
  scrollPosition: number = 0;
  oldScrollPosition: number = 0;
  selectedFilter: number;
  index: number;
  //Restoring End

  pageTitle: any;
  selectedschool: SelectedModel[];
  groupArrays: { schoolName: string; courses: any; }[];
  NoticeForSchoolDashboard: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser', 'course', 'durationFrom', 'durationTo', 'countWeek', 'courseSyllabus', 'actions'];
  displayedRoutineColumns: string[] = ['ser', 'date', 'classType', 'duration', 'period', 'subject', 'classLocation', 'name'];
  displayedExamEvaluationColumns: string[] = ['ser', 'course', 'subject', 'date', 'name'];
  displayedAbsentListColumns: string[] = ['ser', 'course', 'duration', 'absent', 'actions'];
  displayedRoutineCountColumns: string[] = ['ser', 'course', 'moduleName', 'routineCount', 'actions'];
  displayedRoutineAbsentColumns: string[] = ['ser', 'course', 'nominated', 'actions'];
  displayedReadingMaterialColumns: string[] = ['ser', 'course', 'materialCount', 'actions'];
  displayedInstructorColumns: string[] = ['ser', 'course', 'instructorCount', 'actions'];
  displayedUpcomingColumns: string[] = ['ser', 'course', 'durationFrom', 'durationTo', 'daysCalculate', 'actions'];
  displayedNbcdUpcomingColumns: string[] = ['ser', 'comeform', 'course', 'durationFrom', 'durationTo', 'daysCalculate', 'actions'];
  constructor(private datepipe: DatePipe, private snackBar: MatSnackBar, private confirmService: ConfirmService, private authService: AuthService, private baseSchoolNameService: BaseSchoolNameService, private studentDashboardService: StudentDashboardService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder, private ReadingMaterialService: ReadingMaterialService, private schoolDashboardService: SchoolDashboardService, private scrollPositionService: ScrollService, public sharedService: SharedServiceService) { }


  @HostListener('window:scroll')
  onWindowScroll() {
    this.scrollPosition = window.scrollY || window.pageYOffset;
  }

  ngOnInit() {

    this.oldScrollPosition = this.scrollPositionService.getScrollPosition('schoolDashboard');
    this.selectedFilter = this.scrollPositionService.getSelectedFilter('schoolDashboard');
    this.index = this.scrollPositionService.getSelectedIndex('schoolDashboard');


    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    // this.branchId =  this.authService.currentUserValue.branchId.trim();
    this.branchId = this.authService.currentUserValue.branchId ? this.authService.currentUserValue.branchId.trim() : "";
    if (this.role == this.userRole.CO || this.role == this.userRole.TrainingOffice || this.role == this.userRole.TC || this.role == this.userRole.TCO) {
      this.schoolId = this.branchId;
      this.pageTitle = "Dashboard";
      // this.getCoursesByViewType(1);
      // this.getRunningCourseDurationByBase(this.branchId); 
      this.getUpcomingCourseListByBase(this.branchId);
      this.getNominetedTraineeListByBase(this.branchId);
      this.getNominetedForeignTraineeListByBase(this.branchId);
      this.geCourseTotalOfficerListByBase(this.branchId);
      this.getNotificationReminderForDashboard();
 

      this.isShown = true;

      this.oldScrollPosition = this.scrollPositionService.getScrollPosition('schoolDashboard');
      this.selectedFilter = this.scrollPositionService.getSelectedFilter('schoolDashboard');
      // setTimeout(() => {
      //   window.scrollTo(0, this.oldScrollPosition);
      // }, 500);
      this.getCoursesByViewType(this.selectedFilter);
    } else {
      this.schoolId = this.branchId;
      this.pageTitle = "School Dashboard";
      this.getselectedschools();
      this.getNotificationReminderForDashboard();
      this.getNominetedTraineeListBySchoolId(this.schoolId);
      this.getNominetedForeignTraineeListBySchoolId(this.schoolId);
      this.getrunningCourseTotalOfficerListBySchoolId(this.schoolId);
      // this.getCoursesByViewType(1);
      this.getUpcomingCourseListBySchool(this.schoolId);
      //this.getUpcomingCourseListByNbcdSchool(this.schoolId);
      this.getPendingExamEvaluation(this.schoolId);
      this.getTraineeAbsentList(this.schoolId);
      this.getRoutineInfoByCourse(this.schoolId);
      this.getCurrentRoutineBySchool(this.schoolId);
      this.getReadingMetarialBySchool(this.schoolId);
      this.getInstructorByCourse(this.schoolId);
      this.getCurrentAttendanceBySchool(this.schoolId);
      this.getActiveBulletins(this.schoolId);
      this.isShown = true;

      this.oldScrollPosition = this.scrollPositionService.getScrollPosition('schoolDashboard');
      this.selectedFilter = this.scrollPositionService.getSelectedFilter('schoolDashboard');
      // setTimeout(() => {
      //   window.scrollTo(0, this.oldScrollPosition);
      // }, 500);
      this.getCoursesByViewType(this.selectedFilter);
    }
    this.schoolId = this.branchId;
    this.baseSchoolNameService.find(this.schoolId).subscribe(response => {
      this.schoolName = response.schoolName;
    })
    
    this.baseSchoolNameService.getUserManualByRole(this.role).subscribe(response => {
      
      this.userManual = response[0]?.doc;
    })


    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    // let currentDateTime = '02/11/2024';
    this.schoolDashboardService.getNoticeBySchoolId(this.schoolId, currentDateTime).subscribe(response => {
      this.NoticeForSchoolDashboard = response;
      response.forEach(element => {
        this.newStatus = element.newStatus;
        if (element.newStatus == "new") {
          this.newStatusCount++;
        }
      });
    })
  }


  ngOnDestroy() {
    this.scrollPositionService.setScrollPosition('schoolDashboard', this.scrollPosition);
    this.scrollPositionService.setSelectedFilter('schoolDashboard', this.selectedFilter);
  }

  GetIndexValue(index: number) {
    this.scrollPositionService.setSelectedIndex('schoolDashboard', index);
  }

  getActiveBulletins(baseSchoolNameId) {
    this.studentDashboardService.getActiveBulletinList(baseSchoolNameId).subscribe(res => {
      this.bulletinList = res;
    });
  }

  getselectedschools() {
    this.ReadingMaterialService.getselectedschools().subscribe(res => {
      this.selectedschool = res;
    });
  }

  getReadingMetarialBySchool(schoolId) {
    this.schoolDashboardService.getReadingMetarialBySchool(schoolId).subscribe(response => {
      this.ReadIngMaterialList = response;
    })
  }
  getCurrentRoutineBySchool(schoolId) {
    this.dbType = 1;
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getCurrentRoutineBySchool(currentDateTime, schoolId).subscribe(response => {
      this.TodayRoutineList = response;
    })
  }

  getCurrentAttendanceBySchool(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getCurrentAttendanceBySchool(currentDateTime, schoolId).subscribe(response => {
      this.TodayAttendanceList = response;
    })
  }

  getNominetedTraineeListBySchoolId(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getnominatedCourseListFromSpRequestBySchoolId(currentDateTime, schoolId).subscribe(response => {
      this.nomineeCount = response.length;
    })
  }

  getNominetedTraineeListByBase(schoolId) {
    // let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getNominatedTotalTraineeByBaseFromSp(schoolId).subscribe(response => {
      this.nomineeCount = response.length;
    })
  }

  getNotificationReminderForDashboard() {
    if (this.role == this.userRole.SchoolOIC) {
      this.userRoleFornotification = this.userRole.SuperAdmin;
    } else {
      this.userRoleFornotification = this.role;
    }
    // let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getNotificationReminderForDashboard(this.userRoleFornotification, this.branchId).subscribe(response => {
      this.notificationCount = response[0].notificationCount;
    })
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

  getRunningCourseDurationByBase(viewStatus) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getRunningCourseDurationByBase(currentDateTime, this.schoolId, viewStatus).subscribe(response => {
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

    })
  }

  getInstructorByCourse(schoolId) {
    this.schoolDashboardService.getInstructorByCourse(schoolId).subscribe(response => {
      this.InstructorList = response;
    })
  }

  getNominetedForeignTraineeListBySchoolId(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getnominatedForeignTraineeFromSpRequestBySchoolId(currentDateTime, schoolId, this.masterData.OfficerType.Foreign).subscribe(response => {
      this.foreignNomineeCount = response.length;
    })
  }
  getNominetedForeignTraineeListByBase(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getNominatedForeignTraineeByTypeAndBase(currentDateTime, schoolId, this.masterData.OfficerType.Foreign).subscribe(response => {
      this.foreignNomineeCount = response.length;
    })
  }

  getrunningCourseTotalOfficerListBySchoolId(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getrunningCourseTotalOfficerListBySchoolRequest(currentDateTime, this.masterData.TraineeStatus.officer, schoolId).subscribe(response => {
      this.runningOfficerCount = response.length;
    })
    this.schoolDashboardService.getrunningCourseTotalOfficerListBySchoolRequest(currentDateTime, this.masterData.TraineeStatus.sailor, schoolId).subscribe(response => {
      this.runningSailorCount = response.length;
    })
    this.schoolDashboardService.getrunningCourseTotalOfficerListBySchoolRequest(currentDateTime, this.masterData.TraineeStatus.civil, schoolId).subscribe(response => {
      this.runningCivilCount = response.length;
    })
  }

  geCourseTotalOfficerListByBase(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getCourseTotalOfficerListByBase(currentDateTime, this.masterData.TraineeStatus.officer, schoolId).subscribe(response => {
      this.runningOfficerCount = response.length;
    })
    this.schoolDashboardService.getCourseTotalOfficerListByBase(currentDateTime, this.masterData.TraineeStatus.sailor, schoolId).subscribe(response => {
      this.runningSailorCount = response.length;
    })
    this.schoolDashboardService.getCourseTotalOfficerListByBase(currentDateTime, this.masterData.TraineeStatus.civil, schoolId).subscribe(response => {
      this.runningCivilCount = response.length;
    })
  }

  getCoursesByViewType(viewStatus) {
  
    this.viewStatus = viewStatus;

    if (this.role == this.userRole.CO || this.role == this.userRole.TrainingOffice || this.role == this.userRole.TC || this.role == this.userRole.TCO) {

      if (viewStatus == 1) {
        this.viewCourseTitle = "Running";
        this.getRunningCourseDurationByBase(viewStatus);
        this.selectedFilter = 1;
       

      } else if (viewStatus == 2) {
        this.viewCourseTitle = "Passing Out";
        this.getRunningCourseDurationByBase(viewStatus);
        this.selectedFilter = 2;
       
      } else if (viewStatus = 3) {
        this.selectedFilter = 3;
       
        let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
        this.viewCourseTitle = "Upcoming";
        this.schoolDashboardService.getUpcomingCourseListByBase(currentDateTime, this.schoolId).subscribe(response => {
          this.UpcomingCourseCount = response.length;
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

        })
      }
    } else {

      if (viewStatus == 1) {
        this.selectedFilter = viewStatus
        this.viewCourseTitle = "Running";
        this.getrunningCourseListBySchool(viewStatus);
      } else if (viewStatus == 2) {
        this.selectedFilter = viewStatus
        this.viewCourseTitle = "Passing Out";
        this.getrunningCourseListBySchool(viewStatus);
      } else if (viewStatus = 3) {
        this.selectedFilter = viewStatus
        let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
        this.viewCourseTitle = "Upcoming";
      
        if (this.schoolId == this.masterData.schoolName.NBCDSchool || this.role == this.userRole.OICNBCDSchool) {
          this.schoolDashboardService.getUpcomingCourseListByNbcdSchool(currentDateTime, this.masterData.coursetype.LocalCourse, this.schoolId).subscribe(response => {
            this.UpcomingCourseCount = response.length;
            this.upcomingCourses = response;
          })
        }
        else {
          this.schoolDashboardService.getUpcomingCourseListBySchool(currentDateTime, this.masterData.coursetype.LocalCourse, this.schoolId).subscribe(response => {
            this.runningCourses = response;
          })
        }
      }
    }

  }

  getrunningCourseListBySchool(viewStatus) {

    const startTime = performance.now();
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');

    /*if (this.branchId==this.masterData.schoolName.NETS ){
      this.schoolDashboardService.getrunningCourseListBySchool(currentDateTime, this.masterData.coursetype.NETS, this.schoolId,viewStatus).subscribe(response => {         
        this.localCourseCount=response.length; 
        this.runningCourses=response;
      });
    }
    else
    {
    this.schoolDashboardService.getrunningCourseListBySchool(currentDateTime, this.masterData.coursetype.LocalCourse, this.schoolId,viewStatus).subscribe(response => {         
      this.localCourseCount=response.length;
      this.runningCourses=response;  
    

    });
  }*/

    this.schoolDashboardService.getrunningCourseListBySchool(currentDateTime, this.masterData.coursetype.LocalCourse, this.schoolId, viewStatus).subscribe(response => {
      this.localCourseCount = response.length;
      this.runningCourses = response;

        const endTime = performance.now();

        const dataLoadingTime = endTime - startTime;
        setTimeout(()=>{
          this.restoreScroll(dataLoadingTime);
        },0)

    });

  }

  callback(){
    window.scrollTo(0, this.oldScrollPosition);
  }
  restoreScroll(callback){
    this.callback();
  }

  getDateComparision(obj) {

    var currentDate = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var current = new Date(currentDate);
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

  getUpcomingCourseListBySchool(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    if (schoolId == this.masterData.schoolName.NBCDSchool) {
      this.schoolDashboardService.getUpcomingCourseListByNbcdSchool(currentDateTime, this.masterData.coursetype.LocalCourse, schoolId).subscribe(response => {

        this.UpcomingCourseCount = response.length;
        this.upcomingCourses = response;
      })
    }
    else {
      this.schoolDashboardService.getUpcomingCourseListBySchool(currentDateTime, this.masterData.coursetype.LocalCourse, schoolId).subscribe(response => {

        this.UpcomingCourseCount = response.length;
        this.upcomingCourses = response;
      })
    }
  }

  getUpcomingCourseListByBase(baseId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getUpcomingCourseListByBase(currentDateTime, baseId).subscribe(response => {
      this.UpcomingCourseCount = response.length;
      this.upcomingCourses = response;

      setTimeout(() => {
        window.scrollTo(0, this.oldScrollPosition);
      }, 500); 
    })
  }

  courseWeekGenerate(row) {
    const id = row.courseDurationId;

    this.confirmService.confirm('Confirm  message', 'Are You Sure ').subscribe(result => {
      if (result) {
        this.schoolDashboardService.genarateCourseWeek(id).subscribe(() => {
          this.getCoursesByViewType(1);
          this.snackBar.open('Course Week Generated Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
  }

  getPendingExamEvaluation(schoolId) {
    this.schoolDashboardService.getPendingExamEvaluation(schoolId).subscribe(response => {
      this.PendingExamEvaluation = response;
    })
  }

  getTraineeAbsentList(schoolId) {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.schoolDashboardService.getTraineeAbsentList(currentDateTime, schoolId).subscribe(response => {
      this.TraineeAbsentList = response;
    })
  }

  getRoutineInfoByCourse(schoolId) {
    this.schoolDashboardService.getRoutineByCourse(schoolId).subscribe(response => {
      this.RoutineByCourse = response;
    })
  }
}
