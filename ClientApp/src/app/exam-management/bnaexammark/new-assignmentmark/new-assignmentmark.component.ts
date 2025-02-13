import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { BNASubjectName } from '../../../../../src/app/subject-management/models/BNASubjectName';
import { SubjectMark } from '../../../subject-management/models/SubjectMark';
import { TraineeNominationService } from '../../../course-management/service/traineenomination.service'
import { TraineeList } from '../../../attendance-management/models/traineeList';
import { TraineeListForExamMark } from '../../models/traineeListforexammark';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { MarkTypeService } from '../../../../../src/app/basic-setup/service/MarkType.service';
import { SubjectMarkService } from '../../../../../src/app/subject-management/service/SubjectMark.service';
import { ClassRoutineService } from '../../../../../src/app/routine-management/service/classroutine.service';
import {BNASubjectNameService} from '../../../subject-management/service/BNASubjectName.service'
import { Role } from '../../../../../src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-assignmentmark',
  templateUrl: './new-assignmentmark.component.html',
  styleUrls: ['./new-assignmentmark.component.css']
})
export class NewAssignmentMarkComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  BNAExamMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools: SelectedModel[];
  showHideDiv= false
  selectedcoursename: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectCourse:SelectedModel[]
  selectedClassTypeByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
  selectedSubjectNameByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
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
  courseName:any;
  getExamMarkData:any;
  subjectPassMark:any;
  isShown: boolean = false;
  isBigger:boolean =false;
  selectedCourseDuration: number;
  traineeList: TraineeListForExamMark[]
  examTypeCount: number;
  selectedCourseSection:SelectedModel[];
  selectSection:SelectedModel[];
  sectionId:number;
  bnaExamMarkId:any;
  mark:any;
  markType:any;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  courseSection:any;
  schoolName:any;
  courseNameTitle:any;
  selectedSubjectNameForAssignment:SelectedModel[];
  selectSubject:SelectedModel[];
  selectedSubjectMarkForAssignments:any[];
  subjectMarkId:any;
  noSubjectAvailable: boolean = false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['sl', 'markType', 'passMark', 'mark'];
  displayedColumnsForTraineeList: string[] = ['sl', 'traineePNo', 'traineeName', 'obtaintMark', 'examMarkRemarksId'];

  constructor(private snackBar: MatSnackBar,private BNASubjectNameService:BNASubjectNameService,private ClassRoutineService: ClassRoutineService, private subjectMarkService: SubjectMarkService, private authService: AuthService, private markTypeService: MarkTypeService, private traineeNominationService: TraineeNominationService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private BNAExamMarkService: BNAExamMarkService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('bnaExamMarkId');
    if (id) {
      this.pageTitle = 'Edit  Assignment Mark';
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
            courseSectionId:res.courseSectionId,
            isActive: res.isActive,
            reExamStatus:res.reExamStatus
          });
        }
      );
    } else {
      this.pageTitle = 'Create Assignment Mark';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.BNAExamMarkForm.get('baseSchoolNameId')?.setValue(this.branchId);
      this.BNAExamMarkForm.get('schoolDb')?.setValue(2);
      this.getSelectedCourseDurationByschoolname();
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
      subjectMarkId: [],
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
    return (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
  }
  private createTraineeData() {

    return this.fb.group({
      courseNameId: [],
      status: [],
      pno: [],
      traineeId: [],
      traineeNominationId:[],
      name: [],
      position: [],
      obtaintMark: [],
      resultStatusShow:[''],
      resultStatus:[],
      checkStatus:[],
      examMarkRemarksId: []
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
    

    //this.BNAExamMarkService.getExamMarkForValidation(baseSchoolNameId,courseDurationId,courseSectionId,bnaSubjectNameId,this.markType).subscribe(res=>{
      //this.mark=res;
      if( value >this.mark){
          this.isBigger=true;
          (this.BNAExamMarkForm.get('traineeListForm') as FormArray).at(i).get('obtaintMark')?.setValue("");
      }
      else{
        this.isBigger=false;
    }
   // });
  }
  areAllMarksProvided(): boolean {
    const traineeListForm = this.BNAExamMarkForm.get('traineeListForm') as FormArray;
    
    return traineeListForm.controls.every(control => {
      const obtaintMark = control.get('obtaintMark')?.value;
      return obtaintMark !== null && obtaintMark !== '';
    });
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
      // if (baseSchoolNameId != null && courseNameId != null) {
      //   this.BNAExamMarkService.getSelectedSubjectNameByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId, courseDurationId).subscribe(res => {
      //     this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId = res;
      //   });
      // }

      // this.BNAExamMarkService.getCourseDurationByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {

      //   this.selectedCourseDuration = res;
        
      // });
      this.BNAExamMarkService.getselectedCourseSection(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseSection=res;
        this.selectSection=res;
      });
    }
  }
  filterBySection(value:any){
    this.selectedCourseSection=this.selectSection.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSubjectbycourseandsection(){
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
    var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
    var courseSectionId = this.BNAExamMarkForm.value['courseSectionId'];


    if (baseSchoolNameId != null && courseNameId != null) {
      this.BNAExamMarkService.getSelectedSubjectNameByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId, courseDurationId,courseSectionId).subscribe(res => {
        this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId = res;
      });
    }
  }

  onSubjectNameSelectionChangeGetTotalMarkAndPassMark(dropdown) {

    if (dropdown.isUserInput) {

      this.isShown = true;
      var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
      var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
      var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
      var courseSectionId = this.BNAExamMarkForm.value['courseSectionId'];

         ///-------
         this.markTypeName ="";
         this.bnaSubjectNameId =dropdown.source.value.bnaSubjectNameId;

         this.BNAExamMarkForm.get('bnaSubjectNameId')?.setValue(this.bnaSubjectNameId);

   
         this.BNAExamMarkService.GetSubjectMarkByBaseSchoolNameIdCourseNameAndSubjectNameId(baseSchoolNameId, courseNameId, this.bnaSubjectNameId).subscribe(res => {
       
          this.subjectMarkList = res;
        });

        this.BNAExamMarkService.GetTotalMarkAndPassMarkByBaseSchoolIdCourseIdAndSubjectId(baseSchoolNameId, courseNameId, this.bnaSubjectNameId).subscribe(res => {
       
          this.getTotalMarkAndPassMark = res;
          // this.totalMark = res[0].totalMark;
          // this.passMarkBna = res[0].passMarkBNA;
          this.courseName=res[0].courseName;
          // this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
          // this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
        });
   
          this.subjectMarkService.getSelectedSubjectMarkForAssignments(baseSchoolNameId,courseNameId,this.bnaSubjectNameId).subscribe(res => {
            this.selectedSubjectMarkForAssignments = res
            this.markTypeName = res[0].typeName;
            this.subjectMarkId =res[0].subjectMarkId;

             this.BNAExamMarkForm.get('subjectMarkId')?.setValue(this.subjectMarkId);

             this.subjectMarkService.find(this.subjectMarkId).subscribe(res => {
              this.subjectPassMark = res.passMark;
              var mark = res.mark;
              this.mark =mark;
              this.BNAExamMarkForm.get('totalMark')?.setValue(mark);
              this.BNAExamMarkForm.get('passMark')?.setValue(this.subjectPassMark);
            });
          });



          this.getTraineeListByDurationAndSection(courseDurationId,courseSectionId,courseNameId);

         //-----


      //    var subjectArr = dropdown.source.value.value.split('_');
      
      // this.bnaSubjectNameId = subjectArr[0];
      // var courseModuleId = subjectArr[1];
      // var classRoutineId = subjectArr[2];
      // var courseSectionId = subjectArr[3];
      // var SubjectMarkId = subjectArr[4];
      // var markTypeId = subjectArr[5];
      // var bnaExamMarkId = subjectArr[6];

      // this.markType =markTypeId;
      
      // this.BNAExamMarkForm.get('bnaSubjectName').setValue(dropdown.text);
      // this.BNAExamMarkForm.get('bnaSubjectNameId').setValue(this.bnaSubjectNameId);
      // this.BNAExamMarkForm.get('classRoutineId').setValue(classRoutineId);
      // this.BNAExamMarkForm.get('SubjectMarkId').setValue(SubjectMarkId);
      // this.BNAExamMarkForm.get('examTypeCount').setValue(1);

      // this.markTypeService.find(markTypeId).subscribe(res => {
      //   this.markTypeName = res.typeName;
      // });
      // this.ClassRoutineService.getClassRoutineHeaderByParams(baseSchoolNameId,courseNameId,courseDurationId,this.sectionId).subscribe(res=>{
      //   this.courseSection = res[0].sectionName;
      //   this.schoolName = res[0].schoolName;
      //   this.courseNameTitle = res[0].courseNameTitle;
      // });
    
      // this.subjectMarkService.find(SubjectMarkId).subscribe(res => {
      //   this.subjectPassMark = res.passMark;
      //   var mark = res.mark;
      //   this.mark =mark;
      //   this.BNAExamMarkForm.get('totalMark').setValue(mark);
      //   this.BNAExamMarkForm.get('passMark').setValue(this.subjectPassMark);
      // });

      // this.BNAExamMarkService.getselectedmarktypes(baseSchoolNameId, courseNameId, courseDurationId, this.bnaSubjectNameId, courseModuleId).subscribe(res => {
      //   this.selectedmarktype = res
      //   this.examTypeCount = res.length;
      //   this.BNAExamMarkForm.get('examTypeCount').setValue(this.examTypeCount);
      // });



      this.BNAExamMarkService.GetTotalMarkAndPassMarkByBaseSchoolIdCourseIdAndSubjectId(baseSchoolNameId, courseNameId, this.bnaSubjectNameId).subscribe(res => {
       
        this.getTotalMarkAndPassMark = res;
        this.totalMark = res[0].totalMark;
        this.passMarkBna = res[0].passMarkBNA;
        this.courseName=res[0].courseName;
        // this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
        // this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
      });
      //  this.totalMark="";
      //  this.passMarkBna="";

    }
  }

  getTraineeListByDurationAndSection(courseDurationId,courseSectionId,courseNameId){
    this.traineeNominationService.getTraineeListForAssignmentsByCourseDurationId(courseDurationId,courseSectionId,courseNameId).subscribe(res => {
      this.traineeList = res.filter(x=>x.withdrawnTypeId === null);
      this.clearList()
      this.getTraineeListonClick();
    });
  }

  
  getSelectedCourseDurationByschoolname() {
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    this.isShown = false;

    this.BNAExamMarkService.getSelectedCourseDurationByschoolname(baseSchoolNameId).subscribe(res => {
      this.selectedcoursedurationbyschoolname = res;
      this.selectCourse=res;

    });
  }
filterByCourseName(value:any){
  this.selectedcoursedurationbyschoolname=this.selectCourse.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSectionSelectionGet(){
    // this.sectionId = this.BNAExamMarkForm.value['courseSectionId'];
    //this.BNAExamMarkForm.get('courseSectionId').setValue(this.sectionId);
    

    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
    // var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
    // this.sectionId = this.BNAExamMarkForm.value['courseSectionId'];
    if (baseSchoolNameId != null && courseNameId != null) {
      // this.BNAExamMarkService.getSelectedSubjectNameByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId, courseDurationId,this.sectionId).subscribe(res => {
      //   this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId = res;
      // });
      this.BNASubjectNameService.getSelectedsubjectsBySchoolAndCourseForAssignment(baseSchoolNameId, courseNameId).subscribe(res => {
        this.selectedSubjectNameForAssignment = res;
        this.selectSection=res
        this.noSubjectAvailable = res.length == 0;
      });
    }
  }
  filterBySubject(value:any){
    this.selectedSubjectNameForAssignment=this.selectSubject.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedcoursename() {
    this.BNAExamMarkService.getselectedcoursename().subscribe(res => {
      this.selectedcoursename = res
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
    popupWin = window.open( 'Restricted', 'top=0,left=0,height=100%,width=auto');
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
                    .dynamic-tbl-forroutine tr th span {
                      writing-mode: vertical-rl;
                      transform: rotate(180deg);
                      padding: 5px;
                      text-transform: capitalize;
                      height:195px;
                  }

                    table th {
                  font-size: 13px;
                    }
            .first-col-hide .mat-header-row.cdk-header-row.ng-star-inserted .mat-header-cell:first-child, .first-col-hide .mat-row.cdk-row.ng-star-inserted .mat-cell:first-child {
                      display: none;
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
          <h3>School:- ${this.schoolName}</h3>
          <h3>Course:- ${this.courseNameTitle}</h3>
          <h3>Course Section :- ${this.courseSection }</h3>
          <h3>MarkType:- ${this.markTypeName}</h3>
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
  onSubmit() {
    const id = this.BNAExamMarkForm.get('bnaExamMarkId')?.value;

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading = true;
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
          this.loading = true;
          this.BNAExamMarkService.submit(JSON.stringify(this.BNAExamMarkForm.value)).subscribe(response => {
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
