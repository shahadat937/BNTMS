import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import {SelectedModel} from '../../../../app/core/models/selectedModel';
import {CodeValueService} from '../../../../app/basic-setup/service/codevalue.service';
import {MasterData} from '../../../../assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import {ConfirmService} from '../../../../app/core/service/confirm.service'
import {BNASubjectName} from '../../../../app/subject-management/models/BNASubjectName';
import { SubjectMark } from '../../../subject-management/models/SubjectMark';
import { TraineeNominationService } from '../../../course-management/service/traineenomination.service'
import { TraineeList } from '../../../attendance-management/models/traineeList';
import { TraineeListForExamMark } from '../../models/traineeListforexammark';
import {AuthService} from '../../../../app/core/service/auth.service';
import {MarkTypeService} from '../../../../app/basic-setup/service/MarkType.service'
import{SubjectMarkService} from '../../../../app/subject-management/service/SubjectMark.service'
import { Role } from '../../../../../src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-reexammark',
  templateUrl: './new-reexammark.component.html',
  styleUrls: ['./new-reexammark.component.css']
})
export class NewReExamMarkComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  userRole = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  BNAExamMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools: SelectedModel[];

  selectedcoursename: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectCourseName:SelectedModel[];
  selectedClassTypeByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
  selectedSubjectNameByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
  selectSubject:SelectedModel[];
  selectedmarktype: SelectedModel[];
  selectedcoursModulebySchoolAndCourse: SelectedModel[];
  selectedmarkremarks: SelectedModel[];
  getTotalMarkAndPassMark: BNASubjectName;
  totalMark: string;
  baseSchoolNameId: number;
  classRoutineId: number;
  bnaSubjectNameId: number;
  passMarkBna: string;
  subjectMarkList: SubjectMark[];
  markTypeName:any;
  subjectPassMark:any;
  isShown: boolean = false;
  selectedCourseDuration: number;
  traineeList: TraineeListForExamMark[]
  examTypeCount: number;
  selectedCourseSection:SelectedModel[];
  selectSection:SelectedModel[];
  mark:any;
  markType:any;
  isBigger:boolean =false;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  noSubjectAvailable: boolean = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['sl', 'markType', 'passMark', 'mark'];
  displayedColumnsForTraineeList: string[] = ['sl', 'traineePNo', 'traineeName', 'obtaintMark', 'examMarkRemarksId'];

  constructor(
    private snackBar: MatSnackBar,
    private subjectMarkService: SubjectMarkService,
    private authService: AuthService, 
    private markTypeService: MarkTypeService, 
    private traineeNominationService: TraineeNominationService,
    private confirmService: ConfirmService, 
    private CodeValueService: CodeValueService,
    private BNAExamMarkService: BNAExamMarkService, 
    private fb: FormBuilder,
    private router: Router, 
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  )
  {
    super();
  }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('bnaExamMarkId');
    if (id) {
      this.pageTitle = 'Edit Absent From Exam';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.BNAExamMarkService.find(+id).subscribe(
        res => {
          this.BNAExamMarkForm.patchValue({
            bnaExamMarkId: res.bnaExamMarkId,
            bnaExamScheduleId: res.bnaExamScheduleId,
            bnaSemesterId: res.bnaSemesterId,
            bnaBatchId: res.bnaBatchId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId: res.courseNameId,
            examTypeId: res.examTypeId,
            bnaCurriculamTypeId: res.bnaCurriculamTypeId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            totalMark: res.totalMark,
            passMark: res.passMark,
            isApproved: res.isApproved,
            isApprovedBy: res.isApprovedBy,
            isApprovedDate: res.isApprovedDate,
            remarks: res.remarks,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
            courseSectionId:res.courseSectionId,
            reExamStatus:res.reExamStatus,
            isAbsent:res.isAbsent
          });
        }
      );
    } else {
      this.pageTitle = 'Create Absent From Exam';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.BNAExamMarkForm.get('baseSchoolNameId')?.setValue(this.branchId);
      this.BNAExamMarkForm.get('schoolDb')?.setValue(1);
      //this.getselectedcoursedurationbyschoolname();
      this.getSelectedCourseDurationByschoolname()
     }
    this.getselectedbaseschools();
    this.getselectedcoursename();
    this.getselectedexammarkremark();

  }
  intitializeForm() {
    this.BNAExamMarkForm = this.fb.group({
      bnaExamMarkId: [0],
      traineeId: [],
      bnaExamScheduleId: [],
      bnaSemesterId: [],
      courseName: [''],
      bnaBatchId: [],
      baseSchoolNameId: [],
      courseNameId: [],
      courseTypeId: [],
      SubjectMarkId: [],
      bnaCurriculamTypeId: [],
      bnaSubjectNameId: [],
      bnaSubjectName: [''],
      courseDurationId: [],
      classRoutineId: [],
      totalMark: [''],
      passMark: [''],
      schoolDb: [''],
      obtaintMark: [],
      examTypeCount: [],
      isApproved: [false],
      isApprovedBy: [],
      isApprovedDate: [],
      remarks: [],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      status: [],
      isActive: [true],
      courseSectionId:[],
      reExamStatus:[0],
      isAbsent:[true]
    })
  }
  getControlLabel(index: number, type: string) {
    return (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
  }
  private createTraineeData() {

    return this.fb.group({
      courseNameId: [],
      status: [],
      pno: [],
      traineeId: [],
      name: [],
      position: [],
      obtaintMark: [],
      resultStatusShow:[''],
      resultStatus:[],
      checkStatus:[],
      examMarkRemarksId: [],
      attendanceStatus:[],
      attendanceId:[],
    });
  }
  areAllMarksProvided(): boolean {
    const traineeListForm = this.BNAExamMarkForm.get('traineeListForm') as FormArray;
    
    return traineeListForm.controls.every(control => {
      const obtaintMark = control.get('obtaintMark')?.value;
      return obtaintMark !== null && obtaintMark !== '';
    });
  }
  getTraineeListonClick() {
    const control = <FormArray>this.BNAExamMarkForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData());
      
    }
    this.BNAExamMarkForm.patchValue({ traineeListForm: this.traineeList });
    
  }

  clearList() {
    const control = <FormArray>this.BNAExamMarkForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

//   onSectionSelectionGet(){
//     this.sectionId = this.BNAExamMarkForm.value['courseSectionId'];
//   }

  getselectedbaseschools() {
    this.BNAExamMarkService.getselectedbaseschools().subscribe(res => {
      this.selectedbaseschools = res
    });
  }

  onValueChange(value,i){
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
    var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
    var courseSectionId = this.BNAExamMarkForm.value['courseSectionId'];
    var bnaSubjectNameId = this.BNAExamMarkForm.value['bnaSubjectNameId'];
    var classRoutineId = this.BNAExamMarkForm.value['classRoutineId'];
    

    // this.BNAExamMarkService.getExamMarkForValidation(baseSchoolNameId,courseDurationId,courseSectionId,bnaSubjectNameId,this.markType).subscribe(res=>{
    //   this.mark=res;
      if( value >this.mark){
          this.isBigger=true;
          (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(i).get('obtaintMark')?.setValue("");
      }
      else{
        this.isBigger=false;
    }
   // });
  }


  OnTextCheck(value,index ){

    if(value >= this.subjectPassMark){
      (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get('resultStatusShow')?.setValue('Pass');
      (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get('resultStatus')?.setValue(1);
    }else{
      (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get('resultStatusShow')?.setValue('Fail');
      (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get('resultStatus')?.setValue(0);
    }
  }

  getselectedexammarkremark() {
    this.BNAExamMarkService.getselectedexammarkremark().subscribe(res => {
      this.selectedmarkremarks = res
    });
  }
  onCourseNameSelectionChangeGetSubjectAndTraineeList(dropdown) {

    if (dropdown.isUserInput) {
      var courseNameArr = dropdown.source.value.value.split('_');
      var courseNameTextArr = dropdown.source.value.text.split('_');
      var courseName = courseNameTextArr[0];
      var coursetitle = courseNameTextArr[1];
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];
      this.BNAExamMarkForm.get('courseName')?.setValue(courseName);
      this.BNAExamMarkForm.get('courseNameId')?.setValue(courseNameId);
      this.BNAExamMarkForm.get('courseDurationId')?.setValue(courseDurationId);
      this.isShown = false;

      var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
      this.baseSchoolNameId = baseSchoolNameId;
      var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
      

      this.BNAExamMarkService.getselectedCourseSection(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseSection=res;
        this.selectSection=res;
      });
      
      // this.BNAExamMarkService.getCourseDurationByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {

      //   this.selectedCourseDuration = res;
        
      // });

    }
  }
  filterBySection(value:any){
        this.selectedCourseSection=this.selectSection.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onSubjectNameSelectionChangeGetTotalMarkAndPassMark(dropdown) {
    if (dropdown.isUserInput) {
      this.isShown = true;
      var subjectArr = dropdown.source.value.value.split('_');
      var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
      var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
      var courseDurationId = this.BNAExamMarkForm.value['courseDurationId']; 
      this.bnaSubjectNameId = subjectArr[0];
      var courseModuleId = subjectArr[1];
      var classRoutineId = subjectArr[2];
      var courseSectionId = subjectArr[3];
      var SubjectMarkId = subjectArr[4];
      var markTypeId = subjectArr[5];
      this.markType=markTypeId
      this.BNAExamMarkForm.get('bnaSubjectName')?.setValue(dropdown.text);
      this.BNAExamMarkForm.get('bnaSubjectNameId')?.setValue(this.bnaSubjectNameId);
      this.BNAExamMarkForm.get('classRoutineId')?.setValue(classRoutineId);
      this.BNAExamMarkForm.get('SubjectMarkId')?.setValue(SubjectMarkId);
      this.BNAExamMarkForm.get('examTypeCount')?.setValue(1);
      
      this.getTraineeListByDurationAndSection(courseDurationId,courseSectionId,baseSchoolNameId,
        courseNameId,this.bnaSubjectNameId,classRoutineId);
      this.BNAExamMarkService.GetSubjectMarkByBaseSchoolNameIdCourseNameAndSubjectNameId(baseSchoolNameId, courseNameId, 
        this.bnaSubjectNameId).subscribe(res => {
        this.subjectMarkList = res;
      });

      this.markTypeService.find(markTypeId).subscribe(res => {
        this.markTypeName = res.typeName;
      });

      this.subjectMarkService.find(SubjectMarkId).subscribe(res => {
        this.subjectPassMark = res.passMark;
        var mark = res.mark;
        this.mark=mark;
        this.BNAExamMarkForm.get('totalMark')?.setValue(mark);
        this.BNAExamMarkForm.get('passMark')?.setValue(this.subjectPassMark);
      });

      // this.BNAExamMarkService.getselectedmarktypes(baseSchoolNameId, courseNameId, courseDurationId, this.bnaSubjectNameId, courseModuleId).subscribe(res => {
      //   this.selectedmarktype = res
      //   this.examTypeCount = res.length;
      //   this.BNAExamMarkForm.get('examTypeCount').setValue(this.examTypeCount);
      // });




      this.BNAExamMarkService.GetTotalMarkAndPassMarkByBaseSchoolIdCourseIdAndSubjectId(baseSchoolNameId, courseNameId, this.bnaSubjectNameId).subscribe(res => {

        this.getTotalMarkAndPassMark = res;
        this.totalMark = res[0].totalMark;
        this.passMarkBna = res[0].passMarkBNA;
        // this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
        // this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
      });


      //  this.totalMark="";
      //  this.passMarkBna="";
    }
  }

  getSubjectbycourseandsection(){
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
    var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
    var courseSectionId = this.BNAExamMarkForm.value['courseSectionId'];


    if (baseSchoolNameId != null && courseNameId != null) {
      this.BNAExamMarkService.getSelectedSubjectNameByParametersFromAttendanceTableForExam(baseSchoolNameId, courseNameId, courseDurationId,courseSectionId,1).subscribe(res => {
        this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId = res;
        this.selectSubject=res
        this.noSubjectAvailable = res.length == 0;
      });
    }
  }
  filterBySubject(value:any){
    this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId=this.selectSubject.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getTraineeListByDurationAndSection(courseDurationId,courseSectionId,baseSchoolNameId,courseNameId,subjectNameId,classRoutineId){
    this.traineeNominationService.getTraineeAttendanceListByCourseDurationId(courseDurationId,courseSectionId,0,baseSchoolNameId,courseNameId,subjectNameId,classRoutineId).subscribe(res => {
      this.traineeList = res.filter(x=>x.withdrawnTypeId == null);
      this.clearList()
      this.getTraineeListonClick();
    });
  }

  getSelectedCourseDurationByschoolname() {
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    this.isShown = false;

    this.BNAExamMarkService.getSelectedCourseDurationByschoolname(baseSchoolNameId).subscribe(res => {
      this.selectedcoursedurationbyschoolname = res;
      this.selectCourseName=res

    });
  }
  filterByCourse(value:any){
    this.selectedcoursedurationbyschoolname=this.selectCourseName.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  getselectedcoursename() {
    this.BNAExamMarkService.getselectedcoursename().subscribe(res => {
      this.selectedcoursename = res
    });
  }

  onSubmit() {
    const id = this.BNAExamMarkForm.get('bnaExamMarkId')?.value;

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.BNAExamMarkService.update(+id, JSON.stringify(this.BNAExamMarkForm.value)).subscribe(response => {
            this.router.navigateByUrl('/exam-management/bnaexammark-list');
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
    } else {
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
        if (result) {
      
          this.BNAExamMarkService.submit(JSON.stringify(this.BNAExamMarkForm.value)).subscribe(response => {
            //this.router.navigateByUrl('/exam-management/bnaexammark-list');
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

    }
  }
}
