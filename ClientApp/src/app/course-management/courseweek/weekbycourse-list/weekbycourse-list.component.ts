import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseWeek} from '../../models/CourseWeek'
import {CourseWeekService} from '../../service/CourseWeek.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { MatSort } from '@angular/material/sort';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-weekbycourse-list',
  templateUrl: './weekbycourse-list.component.html',
  styleUrls: ['./weekbycourse-list.component.sass'] 
})
export class WeekByCourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseWeek[] = [];
  isLoading = false;
  btnText:string;
  runningCourses:any;
  branchId:any;
  courseWeekId:any;
  traineeId:any;
  role:any;
  showHideDiv= false;
  schoolId:any;
  schoolName:any;
  passOutStatus:any;
  course:any;
  currentDate:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  groupArrays:{ courseName: string; courses: any; }[];

 


  displayedColumns: string[] = ['ser','course', 'durationFrom', 'durationTo','countWeek'];
  // dataSource: MatTableDataSource<CourseWeek> = new MatTableDataSource();
  
  // dataSource = new MatTableDataSource<any>();

  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  matSort!: MatSort;

   selection = new SelectionModel<CourseWeek>(true, []);
  
  
  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe,private authService: AuthService,private CourseWeekService: CourseWeekService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {

    this.currentDate = this.datepipe.transform((new Date), 'MM/dd/yyyy');

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.schoolId = this.branchId;
    this.CourseWeekService.find(this.schoolId).subscribe(response => {  
      // this.schoolId= response.baseSchoolNameId
          //this.schoolId = response.courseNameId  
      // this.schoolName = response.schoolName;
    })

    this.getrunningCourseListBySchool(this.schoolId);
    
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
    printContents = document.getElementById('print-routine').innerHTML;
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
                    .tbl-by-group.db-li-s-in tr .btn-tbl-view {
                      display:none;
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
                .header-text{
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
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <span class="header-warning top">CONFIDENTIAL</span>
          <h3> ${this.course}</h3>
          <h3> ${this.schoolName}</h3>
          </div>
          <br>
          <hr>
          ${printContents}
          <span class="header-warning bottom">CONFIDENTIAL</span>
        </body>
      </html>`
    );
    popupWin.document.close();

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
// <h3> ${this.course} - ${this.courseTitle} </h3>
  getrunningCourseListBySchool(schoolId){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.CourseWeekService.getrunningCourseListBySchool(currentDateTime, this.masterData.coursetype.LocalCourse, schoolId).subscribe(response => {   

      this.dataSource = new MatTableDataSource(response);
     
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;
      
      
      //this.localCourseCount=response.length;
      this.runningCourses=response;
      this.schoolName=response[0].schoolName;
      this.course=response[0].course;
      // this.schoolName=response.schoolName
      this.dataSource = new MatTableDataSource(response);
      // this.dataSource.paginator = this.paginator;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.matSort;

    })
   

  }
  applySearch(filterValue: string) {
   
    filterValue = filterValue.toLowerCase().replace(/\s/g,'');
    this.dataSource.filter = filterValue;
  }
 
}
