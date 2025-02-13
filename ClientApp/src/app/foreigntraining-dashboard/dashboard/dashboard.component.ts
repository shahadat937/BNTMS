import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ForeignDashboardService } from '../services/ForeignDashboard.service';
import { ActivatedRoute, Router } from '@angular/router';

import { MasterData } from '../../../../src/assets/data/master-data';
import { environment } from '../../../../src/environments/environment';
import { DatePipe } from '@angular/common';
import { scheduled } from 'rxjs';
import { SelectedModel } from '../../../../src/app/core/models/selectedModel';
import { StudentDashboardService } from '../../../../src/app/student/services/StudentDashboard.service';
import { BaseSchoolNameService } from '../../../../src/app/basic-setup/service/BaseSchoolName.service';
import { TraineeNominationService } from '../../course-management/service/traineenomination.service';
import { AuthService } from '../../../../src/app/core/service/auth.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.sass'],
})
export class DashboardComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  masterData = MasterData;
  loading = false;
  GetSchoolForm: FormGroup;
  isShown: boolean = false;
  paramBaseSchoolNameId: any;

  fileUrl: any = environment.fileUrl;
  bulletinList: any;

  courseList: any;
  totalNomineted: any;

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
  dbType: any;
  branchId: any;
  traineeId: any;
  runningCourseType: any;

  ForeignTraineeCount: any;
  ForeignOfficerCount: any;
  ForeignSailorCount: any;
  ForeignCivilTraineeCount: any;
  ForeignCivilInstructor: any;
  TotalCivilCount: any;
  ForeignMidCount: any;
  ForeignCadetCount: any;

  role: any;
  dayCount: any;
  selectedschool: SelectedModel[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['ser', 'course', 'duration', 'dayCount', 'country', 'goStatus', 'candidates', 'sanction', 'actions'];

  constructor(private datepipe: DatePipe, private authService: AuthService, private TraineeNominationService: TraineeNominationService, private baseSchoolNameService: BaseSchoolNameService, private studentDashboardService: StudentDashboardService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder, private foreignDashboardService: ForeignDashboardService, public sharedService: SharedServiceService) {
    super();
  }
  ngOnInit() {

    this.dbType = this.masterData.dbType.foreignTrainingDb;
    this.runningCourseType = this.masterData.coursetype.ForeignCourse;

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    this.schoolId = 20;
    this.baseSchoolNameService.find(this.schoolId).subscribe(response => {
      this.schoolName = response.schoolName;
    })

    //this.getrunningCourseListBySchool();
    this.getCoursesByViewType(1);
    this.getSpUpcomingCourseDurationsByTypeForInterService()
    this.getnominatedCourseListFromSpRequest();
    this.getRunningCourseTotalTraineeByCourseType();

    this.isShown = true;
    // this.paramBaseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
  }

  getDaysfromDate(dateFrom: any, dateTo: any) {
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var date1 = new Date(dateFrom);
    var date2 = new Date(dateTo);
    var Time = date2.getTime() - date1.getTime();
    var Days = Time / (1000 * 3600 * 24);
    this.dayCount = Days + 1;
    return this.dayCount;
  }


  getnominatedCourseListFromSpRequest() {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.foreignDashboardService.getnominatedCourseListFromSpRequest(currentDateTime ?? "").subscribe(response => {

      this.nomineeCount = response.length;
    })
  }
  getTraineeNominationsByCourseDurationId(courseDurationId) {
    //this.isLoading = true;
    this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize, this.searchText, courseDurationId).subscribe(response => {
      //this.dataSource.data = response.items; 
      this.totalNomineted = response.totalItemsCount;
    })
  }


  // getrunningCourseListBySchool(){
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.foreignDashboardService.getrunningForeignCourseList(currentDateTime, this.masterData.coursetype.ForeignCourse).subscribe(response => {   

  //     this.localCourseCount=response.length;
  //     this.runningCourses=response;
  //   })
  // }
  getCoursesByViewType(viewStatus) {
    this.viewStatus = viewStatus;
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy') ?? "";
    this.foreignDashboardService.getSpRunningForeignCourseDurationsByType(this.runningCourseType, currentDateTime, viewStatus).subscribe(response => {
      this.runningCourses = response;
    })
  }
  getSpUpcomingCourseDurationsByTypeForInterService() {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy') ?? "";
    this.foreignDashboardService.getSpUpcomingCourseDurationsByTypeForInterService(this.runningCourseType, currentDateTime).subscribe(response => {
      this.runningCourses = response;
    })
  }

  getRunningCourseTotalTraineeByCourseType() {
    let currentDateTime = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, 0).subscribe(response => {
      this.ForeignTraineeCount = response.length;
    })
    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.officer).subscribe(response => {
      this.ForeignOfficerCount = response.length;
    })
    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.sailor).subscribe(response => {
      this.ForeignSailorCount = response.length;
    })

    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.civil).subscribe(response => {
      this.ForeignCivilTraineeCount = response.length;
      this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.civilInstructor).subscribe(response => {
        this.ForeignCivilInstructor = response.length;
        this.TotalCivilCount = this.ForeignCivilInstructor + this.ForeignCivilTraineeCount;
      })
    })

   
    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.mid).subscribe(response => {
      this.ForeignMidCount = response.length;
    })
    this.foreignDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime, this.runningCourseType, this.masterData.TraineeStatus.cadet).subscribe(response => {
      this.ForeignCadetCount = response.length;
    })
  }


}
