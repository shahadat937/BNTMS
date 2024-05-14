import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/core/service/auth.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-add-bnaexammarkentry',
  templateUrl: './add-bnaexammarkentry.component.html',
  styleUrls: ['./add-bnaexammarkentry.component.sass']
})
export class AddBnaexammarkentryComponent implements OnInit {

  BNAExamMarkEntryForm: FormGroup;
  pageTitle : string;
  role:any;
  traineeId:any;
  branchId:any;
  selectedCourseSection:any;
  baseSchoolNameId:any;
  selectedcoursedurationbyschoolname:SelectedModel[];
  constructor(private snackBar: MatSnackBar, private authService: AuthService, private confirmService: ConfirmService,  private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private BNAExamMarkService: BNAExamMarkService,) { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Exam Mark';
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.intitializeForm();
    this.getSelectedCourseDurationByschoolname();
  }

  intitializeForm() {
    this.BNAExamMarkEntryForm = this.fb.group({
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
      courseSectionId:[''],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      status: [],
      isActive: [true],
      reExamStatus:[0]
    })
  }
  getControlLabel(index: number, type: string) {
    return (this.BNAExamMarkEntryForm.get('traineeListForm') as FormArray).at(index).get(type).value;
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
      examMarkRemarksId: []
    });
  }

  getSelectedCourseDurationByschoolname() {

    this.BNAExamMarkService.getSelectedCourseDurationByschoolname(this.branchId).subscribe(res => {
      this.selectedcoursedurationbyschoolname = res;
    });
  }

  onCourseNameSelectionChangeGetSubjectAndTraineeList(dropdown){
    if (dropdown.isUserInput) {
      var courseNameArr = dropdown.source.value.value.split('_');
      var courseNameTextArr = dropdown.source.value.text.split('_');
      var courseName = courseNameTextArr[0];
      var coursetitle = courseNameTextArr[1];
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];
      this.BNAExamMarkEntryForm.get('courseName').setValue(courseName);
      this.BNAExamMarkEntryForm.get('courseNameId').setValue(courseNameId);
      this.BNAExamMarkEntryForm.get('courseDurationId').setValue(courseDurationId);
      // this.isShown = false;

      // var baseSchoolNameId = this.BNAExamMarkEntryForm.value['baseSchoolNameId'];
      this.baseSchoolNameId = this.branchId;
      var courseNameId = this.BNAExamMarkEntryForm.value['courseNameId'];
      
      this.BNAExamMarkService.getBnaSelectedCourseSection(this.baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseSection=res;
        console.log(res)
      });
    }
  }

  onSectionSelectionGet(){

  }

  onSubmit(){

  }
}
