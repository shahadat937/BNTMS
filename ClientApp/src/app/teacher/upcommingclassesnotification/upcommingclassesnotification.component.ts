import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { InstructorDashboardService } from '../services/InstructorDashboard.service';
//import { SchoolDashboardService } from '../services/SchoolDashboard.service';
import { environment } from '../../../../src/environments/environment';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-upcommingclassesnotification.component',
  templateUrl: './upcommingclassesnotification.component.html',
  styleUrls: ['./upcommingclassesnotification.component.sass']
})

export class UpcommingClassesNotification implements OnInit,OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  routineList:any;
  MaterialByCourse:any;
  traineeId:any;
  ReadIngMaterialList:any;
  schoolId:any;
  fileUrl:any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedRoutineColumns: string[] = ['ser', 'durationForm','durationTo','subjectName', 'classLocation'];
  subscription: any;
  constructor(private datepipe: DatePipe,private instructorDashboardService: InstructorDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
   this.traineeId = this.route.snapshot.paramMap.get('traineeId');
   this.getSpCurrentRoutineForStudentDashboard(this.traineeId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  getSpCurrentRoutineForStudentDashboard(id){
    this.subscription = this.instructorDashboardService.getSpCurrentRoutineForStudentDashboard(id).subscribe(res=>{
      this.routineList = res;
    });
  }
}
