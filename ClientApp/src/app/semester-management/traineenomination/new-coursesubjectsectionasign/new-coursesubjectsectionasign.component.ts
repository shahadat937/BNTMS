import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators,FormControl,FormGroupDirective,NgForm} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AttendanceService } from '../../../attendance-management/service/attendance.service'; 
import { SelectedModel } from '../../../core/models/selectedModel';
import { MasterData } from '../../../../assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { BNASubjectNameService } from '../../../subject-management/service/BNASubjectName.service'; 
import { TraineeNomination } from '../../../course-management/models/traineenomination';
import { SelectionModel } from '@angular/cdk/collections';
import { nomeneeSubjectSection } from '../../models/nomeneeSubjectSection';
import { CheckboxSelectedModel } from '../../../core/models/checkboxSelectedModel';
import { TraineeList } from '../../../attendance-management/models/traineeList';
import { DatePipe } from '@angular/common';
import { CoursesubjectsectionasignService } from '../../../semester-management/service/Coursesubjectsectionasign.service';
import { AuthService } from '../../../core/service/auth.service';
import { Role } from '../../../core/models/role';
import { TraineeListForExamMark } from '../../../exam-management/models/traineeListforexammark';
import { TraineeNominationService } from 'src/app/course-management/service/traineenomination.service';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-new-coursesubjectsectionasign',
  templateUrl: './new-coursesubjectsectionasign.component.html',
  styleUrls: ['./new-coursesubjectsectionasign.component.sass']
}) 
export class NewcoursesubjectsectionasignComponent implements OnInit {
  masterData = MasterData;
  loading = false;
  myModel = true;
  buttonText:string;
  pageTitle: string;
  destination:string;
  NomeneeSubjectSectionForm: FormGroup;
  validationErrors: string[] = [];
  selectedclassroutine:SelectedModel[];
  selectedbaseschools:SelectedModel[];
  selectedcoursename:SelectedModel[];
  selectedbnasubjectname:SelectedModel[];
  selectedclassperiod:SelectedModel[];
  selectedbnaattendanceremark:SelectedModel[];
  selectedCourse:SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
  selectedCourseDurationByParameterRequest:number;
  traineeNominationListForAttendance: TraineeList[];
  selectedvalues:CheckboxSelectedModel[];
  traineeForm: FormGroup;
  courseSectionList:SelectedModel[];
  selectedCourseDurationByCourseTypeAndCourseName:SelectedModel[];
  subjectName:string;
  bnaSubjectNameId:number;
  classRoutineId:number;
  courseDurationId:any;
  courseNameId:any;
  isLoading = false;
  displayedColumnsList: string[];
  // subjectList:TraineeNomination[];
  subjectList:SelectedModel[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  schollNameId:any;
  bnaSubjectCurriculumId:any;
  bnaSemesterId:any;

  actionStatus : any;

  searchText="";

  displayedColumnsRoutine: string[] = ['ser','bnaSubjectName','date','timeDuration', 'actions'];
   dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();

  checked = false;
  isShown: boolean = false ;
  isShownForTraineeList:boolean=false;
  // displayedColumns: string[] = ['ser','traineePNo','attendanceStatus','bnaAttendanceRemarksId'];
  // dataSource ;
  constructor(private snackBar: MatSnackBar, private authService: AuthService,private subjectNameService: BNASubjectNameService,private CoursesubjectsectionasignService:CoursesubjectsectionasignService,private datepipe:DatePipe, private confirmService: ConfirmService,private traineeNominationService:TraineeNominationService,private CodeValueService: CodeValueService,private AttendanceService: AttendanceService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, private location: Location) { }

  goBack() {
    this.location.back();
  }

  ngOnInit(): void {
    // 3136
   // const id = this.route.snapshot.paramMap.get('attendanceId'); 
    //this.courseDurationId=this.route.snapshot.paramMap.get('courseDurationId'); 
    
    let  traineeNominationId= this.route.snapshot.paramMap.get('traineeNominationId');
    this.schollNameId= this.route.snapshot.paramMap.get('schollNameId');
    this.courseNameId= this.route.snapshot.paramMap.get('courseNameId');
    this.bnaSubjectCurriculumId= this.route.snapshot.paramMap.get('bnaSubjectCurriculumId');
    this.bnaSemesterId= this.route.snapshot.paramMap.get('bnaSemesterId');


    
    this.intitializeForm();
      this.getTraineeNominationIdList(traineeNominationId);

    this.getCourseSection();
  }


  intitializeForm() {
    this.NomeneeSubjectSectionForm = this.fb.group({
      attendanceId: [0],
      baseSchoolNameId:[''],
      courseNameId:[''],
      courseNameIds:[''],
      courseDurationId:[''],
      classPeriodId:[''], 
      attendanceDate:[], 
      classLeaderName:[''],
      indexNo:[''],
      attendanceStatus:[true],
     subjectSectionForm: this.fb.array([this.createSubjectListData()]),
    })
  }

  getCourseSection(){
    this.CoursesubjectsectionasignService.getselectedcoursedurationForBna().subscribe(res=>{  
        this.courseSectionList=res;
      
    });
  }

  private createSubjectListData() {

    return this.fb.group({
      courseNomeneeId: [0],   
      traineeNominationId  :[''],
      courseDurationId  :[''],
      courseNameId  :[''],
     baseSchoolNameId  :[''],
     courseModuleId  :[''],
     bnaSubjectNameId  :[''],
     bnaSemesterId  :[''],
     departmentId  :[''],
     bnaSubjectCurriculumId  :[''],
     courseSectionId  :[''],
     traineeId  :[''],
      subjectMarkId  :[''],
      markTypeId  :[''],
      subjectName:[''],
    });
  }


  getControlLabel(index: number, type: string) {
    return (this.NomeneeSubjectSectionForm.get('subjectSectionForm') as FormArray).at(index).get(type).value;
  }

  getTraineeListonClick() {
    const control = <FormArray>this.NomeneeSubjectSectionForm.controls["subjectSectionForm"];
    for (let i = 0; i < this.subjectList.length; i++) {
      control.push(this.createSubjectListData());
    }
    this.NomeneeSubjectSectionForm.patchValue({ subjectSectionForm: this.subjectList });
  }

  clearList() {
    const control = <FormArray>this.NomeneeSubjectSectionForm.controls["subjectSectionForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

 

  getTraineeNominationIdList(traineeNominationId){

    this.CoursesubjectsectionasignService.BnaNomeneeSubjectSectionAsignId(this.schollNameId,this.courseNameId,this.bnaSubjectCurriculumId,this.bnaSemesterId).subscribe(res=>{
      this.subjectList=res;
      console.log("Subject List : ", this.subjectList);
      if (res.length==0){
 
      this.CoursesubjectsectionasignService.BnaNomeneeSubjectSectionAlredyAsignId(traineeNominationId).subscribe(res=>{
        this.pageTitle = 'Assign Course Section';
        this.destination = "Assign"; 
        //this.buttonText= "Update"; 
        this.actionStatus='U';
        this.clearList();
        this.getTraineeListonClick();
      });
      }
      else
      {
        this.pageTitle = 'Assign Course Section';
        this.destination = "Assign"; 
        this.buttonText= "SAVE"; 
        this.actionStatus='S';
        this.clearList();
        this.getTraineeListonClick();
      }

    });


    
  }
  


  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {

    //  const id = this.AttendanceForm.get('traineeNominationId').value;

if (this.actionStatus=='S'){
    this.confirmService.confirm('Confirm Save message', 'Are You Sure Inserted This Records?').subscribe(result => {
      if (result) {
        this.loading = true;
        this.CoursesubjectsectionasignService.submit(this.NomeneeSubjectSectionForm.value).subscribe(response => {
       //   this.router.navigateByUrl('/semester-management/add-traineenomination='+);
          this.snackBar.open('Information Inserted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        }, error => {
          this.validationErrors = error;
        })
      }
    })}
    else if(this.actionStatus=='U'){
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Update This Records?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.CoursesubjectsectionasignService.update(this.NomeneeSubjectSectionForm.value).subscribe(response => {
            //this.router.navigateByUrl('/course-management/schoolcourse-list');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
  }
/*
  onSubmit() {
    
    //  const id = this.NomeneeSubjectSectionForm.get('traineeNominationId').value;
    this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
      if (result) {
        this.loading = true;
        this.CoursesubjectsectionasignService.submit(JSON.stringify(this.NomeneeSubjectSectionForm.value) ).subscribe(response => {
          //this.router.navigateByUrl('/exam-management/bnaexammark-list');
         // this.reloadCurrentRoute();
         this.reloadCurrentRoute();
          this.snackBar.open('Information Inserted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        }, error => {
          this.validationErrors = error;
        })
      }
    })

  }*/
}

