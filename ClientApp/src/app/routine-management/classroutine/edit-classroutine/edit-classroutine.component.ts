import { Component, OnDestroy, OnInit } from '@angular/core';
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

import { ClassRoutineService } from '../../service/classroutine.service';
import { ClassRoutine } from '../../models/classroutine';

@Component({
  selector: 'app-edit-classroutine',
  templateUrl: './edit-classroutine.component.html',
  styleUrls: ['./edit-classroutine.component.sass']
}) 
export class EditClassRoutineComponent implements OnInit, OnDestroy {
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
    selectedclasstype:SelectedModel[];
    selectedsubjectname:SelectedModel[];
    selectedclassperiod:SelectedModel[];
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
    sectionId:any;
    routineCount:any;
    totalPeriod:any;
    editedRoutineList:ClassRoutine[];

    ApproveMsgScreen: boolean = false ;
    ApproveMsg:string;


    paging = {
      pageIndex: this.masterData.paging.pageIndex,
      pageSize: this.masterData.paging.pageSize,
      length: 1
    }
  subscription: any;
  
  constructor(private snackBar: MatSnackBar,private classRoutineService:ClassRoutineService,private traineeNominationService:TraineeNominationService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private BNAExamMarkService: BNAExamMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, ) { }

  ngOnInit(): void {
     
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.durationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.courseId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.weekId = this.route.snapshot.paramMap.get('courseWeekId'); 
    this.sectionId = this.route.snapshot.paramMap.get('courseSectionId'); 
    
     this.intitializeForm();   
     

    this.getEditedRoutineList(this.schoolId,this.durationId,this.courseId,this.weekId,this.sectionId)
    this.getSubjectName(this.schoolId,this.courseId);
    this.getModifiedRoutine(this.schoolId,this.courseId,this.weekId,this.sectionId)
    this.getselectedclasstype();
    this.getselectedclassperiod(this.schoolId,this.courseId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  intitializeForm() {
    this.EditedClassRoutineForm = this.fb.group({
      
      RoutineList: this.fb.array([
        this.createTraineeData()
      ]) 
      
    })
  }
  getSubjectName(schoolName,courseName){
    this.subscription = this.classRoutineService.getselectedSubjectNamesBySchoolAndCourse(schoolName,courseName).subscribe(res=>{
      this.selectedsubjectname=res;
    });
  }
  getEditedRoutineList(schoolId,durationId,courseId,weekId,sectionId){
    this.subscription = this.classRoutineService.getClassRoutineListByParams(schoolId,durationId,courseId,weekId,sectionId).subscribe(res=>{
      this.editedRoutineList=res;
      this.schoolName=this.editedRoutineList[0].baseSchoolName;
      this.CourseName=this.editedRoutineList[0].courseName;
      this.CourseTitle=this.editedRoutineList[0].courseDuration;
      this.weekName=this.editedRoutineList[0].courseWeek;
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
      markType:[''],
      bnaSubjectName:[''],
      courseSection:[''],
      bnaSubjectNameId:[],
      subjectMarkId:[],
      markTypeId:[],
      traineeId:[],
      trainee:[''],
      courseSectionId:[],
      courseWeekId:[],
      examMarkComplete:[0],
      attendanceComplete:[0],
      classTypeId:[],
      classCountPeriod:[],
      totalClassPeriod:[],
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
      classRoomName:[],   
      classTopic:[] 
    });
  }

  selectedInstructor ={};
  selectedmarktypearray ={};

  onSubjectNameSelectionChangeGet(dropdown,index: number){
 
   


    var bnaSubjectNameId = dropdown.value;

    //this.onSubjectNameSelectionChange(this.schoolId,this.courseId,this.sectionId,bnaSubjectNameId, this.durationId,index);  

    this.subscription = this.classRoutineService.getselectedInstructor(this.schoolId,this.courseId,this.durationId,this.sectionId,bnaSubjectNameId).subscribe(res=>{
  
      this.selectedInstructor[bnaSubjectNameId]=res;
    });
    
    this.subscription = this.classRoutineService.getselectedmarktype(bnaSubjectNameId).subscribe(res=>{
      this.selectedmarktypearray[bnaSubjectNameId]=res;
    });

    this.subscription = this.classRoutineService.getClassRoutineCountByParameterRequest(this.schoolId,this.courseId,bnaSubjectNameId,this.durationId,this.sectionId).subscribe(res=>{
      this.routineCount=res;
      (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('totalClassPeriod').setValue(this.routineCount);
    });
  }

  onSubjectNameSelectionChange(baseSchoolNameId,courseNameId,courseSectionId,bnaSubjectNameId,courseDurationId,index){
    


    this.subscription = this.classRoutineService.getClassRoutineCountByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId,courseDurationId,courseSectionId).subscribe(res=>{
      this.routineCount=res;
      (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('classCountPeriod').setValue(this.routineCount);
    });

 
  
    this.subscription = this.classRoutineService.getTotalPeriodByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      this.totalPeriod=res;
      (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('subjectCountPeriod').setValue(this.totalPeriod);
     
    });

 
  }

  onSubjectMarkSelectionGetMarkType(index: number){
     
    let markId = (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('subjectMarkId').value;
     // var subjectMarkId = this.ClassRoutineForm.value['subjectMarkId'];
     this.classRoutineService.findSubjectMark(markId).subscribe(res=>{
       (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('markTypeId').setValue(res.markTypeId);
      // this.ClassRoutineForm.get('markTypeId').setValue(res.markTypeId);
     });
 
   }

  getselectedclassperiod(baseSchoolNameId: number,courseNameId: number){
    this.subscription = this.classRoutineService.getselectedClassPeriodbyschoolandcourse(baseSchoolNameId,courseNameId).subscribe(res=>{
      this.selectedclassperiod=res;
    });
  }

  getselectedclasstype(){
    this.subscription = this.classRoutineService.getselectedclasstype().subscribe(res=>{
      this.selectedclasstype=res;
    });
  }


  getbnasubjectnamechange(bnaSubjectNameId, event: any){
    if (event.isUserInput) {    // ignore on deselection of the previous option
      
      var courseSectionId=0;
      this.subscription = this.classRoutineService.getClassRoutineCountByParameterRequest(this.schoolId,this.courseId,bnaSubjectNameId,this.durationId,courseSectionId).subscribe(res=>{
        this.routineCount=res;
        //this.ClassRoutineForm.get('classCountPeriod').setValue(this.routineCount);
        //this.EditedClassRoutineForm.controls["RoutineList"].get('classCountPeriod').setValue(this.routineCount);
      });
    
      this.subscription = this.classRoutineService.getTotalPeriodByParameterRequest(this.schoolId,this.courseId,bnaSubjectNameId).subscribe(res=>{
        this.totalPeriod=res;
        //this.ClassRoutineForm.get('subjectCountPeriod').setValue(this.totalPeriod);
        //this.EditedClassRoutineForm.controls["RoutineList"].get('subjectCountPeriod').setValue(this.totalPeriod);
    
      });
    } 
  
  }

//   onSubjectNameSelectionChangeGet(dropdown){
//     var courseNameArr = dropdown.value.split('_');
//     var bnaSubjectNameId = courseNameArr[0];
//     var courseModuleId=courseNameArr[1];
//     this.EditedClassRoutineForm.controls["RoutineList"].get('subjectName').setValue(dropdown.text);
//     this.EditedClassRoutineForm.controls["RoutineList"].get('bnaSubjectNameId').setValue(bnaSubjectNameId);
//     this.EditedClassRoutineForm.controls["RoutineList"].get('courseModuleId').setValue(courseModuleId);
// }

  

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

  getModifiedRoutine(baseSchoolNameId,courseNameId,courseWeekId,courseSectionId){
    this.isShown=true;
    this.subscription = this.classRoutineService.getClassRoutineByCourseNameBaseSchoolNameSpRequest(baseSchoolNameId,courseNameId,courseWeekId,courseSectionId).subscribe(res=>{
      this.selectedRoutineByParametersAndDate=res;
      for(let i=0;i<=this.selectedRoutineByParametersAndDate.length;i++){

      }

      this.displayedColumns =[...Object.keys(this.selectedRoutineByParametersAndDate[0])];
      


    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  deleteItem(index) {
    const id = (this.EditedClassRoutineForm.get('RoutineList') as FormArray).at(index).get('classRoutineId').value;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.classRoutineService.delete(id).subscribe(() => {
          this.reloadCurrentRoute();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
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
      
    
      this.subscription = this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.classRoutineService.weeklyRoutineUpdate(JSON.stringify(this.EditedClassRoutineForm.value)).subscribe(response => {                        
            this.reloadCurrentRoute();
            this.getModifiedRoutine(this.schoolId,this.courseId,this.weekId, this.sectionId)
            this.getEditedRoutineList(this.schoolId,this.durationId,this.courseId,this.weekId, this.sectionId)
            this.snackBar.open('Information Updated Successfully ', '', {
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
