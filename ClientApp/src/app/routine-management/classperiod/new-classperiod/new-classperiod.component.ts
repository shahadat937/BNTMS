import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassPeriodService } from '../../service/classperiod.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { CourseNameService } from '../../../basic-setup/service/CourseName.service';
import { ClassPeriod } from '../../models/classperiod';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-classperiod',
  templateUrl: './new-classperiod.component.html',
  styleUrls: ['./new-classperiod.component.sass']
}) 
export class NewClassPeriodComponent implements OnInit, OnDestroy {
   masterData = MasterData;
   userRole = Role;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  courseNameId:number;
  ClassPeriodForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschool:SelectedModel[];
  selectSchool:SelectedModel[];
  selectedcoursestatus:SelectedModel[];
  selectEvent:SelectedModel[];
  selectedcoursename:SelectedModel[];
  isShown: boolean = false ;
  GetPeriodListByParameter:ClassPeriod[];
  isEditMode:boolean=false;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;

  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser', 'periodName','bnaClassScheduleStatus','durationForm','durationTo', 'menuPosition', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService, private CourseNameService: CourseNameService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private ClassPeriodService: ClassPeriodService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('classPeriodId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    if (id) {
      this.pageTitle = 'Edit Class Period'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" ;
      this.isEditMode=true;
      this.subscription = this.ClassPeriodService.find(+id).subscribe(
        res => {
          this.ClassPeriodForm.patchValue({          
            classPeriodId:res.classPeriodId, 
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId:res.courseNameId, 
            periodName:res.periodName, 
            bnaClassScheduleStatusId:res.bnaClassScheduleStatusId, 
            durationForm:res.durationForm, 
            durationTo:res.durationTo,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
            course:res.courseName,
          }); 
          this.courseNameId = res.courseNameId;         
        }
      );
    } else {
      this.pageTitle = 'Create Class Period';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.ClassPeriodForm.get('baseSchoolNameId').setValue(this.branchId);
    }else if(this.role === this.userRole.TrainingOffice || this.role === this.userRole.CO){
      this.getselectedbaseschoolsByBase(this.branchId);
    }else{
      this.getselectedbaseschools();
      // this.getRoutineNoteList();
    }
    // this.getselectedbaseschools();
    this.getselectedbnaclassschedulestatus();
    this.getselectedcoursename();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.ClassPeriodForm = this.fb.group({
      classPeriodId: [0],
      baseSchoolNameId:['',Validators.required],
      courseNameId:['',Validators.required],
      course:[''],
      periodName:['',Validators.required],
      bnaClassScheduleStatusId:['',Validators.required],
      durationForm:[''],
      durationTo:[''],
      menuPosition:[],
      status:[1],
      isActive: [true],    
    })
    this.ClassPeriodForm.get('course').valueChanges
    .subscribe(value => {
        this.getSelectedCourseAutocomplete(value);
    })
  }
  
//autocomplete
onCourseSelectionChanged(item) {
  this.courseNameId = item.value 
  this.ClassPeriodForm.get('courseNameId').setValue(item.value);
  this.ClassPeriodForm.get('course').setValue(item.text);
  this.onCourseSelectionChangeGetPeriodList()
}
getSelectedCourseAutocomplete(cName){
  this.subscription = this.CourseNameService.getSelectedCourseByName(cName).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}


  getselectedbaseschools(){
    this.subscription = this.ClassPeriodService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
      this.selectSchool=res
    });
  }
  filterBySchool(value:any){
    this.selectedbaseschool=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  getselectedbaseschoolsByBase(baseNameId){
    this.subscription = this.ClassPeriodService.getselectedbaseschoolsByBase(baseNameId).subscribe(res=>{
      this.selectedbaseschool=res;
      this.selectSchool=res
    });
  }

  onCourseSelectionChangeGetPeriodList(){
    var baseSchoolNameId=this.ClassPeriodForm.value['baseSchoolNameId'];
    var courseNameId=this.ClassPeriodForm.value['courseNameId'];
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null){
      this.subscription = this.ClassPeriodService.getSelectedPeriodBySchoolAndCourse(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.GetPeriodListByParameter=res;  
      }); 
    }
  }
  
  getselectedbnaclassschedulestatus(){
    this.subscription = this.ClassPeriodService.getselectedbnaclassschedulestatus().subscribe(res=>{
      this.selectedcoursestatus=res;
      this.selectEvent=res;
    });
  }
  filterByStatus(value:any){
    this.selectedcoursestatus=this.selectEvent.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedcoursename(){
    this.subscription = this.ClassPeriodService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res;
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }


  onSubmit() {
    const id = this.ClassPeriodForm.get('classPeriodId').value; 
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.ClassPeriodService.update(+id,this.ClassPeriodForm.value).subscribe(response => {
            this.router.navigateByUrl('/routine-management/add-classperiod');
           // this.reloadCurrentRoute();
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
      this.subscription = this.ClassPeriodService.submit(this.ClassPeriodForm.value).subscribe(response => {
        //this.router.navigateByUrl('/routine-management/add-classperiod');
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
 
  }

  deleteItem(row) {
    const id = row.classPeriodId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.ClassPeriodService.delete(id).subscribe(() => {
          this.onCourseSelectionChangeGetPeriodList();
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
}
