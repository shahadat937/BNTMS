import { Component, OnInit  } from '@angular/core';
import { BNASubjectName } from '../../../subject-management/models/BNASubjectName';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{ MasterData } from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNAExamMarkService } from '../../../exam-management/service/bnaexammark.service';
import { CourseDurationService } from '../../service/courseduration.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { BaseSchoolNameService } from '../../../../../src/app/security/service/BaseSchoolName.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-marklistbycourse',
  templateUrl: './marklistbycourse-list.component.html',
  styleUrls: ['./marklistbycourse-list.component.sass','./marklistbycourse-list.component.css']
})
export class MarkListByCourseComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  status=1;
  title:any;
  marklistbycourse:any[];
  courseNameId: any;
  course:any;
  dbType:Number = 0;
  dbType1:any;
  dbType2:any;
  mainDb:any;
  
  role:any;
  traineeId:any;
  branchId:any;
  schoolName:any;

  courseType:Number;
  showHideDiv = false;
  isShown: boolean= false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  warningMessage = ''
  
  displayedColumns: string[] ;
  //displayedColumns: string[] = ['ser','pno','name','rankposition','course','courseTitle','subjectName','totalMark','passMarkBna', 'obtaintMark'];
  //displayedColumns: string[] = ['pno','name','position','general Navigation ','instrument','relvel and Fleet Work','rule of The Road'];


   selection = new SelectionModel<BNASubjectName>(true, []);

  
  constructor(
    private snackBar: MatSnackBar,
    private baseSchoolNameService: BaseSchoolNameService,
    private authService: AuthService,
    private courseDurationService: CourseDurationService,
    private BNAExamMarkService: BNAExamMarkService,
    private router: Router,
    private confirmService: ConfirmService,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
   
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId  ? this.authService.currentUserValue.branchId.trim() : "";

    this.baseSchoolNameService.find(this.branchId).subscribe(res=>{
      this.schoolName = res.schoolName;
    });

    this.getTraineeMarkListByDuration();

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
                    .dynamic-tbl tr th span {
                      writing-mode: vertical-rl;
                      transform: rotate(180deg);
                      padding: 5px;
                      text-transform: capitalize;
                      height:195px;
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
                .text-bold-cap-und{
                  font-weight: bold;
                  text-transform: uppercase;
                  text-decoration: underline;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <span class="header-warning top">CONFIDENTIAL</span>
            
            <div class="text-bold-cap-und"> 
              
              <h3>Result sheet of ${this.course} </h3>
              <h3> ${this.schoolName} </h3>
            </div>
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
 
  getTraineeMarkListByDuration() {
    this.isLoading = true;
    
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    this.dbType = Number(this.route.snapshot.paramMap.get('dbType')); 
    this.mainDb = Number(this.route.snapshot.paramMap.get('mainDb')); 
    this.dbType1=this.route.snapshot.paramMap.get('dbType1');
    this.dbType2=this.route.snapshot.paramMap.get('dbType2');
    this.courseType = Number(this.route.snapshot.paramMap.get('courseTypeId')); 

    this.courseDurationService.find(Number(courseDurationId)).subscribe(res=>{
  
      this.course = res.courseName+"_"+res.courseTitle;
    });
    if(this.courseNameId == this.masterData.courseName.StaffCollage){
      // console.log("Test 1")
      this.title = "Staff Collage Mark";
      this.BNAExamMarkService.getTraineeMarkListByDurationForStuffClg(courseDurationId).subscribe(res=>{
        this.marklistbycourse=res;  
        if(this.marklistbycourse && this.marklistbycourse.length)
        this.displayedColumns =[...Object.keys(this.marklistbycourse[0])];
        this.isLoading = false;
        
      });
    }else if(this.courseNameId == this.masterData.courseName.JCOsTraining){
      // console.log("Test 2")
      this.title = "JCO's Exam Mark";
      this.BNAExamMarkService.getTraineeMarkListByDurationForStuffClg(courseDurationId).subscribe(res=>{
        this.marklistbycourse=res;  
        this.displayedColumns =[...Object.keys(this.marklistbycourse[0])];
        this.isLoading = false;
        
      });
    }else if(this.courseNameId == this.masterData.courseName.QExam){
      // console.log("Test 3")
      this.title = " Q-Exam Mark";
      this.BNAExamMarkService.getTraineeMarkListByDurationForQexam(courseDurationId).subscribe(res=>{
        this.marklistbycourse=res;  
        if(this.marklistbycourse && this.marklistbycourse.length)
        this.displayedColumns =[...Object.keys(this.marklistbycourse[0])];
        this.isLoading = false;
      
      });
    }else{
      this.title = "Course Subject";
      this.BNAExamMarkService.getTraineeMarkListByDuration(courseDurationId).subscribe(res=>{
        this.marklistbycourse=res;   
        if(this.marklistbycourse && this.marklistbycourse.length){
          this.displayedColumns =[...Object.keys(this.marklistbycourse[0])];
          this.isShown=true;
        }
        else{
          this.warningMessage = "Trainee Mark has not been assigned yet";
          
        }
   
        this.isLoading = false;
       
      });
    }
    
  }

  
}
