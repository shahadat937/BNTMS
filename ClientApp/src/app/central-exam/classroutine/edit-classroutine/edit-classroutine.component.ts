import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNAExamMarkService } from '../../../exam-management/service/bnaexammark.service'
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BNASubjectName } from 'src/app/subject-management/models/BNASubjectName';
import { SubjectMark } from '../../../subject-management/models/SubjectMark';
import {TraineeNominationService} from '../../../course-management/service/traineenomination.service'
import { TraineeList } from '../../../attendance-management/models/traineeList';
import { TraineeListForExamMark } from '../../../exam-management/models/traineeListforexammark';

import { ClassRoutineService } from '../../../routine-management/service/classroutine.service';
import { ClassRoutine } from '../../../routine-management/models/classroutine';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { SubjectMarkService } from '../../service/SubjectMark.service';

@Component({
  selector: 'app-edit-classroutine',
  templateUrl: './edit-classroutine.component.html',
  styleUrls: ['./edit-classroutine.component.sass']
}) 
export class EditClassRoutineComponent implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  EditedClassRoutineForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools:SelectedModel[];
 
   selectedcoursename:SelectedModel[];
    selectedcoursedurationbyschoolname:SelectedModel[];
    selectedClassTypeByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
    selectedSubjectNameByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
    selectedmarktype:SelectedModel[];
    selectedsubjectname:SelectedModel[];
    selectedBranch:SelectedModel[];
    getTotalMarkAndPassMark:BNASubjectName;
    totalMark: string;
    baseSchoolNameId:number;
    classRoutineId:number;
    bnaSubjectNameId:number;
    passMarkBna:string;
    subjectMarkList:SubjectMark[];
    isShown: boolean = false ;
    selectedCourseDuration:number;
    traineeList:TraineeListForExamMark[];
    examTypeCount:number;
    selectedRoutineByParametersAndDate:any;
    displayedColumns: string[];

    schoolName:any;
    CourseName:any;
    CourseTitle:any;
    weekName:any;

    schoolId:any;
    durationId:any;
    courseId:any;
    weekId:any;
    qexamRoutineList:ClassRoutine[];
    editedRoutineList:ClassRoutine[];

    //ApproveMsgScreen: boolean = false ;
    ApproveMsg:string;


    paging = {
      pageIndex: this.masterData.paging.pageIndex,
      pageSize: this.masterData.paging.pageSize,
      length: 1
    }
  
  constructor(private snackBar: MatSnackBar,private SubjectMarkService: SubjectMarkService,private subjectNameService: BNASubjectNameService,private classRoutineService:ClassRoutineService,private traineeNominationService:TraineeNominationService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private BNAExamMarkService: BNAExamMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, ) { }

  ngOnInit(): void {
     
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.durationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.courseId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.weekId = this.route.snapshot.paramMap.get('courseWeekId'); 
    
     this.intitializeForm();   
     

    this.getEditedRoutineList(this.durationId)
    this.getSelectedBranch();
    this.getSubjectName(this.courseId);
    this.getModifiedRoutine(this.durationId)
  }
  intitializeForm() {
    this.EditedClassRoutineForm = this.fb.group({
      
      RoutineList: this.fb.array([
        this.createTraineeData()
      ]) 
      
    })
  }
  onSelectedSubjectNameByBranchId(branchId) {
    this.SubjectMarkService.getSelectedSubjectNameByBranchId(branchId).subscribe(res => {
      this.selectedsubjectname = res
    });
  }

  getSubjectName(courseName){
    this.subjectNameService.getSelectedSubjectNameByCourseNameId(courseName).subscribe(res => {
      this.selectedsubjectname = res;
    });
  }
  getEditedRoutineList(durationId){
    // this.ClassRoutineService.getQexamRoutine(courseDurationId).subscribe(response => {     
    //   this.qexamRoutineList=response;
    this.classRoutineService.getCentralExamRoutineListByParams(durationId).subscribe(res=>{
      this.editedRoutineList=res;
      //this.schoolName=this.editedRoutineList[0].baseSchoolName;
      this.CourseName=this.editedRoutineList[0].courseName;
      this.CourseTitle=this.editedRoutineList[0].courseDuration;
      //this.weekName=this.editedRoutineList[0].courseWeek;
      this.clearList();
      this.getEditedRoutineListonClick();
    });
    
  }
  getControlLabel(index: number,type: string){
    return  (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get(type).value;
   }
  private createTraineeData() {
 
    return this.fb.group({
      classRoutineId: [],
      courseModuleId:[],
      courseNameId:[],
      classPeriodId:[''],
      baseSchoolNameId:[''],
      courseDurationId:[],
      subjectName:[''],
      bnaSubjectNameId:[],
      courseWeekId:[],
      branchId:[],
      branch:[],
      examMarkComplete:[],
      attendanceComplete:[0],
      classTypeId:[],
      classCountPeriod:[],
      subjectCountPeriod:[],
      date:[], 
      classLocation:[''],
      isApproved:[],
      approvedDate:[],
      approvedBy:[],
      status:[],
      isActive: [],
      classPeriod:[],
      classPeriodDurationForm:[],
      classPeriodDurationTo:[],
      classType:[],
    });
  }

  getSelectedBranch() {
    
    this.SubjectMarkService.getSelectedBranch().subscribe(res => {
      this.selectedBranch = res
    });
  }

  onSubjectNameSelectionChangeGet(dropdown){
    var courseNameArr = dropdown.value.split('_');
    var bnaSubjectNameId = courseNameArr[0];
    var courseModuleId=courseNameArr[1];
    this.EditedClassRoutineForm.controls["RoutineList"].get('subjectName').setValue(dropdown.text);
    this.EditedClassRoutineForm.controls["RoutineList"].get('bnaSubjectNameId').setValue(bnaSubjectNameId);
    this.EditedClassRoutineForm.controls["RoutineList"].get('courseModuleId').setValue(courseModuleId);
}

  

  getEditedRoutineListonClick(){ 
    const control = <FormArray>this.EditedClassRoutineForm.controls["RoutineList"];
    for (let i = 0; i < this.editedRoutineList.length; i++) {
      control.push(this.createTraineeData()); 
    }
    this.EditedClassRoutineForm.patchValue({ RoutineList: this.editedRoutineList });
  }

  clearList() {
    const control = <FormArray>this.EditedClassRoutineForm.controls["RoutineList"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getModifiedRoutine(courseDurationId){
    this.isShown=true;
    this.classRoutineService.getQexamRoutine(courseDurationId).subscribe(response => {     
      this.qexamRoutineList=response;

      for(let i=0;i<=this.qexamRoutineList.length;i++){

       }

       this.displayedColumns =[...Object.keys(this.qexamRoutineList[0])];
       

    })
  }

  onSubmit() {
    //const id = this.EditedClassRoutineForm.get('bnaExamMarkId').value; 
     
    // if (id) {
    //   this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
    //     if (result) {
    //       this.BNAExamMarkService.update(+id,JSON.stringify(this.EditedClassRoutineForm.value)).subscribe(response => {
    //         this.router.navigateByUrl('/exam-management/bnaexammark-list');
    //         this.snackBar.open('Information Updated Successfully ', '', {
    //           duration: 2000,
    //           verticalPosition: 'bottom',
    //           horizontalPosition: 'right',
    //           panelClass: 'snackbar-success'
    //         });
    //       }, error => {
    //         this.validationErrors = error;
    //       })
    //     }
    //   })
    // }else {
      
    
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.classRoutineService.weeklyRoutineUpdate(JSON.stringify(this.EditedClassRoutineForm.value)).subscribe(response => {                        
            this.getModifiedRoutine(this.durationId)
            this.snackBar.open('Information Inserted Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warn'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })          
  }
}
