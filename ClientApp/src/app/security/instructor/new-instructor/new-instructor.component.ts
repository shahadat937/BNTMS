import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../service/User.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BaseSchoolNameService } from '../../service/BaseSchoolName.service';
import {RoleService} from '../../service/role.service'

@Component({
  selector: 'app-new-instructor',
  templateUrl: './new-instructor.component.html',
  styleUrls: ['./new-instructor.component.sass']
})
export class NewInstructorComponent implements OnInit, OnDestroy {
  loading = false;
  pageTitle: string;
  destination:string;
  InstructorForm: FormGroup;
  buttonText:string;
  hide1 = true;
  hide2 = true;
  validationErrors: string[] = [];
  roleValues:SelectedModel[]; 
  branchValues:SelectedModel[]; 
  selectedOrganization:SelectedModel[];
  selectedCommendingArea:SelectedModel[];
  selectedBaseName:SelectedModel[];
  selectedSchoolName:SelectedModel[];
  organizationId:any;
  commendingAreaId:any;
  baseNameId:any;
  schoolNameId:any;
  isEdit:boolean=false;
  options = [];
  filteredOptions;
  subscription: any;

  constructor(private snackBar: MatSnackBar,private RoleService: RoleService,private BaseSchoolNameService: BaseSchoolNameService,private confirmService: ConfirmService,private UserService: UserService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('userId'); 
    if (id) {
      this.pageTitle = 'Edit Instructor';
      this.destination = "Edit";
      this.buttonText= "Update";
      this.isEdit=true;
      this.subscription = this.UserService.find(id).subscribe(
        res => {
          this.InstructorForm.patchValue({          

            id: res.id,
            userName: res.userName,
          //  menuPosition: res.menuPosition,
            roleName: res.roleName,
            password: res.password,
            confirmPassword: res.confirmPassword,          
            firstName : res.firstName,
            lastName : res.lastName,
            firstLevel : res.firstLevel,
            secondLevel : res.secondLevel,
            thirdLevel : res.thirdLevel,
            fourthLevel : res.fourthLevel,
            phoneNumber : res.phoneNumber,
            email : res.email,   
            traineeId:res.traineeId,
            trainee:res.traineeName,       
          
          });   
          this.getSelectedOrganization();  
          this.onOrganizationSelectionChangeGetCommendingArea();
      
          this.onCommendingAreaSelectionChangeGetBaseName();
          this.onBaseNameSelectionChangeGetBaseSchoolName();       
        }
      );
    } else {
      this.pageTitle = 'Create Instructor';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getSelectedOrganization();
    this.getRoleName();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  intitializeForm() {
    this.InstructorForm = this.fb.group({
      id: [0],
      userName: ['', Validators.required],
      roleName: [''],
      // password:[],
      // confirmPassword:[],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required],
      traineeId:[],
      trainee:[''],
      firstLevel:['',Validators.nullValidator],
      secondLevel:['',Validators.nullValidator],
      thirdLevel:['',Validators.nullValidator],    
      fourthLevel:['',Validators.nullValidator]

    })
    this.InstructorForm.get('trainee').valueChanges
    .subscribe(value => {
     
        this.getSelectedTraineeAutocomplete(value);
    })
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    //this.courseNameId = item.value 
    this.InstructorForm.get('traineeId').setValue(item.value);
    this.InstructorForm.get('trainee').setValue(item.text);
  }
  getSelectedTraineeAutocomplete(pno){
    this.subscription = this.UserService.getSelectedTraineeByPno(pno).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }
  
  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value 
        ? null : {isMatching: true}
    }
  }

  getRoleName(){
    this.subscription = this.RoleService.getselectedrolesForTrainee().subscribe(res=>{
      this.roleValues=res
    });
  }

  getSelectedOrganization(){
    this.subscription = this.BaseSchoolNameService.getSelectedOrganization().subscribe(res=>{
      this.selectedOrganization=res
    });
  }

  onOrganizationSelectionChangeGetCommendingArea(){
    this.organizationId=this.InstructorForm.value['firstLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedCommendingArea(this.organizationId).subscribe(res=>{
      this.selectedCommendingArea=res
    });        
  }
  
  onCommendingAreaSelectionChangeGetBaseName(){
    this.commendingAreaId=this.InstructorForm.value['secondLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedBaseName(this.commendingAreaId).subscribe(res=>{
      this.selectedBaseName=res
    });  
    //this.getBaseNameList(this.commendingAreaId);
            
  }
  onBaseNameSelectionChangeGetBaseSchoolName(){
    this.baseNameId=this.InstructorForm.value['thirdLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedSchoolName(this.baseNameId).subscribe(res=>{
      this.selectedSchoolName=res
    }); 
  }

  
  onSubmit() {
    const id = this.InstructorForm.get('id').value;  
    if (id) {
      this.InstructorForm.get('password').setValue('Admin@123');
      this.InstructorForm.get('confirmPassword').setValue('Admin@123');

      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.UserService.update(id,this.InstructorForm.value).subscribe(response => {
            this.router.navigateByUrl('/security/instructor-list');
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
      this.loading=true;
      this.subscription = this.UserService.submit(this.InstructorForm.value).subscribe(response => {
        this.router.navigateByUrl('/security/instructor-list');
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
