import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNAExamAttendanceService } from '../../service/bnaexamattendance.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AttendanceService } from '../../service/attendance.service';
import { TraineeList } from '../../models/traineeList';
import { MasterData } from '../../../../assets/data/master-data';
import { SelectedModel } from '../../../core/models/selectedModel';
import { ConfirmService } from '../../../core/service/confirm.service';
import { TraineeNominationService } from '../../../course-management/service/traineenomination.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';


@Component({
  selector: 'app-new-bnaexamattendance',
  templateUrl: './new-bnaexamattendance.component.html',
  styleUrls: ['./new-bnaexamattendance.component.sass']
}) 
export class NewBNAExamAttendanceComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BNAExamAttendanceForm: FormGroup;
  validationErrors: string[] = [];
   selectedbnasemesterduration:SelectedModel[];
   selectedbnasemester:SelectedModel[];
   selectedbnabatch:SelectedModel[];
   selectebnaexamschedule:SelectedModel[];
   selectedbnasubjectname:SelectedModel[];
   selectedexamtype:SelectedModel[];
   selectedCourse:SelectedModel[];
   selectedbaseschools:SelectedModel[];
   selectedClassPeriodByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
   selectedCourseDurationByParameterRequest:number;
   traineeNominationListForAttendance:TraineeList[];
   traineeForm:FormGroup;
   traineeList:FormArray;
   displayedColumns: string[] = ['ser','traineePNo','traineeName','attendanceStatus','bnaAttendanceRemarksId','actions'];
   
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private attendanceService: AttendanceService,
    private BNAExamAttendanceService: BNAExamAttendanceService,
    private traineeNominationService:TraineeNominationService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute, 
    public sharedService: SharedServiceService,
    ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bnaExamAttendanceId'); 
    if (id) {
      this.pageTitle = 'Edit BNA Exam Attendance'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.BNAExamAttendanceService.find(+id).subscribe(
        res => {
          this.BNAExamAttendanceForm.patchValue({          
            bnaExamAttendanceId:res.bnaExamAttendanceId, 
            bnaSemesterDurationId: res.bnaSemesterDurationId, 
            bnaSemesterId:res.bnaSemesterId, 
            bnaBatchId:res.bnaBatchId, 
            baseSchoolNameId:res.baseSchoolNameId,
            courseNameId:res,
            classPeriodId:res, 
            bnaExamScheduleId:res.bnaExamScheduleId, 
            bnaSubjectNameId:res.bnaSubjectNameId,
            traineeId:res.traineeId,
            examTypeId:res.examTypeId,
            examDate:res.examDate,
            isApproved:res.isApproved,
            aprovedUser:res.aprovedUser,
            approvedDate:res.approvedDate,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create BNA Exam Attendance';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
     this.getselectedbnasemesterduration();
     this.getselectedbnasemester();
     this.getselectedbnabatch();
     this.getselectebnaexamschedule();
     this.getselectedbnasubjectname();
     this.getselectedexamtype();
     this.getselectedbaseschools();
  }
  intitializeForm() {
    this.BNAExamAttendanceForm = this.fb.group({
      bnaExamAttendanceId: [0],
      bnaSemesterDurationId:[''],
      baseSchoolNameId:[''],
      courseNameId:[''],
      classPeriodId:[''], 
      examTypeId:[''], 
      examDate:[''],
      traineeList: this.fb.array([this.createTraineeList(null)]),
         
    })
  }
  

  createTraineeList(traineeInfo): FormGroup {
    if(traineeInfo){
      
       this.traineeForm.patchValue(traineeInfo)
      
    }
    else{
      this.traineeForm = this.fb.group({
        attendanceStatus: [''],
        bnaAttendanceRemarksId: [''],
        courseDuration: [''],
        courseDurationId: [''],
        courseName: [''],
        courseNameId: [''],
        familyAllowId: [''],
        indexNo: [''],
        isActive: [''],
        menuPosition: [''],
        rankName: [''],
        status: [''],
        traineeCourseStatus: [''],
        traineeCourseStatusId: [''],
        traineeId: [''],
        traineeName: [''],
        traineeNominationId: [''],
        traineePNo: [''],
        withdrawnDate: [''],
        withdrawnDoc: [''],
        withdrawnDocId: [''],
        withdrawnRemarks: ['']
      });
    }
 
    return this.traineeForm;
}

  onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId){
    this.attendanceService.getCourseByBaseSchoolNameId(baseSchoolNameId).subscribe(res=>{
      this.selectedCourse=res
    });
   }

   getselectedbaseschools(){
    this.attendanceService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschools=res
    }); 
  } 

  onCourseNameSelectionChangeGetClassPeriod(){
    var baseSchoolNameId=this.BNAExamAttendanceForm.value['baseSchoolNameId'];
    var courseNameId=this.BNAExamAttendanceForm.value['courseNameId'];
     if(baseSchoolNameId != null && courseNameId != null){
      
     }  
   }

   onClassPeriodSelectionChangeGetCourseDuration(){
    var baseSchoolNameId=this.BNAExamAttendanceForm.value['baseSchoolNameId'];
      var courseNameId=this.BNAExamAttendanceForm.value['courseNameId']; 
      var classPeriodId=this.BNAExamAttendanceForm.value['classPeriodId']; 
       if(baseSchoolNameId != null && courseNameId != null && classPeriodId !=null){
        this.attendanceService.getSelectedCourseDurationByParameterRequestFromClassRoutine(baseSchoolNameId,courseNameId,classPeriodId).subscribe(res=>{
          this.selectedCourseDurationByParameterRequest=res;   
         this.traineeNominationService.getTraineeNominationByCourseDurationId(this.selectedCourseDurationByParameterRequest,0).subscribe(res=>{
          this.traineeNominationListForAttendance=res;  
           this.BNAExamAttendanceForm.get('traineeList')?.setValue(res); 
         });
        });
      }  
   }
 
  getselectedbnasemesterduration(){
    this.BNAExamAttendanceService.getselectedbnasemesterduration().subscribe(res=>{
      this.selectedbnasemesterduration=res
    });
  } 

  getselectedbnasemester(){
    this.BNAExamAttendanceService.getselectedbnasemester().subscribe(res=>{
      this.selectedbnasemester=res
    });
  } 

  getselectedbnabatch(){
    this.BNAExamAttendanceService.getselectedbnabatch().subscribe(res=>{
      this.selectedbnabatch=res
    });
  }

  getselectebnaexamschedule(){
    this.BNAExamAttendanceService.getselectebnaexamschedule().subscribe(res=>{
      this.selectebnaexamschedule=res
    });
  }
  getselectedbnasubjectname(){
    this.BNAExamAttendanceService.getselectedbnasubjectname().subscribe(res=>{
      this.selectedbnasubjectname=res
    });
  }

  getselectedexamtype(){
    this.BNAExamAttendanceService.getselectedexamtype().subscribe(res=>{
      this.selectedexamtype=res
    });
  }

  onSubmit() {
    const id = this.BNAExamAttendanceForm.get('bnaExamAttendanceId')?.value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BNAExamAttendanceService.update(+id,this.BNAExamAttendanceForm.value).subscribe(response => {
            this.router.navigateByUrl('/attendance-management/bnaexamattendance-list');
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
    }else {
      this.loading = true;
      this.BNAExamAttendanceService.submit(this.BNAExamAttendanceForm.value).subscribe(response => {
        this.router.navigateByUrl('/attendance-management/bnaexamattendance-list');
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
 
  }
}
