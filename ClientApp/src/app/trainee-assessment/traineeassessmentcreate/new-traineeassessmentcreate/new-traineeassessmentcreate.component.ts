import { Component, OnDestroy, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeAssessmentCreateService } from '../../service/TraineeAssessmentCreate.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../src/app/core/models/role';
import {MasterData} from '../../../../../src/assets/data/master-data'
import {TraineeAssessmentCreate} from '../../models/TraineeAssessmentCreate'
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-traineeassessmentcreate',
  templateUrl: './new-traineeassessmentcreate.component.html',
  styleUrls: ['./new-traineeassessmentcreate.component.sass']
})
export class NewTraineeAssessmentCreateComponent implements OnInit, OnDestroy {
  buttonText:string;
  userRole = Role;
  loading = false;
  pageTitle: string;
  destination:string;
  selectedRoles:any;
  masterData = MasterData;
  isShown:boolean=false;
  selectedcoursedurationbyschoolname:any;
  selectCourse:SelectedModel[]

  role : any;
  traineeId : any;
  branchId : any;
  courseDuration:any;

  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  TraineeAssessmentCreateForm: FormGroup;
  validationErrors: string[] = [];

  displayedColumns: string[] = ['ser','course','assessmentName','startDate','endDate','status', 'actions'];
  dataSource: MatTableDataSource<TraineeAssessmentCreate> = new MatTableDataSource();
  subscription: any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private TraineeAssessmentCreateService: TraineeAssessmentCreateService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId  ? this.authService.currentUserValue.branchId.trim() : "";

    const id = this.route.snapshot.paramMap.get('traineeAssessmentCreateId'); 
    if (id) {
      this.pageTitle = 'Edit Trainee Assessment';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.TraineeAssessmentCreateService.find(+id).subscribe(
        res => {
          this.TraineeAssessmentCreateForm.patchValue({          

            traineeAssessmentCreateId: res.traineeAssessmentCreateId,
            assessmentName: res.assessmentName,
            courseDurationId: res.courseDurationId,
            baseSchoolNameId: res.baseSchoolNameId,
            startDate: res.startDate,
            endDate: res.endDate,
            remarks: res.remarks,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive:res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Trainee Assessment';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();

    if(this.role == this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool || this.role == this.userRole.SchoolOIC || this.role == this.userRole.TCO){
      this.TraineeAssessmentCreateForm.get('baseSchoolNameId')?.setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
    }
    this.getTraineeAssessmentCreates();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.TraineeAssessmentCreateForm = this.fb.group({
      traineeAssessmentCreateId: [0],
      assessmentName: [''],
      courseName: [''],
      courseDurationId: [],
      baseSchoolNameId: [],
      startDate: [''],
      endDate: [''],
      remarks: [''],
      status: [0],
      menuPosition: [0],
      isActive: [true],
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTraineeAssessmentCreates();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTraineeAssessmentCreates();
  } 

  getTraineeAssessmentCreates() {
    this.isLoading = true;
    this.subscription = this.TraineeAssessmentCreateService.getTraineeAssessmentCreates(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.branchId,this.courseDuration).subscribe(response => {
     
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.TraineeAssessmentCreateForm.value['baseSchoolNameId'];
    this.subscription = this.TraineeAssessmentCreateService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedcoursedurationbyschoolname=res;
      this.selectCourse=res
    });
  }  

  filterByCourse(value:any){
    this.selectedcoursedurationbyschoolname=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getselectedbnasubjectname(){
    
    this.isShown =true;
      var courseNameArrVal=this.TraineeAssessmentCreateForm.value['courseName'];
      var courseNameArr = courseNameArrVal.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];
     this.courseDuration= courseDurationId;
      // this.courseName=dropdown.text;
      // this.ClassRoutineForm.get('courseName').setValue(dropdown.text);
      // this.ClassRoutineForm.get('courseNameId').setValue(courseNameId);
      this.TraineeAssessmentCreateForm.get('courseDurationId')?.setValue(courseDurationId);

      this.getTraineeAssessmentCreates();
       
  } 

  inActiveItem(row){
    const id = row.traineeAssessmentCreateId;    
    //var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    if(row.status == 0){
      this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Stop This Assessment').subscribe(result => {
        if (result) {
          //this.runningload = true;
          this.subscription = this.TraineeAssessmentCreateService.ChangeAssessmentStatus(id,1).subscribe(() => {
          //  this.getBulletins(baseSchoolNameId);
          this.getTraineeAssessmentCreates();
            this.snackBar.open('Assessment Stopped!', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    }
    else{
      
      this.subscription = this.confirmService.confirm('Confirm Active message', 'Are You Sure Run This Assessment').subscribe(result => {
        if (result) {
          //this.runningload = true;
          this.TraineeAssessmentCreateService.ChangeAssessmentStatus(id,0).subscribe(() => {
          //  this.getBulletins(baseSchoolNameId);
          this.getTraineeAssessmentCreates();
            this.snackBar.open('Assessment Running!', '', { 
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          })
        }
      })
    }
  }

  deleteItem(row) {
    const id = row.traineeAssessmentCreateId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.TraineeAssessmentCreateService.delete(id).subscribe(() => {
          this.getTraineeAssessmentCreates();
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
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {    
    
    const id = this.TraineeAssessmentCreateForm.get('traineeAssessmentCreateId')?.value;  
    // const formData = new FormData();
    // for (const key of Object.keys(this.TraineeAssessmentCreateForm.value)) {
    //   const value = this.TraineeAssessmentCreateForm.value[key];
    //   formData.append(key, value);
    // } 
    if (id) {      
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.TraineeAssessmentCreateService.update(+id,this.TraineeAssessmentCreateForm.value).subscribe(response => {
            // this.router.navigateByUrl('/trainee-assessment/traineeassessmentcreate-list');
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

    else {
      this.loading = true;
      this.subscription = this.TraineeAssessmentCreateService.submit(this.TraineeAssessmentCreateForm.value).subscribe(response => {
        // this.router.navigateByUrl('/trainee-assessment/traineeassessmentcreate-list');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
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
