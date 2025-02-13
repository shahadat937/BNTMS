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
  selector: 'app-weeklyroutineteacherdashboard.component',
  templateUrl: './weeklyroutineteacherdashboard.component.html',
  styleUrls: ['./weeklyroutineteacherdashboard.component.sass']
})

export class WeeklyRoutineTeacherDashboard implements OnInit,OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  routineList:any;
  MaterialByCourse:any;
  traineeId:any;
  ReadIngMaterialList:any;
  showHideDiv= false;
  groupArrays:{ course: string; courses: any; }[];
  schoolId:any;
  fileUrl:any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedRoutineColumns: string[] = ['ser', 'date','schoolName','duration', 'course','subject', 'location'];
  subscription: any;
  dataSource: any;
  constructor(private datepipe: DatePipe,private instructorDashboardService: InstructorDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
   this.traineeId = this.route.snapshot.paramMap.get('traineeId');
   this.getWeeklyRoutineByInstructor(this.traineeId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  getWeeklyRoutineByInstructor(id){
    this.subscription = this.instructorDashboardService.getSpInstructorRoutineByTraineeId(id).subscribe(res=>{
      this.routineList = res;
      this.dataSource = new MatTableDataSource(res);
      this.sharedService.groupedData = this.sharedService.groupBy(
        this.dataSource.data,
        (courses) => courses.course+"_"+courses.courseTitle
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
          <h3>Weekly Class Routine List</h3>
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
        
        
      </html>`
      
    );
    popupWin.document.close();

}
}
