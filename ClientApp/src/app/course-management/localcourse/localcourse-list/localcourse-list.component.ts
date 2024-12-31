import { number } from 'echarts';
import { Component, HostListener, OnDestroy, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration'
import {CourseDurationService} from '../../service/courseduration.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from '../../../../environments/environment';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { DatePipe } from '@angular/common';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { MasterData } from '../../../../assets/data/master-data';
import { dashboardService } from '../../../admin/dashboard/services/dashboard.service';
import { ScrollService } from '../scrole-restore/scrole-position.service';
@Component({
  selector: "app-localcourse-list",
  templateUrl: "./localcourse-list.component.html",
  styleUrls: ["./style.component.css"],
})
export class LocalcourseListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit, OnDestroy
{
  scrollPosition: number = 0;
  oldScrollPosition: number = 0;
  maxScrolledPosition = 0;
  index: number;

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  fileUrl = environment.fileUrl;
  courseTypeId = MasterData.coursetype.LocalCourse;
  groupArrays: { schoolName: string; courses: any }[];
  paging = {
    pageIndex: 5,
    pageSize: 1,
    length: 1,
  };
  searchText = "";
  viewStatus = 1;
  candidateCount: any;
  passOutStatus: any;
  localCourseList: any;
  courseList: any[] = [];
  scrollCounter = 0;
  isAllDataLoaded : boolean = false
  lastApiCallPosition = 0;

 

  displayedColumns: string[] = [
    "ser",
    "baseSchoolName",
    "courseName",
    "professional",
    "noOfCandidates",
    "nbcd",
    "durationFrom",
    "durationTo",
    "remark",
    "actions",
  ];

  //displayedColumns: string[] = ['ser','baseSchoolName','courseName', 'professional','nbcd','durationFrom','durationTo', 'remark', 'actions'];

  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();

  selection = new SelectionModel<CourseDuration>(true, []);

  constructor(
    private datepipe: DatePipe,
    private DashboardService: dashboardService,
    private snackBar: MatSnackBar,
    private TraineeNominationService: TraineeNominationService,
    private CourseDurationService: CourseDurationService,
    private router: Router,
    private confirmService: ConfirmService,
    private scrollPositionService: ScrollService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  @HostListener("window:scroll")
  onWindowScroll() {
    
    this.scrollPosition = window.scrollY || window.pageYOffset; // Current scroll position

    let delay = this.selectedFilter === 2? 500 : 250;
  
    if (!this.isAllDataLoaded && this.scrollPosition - this.lastApiCallPosition >= delay && this.scrollPosition > this.lastApiCallPosition) {
      this.paging.pageSize++;
      this.lastApiCallPosition = this.scrollPosition; 
      this.getCoursesByViewType(this.selectedFilter); 
      // console.log('API called at position:', this.scrollPosition);
    }
   
   
    
  }
  selectedFilter: number;
  ngOnInit() {
    const startTime = performance.now();
    this.oldScrollPosition =
      this.scrollPositionService.getScrollPosition("localCourse");
    this.selectedFilter =
      this.scrollPositionService.getSelectedFilter("localCourse");

    this.getCoursesByViewType(this.selectedFilter);
    this.CourseDurationService.getCourseDurationsByCourseType(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText,
      this.courseTypeId,
      this.viewStatus
    ).subscribe((response) => {
      const endTime = performance.now();

      const dataLoadingTime = endTime - startTime;
      setTimeout(() => {
        this.restoreScroll(dataLoadingTime);
      }, 0);
    });

    this.getCourseDurationFilterList(this.selectedFilter);
    this.index = this.scrollPositionService.getSelectedIndex("localCourse");
  }

  callback() {
    window.scrollTo(0, this.oldScrollPosition);
  }
  restoreScroll(callback) {
    this.callback();
  }

  //***** Scroll Restoration will work after loading all data *****//
  // ngOnInit() {
  //  const startTime = performance.now();
  //  this.oldScrollPosition = this.scrollPositionService.getScrollPosition('test1');
  //  this.getCourseDurationFilterList(1);

  //  this.loading = true;
  //  this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize, this.searchText, this.courseTypeId).subscribe(response => {
  //    this.loading = false;
  //    const endTime = performance.now();
  //    const dataLoadingTime = endTime - startTime;
  //    const waitTime = 500;
  //    setTimeout(() => {
  //      window.scrollTo(0, this.oldScrollPosition);
  //    }, dataLoadingTime);
  //  });
  // }

  ngOnDestroy() {
    this.scrollPositionService.setScrollPosition(
      "localCourse",
      this.scrollPosition
    );
    this.scrollPositionService.setSelectedFilter(
      "localCourse",
      this.selectedFilter
    );
  }

  GetIndexValue(number: number) {
    this.scrollPositionService.setSelectedIndex("localCourse", number);
  }

  getCourseDurationsByCourseType() {
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(     
      this.paging.pageSize,
      this.paging.pageIndex,
      this.searchText,
      this.courseTypeId,
      this.viewStatus
    ).subscribe((response) => {
      // console.log(response);

      this.courseList = [  ...this.courseList, ...response.items ]
      // console.log(this.courseList);
      this.isAllDataLoaded = !response.items.length? true : false
      this.dataSource.data = this.courseList;
      this.sharedService.groupedData = this.sharedService.groupBy(
        this.dataSource.data,
        (courses) => courses.baseSchoolName
      );
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }

  getCoursesByViewType(viewStatus) {
    if(this.selectedFilter !== viewStatus){
      this.courseList = [];
      this.paging.pageIndex = 5;
      this.paging.pageSize = 1;
      this.lastApiCallPosition = 0;
    }
    if (viewStatus == 1) {
      this.isLoading = true;     
      this.selectedFilter = 1;
      this.viewStatus = 1;
      this.getCourseDurationsByCourseType();
    } else if (viewStatus == 2) {
      this.isLoading = true;     
      this.selectedFilter = 2;
      this.viewStatus = 2;
      this.getCourseDurationsByCourseType();
    } else if (viewStatus == 3) {

      this.isLoading = true;      
      this.selectedFilter = 3;
      this.viewStatus = 3;
      this.getCourseDurationsByCourseType();
    }
  }

  getCourseDurationFilterList(viewStatus) {
    if (viewStatus == 1 || viewStatus == 2) {
      this.CourseDurationService.getCourseDurationFilter(
        viewStatus,
        this.masterData.coursetype.LocalCourse
      ).subscribe((response) => {
        this.localCourseList = response;
        this.sharedService.groupedData = this.sharedService.groupBy(
          this.dataSource.data,
          (courses) => courses.baseSchoolName
        );

      });
    } else {
      let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
      this.DashboardService
        .getUpcomingCourseListByBase(currentDateTime, 0)
        .subscribe((response) => {
          this.localCourseList = response;
          this.sharedService.groupedData = this.sharedService.groupBy(
            this.dataSource.data,
            (courses) => courses.baseSchoolName
          );
        });
    }
  }

  getDateComparision(obj) {
    let currentDate = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    //Date dateTime11 = Convert.ToDateTime(dateFrom);
    let current = new Date(currentDate || '');
    // var date1 = new Date(obj.durationFrom);
    let date2 = new Date(obj.durationTo);

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

  // pageChanged(event: PageEvent) {

  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getCourseDurationsByCourseType();
  // }
  applyFilter(searchText: any) {
    this.courseList = [];
    this.paging.pageIndex = 5;
    this.paging.pageSize = 1;
    this.lastApiCallPosition = 0;
    this.searchText = searchText;

    this.getCourseDurationsByCourseType();
  }

  // getTraineeNominationsByCourseDurationId(courseDurationId) {
  //   this.CourseDurationService.getNominatedTraineeCountByDurationId(courseDurationId).subscribe(res => {
  //     this.candidateCount = res.countedTrainee;
  //   });
  // }


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
