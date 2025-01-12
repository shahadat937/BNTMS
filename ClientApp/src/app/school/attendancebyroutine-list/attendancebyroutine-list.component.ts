import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { SchoolDashboardService } from '../services/SchoolDashboard.service';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-attendancebyroutine-list',
  templateUrl: './attendancebyroutine-list.component.html',
  styleUrls: ['./attendancebyroutine-list.component.sass']
})
export class AttendanceByRoutineListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  AttendanceByRoutine:any;
  courseNameId:any;
  schoolId:any;
  durationId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedRoutineColumns: string[] = ['ser', 'subject', 'name', 'attendanceRemarks'];
  subscription: any;

  constructor(private datepipe: DatePipe,private schoolDashboardService: SchoolDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    //this.getTraineeNominations();
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.durationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    var routineId = this.route.snapshot.paramMap.get('classRoutineId'); 
    this.schoolDashboardService.getCurrentAttendanceDetailByRoutineList(this.courseNameId,this.schoolId,this.subscription = this.durationId,routineId).subscribe(response => {         
      this.AttendanceByRoutine=response;
    })
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
