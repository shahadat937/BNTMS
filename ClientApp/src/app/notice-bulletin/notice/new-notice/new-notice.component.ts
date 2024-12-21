import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NoticeService } from '../../service/notice.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ClassRoutineService } from 'src/app/routine-management/service/classroutine.service';
import { Notice } from '../../models/notice';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { MatOption } from '@angular/material/core';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-new-notice',
  templateUrl: './new-notice.component.html',
  styleUrls: ['./new-notice.component.sass']
}) 
export class NewNoticeComponent implements OnInit, OnDestroy {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
  @ViewChild('allSelected') private allSelected: MatOption;
  @ViewChild('allSelectedCourse') private allSelectedCourse: MatOption;
  isShowCourseName:boolean=false;
  masterData = MasterData;
  loading = false;
  buttonText:string;
  userRole = Role;
  pageTitle: string;
  destination:string;
  NoticeForm: FormGroup;
  validationErrors: string[] = [];
  selectedCourse:SelectedModel[];
  selectCourse:SelectedModel[];
  selectedbaseschools:SelectedModel[];
  selectedNotice:Notice[];
  isShown: boolean = false ;
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

  displayedColumns: string[] = ['ser','noticeHeading','noticeDetails','courseName','status','actions'];
  filteredbaseschools: SelectedModel[];
  subscription: any;
  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private noticeService: NoticeService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute, 
    private classRoutineService: ClassRoutineService,
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
      this.subscription = this.noticeService.find(+id).subscribe(
        res => {
          this.NoticeForm.patchValue({             
            noticeId: res.noticeId,
            courseDurationId: res.courseDurationId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId: res.courseNameId,
            //courseName: res.courseName,
            traineeNominationId: res.traineeNominationId,
            courseInstructorId: res.courseInstructorId,
            noticeHeading:res.noticeHeading,
            endDate:res.endDate,
            status: res.status,
            noticeDetails: res.noticeDetails,
            menuPosition: res.menuPosition,
            isActive: res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Notice';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.NoticeForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
     }
    this.getselectedbaseschools();
    // this.getselectedcoursedurationbyschoolname();
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
      courseDurationId: [''],
      // baseSchoolNameId: [''],
      baseSchoolNameId: [{ value: '', disabled: false }],
      courseNameId: [''],
     // courseNameIds: [''],
      courseName:[''],
      noticeHeading:[''],
      endDate:[],
      traineeNominationId: [''],
      courseInstructorId: [''],
      status: [0],
      noticeDetails: [''],
      menuPosition: [''],
      isActive: [true]
    })
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
   var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];
  var courseNameArr = dropdown.value.split('_');
  var courseDurationId = courseNameArr[0];
  var courseNameId=courseNameArr[1];
  this.courseName=dropdown.text;
  //this.NoticeForm.get('courseName').setValue(dropdown.text);
  this.NoticeForm.get('courseNameId').setValue(courseNameId);
  this.NoticeForm.get('courseDurationId').setValue(courseDurationId);
  }

  filterBaseSchools(value:string) {
    this.filteredbaseschools=this.selectedbaseschools.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()));
  }

  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
filterByCourse(value:any){
  this.selectedCourse=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}
//   getselectedcoursedurationbyschoolname(){
//     var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];
//     this.isShown=true;
//     if (baseSchoolNameId.length ==1){ 
//       this.subscription = this.classRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
//         this.selectedCourse=res;
//         this.selectCourse=res;   
//       },err=>{
        
//       });
//     }else{

//       if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
//         this.isShowCourseName=false;
//        }
//   else{
//       this.isShowCourseName=true;
//       this.selectedCourse=[];
//     }

//     }
   
//     this.subscription = this.noticeService.getNoticeBySchool(baseSchoolNameId).subscribe(res=>{
//       this.selectedNotice=res
//     }); 
// } 
getselectedcoursedurationbyschoolname() {
  const baseSchoolNameId = this.NoticeForm.value['baseSchoolNameId'];

  if (!baseSchoolNameId || baseSchoolNameId.length === 0) {
      console.error('Base School Name ID is invalid.');
      return;
  }

  this.isShown = true;

  if (baseSchoolNameId.length === 1) {
      // Fetch selected course duration by school name
      this.subscription = this.classRoutineService
          .getselectedcoursedurationbyschoolname(baseSchoolNameId)
          .subscribe(
              (res) => {
                  this.selectedCourse = res;
                  this.selectCourse = res;
              },
              (err) => {
                  console.error('Error fetching course duration:', err);
              }
          );
  } else {
      // Handle other roles' visibility logic
      if (
          this.role === this.userRole.SuperAdmin ||
          this.role === this.userRole.JSTISchool ||
          this.role === this.userRole.BNASchool
      ) {
          this.isShowCourseName = false;
      } else {
          this.isShowCourseName = true;
          this.selectedCourse = [];
      }
  }

  // Fetch notices by school name
  this.noticeService.getNoticeBySchool(baseSchoolNameId).subscribe(
      (res) => {
          this.selectedNotice = res;
      },
      (err) => {
          console.error('Error fetching notices:', err);
      }
  );
}


stopNotices(element){
  if(element.status ===0){
    this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
        this.subscription = this.noticeService.stopNotices(element.noticeId).subscribe(() => {
      var baseSchoolNameId=this.NoticeForm.value['baseSchoolNameId'];

      this.subscription = this.noticeService.getNoticeBySchool(baseSchoolNameId).subscribe(res=>{
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

}


  getselectedbaseschools(){
    this.subscription = this.noticeService.getselectedbaseschools().subscribe(res=>{
      // this.dataSource = new MatTableDataSource(response);
     
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;
      this.selectedbaseschools=res
      this.filteredbaseschools = res;
    }); 
  } 

  deleteItem(row) {
    const id = row.noticeId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.noticeService.delete(id).subscribe(() => {
          //this.getNotices();
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
    const id = this.NoticeForm.get('noticeId').value; 
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.noticeService.update(+id,this.NoticeForm.value).subscribe(response => {
             this.router.navigateByUrl('/notice-bulletin/add-notice');
            this.reloadCurrentRoute();
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
    else if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.loading = true;
      this.selectedCourse.forEach(element => {
        var courseNameArr = element.value.split('_');
        var courseDurationId = courseNameArr[0];
        var courseNameId=courseNameArr[1];
        this.NoticeForm.get('courseNameId').patchValue(courseNameId);
        this.NoticeForm.get('courseDurationId').patchValue(courseDurationId);
      });
      
      this.NoticeForm.value.courseName.forEach(element => {
        this.NoticeForm.value.courseName=element;
        this.subscription = this.noticeService.submit(this.NoticeForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        // this.getBulletins(baseSchoolNameId);
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })

      });

      
     }
     
     else {
      this.loading = true;
      this.NoticeForm.value.baseSchoolNameId.forEach(element => {  
        if(element!=0){
          this.NoticeForm.value.baseSchoolNameId=element;
          if(this.NoticeForm.value.courseName!=""){
            this.NoticeForm.value.courseName.forEach((courseElement,index) => {    
            if (courseElement!=0){
              var courseNameArr = courseElement.split('_');    
              var courseDurationId = courseNameArr[0];
              var courseNameId=courseNameArr[1];
               this.NoticeForm.get('courseNameId').patchValue(courseNameId);
                this.NoticeForm.get('courseDurationId').patchValue(courseDurationId);
              this.NoticeForm.value.courseName="" 
              this.NoticeForm.value.baseSchoolNameId=element
            }
            if (courseElement!=0){
              this.subscription = this.noticeService.submit(this.NoticeForm.value).subscribe(response => {
             
              }, error => {
                this.validationErrors = error;
              })
            }
           
              });
          
          }
          else{
            
            this.subscription = this.noticeService.submit(this.NoticeForm.value).subscribe(response => {
              // this.reloadCurrentRoute();
              // // this.getBulletins(baseSchoolNameId);
              // this.snackBar.open('Information Inserted Successfully ', '', {
              //   duration: 2000,
              //   verticalPosition: 'bottom',
              //   horizontalPosition: 'right',
              //   panelClass: 'snackbar-success'
              // });
            }, error => {
              this.validationErrors = error;
            })
      debugger
          }
        }
       
        
       
      });

      this.reloadCurrentRoute();
      // this.getBulletins(baseSchoolNameId);
      this.snackBar.open('Information Inserted Successfully ', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-success'
      }); 
     
    }
 
  }
  ngAfterViewInit() {
    this.cdr.detectChanges();
  }
  
  toggleAllSelection() {
    
    if (this.allSelected.selected) {
      this.NoticeForm.controls.baseSchoolNameId.enable();
  this.isShowCourseName=true;

      this.NoticeForm.controls.baseSchoolNameId
        .patchValue([...this.filteredbaseschools.map(item => item.value), 0]);
    } else {
      this.isShowCourseName=false;
      this.NoticeForm.controls.baseSchoolNameId.patchValue([]);
    }
    
  }
  toggleAllSelectionCourse() {
    if (this.allSelectedCourse.selected) {
      this.NoticeForm.controls.baseSchoolNameId.disable();
      this.NoticeForm.controls.courseName
        .patchValue([...this.selectedCourse.map(item => item.value), 0]);
    } else {
      this.NoticeForm.controls.courseName.patchValue([]);
    }
  }
}
