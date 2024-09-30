import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../../service/User.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BaseSchoolNameService } from '../../service/BaseSchoolName.service';
import {RoleService} from '../../service/role.service'
import { MasterData } from 'src/assets/data/master-data';

@Component({
  selector: 'app-new-user',
  templateUrl: './new-user.component.html',
  styleUrls: ['./new-user.component.sass']
})
export class NewUserComponent implements OnInit, OnDestroy {

  masterData = MasterData;
  loading = false;
  pageTitle: string;
  destination:string;
  UserForm: FormGroup;
  buttonText:string;
  hide1 = true;
  hide2 = true;
  validationErrors: string[] = [];
  roleValues:SelectedModel[]; 
  branchValues:SelectedModel[]; 
  selectedOrganization:SelectedModel[];
  selectedCommendingArea:SelectedModel[];
  selectCommendingArea: SelectedModel[];
  selectedBaseName:SelectedModel[];
  selectBaseName: SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectSchool:SelectedModel[];
  selectRole: SelectedModel[];
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
      this.pageTitle = 'Edit User';
      this.destination = "Edit";
      this.buttonText= "Update";
      this.isEdit=true;
      this.subscription = this.UserService.find(id).subscribe(
     
        res => {
          this.UserForm.patchValue({          

            id: res.id,
            userName: res.userName,
          //  menuPosition: res.menuPosition,
            roleName: res.roleName,
            password: 'Admin@123',
            confirmPassword: 'Admin@123',          
            firstName : res.firstName,
            lastName : res.lastName,
            firstLevel : res.firstLevel,
            secondLevel : res.secondLevel,
            thirdLevel : res.thirdLevel,
            fourthLevel : res.fourthLevel,
            phoneNumber : res.phoneNumber,
            email : res.email,          
          
          });   
          // this.getSelectedOrganization();  
          this.onOrganizationSelectionChangeGetCommendingArea();
      
          this.onCommendingAreaSelectionChangeGetBaseName();
          this.onBaseNameSelectionChangeGetBaseSchoolName();       
        }
      );

      
     
     

    } else {
      this.pageTitle = 'Create User';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.onOrganizationSelectionChangeGetCommendingArea();
    this.getRoleName();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  intitializeForm() {
    this.UserForm = this.fb.group({
      id: [0],
      userName: ['', Validators.required],
      roleName: ['', Validators.required],
      // password:[],
      // confirmPassword:[],
      // password: ['', [Validators.required, Validators.pattern('^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$'), Validators.maxLength(20)]],
      // confirmPassword: ['', [Validators.required,this.matchValues('password')]],
      // firstName: ['', Validators.required],
      // lastName:['', Validators.required],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],
      firstLevel:[this.masterData.UserLevel.navy],
      secondLevel:['',Validators.nullValidator],
      thirdLevel:['',Validators.nullValidator],    
      fourthLevel:['',Validators.nullValidator],    
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required],


       traineeId:[''],
       //trainee:[''],
  
     
    })
    // this.UserForm.get('trainee').valueChanges
    // .subscribe(value => {
     
    //     this.getSelectedTraineeAutocomplete(value);
    // })
  }

  //autocomplete
  // onTraineeSelectionChanged(item) {
   
  //   this.UserForm.get('traineeId').setValue(item.value);
  //   this.UserForm.get('trainee').setValue(item.text);
  // }
  // getSelectedTraineeAutocomplete(pno){
  //   this.UserService.getSelectedTraineeByPno(pno).subscribe(response => {
  //     this.options = response;
  //     this.filteredOptions = response;
  //   })
  // }
  
  matchValues(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value 
        ? null : {isMatching: true}
    }
  }

  filterRoles(value:any){
    this.roleValues=this.selectRole.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getRoleName(){
    this.subscription = this.RoleService.getselectedrole().subscribe(res=>{
      this.roleValues=res
      this.selectRole=res
    });
  }

  getSelectedOrganization(){
    this.subscription = this.BaseSchoolNameService.getSelectedOrganization().subscribe(res=>{
      this.selectedOrganization=res
    });
  }

  filterCommendingArea(value:any){
    this.selectedCommendingArea = this.selectCommendingArea.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onOrganizationSelectionChangeGetCommendingArea(){
    this.organizationId=this.UserForm.value['firstLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedCommendingArea(this.organizationId).subscribe(res=>{
      this.selectedCommendingArea=res
      this.selectCommendingArea=res
    });        
  }
  filterByBase(value:any){
    this.selectedBaseName = this.selectBaseName.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onCommendingAreaSelectionChangeGetBaseName(){
    this.commendingAreaId=this.UserForm.value['secondLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedBaseName(this.commendingAreaId).subscribe(res=>{
      this.selectedBaseName=res
      this.selectBaseName=res
    });  
    //this.getBaseNameList(this.commendingAreaId);
            
  }
  filterBySchoolName(value:any){
    this.selectedSchoolName=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onBaseNameSelectionChangeGetBaseSchoolName(){
    this.baseNameId=this.UserForm.value['thirdLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedSchoolName(this.baseNameId).subscribe(res=>{
      this.selectedSchoolName=res
      this.selectSchool=res
    }); 
  }

  
  onSubmit() {
    const id = this.UserForm.get('id').value;  
    //const id = this.route.snapshot.paramMap.get('userId');   
     
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.UserService.update(id,this.UserForm.value).subscribe(response => {
            this.router.navigateByUrl('/security/user-list');
            this.snackBar.open('User Updated Successfully ', '', {
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
      const userFormList : any[] = [];
      userFormList.push(this.UserForm.value);
      // this.subscription = this.UserService.submit(this.UserForm.value).subscribe(response => {
        this.subscription = this.UserService.submit(userFormList).subscribe(response => {
        this.router.navigateByUrl('/security/user-list');
        this.snackBar.open('User Created Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }
    this.loading=false;
  }

}
