import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SelectedModel } from '../../../../core/models/selectedModel';
import {MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import {ConfirmService} from '../../../../core/service/confirm.service';
import {TraineeNominationService} from '../../../../course-management/service/traineenomination.service';
import {CheckboxSelectedModel} from '../../../../core/models/checkboxSelectedModel';
import { TraineeList } from '../../../../attendance-management/models/traineeList';
import { MatTableDataSource } from '@angular/material/table';
import { ClassRoutine } from '../../../../routine-management/models/classroutine';
import { TraineeListForExamMark } from '../../../../../../src/app/exam-management/models/traineeListforexammark';
import { CourseDurationService } from '../../../../../../src/app/course-management/service/courseduration.service';
import { number } from 'echarts';
import { UnsubscribeOnDestroyAdapter } from '../../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-traineesectionassign-list',
  templateUrl: './traineesectionassign-list.component.html',
  styleUrls: ['./traineesectionassign-list.component.sass']
}) 
export class TraineeSectionAssignListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  findLastCharacter;
  masterData = MasterData;
  loading = false;
  myModel = true;
  buttonText:string;
  pageTitle: string;
  destination:string;
  AttendanceForm: FormGroup;
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
  traineeList:TraineeListForExamMark[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  searchText="";

  displayedColumnsRoutine: string[] = ['ser','bnaSubjectName','date','timeDuration', 'actions'];
   dataSource: MatTableDataSource<ClassRoutine> = new MatTableDataSource();

  checked = false;
  isShown: boolean = false ;
  isShownForTraineeList:boolean=false;
  // displayedColumns: string[] = ['ser','traineePNo','attendanceStatus','bnaAttendanceRemarksId'];
  // dataSource ;
  constructor(
    private snackBar: MatSnackBar,
    private courseDutartionService: CourseDurationService, 
    private confirmService: ConfirmService,
    private traineeNominationService:TraineeNominationService,
    private fb: FormBuilder, private router: Router,  
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
   ) {
    super();
  }

  ngOnInit(): void {
    // 3136
    const id = this.route.snapshot.paramMap.get('attendanceId'); 
    this.courseDurationId=this.route.snapshot.paramMap.get('courseDurationId'); 
    
    this.pageTitle = 'Assign Course Section';
    this.destination = "Assign"; 
    this.buttonText= "Update";

    this.intitializeForm();
    this.onCourseSectionForTraineeList(this.courseDurationId);
    this.getCourseSectionByDurationId(this.courseDurationId);
  }

  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceId: [0],
      baseSchoolNameId:[''],
      courseNameId:[''],
      courseNameIds:[''],
      courseDurationId:[''],
      // courseSectionId: [trainee.courseSectionId],
      classPeriodId:[''], 
      attendanceDate:[], 
      classLeaderName:[''],
      indexNo:[''],
      attendanceStatus:[true],
      traineeListForm: this.fb.array([this.createTraineeData()]),
    })
  }

  getCourseSectionByDurationId(courseDurationId){
    this.courseDutartionService.find(courseDurationId).subscribe(res=>{
      this.courseDutartionService.getSelectedCourseSectionsBySchoolIdAndCourseId(res.baseSchoolNameId,res.courseNameId).subscribe(res=>{
        this.courseSectionList=res;

      });
    });
  }

  
  private createTraineeData() {

    return this.fb.group({

      courseNameId: [],
      status: [],
      traineePNo: [],
      courseDurationId:[],
      
      presentBillet:[],
      examCenterId:[],
      dateCreated:[],
      createdBy:[],
      traineeId: [],
      traineeName: [],
      rankPosition: [],
      saylorRank: [],
      indexNo: [],
      traineeNominationId:[],
      courseSectionId:[],
      examAttemptTypeId:[],
      examTypeId:[],
      familyAllowId:[],
      certificateSerialNo:[],
      traineeCourseStatusId:[],
      withdrawnDocId:[],
      withdrawnRemarks:[],
      withdrawnDate:[],
      newAtemptId:[],
      menuPosition:[]
    });
  }

  getControlLabel(index: number, type: string) {
    return (this.AttendanceForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
  }
  onChangeCertificateSerialNo(newCertificateSerialNo:string){
    const control = this.AttendanceForm.get('traineeListForm') as FormArray;
    for (let i = 0; i < control.length; i++) {
      if(i!=0){
        if(i>=9){
          const traineeFormGroup = control.at(i) as FormGroup;
          traineeFormGroup.get('certificateSerialNo')?.setValue(newCertificateSerialNo.slice(0, -2) + (i+1));
        }else{
          const traineeFormGroup = control.at(i) as FormGroup;
          traineeFormGroup.get('certificateSerialNo')?.setValue(newCertificateSerialNo.slice(0, -1) + (i+1));
        }
       
      }
      
    }
  }
  // onChangeourseSection(courseSectionId:number){
  //   const control = this.AttendanceForm.get('traineeListForm') as FormArray;
  //   for (let i = 0; i < control.length; i++) {
  //     const traineeFormGroup = control.at(i) as FormGroup;
  //         traineeFormGroup.get('courseSectionId').setValue(courseSectionId);
  //   }
  onChangeourseSection(courseSectionId: number, index?: number) {
    const control = this.AttendanceForm.get('traineeListForm') as FormArray;
    if (index === undefined || index === 0) {
      for (let i = 0; i < control.length; i++) {
        const traineeFormGroup = control.at(i) as FormGroup;
        traineeFormGroup.get('courseSectionId')?.setValue(courseSectionId);
      }
    } else {
      const traineeFormGroup = control.at(index) as FormGroup;
      traineeFormGroup.get('courseSectionId')?.setValue(courseSectionId);
    }
  }
  
  
  
      
  getTraineeListonClick() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData());
    }
    this.AttendanceForm.patchValue({ traineeListForm: this.traineeList });
  }

  clearList() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  onCourseSectionForTraineeList(courseDurationId){
    this.traineeNominationService.getTestTraineeNominationByCourseDurationId(courseDurationId,0).subscribe(res => {
      this.clearList()
      this.traineeList = res.filter(x=>x.withdrawnTypeId === null);

      this.getTraineeListonClick();
    
    });
  }
 

  onSubmit() {
    //  const id = this.AttendanceForm.get('traineeNominationId').value;
    this.confirmService.confirm('Confirm Save message', 'Are You Sure Update This Records?').subscribe(result => {
      if (result) {
        this.loading = true;
        this.traineeNominationService.updateTraineeNominationList(this.AttendanceForm.value).subscribe(response => {
          this.router.navigateByUrl('/course-management/schoolcourse-list');
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

