import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../foreign-training/models/courseduration'
import { CourseDurationService } from '../../../../src/app/foreign-training/service/courseduration.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from '../../../../src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from '../../../../src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from '../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-runningcoursforeigntraineecount-list',
  templateUrl: './runningcoursforeigntraineecount-list.component.html',
  styleUrls: ['./runningcoursforeigntraineecount-list.component.sass']
})
export class RunningCoursForeignRraineecountListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  courseTypeId=MasterData.coursetype.ForeignCourse;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  branchId:any;
  traineeId:any;
  role:any;
  dayCount:any;
  foreignCourseCount:number;
  runningCourses:any;
  viewCourseTitle:any;
  userRole = Role;
  viewStatus:any;
  showHideDiv= false;
 

  displayedColumns: string[] = ['ser','courseName', 'country','durationTo','dayCount', 'actions'];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


   selection = new SelectionModel<CourseDuration>(true, []);

  
  constructor(private datepipe: DatePipe,private snackBar: MatSnackBar,private authService: AuthService,private CourseDurationService: CourseDurationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

     this.getrunningCourseListForForeingTrainee(1);
  }
  getrunningCourseListForForeingTrainee(viewStatus){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.CourseDurationService.getrunningCourseListForForeingTrainee(currentDateTime,viewStatus).subscribe(response => {         
      this.foreignCourseCount=response.length;
      this.runningCourses=response;
    });
  }

  getCoursesByViewType(viewStatus){
    this.viewStatus = viewStatus;
    if(this.role == this.userRole.ForeignTraining ){
      if(viewStatus==1){
        this.viewCourseTitle = "Running";
       // this.getRunningCourseDurationByBase(viewStatus);
      }else if(viewStatus==2){
        this.viewCourseTitle = "Passing Out";
        //this.getRunningCourseDurationByBase(viewStatus);
      }else if(viewStatus=3){
        let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
        this.viewCourseTitle = "Upcoming";
        
      }
    }else{
      if(viewStatus==1){
        this.viewCourseTitle = "Running";
        this.getrunningCourseListForForeingTrainee(viewStatus);
      }else if(viewStatus==2){
        this.viewCourseTitle = "Passing Out";
        this.getrunningCourseListForForeingTrainee(viewStatus);
      }else if(viewStatus=3){
        let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
        this.viewCourseTitle = "Upcoming";

       
      }
    }
    
  }
  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }
  print(){ 
     
    let printContents, popupWin;
    printContents = document.getElementById('print-routine')?.innerHTML;
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
                .header-warning{
                  font-size:12px;
                }
                .header-warning.bottom{
                  position:absolute;
                  bottom:0;
                  left:44%;
                }
                .header-warning-lf{
                  font-size:12px;
                }
                .header-warning-lf.bottom{
                  position:absolute;
                  bottom:100;
                  right:24%;
                }
                .header-warning-rk{
                  font-size:12px;
                }
                .header-warning-rk.bottom{
                  position:absolute;
                  bottom:80;
                  right:24.5%;
                }
                .header-warning-ap{
                  font-size:12px;
                }
                .header-warning-ap.bottom{
                  position:absolute;
                  bottom:60;
                  right:20.5%;
                }
                
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <span class="header-warning top">RESTRICTED</span>
          <h3>BREAKDOWN OF ONGOING TRAINEES IN ABROAD</h3>
          <h4>TILL DATE:- ${this.datepipe.transform((new Date), 'dd MMM yyyy')}</h4>
          </div>
          <br>
          <hr>
          
          ${printContents}
          <span class="header-warning-lf bottom">Name:</span>
          <span class="header-warning-rk bottom">Rank:</span>
          <span class="header-warning-ap bottom">Appointment:</span>
          <span class="header-warning bottom">RESTRICTED</span>
        </body>
      </html>`
    );
    popupWin.document.close();

}

}

