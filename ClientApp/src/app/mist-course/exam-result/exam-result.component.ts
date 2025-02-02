import { TraineeListForMIST } from './../../attendance-management/models/trainee-list-for-mist';
import { Component, OnInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, Validators,FormArray } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseTermService } from '../../basic-setup/service/course-term.service';
import { ExamResultService } from '../service/exam-result.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CourseLevelService } from '../../basic-setup/service/course-level.service';
import { BaseSchoolNameService } from '../../basic-setup/service/BaseSchoolName.service';
import{MasterData} from 'src/assets/data/master-data';
import { ExamResult } from '../models/exam-result';
import { CourseDurationService } from '../service/courseduration.service';
import {TraineeNominationService} from '../service/traineenomination.service'
import { TraineeNomination } from '../models/traineenomination';
import { AuthService } from 'src/app/core/service/auth.service';

import { Role } from 'src/app/core/models/role';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';



@Component({
  selector: 'app-exam-result',
  templateUrl: './exam-result.component.html',
  styleUrls: ['./exam-result.component.sass']
})
export class ExamResultComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  pageTitle: string;
  loading = false;
  destination:string;
  btnText:string;
  ExamResultForm: FormGroup;
  validationErrors: string[] = [];
  traineeList:any=[];
  selectedSchool:SelectedModel[];
  SelectedCourseLevel:SelectedModel[];
  SelectedCourseTerm:SelectedModel[];
  selectedCourseduration:SelectedModel[];
  TraineeNominations: TraineeNomination[] = [];
  traineeNominationListForMIST:TraineeNomination[];
  isShown: boolean = false ;
  userRole = Role;

  role:any;

  masterData = MasterData;
  isLoading = false;
   branchId:any ;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'courseTermTitle', 'isActive', 'actions'];
  dataSource: MatTableDataSource<ExamResult> = new MatTableDataSource();
  subscription: any;


  constructor(
    private authService: AuthService,
      private TraineeNominationService:TraineeNominationService, 
      private examResultService : ExamResultService,
      private baseSchoolNameService: BaseSchoolNameService ,
      private CourseLevelService: CourseLevelService,
      private snackBar: MatSnackBar,
      private confirmService: ConfirmService,
      private CourseTermService: CourseTermService,
      private fb: FormBuilder, private router: Router, 
      private route: ActivatedRoute,
      public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
   
      this.pageTitle = 'Create Course Result ';
      this.destination = "Add";
      this.btnText = 'Save';
      this.branchId =  this.authService.currentUserValue.branchId.trim();
      this.role = this.authService.currentUserValue.role.trim();
    this.intitializeForm();

    
    this.getSelectedbaseSchoolName();
    this.getSelectedCourseLevel();

   // this.getSelectedCourseTermByLevel(id);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.ExamResultForm = this.fb.group({
      courseTermId: [0],
      courseTermTitle: ['', Validators.required],
      courseLevelId: ['', Validators.required],
      baseSchoolNameId : ['', Validators.required],
      courseDurationId : ['', Validators.required], 
      courseName: [''],
      totalCredit: [],
      achievedTotalCredit: [],
      achievedGPA :[],
      remark:[''],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      //menuPosition: ['', Validators.required],
      isActive: [true]
    }) 
    this.ExamResultForm.get('baseSchoolNameId').setValue(this.branchId);
    this.getSelectedCourseduration(this.branchId);
  }
  
  private createTraineeData() {
 
    return this.fb.group({
    //   courseNameId: [],
    //   status: [],
    //  traineePNo:[],
    //   traineeId: [],
    //  traineeName:[],
    //  rankPosition:[],
    //  isNotify:[''],
    //   noticeDetails: [],
    //  examMarkRemarksId:[]
    
    baseSchoolNameId: [],
    completeClass: [],
    course:[],
    courseDurationId:[],
    courseTitle:[],
    courseNomeneeId:[],
    name:[],
    percentage:[],
    pno:[],
    position:[],
    totalClass:[],
    traineeAttendance:[],
    traineeId:[],
    traineeNominationId:[],
    achievedTotalCredit:[],
    totalCredit:[],
    achievedGPA:[],
    remark:[],
    courseTermId:[], 
    courseLevelId: [],
    });
  }
  getSelectedCourseduration(id){
    this.subscription = this.examResultService.GetCourseDuration(id).subscribe(res=>{
      this.selectedCourseduration=res
    });
   }
 


   
  onBaseNameSelectionChangeGetModule(dropdown) {

    if (dropdown.isUserInput) {


      var baseSchoolNameId = this.ExamResultForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.source.value.value.split('_');
      var courseDurationId = courseNameArr[0]; 
      var courseNameId = courseNameArr[1];
      this.subscription = this.TraineeNominationService.findByCourseDurationForMIST(+courseDurationId).subscribe(response => {
      this.traineeNominationListForMIST=response;
      this.isShown=true;
      this.clearList()
      this.getTraineeListonClick()
       });

      //this.CourseInstructorForm.get('courseName').setValue(dropdown.text);
    //</FormArray></FormArray> this.ExamResultForm.get('courseNameId').setValue(courseNameId);
    //  this.ExamResultForm.get('courseDurationId').setValue(courseDurationId);
 

       
    }
  }


  getTraineeListonClick(){ 
    const control = <FormArray>this.ExamResultForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeNominationListForMIST.length; i++) {
      control.push(this.createTraineeData()); 
    }
    this.ExamResultForm.patchValue({ traineeListForm: this.traineeNominationListForMIST });
   }
   getControlLabel(index: number,type: string){
    return  (this.ExamResultForm.get('traineeListForm') as FormArray).at(index).get(type).value;
   }
   clearList() {
    const control = <FormArray>this.ExamResultForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  getSelectedCourseTermByLevel (CourseLevelId){
    this.subscription = this.CourseTermService.getselectedCourseTermByCourseLevel(CourseLevelId).subscribe(res=>{
      this.SelectedCourseTerm=res
    });
   }
 
  
  deleteItem(row) {
    const id = row.courseTermId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.examResultService.delete(id).subscribe(() => { 
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })    
  }


  getSelectedbaseSchoolName(){
    this.subscription = this.baseSchoolNameService.getselectedSchools().subscribe(res=>{
      this.selectedSchool=res
    });
   }



   getSelectedCourseLevel(){
    this.subscription = this.CourseLevelService.getselectedCourseLevel().subscribe(res=>{
      this.SelectedCourseLevel=res
    });
   }


reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  
  onSubmit() {
    const id = this.ExamResultForm.get('courseTermId').value;   

   /* if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.examResultService.update(+id,this.ExamResultForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-courseTerm');
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

 else {*/
  this.loading=true;

//</FormArray></FormArray>this.ExamResultForm.traineeListForm.get('courseTermId').setValue(id);
 
this.subscription = this.examResultService.submit(this.ExamResultForm.value).subscribe(response => {
        //this.router.navigateByUrl('/basic-setup/add-courseTerm');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 20000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    
 
  }

}