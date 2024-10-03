import { number } from 'echarts';
import { Component, HostListener, OnDestroy, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration'
import {CourseDurationService} from '../../service/courseduration.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { DatePipe } from '@angular/common';
import { dashboardService } from 'src/app/admin/dashboard/services/dashboard.service';
import { ScrollService } from 'src/app/course-management/localcourse/scrole-restore/scrole-position.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
@Component({
  selector: 'app-localcourse-list',
  templateUrl: './localcourse-list.component.html',
  styleUrls: ['./localcourse-list.component.sass']
})
export class LocalcourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit,OnDestroy {
  scrollPosition: number = 0;
    oldScrollPosition: number = 0;
  index:number;

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  fileUrl = environment.fileUrl;
  courseTypeId=MasterData.coursetype.LocalCourse;
  groupArrays:{ schoolName: string; courses: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 10,
    length: 1
  }
  searchText="";
  candidateCount:any;
  passOutStatus:any;
  localCourseList:any;

  displayedColumns: string[] = ['ser', 'baseSchoolName', 'courseName', 'professional', 'noOfCandidates', 'nbcd', 'durationFrom', 'durationTo', 'remark', 'actions'];

  //displayedColumns: string[] = ['ser','baseSchoolName','courseName', 'professional','nbcd','durationFrom','durationTo', 'remark', 'actions'];

  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


   selection = new SelectionModel<CourseDuration>(true, []);
   


  constructor(private datepipe: DatePipe, private dashboardService: dashboardService, private snackBar: MatSnackBar, private TraineeNominationService: TraineeNominationService, private CourseDurationService: CourseDurationService, private router: Router, private confirmService: ConfirmService, private scrollPositionService: ScrollService) {
    super();
  }

  @HostListener('window:scroll')
  onWindowScroll() {
    this.scrollPosition = window.scrollY || window.pageYOffset;
  }
  selectedFilter: number;
  ngOnInit() {
     const startTime = performance.now();
    this.oldScrollPosition = this.scrollPositionService.getScrollPosition('localCourse');
    this.selectedFilter = this.scrollPositionService.getSelectedFilter('localCourse');

    this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize, this.searchText, this.courseTypeId).subscribe(response => {
        const endTime = performance.now();

        const dataLoadingTime = endTime - startTime;
        setTimeout(()=>{
          this.restoreScroll(dataLoadingTime);
        },0)
    })

     this.getCourseDurationFilterList(this.selectedFilter);
     this.index = this.scrollPositionService.getSelectedIndex('localCourse');
  }
  
  callback(){
    window.scrollTo(0, this.oldScrollPosition);
  }
  restoreScroll(callback){
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
    this.scrollPositionService.setScrollPosition('localCourse', this.scrollPosition);
    this.scrollPositionService.setSelectedFilter('localCourse', this.selectedFilter);
  }
  
  GetIndexValue(number: number){
    this.scrollPositionService.setSelectedIndex('localCourse', number);
  }

  getCourseDurationsByCourseType(){
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseTypeId).subscribe(response => {
      this.dataSource.data = response.items; 

      // this gives an object with dates as keys
    const groups = this.dataSource.data.reduce((groups, courses) => { 
        const schoolName = courses.baseSchoolName;
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

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  
  getCoursesByViewType(viewStatus){

    if(viewStatus==1){
     this.getCourseDurationFilterList(viewStatus)
     this.selectedFilter = 1;
    }
    else if(viewStatus==2){
      this.getCourseDurationFilterList(viewStatus)
      this.selectedFilter = 2;
    }
    else if(viewStatus==3){
      this.selectedFilter = 3;
      this.getCourseDurationFilterList(viewStatus)
    }
  }

  getCourseDurationFilterList(viewStatus){
    if(viewStatus == 1 || viewStatus == 2){
      this.CourseDurationService.getCourseDurationFilter(viewStatus,this.masterData.coursetype.LocalCourse).subscribe(response => {
        this.localCourseList = response; 
  
        // this gives an object with dates as keys
        const groups = this.localCourseList.reduce((groups, courses) => {
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
        
  
        // this.paging.length = response.totalItemsCount    
        // this.isLoading = false;
      })
    }
    else{
      let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
      this.dashboardService.getUpcomingCourseListByBase(currentDateTime,0).subscribe(response => {         
        
        this.localCourseList=response;
  
        // this gives an object with dates as keys
        const groups = this.localCourseList.reduce((groups, courses) => {
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
  }
  
  getDateComparision(obj){

    var currentDate = this.datepipe.transform((new Date), 'MM/dd/yyyy');
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var current = new Date(currentDate);
    // var date1 = new Date(obj.durationFrom); 
	  var date2 =  new Date(obj.durationTo);
    

    if(current > date2){
      this.passOutStatus = 1;
    }else{
      this.passOutStatus = 0;
    }
    // else if(current >= date1 && current <= date2){
    //   this.weekStatus = 2;
    // }else if(current < date1){
    //   this.weekStatus = 3;
    // }else{
    // }
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseDurationsByCourseType();
  }
  applyFilter(searchText: any){ 
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
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseDurationService.delete(id).subscribe(() => {
         this.getCourseDurationsByCourseType();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    }) 
  }
}
