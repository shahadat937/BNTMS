import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-weeklyattendance',
  templateUrl: './weeklyattendance-list.component.html',
  styleUrls: ['./weeklyattendance-list.component.sass']
})
export class WeeklyAttendanceListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  AttendanceByTraineeAndCourseDuration:any;
  status=1;
  showHideDiv= false;
  groupArrays:{ attendanceDate: string; attendance: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  traineeParcentage:any;

  displayedAttendanceColumns: string[] = ['ser','attendanceDate','periodName','classLeaderName','attendanceStatus'];


   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;
  dataSource: any;

  
  constructor(private snackBar: MatSnackBar,private studentDashboardService: StudentDashboardService,private BNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    var traineeId = this.route.snapshot.paramMap.get('traineeId');
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.getAttendanceByTraineeAndCourseDuration(traineeId, courseDurationId)
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getAttendanceByTraineeAndCourseDuration(traineeId,courseDurationId){
    this.subscription = this.studentDashboardService.getAttendanceParcentageByTraineeAndCourseDuration(traineeId,courseDurationId).subscribe(res=>{
      this.traineeParcentage=res[0].percentage;
    });
    this.subscription = this.studentDashboardService.getAttendanceByTraineeAndCourseDuration(traineeId,courseDurationId).subscribe(res=>{
      this.AttendanceByTraineeAndCourseDuration = res;
      this.dataSource = new MatTableDataSource(res);
      this.sharedService.groupedData = this.sharedService.groupBy(
        this.dataSource.data,
        (courses) => courses.attendanceDate
      );
      
    });
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
                
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Weekly Attendance</h3>
         
          </div>
          <br>
          <hr>
          
          ${printContents}
        </body>
      </html>`
    );
    popupWin.document.close();

}

  // getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId){    
  //   this.studentDashboardService.getReadingMAterialInfoBySchoolAndCourse(baseSchoolNameId, courseNameId).subscribe(res=>{
  //     this.ReadingMaterialBySchoolAndCourse = res;
  //   });
  // }

}
