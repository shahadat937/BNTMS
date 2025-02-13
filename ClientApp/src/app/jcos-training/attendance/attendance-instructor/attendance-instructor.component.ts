import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators,FormControl,FormGroupDirective,NgForm} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AttendanceService } from '../../service/attendance.service';
import { SelectedModel } from '../../../core/models/selectedModel';
import {CodeValueService} from '../../../basic-setup/service/codevalue.service'
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import {ConfirmService} from '../../../../../src/app/core/service/confirm.service'
import { TraineeNominationService } from '../../../../../src/app/course-management/service/traineenomination.service';
import { CheckboxSelectedModel } from '../../../../../src/app/core/models/checkboxSelectedModel';
import { TraineeList } from '../../models/traineeList';
import { DatePipe } from '@angular/common';
import { ClassRoutineService } from '../../../../../src/app/routine-management/service/classroutine.service';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-attendance-instructor',
  templateUrl: './attendance-instructor.component.html',
  styleUrls: ['./attendance-instructor.component.sass']
})
export class AttendanceInstructorComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  AttendanceForm: FormGroup;
  validationErrors: string[] = [];
  selectedclassroutine:SelectedModel[];
  selectedbaseschools:SelectedModel[];
  selectedcoursename:SelectedModel[];
  selectedbnasubjectname:SelectedModel[];
  selectedclassperiod:any[];
  selectedbnaattendanceremark:SelectedModel[];
  selectedCourse:SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
  selectedCourseDurationByParameterRequest:number;
  traineeNominationListForAttendance: TraineeList[];
  selectedvalues:CheckboxSelectedModel[];
  traineeForm: FormGroup;
  subjectNamefromClassRoutine:SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameIdforAttendanceApprove:SelectedModel[];
  subjectName:string;
  bnaSubjectNameId:number;
  traineeId:any;
  classRoutineId:number;
  traineeList:TraineeList[]
  isShown: boolean = false ;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedColumns: string[] = ['ser','traineePNo','attendanceStatus','bnaAttendanceRemarksId'];
  dataSource ;
  constructor(private snackBar: MatSnackBar,private classRoutineService:ClassRoutineService,private datepipe:DatePipe, private confirmService: ConfirmService,private traineeNominationService:TraineeNominationService,private CodeValueService: CodeValueService,private AttendanceService: AttendanceService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    const id = this.route.snapshot.paramMap.get('attendanceId'); 
    if (id) {
      this.pageTitle = 'Edit Attendance Instructor'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.AttendanceService.find(+id).subscribe(
        res => {
          this.AttendanceForm.patchValue({          
            attendanceId:res.attendanceId, 
            classRoutineId: res.classRoutineId, 
            baseSchoolNameId:res.baseSchoolNameId, 
            courseNameId:res.courseNameId, 
            bnaSubjectNameId:res.bnaSubjectNameId, 
            classPeriodId:res.classPeriodId,
            attendanceDate:res.attendanceDate,
            classLeaderName:res.classLeaderName,
            isApproved:res.isApproved,
            approvedUser:res.approvedUser,
            approvedDate:res.approvedDate,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Attendance Instructor';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
     this.getselectedclassperiod(this.traineeId);
    this.getselectedbnaattendanceremark();
  }
  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceId: [0],
      baseSchoolNameId:[''],
      courseDurationId:[''],
      classPeriodIds:[''], 
      bnaSubjectNameId:[''],
      classRoutineId:[''],
      courseNameId:[''],
      attendanceDate:[], 
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
    })
  }

  getControlLabel(index: number,type: string){
    return  (this.AttendanceForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
   }

   private createTraineeData() {
  
    return this.fb.group({
     attendanceId: [],
      baseSchoolNameId:[''],
      courseNameId:[''],
      classPeriodId:[''], 
    //  bnaSubjectNameId:[''],
      classRoutineId:[''],
      courseDurationId:[''],
      attendanceDate:[],
      attendanceStatus: [''],
      bnaAttendanceRemarksId: [''], 
      traineeId: [''],
      traineePNo:[''],
      traineeName:[''],
      classLeaderName:[''],
      rankPosition:[''],
      dateCreated:[],
      createdBy:[],
    });
  }
  clearList() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }
  getTraineeListonClick(){
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    
  
    for (let i = 0; i < this.traineeNominationListForAttendance.length; i++) {
      control.push(this.createTraineeData()); 
    }
    this.AttendanceForm.patchValue({ traineeListForm: this.traineeNominationListForAttendance });
   }

     getselectedclassperiod(traineeId){
      this.AttendanceService.getSelectedClassPeriodForAttendanceInstructorBySpRequest(traineeId).subscribe(res=>{
      this.selectedclassperiod=res
    });
  }

     onClassPeriodSelectionChangeGetCourseDuration(dropdown){ 

      if(dropdown.isUserInput) {   
        var courseDurationId=dropdown.source.value.courseDurationId;
        var classPeriodId=dropdown.source.value.classPeriodId
        var classRoutineId=dropdown.source.value.classRoutineId;
        var baseSchoolNameId=dropdown.source.value.baseSchoolNameId;
        var courseNameId=dropdown.source.value.courseNameId;
        var bnaSubjectNameId=dropdown.source.value.bnaSubjectNameId;
 
        //set value to form
        this.AttendanceForm.get('courseDurationId')?.setValue(courseDurationId);
        this.AttendanceForm.get('classPeriodIds')?.setValue(classPeriodId);
        this.AttendanceForm.get('classRoutineId')?.setValue(classRoutineId);
        this.AttendanceForm.get('courseNameId')?.setValue(courseNameId);
        this.AttendanceForm.get('baseSchoolNameId')?.setValue(baseSchoolNameId);
        this.AttendanceForm.get('bnaSubjectNameId')?.setValue(bnaSubjectNameId);


        this.isShown=true;
        this.clearList();

        this.traineeNominationService.getTraineeNominationByCourseDurationId(courseDurationId).subscribe(res=>{
          this.traineeNominationListForAttendance=res; 
          this.getTraineeListonClick();
         });


     }
    }
    


  getselectedbnaattendanceremark(){
    this.AttendanceService.getselectedbnaattendanceremark().subscribe(res=>{
      this.selectedbnaattendanceremark=res
    });
  }

  onSubmit() {
    const id = this.AttendanceForm.get('attendanceId')?.value;
    
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
      
        if (result) {
          this.AttendanceService.updateAttendanceList(JSON.stringify(this.AttendanceForm.value)).subscribe(response => {
            this.router.navigateByUrl('/attendance-management/add-attendance');
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
    else {
      this.AttendanceService.submitAttendance(this.AttendanceForm.value).subscribe(response => {
        

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
