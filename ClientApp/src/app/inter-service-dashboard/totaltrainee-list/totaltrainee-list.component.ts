import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import { InterServiceDashboardService } from '../services/InterServiceDashboard.service';
import {MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../../../../src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { UnsubscribeOnDestroyAdapter } from '../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-totaltrainee-list',
  templateUrl: './totaltrainee-list.component.html',
  styleUrls: ['./totaltrainee-list.component.sass']
})
export class totaltraineeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  courseDurationId:number;
  courseNameId:number;
  courseTypeId:number;
  traineeStatusId:number;
  interServiceTraineeList:any;
  baseSchoolNameId:any;
  titleText:any;
  dbType:any;
  dbType1:any;
  courseType3:any;
  showHideDiv= false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  
  branchId:any;
  traineeId:any;
  role:any;

  displayedColumns: string[] = ['ser','traineeName','courseName'];

  
  constructor(private datepipe: DatePipe,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private interServiceDashboardService: InterServiceDashboardService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    
    this.courseTypeId = Number(this.route.snapshot.paramMap.get('courseTypeId'));
    this.traineeStatusId = Number(this.route.snapshot.paramMap.get('traineeStatusId'));
    this.dbType = Number(this.route.snapshot.paramMap.get('dbType'));
    
    this.getRunningCourseTotalTraineeByCourseType(this.courseTypeId, this.traineeStatusId)
  }

  getRunningCourseTotalTraineeByCourseType(courseTypeId, traineeStatusId) {
    if(traineeStatusId == 0){
      this.titleText = "Trainee";
    }else if(traineeStatusId == this.masterData.TraineeStatus.officer){
      this.titleText = "Officer";
    }else if(traineeStatusId == this.masterData.TraineeStatus.sailor){
      this.titleText = "Sailor";
    }else if(traineeStatusId == this.masterData.TraineeStatus.civil){
      this.titleText = "Civil";
    }
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.interServiceDashboardService.getRunningCourseTotalTraineeByCourseType(currentDateTime,courseTypeId,traineeStatusId).subscribe(response => {           
      this.interServiceTraineeList=response;
    })
  }
  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById('print-routine')?.innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
            /* General body styling */
            body {
              font-family: Arial, sans-serif;
              margin: 0;
              padding: 0;
              width: 100%;
            }
  
            /* Ensure the table stretches to full width */
            mat-table {
              display: table;
              width: 100%;
              border-collapse: collapse;
              table-layout: fixed; /* Ensure uniform column width */
              margin: 0 auto; /* Center table horizontally */
            }
  
            /* Styling table rows and cells */
            mat-header-row, mat-row {
              display: table-row;
            }
  
            mat-header-cell, mat-cell {
              display: table-cell;
              border: 1px solid silver;
              padding: 8px;
              text-align: left;
              vertical-align: middle;
              word-wrap: break-word; /* Ensure content doesn't overflow */
            }
  
            mat-header-cell {
              font-weight: bold;
              background-color: #f5f5f5;
              text-align: center; /* Center header text */
            }
  
            /* Optional header styling */
            .header-text {
              text-align: center;
            }
  
            .header-text h3 {
              margin: 10px 0;
            }
  
            /* Adjustments for better printing */
            @media print {
              body {
                margin: 0;
                padding: 0;
              }
              mat-table {
                width: 99%;
              }
            }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <h3>Trainee List</h3>
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
      </html>`);
    popupWin.document.close();
  }
  
  
  
  

  
}
