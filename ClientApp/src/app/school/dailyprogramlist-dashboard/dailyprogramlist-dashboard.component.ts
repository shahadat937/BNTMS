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
import { environment } from '../../../../src/environments/environment';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-dailyprogramlist-dashboard.component',
  templateUrl: './dailyprogramlist-dashboard.component.html',
  styleUrls: ['./dailyprogramlist-dashboard.component.sass']
})
export class DailyprogramlistDashboardComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  MaterialByCourse:any;
  ReadIngMaterialList:any;
  schoolId:any;
  RoutineByCourse:any;
  dbType:any;
  TodayRoutineList:any;
  fileUrl:any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedRoutineCountColumns: string[] = ['ser','course','moduleName','routineCount','actions'];
  subscription: any;

  constructor(private datepipe: DatePipe,private schoolDashboardService: SchoolDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.getCurrentRoutineBySchool(this.schoolId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getCurrentRoutineBySchool(schoolId){
    this.dbType=1;
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.subscription = this.schoolDashboardService.getCurrentRoutineBySchool(currentDateTime,schoolId).subscribe(response => {   
      this.TodayRoutineList=response;
    })
  }
}
