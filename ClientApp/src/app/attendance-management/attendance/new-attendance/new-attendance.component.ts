import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators,FormControl,FormGroupDirective,NgForm} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AttendanceService } from '../../service/attendance.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { TraineeNominationService } from 'src/app/course-management/service/traineenomination.service';
import { BNASubjectNameService } from 'src/app/subject-management/service/BNASubjectName.service';
import { TraineeNomination } from 'src/app/course-management/models/traineenomination';
import { SelectionModel } from '@angular/cdk/collections';
import { Attendance } from '../../models/attendance';
import { CheckboxSelectedModel } from 'src/app/core/models/checkboxSelectedModel';
import { TraineeList } from '../../models/traineeList';
import { DatePipe } from '@angular/common';
import { ClassRoutineService } from 'src/app/routine-management/service/classroutine.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-attendance',
  templateUrl: './new-attendance.component.html',
  styleUrls: ['./new-attendance.component.sass']
}) 
export class NewAttendanceComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  myModel = true;
  userRole = Role;
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
  selectCourse:SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
  selectPeriod:SelectedModel[]
  selectedCourseDurationByParameterRequest:number;
  traineeNominationListForAttendance: TraineeList[];
  selectedvalues:CheckboxSelectedModel[];
  traineeForm: FormGroup;
  subjectNamefromClassRoutine:any;
  selectedCourseSection:SelectedModel[];
  subjectName:string;
  bnaSubjectNameId:number;
  classRoutineId:number;
  courseDurationId:any;
  selectedMarkType:any;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  traineeNominationListForAttendanceNew:any;
  traineeNominationListForAttendanceFilter:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  checked = false;
  isShown: boolean = false ;
  isShowSubjectName:boolean=false;
  isShownForTraineeList:boolean=false;
  displayedColumns: string[] = ['ser','traineePNo','attendanceStatus','bnaAttendanceRemarksId'];
  dataSource ;
  constructor(
    private snackBar: MatSnackBar, 
    private authService: AuthService,
    private subjectNameService: BNASubjectNameService,
    private classRoutineService:ClassRoutineService,
    private datepipe:DatePipe, 
    private confirmService: ConfirmService,
    private traineeNominationService:TraineeNominationService,
    private CodeValueService: CodeValueService,
    private AttendanceService: AttendanceService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute,
    public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('attendanceId'); 
    if (id) {
      this.pageTitle = 'Edit Attendance'; 
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
            courseSectionId:res.courseSectionId,
            bnaAttendanceRemarksId:res.bnaAttendanceRemarksId,
            attendanceDate:res.attendanceDate,
            classLeaderName:res.classLeaderName,
            attendanceStatus:res.attendanceStatus,
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
      this.pageTitle = 'Create Attendance';
      this.destination = "Add"; 
      this.buttonText= "Save";
    } 
     this.intitializeForm();
     if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.AttendanceForm.get('baseSchoolNameId').setValue(this.branchId);
      this.onBaseSchoolNameSelectionChangeGetCourse(this.branchId);
     }
     this.getselectedclassroutine();
     this.getselectedbaseschools();
     this.getselectedcoursename();
     this.getselectedbnasubjectname();
     this.getselectedclassperiod();
     this.getselectedbnaattendanceremark();
  }
  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceId: [0],
      baseSchoolNameId:[''],
      courseNameId:[''],
      courseDurationId:[''],
      classPeriodId:[''],
      classPeriod:[''], 
      courseSectionId:[''], 
      attendanceDate:[], 
      classLeaderName:[''],
      attendanceStatus:[true],
      absentForExamStatus:[false],
     traineeList: this.fb.array([this.createTraineeData()]),
    })
  }
  onOptionsSelected(index,value) {
    this.traineeNominationListForAttendance[index]["bnaAttendanceRemarksId"] = value;
 }
  onCheckboxChange(index,event) {
    this.traineeNominationListForAttendance[index]["attendanceStatus"] = event.checked;
    this.traineeNominationListForAttendance[index]["absentForExamStatus"] = !event.checked;
  }
  private createTraineeData() {
    return this.fb.group({
      bnaAttendanceRemarksId: [''],
      courseDurationId: [''],
      traineeId: [''],

    });
  }
  onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId){
      this.AttendanceService.getCourseByBaseSchoolNameId(baseSchoolNameId).subscribe(res=>{
        this.selectedCourse=res
        this.selectCourse=res
      });
     }
      get f() { return this.AttendanceForm.controls; }
      get t() { return this.f.traineeLists as FormArray; }

     onClassPeriodSelectionChangeGetCourseDuration(){  
      this.isShown=true
      this.isShowSubjectName=true;
      var baseSchoolNameId=this.AttendanceForm.value['baseSchoolNameId'];
      var courseNameId=this.AttendanceForm.value['courseNameId']; 
      var classPeriod=this.AttendanceForm.value['classPeriod']; 
      var date=this.AttendanceForm.value['attendanceDate']; 

      var courseNameArr = courseNameId.split('_');
      this.courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];

      var classPeriodArr = classPeriod.split('_');
      this.classRoutineId = classPeriodArr[0];
      var classPeriodId = classPeriodArr[1];
      var courseSectionId=classPeriodArr[2];
      this.bnaSubjectNameId=classPeriodArr[3];

      this.AttendanceForm.get('classPeriodId').setValue(classPeriodId);
      this.AttendanceForm.get('courseSectionId').setValue(courseSectionId);

      this.classRoutineService.getselectedCourseSection(baseSchoolNameId,courseNameId).subscribe(res=>{
        
        this.selectedCourseSection=res;
        
      });
      

      this.subjectNameService.find(this.bnaSubjectNameId).subscribe(res=>{
        this.subjectNamefromClassRoutine = res.subjectName;
      })

      this.classRoutineService.getSelectedMarkTypeByRoutineId(this.classRoutineId).subscribe(res=>{
        
         this.selectedMarkType=res[0]?.text;
        
      });

      

      // var  formatedDate=this.datepipe.transform((date), 'MM/dd/yyyy');
      // this.classRoutineService.getSubjectNameFromRoutineForLocal(baseSchoolNameId,courseNameId,formatedDate,classPeriodId,this.courseDurationId,courseSectionId).subscribe(res=>{
      //   this.subjectNamefromClassRoutine=res[0].text;
      //   this.bnaSubjectNameId=res[0].value;
      //         // for (let i =0; i < this.subjectNamefromClassRoutine.length; i++) {
      //         //       this.bnaSubjectNameId= this.subjectNamefromClassRoutine[i].value
      //         //      }  
      // })

      // this.classRoutineService.getSelectedRoutineIdFilter(baseSchoolNameId,courseNameId,classPeriodId,this.courseDurationId,formatedDate,courseSectionId).subscribe(res=>{
      //   this.classRoutineId=res;
      // })

       if(baseSchoolNameId != null && courseNameId != null && this.courseDurationId !=null && classPeriodId !=null){
        this.traineeNominationService.getTraineeNominationByCourseDurationId(this.courseDurationId,courseSectionId).subscribe(res=>{
         
          this.traineeNominationListForAttendance=res.filter(x=>x.withdrawnTypeId === null);
        
          if(this.traineeNominationListForAttendance.length){
            for(let i=0;i<=this.traineeNominationListForAttendance.length;i++)
              {
                this.traineeNominationListForAttendance[i].attendanceStatus=true;
                this.traineeNominationListForAttendance[i].absentForExamStatus=false;
              }
          }
         
         });
      } 
     
     }

     onDateSelectionChange(event){
      var date=this.datepipe.transform((event.value), 'MM/dd/yyyy');
           var baseSchoolNameId=this.AttendanceForm.value['baseSchoolNameId'];
           var courseNameId=this.AttendanceForm.value['courseNameId'];

           var courseNameArr = courseNameId.split('_');
           var courseDurationId = courseNameArr[0];
           var courseNameId=courseNameArr[1];

            if(baseSchoolNameId != null && courseNameId != null  && courseDurationId !=null){
              this.AttendanceService.getSelectedClassPeriodByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId,courseDurationId,date).subscribe(res=>{
                this.selectedClassPeriodByBaseSchoolNameIdAndCourseNameId=res;     
              });
            }  
     }
     filterByPeriod(value:any){
    
      this.selectedClassPeriodByBaseSchoolNameIdAndCourseNameId=this.selectPeriod.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
     
     }

     filterByCourse(value:any){     
        this.selectedCourse=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
     }

  getselectedclassroutine(){
    this.AttendanceService.getselectedclassroutine().subscribe(res=>{
      this.selectedclassroutine=res
    });
  } 

  getselectedbaseschools(){
    this.AttendanceService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschools=res
    });
  } 

  getselectedcoursename(){
    this.AttendanceService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res
    });
  }

  getselectedbnasubjectname(){
    this.AttendanceService.getselectedbnasubjectname().subscribe(res=>{
      this.selectedbnasubjectname=res
    });
  }
  getselectedclassperiod(){
    this.AttendanceService.getselectedclassperiod().subscribe(res=>{
      this.selectedclassperiod=res
    });
  }

  getselectedbnaattendanceremark(){
    this.AttendanceService.getselectedbnaattendanceremark().subscribe(res=>{
      this.selectedbnaattendanceremark=res
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This  Item').subscribe(result => {
      if (result) {
        const id = this.AttendanceForm.get('attendanceId').value;
        this.isShowSubjectName=false;
        var classLeaderName= this.AttendanceForm.value['classLeaderName'];
        var attendanceDate= this.AttendanceForm.value['attendanceDate'];
        var baseSchoolNameId=this.AttendanceForm.value['baseSchoolNameId'];
        var classPeriodId = this.AttendanceForm.value['classPeriodId'];
     
         for (let i = 0; i < this.traineeNominationListForAttendance.length; i++) {
          this.traineeNominationListForAttendance[i]["classLeaderName"] = classLeaderName;
          this.traineeNominationListForAttendance[i]["attendanceDate"] = this.datepipe.transform((new Date), 'MM/dd/yyyy');
          this.traineeNominationListForAttendance[i]["bnaSubjectNameId"] = this.bnaSubjectNameId; 
          this.traineeNominationListForAttendance[i]["baseSchoolNameId"] = baseSchoolNameId;
          this.traineeNominationListForAttendance[i]["classPeriodId"] = classPeriodId;
          this.traineeNominationListForAttendance[i]["classRoutineId"] = this.classRoutineId;
        }
        
          this.loading=true;
          this.AttendanceService.submit(JSON.stringify(this.traineeNominationListForAttendance) ).subscribe(response => {
            this.reloadCurrentRoute();
            this.isShown=false;
    
            this.snackBar.open('Information Inserted Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          });
      }
    })
  }
}
