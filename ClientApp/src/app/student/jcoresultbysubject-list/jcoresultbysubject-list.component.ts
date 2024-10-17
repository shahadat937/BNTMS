import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { CourseDurationService } from '../../course-management/service/courseduration.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';


@Component({
  selector: 'app-jcoresultbysubject',
  templateUrl: './jcoresultbysubject-list.component.html',
  styleUrls: ['./jcoresultbysubject-list.component.sass']
})
export class JcoResultBySubjectListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  JcoResultBySubject:any;
  courseDurationId:any;
  course:any;
  subject:any;
  passMark:any;
  totalMark:any;
  status=1;
  showHideDiv= false;
  SelectedsubjectsBySchoolAndCourse:BNASubjectName[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedCourseModuleColumns: string[] = ['ser','trainee','indexNo','obtainedMark', 'resultStatus'];


   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private courseDurationService:CourseDurationService,private studentDashboardService: StudentDashboardService,private bNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    var bnaSubjectNameId = this.route.snapshot.paramMap.get('bnaSubjectNameId');
    var resultStatus = this.route.snapshot.paramMap.get('resultStatus');
    this.getJcoResultBySubject(this.courseDurationId,bnaSubjectNameId,resultStatus)
    this.courseDurationService.find(this.courseDurationId).subscribe(res=>{
      // this.JcoResultBySubject = res;
      this.course = res.courseName+"_"+res.courseTitle;
    });
    this.bNASubjectNameService.find(Number(bnaSubjectNameId)).subscribe(res=>{
      // this.JcoResultBySubject = res;
      // this.course = res.courseName+"_"+res.courseTitle;
      this.subject = res.subjectName;
      this.passMark = res.passMarkBna;
      this.totalMark = res.totalMark;
    });
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getJcoResultBySubject(courseDurationId,bnaSubjectNameId,resultStatus){
    this.subscription = this.studentDashboardService.getJcoResultBySubject(courseDurationId,bnaSubjectNameId,resultStatus).subscribe(res=>{
      this.JcoResultBySubject = res;
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
                    .tbl-by-group tr .cl-mrk-rmrk {
                      display:none;
                    }
                    .tbl-by-group tr .btn-tbl-view {
                      display:none;
                    }
                    .tbl-by-group tr .btn-tbl-nomination {
                      display:none;
                    }
                    table td button{
                      background:none;
                      border:none;
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
            <h3>Course Name: ${this.course}</h3>
            <p>Subject Name: ${this.subject}</p>
            <p>Total Mark: ${this.totalMark} Pass Mark: ${this.passMark}</p>
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
        
        <footer>
        <p>tms.navy.mil.bd</p>
        </footer>
      </html>`
      
    );
    popupWin.document.close();

}

}
