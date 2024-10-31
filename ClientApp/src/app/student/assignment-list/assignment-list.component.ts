import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseInstructor} from '../../subject-management/models/courseinstructor';
import {CourseInstructorService} from '../../subject-management/service/courseinstructor.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { DatePipe } from '@angular/common';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-assignment-list',
  templateUrl: './assignment-list.component.html',
  styleUrls: ['./assignment-list.component.sass']
})
export class AssignmentListComponent extends UnsubscribeOnDestroyAdapter implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  NoticeForStudent:any[];
  baseSchoolNameId:any;
  courseNameId:any;
  courseDurationId:any;
  traineeId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[]= ['ser','bnaSubjectName', 'endDate', 'assignmentMark','assignmentTopic','actions'];
  subscription: any = null;
  
  constructor(private snackBar: MatSnackBar, private datepipe: DatePipe ,private route: ActivatedRoute,private studentDashboardService: StudentDashboardService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { super()}

  ngOnInit() {
    this.onModuleSelectionChangeGetsubjectList();
    
  }
  // ngOnDestroy() {
  //   if (this.subscription) {
  //     this.subscription.unsubscribe();
  //   }
  // }

  onModuleSelectionChangeGetsubjectList(){
    this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
   
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    

    if(this.baseSchoolNameId != null && this.courseDurationId !=null && this.courseNameId !=null){
      this.studentDashboardService.getAssignmentListForStudent(currentDateTime,this.baseSchoolNameId,this.subscription = this.courseNameId,this.courseDurationId).subscribe(response => {   
        this.NoticeForStudent=response;
      })
    }
  }
  
}
