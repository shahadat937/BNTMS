import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NoticeService } from '../../service/notice.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ClassRoutineService } from '../../../../../src/app/routine-management/service/classroutine.service';
import { TraineeNominationService } from '../../../../../src/app/central-exam/service/traineenomination.service';
import { Notice } from '../../models/notice';
import { TraineeList } from '../../../../../src/app/attendance-management/models/traineeList';
import {IndividualNoticeService} from '../../../notice-bulletin/service/individualnotice.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../src/app/core/models/role';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-new-individualnotice',
  templateUrl: './new-individualnotice.component.html',
  styleUrls: ['./new-individualnotice.component.sass']
}) 
export class IndividualNoticeComponent implements OnInit, OnDestroy {
  masterData = MasterData;
  loading = false;
  userRole = Role;
  buttonText:string;
  pageTitle: string;
  destination:string;
  NoticeForm: FormGroup;
  validationErrors: string[] = [];
  selectedCourse:SelectedModel[];
  filteredCourse: SelectedModel[];
  selectedbaseschools:SelectedModel[];
  filteredbaseschools: SelectedModel[];
  selectedNotice:Notice[];
  isShown: boolean = false ;
  traineeNominationListForNotice:TraineeList[];
  courseName:any;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser','courseName','noticeDetails','status'];
  displayedColumnsForTraineeList: string[] = ['sl','traineePNo','traineeName', 'obtaintMark','examMarkRemarksId'];
  subscription: any;
  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private individualNoticeService: IndividualNoticeService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute, 
    private classRoutineService: ClassRoutineService,
    private traineeNominationService:TraineeNominationService,
    private authService: AuthService,
    private cdr: ChangeDetectorRef,
    public sharedService: SharedServiceService
    ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('noticeId'); 
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    if (id) {
      this.pageTitle = 'Edit Notice'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.subscription = this.individualNoticeService.find(+id).subscribe(
        res => {
          this.NoticeForm.patchValue({             
            noticeId: res.noticeId,
            courseDurationId: res.courseDurationId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId: res.courseNameId,
            traineeNominationId: res.traineeNominationId,
            courseInstructorId: res.courseInstructorId,
            status: res.status,
            noticeDetails: res.noticeDetails,
            endDate:res.endDate,
            menuPosition: res.menuPosition,
            isActive: res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Individual Notice';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.NoticeForm.get('baseSchoolNameId')?.setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
     }
    this.getselectedbaseschools();
    //this.getselectedcoursedurationbyschoolname();
   // this.getNoticeBySchool();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.NoticeForm = this.fb.group({
      noticeId: [0],
      courseDurationId: [],
      baseSchoolNameId: [],
      courseNameId: [''],
      courseNameIds: [''],
      courseName:[''],
      traineeNominationId: [],
      courseInstructorId: [],
      status: [0],
      noticeDetails: [''],
      endDate:[],
      menuPosition: [],
      isActive: [true],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
    })
  }
  
  getControlLabel(index: number,type: string){
    return  (this.NoticeForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
   }
  private createTraineeData() {
 
    return this.fb.group({
      courseNameId: [],
      status: [],
     traineePNo:[],
      traineeId: [],
     traineeName:[],
     rankPosition:[],
     isNotify:[''],
    //   noticeDetails: [],
    //  examMarkRemarksId:[]
    });
  }

  getTraineeListonClick(){ 
    const control = <FormArray>this.NoticeForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeNominationListForNotice.length; i++) {
      control.push(this.createTraineeData()); 
    }
    this.NoticeForm.patchValue({ traineeListForm: this.traineeNominationListForNotice });
   }
  
   clearList() {
    const control = <FormArray>this.NoticeForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  // onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId){
  //     this.classRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
  //     this.selectedCourse=res;
  //   });
  // var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
  // var courseNameArr = dropdown.value.split('_');
  // var courseDurationId = courseNameArr[0];
  // var courseNameId=courseNameArr[1];
  // this.courseName=dropdown.text;
  // this.ClassRoutineForm.get('courseName').setValue(dropdown.text);
  // this.ClassRoutineForm.get('courseNameId').setValue(courseNameId);
  // this.ClassRoutineForm.get('courseDurationId').setValue(courseDurationId);
  // }

  getSelectedCourseName(dropdown){
 
  this.NoticeForm.value['courseNameIds'];
  var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];
  var courseNameArr = dropdown.value.split('_');
  var courseDurationId = courseNameArr[0];
  var courseNameId=courseNameArr[1];
  this.courseName=dropdown.text;

  this.subscription = this.traineeNominationService.getTraineeNominationByCourseDurationId(courseDurationId).subscribe(res=>{
    this.traineeNominationListForNotice=res; 

    for(let i=0;i < this.traineeNominationListForNotice.length;i++ ){
      this.traineeNominationListForNotice[i].isNotify=true;
    }
    
    this.isShown=true;
    this.clearList()
    this.getTraineeListonClick();
   });



  //this.NoticeForm.get('courseName').setValue(dropdown.text);
  this.NoticeForm.get('courseNameId')?.setValue(courseNameId);
  this.NoticeForm.get('courseDurationId')?.setValue(courseDurationId);
  }

  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];
   // this.isShown=true;
   this.subscription = this.classRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedCourse=res;
      this.filteredCourse = res;   
    });
//     this.individualNoticeService.getNoticeBySchool(baseSchoolNameId).subscribe(res=>{
//       this.selectedNotice=res
//     }); 
}


stopNotices(element){
  this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
        this.subscription = this.individualNoticeService.stopNotices(element.noticeId).subscribe(() => {
      var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];

      this.subscription = this.individualNoticeService.getNoticeBySchool(baseSchoolNameId).subscribe(res=>{
        this.selectedNotice=res
      }); 

     // this.getCourseplanCreates();
      this.snackBar.open('Information Stop Successfully ', '', {
        duration: 3000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-warning'
      });
    })
  }
})
}
// stopNotices(id: number) {
//   this.individualNoticeService.st
// }
  // this.individualNoticeService.stopNotices(id).subscribe(res=>{
  //   this.Notices=res
  // }); 


// inActiveItem(){

//   if(row.isActive == true){
//     this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Deactive This Item').subscribe(result => {
//       if (result) {
//     this.CourseplanCreateService.deactiveCoursePlan(id).subscribe(() => {
//       this.getCourseplanCreates();
//       this.snackBar.open('Information Deactive Successfully ', '', {
//         duration: 3000,
//         verticalPosition: 'bottom',
//         horizontalPosition: 'right',
//         panelClass: 'snackbar-warning'
//       });
//     })
//   }
// })
// }
//   this.individualNoticeService.stopNotices(id).subscribe(() => {
//     //this.getCourseplanCreates();
//     this.snackBar.open('Information Deactive Successfully ', '', {
//       duration: 3000,
//       verticalPosition: 'bottom',
//       horizontalPosition: 'right',
//       panelClass: 'snackbar-warning'
//     });
//   })
// }
ngAfterViewInit() {
  this.cdr.detectChanges();
}


  getselectedbaseschools(){
    this.subscription = this.individualNoticeService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschools=res
      this.filteredbaseschools = res;
    }); 
  } 

  filterBaseSchools(value:string) {
    this.filteredbaseschools = this.selectedbaseschools.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }

  filterCourse(value:string) {
    if(this.selectedCourse==undefined||this.selectedCourse.length<=0) {
      return;
    }
    this.filteredCourse = this.selectedCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }

  // onSubmit() {
  //   const id = this.NoticeForm.get('noticeId').value;
   
  //   this.NoticeForm.value.filter(x=>x.isNotify==true)
  //  this.NoticeForm.value.filter((x:any)=>{ return x.isNotify})

  //   if (id) {
  //     this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
  //       if (result) {
  //         this.loading = true;
  //         this.subscription = this.individualNoticeService.update(+id,this.NoticeForm.value).subscribe(response => {
  //           // this.router.navigateByUrl('/notice-bulletin/notice-list');
  //           this.reloadCurrentRoute();
  //           this.snackBar.open('Information Updated Successfully ', '', {
  //             duration: 2000,
  //             verticalPosition: 'bottom',
  //             horizontalPosition: 'right',
  //             panelClass: 'snackbar-success'
  //           });
  //         }, error => {
  //           this.validationErrors = error;
  //         })
  //       }
  //     })
  //   }else {
  //     this.loading = true;
  //     this.subscription = this.individualNoticeService.submit(this.NoticeForm.value).subscribe(response => {
  //       // this.router.navigateByUrl('/notice-bulletin/notice-list');
  //       this.reloadCurrentRoute();
  //       this.snackBar.open('Information Inserted Successfully ', '', {
  //         duration: 2000,
  //         verticalPosition: 'bottom',
  //         horizontalPosition: 'right',
  //         panelClass: 'snackbar-success'
  //       });
  //     }, error => {
  //       this.validationErrors = error;
  //     })
  //   }
 
  // }
  onSubmit() {
    const id = this.NoticeForm.get('noticeId')?.value;
   
  
 
    const notices = this.NoticeForm.get('notices')?.value; 
    const filteredNotices = Array.isArray(notices) 
      ? notices.filter((x: any) => x.isNotify === true)
      : [];
  
  
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item')
        .subscribe(result => {
          if (result) {
            this.loading = true;
            this.subscription = this.individualNoticeService.update(+id, this.NoticeForm.value).subscribe(response => {
              this.reloadCurrentRoute();
              this.snackBar.open('Information Updated Successfully ', '', {
                duration: 2000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
            }, error => {
              this.validationErrors = error;
            });
          }
        });
    } else {
      this.loading = true;
      this.subscription = this.individualNoticeService.submit(this.NoticeForm.value).subscribe(response => {
        this.reloadCurrentRoute();
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
  }
  
}
