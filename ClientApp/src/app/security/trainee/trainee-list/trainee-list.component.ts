import { Component, OnDestroy, OnInit } from '@angular/core';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { Role } from '../../models/role';
import { User } from '../../models/User';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSnackBar } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { UserService } from '../../service/User.service';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-trainee-list',
  templateUrl: './trainee-list.component.html',
  styleUrls: ['./trainee-list.component.sass']
})
export class TraineeListComponent implements OnInit, OnDestroy{

  masterData = MasterData;
  loading = false;
  allRole : Role;
  ELEMENT_DATA: User[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  TraineeForm: FormGroup

  displayedColumns: string[] = ['ser', 'userName','email','phoneNumber','roleName', 'actions'];
  dataSource: MatTableDataSource<User> = new MatTableDataSource();

  selection = new SelectionModel<User>(true, []);
  subscription: any;
  
  constructor(private snackBar: MatSnackBar,private UserService: UserService,private fb: FormBuilder,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
 
  ngOnInit(): void {
    this.getAllTrainee();
    this.intitializeForm();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getAllTrainee() {
    this.isLoading = true;
    this.subscription = this.UserService.getAllTrainee(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
    this.dataSource.data = response.items; 
    this.paging.length = response.totalItemsCount    
    this.isLoading = false;

    })
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length; 
    const numRows = this.dataSource.filteredData.length;  
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAllTrainee();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getAllTrainee();
  } 


  deleteItem(row) {
    const id = row.id; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.UserService.delete(id).subscribe(() => {
          this.getAllTrainee();
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

  intitializeForm() {
    this.TraineeForm = this.fb.group({
      id: [0],
      userName: ['', Validators.required],
      roleName: [''],
      // password:[],
      // confirmPassword:[],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: [''],
      lastName:[''],
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required],
      traineeId:[]

    })
  }

  PasswordUpdate(row) {
    const id = row.id; 
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Resetting This  User Password?').subscribe(result => {


      if (id&&result) {
        this.subscription = this.UserService.find(id).subscribe(

          res => {
            this.TraineeForm.patchValue({          
  
              id: res.id,
              userName: res.userName,            
              roleName: res.roleName,         
              firstName : res.firstName,
              lastName : res.lastName,
              phoneNumber : res.phoneNumber,
              email : res.email,   
              traineeId:res.traineeId     
            
            });   
            this.subscription = this.UserService.resetPassword(id,this.TraineeForm.value).subscribe(response => {
              
              this.getAllTrainee();
              this.snackBar.open('Password Reseted Successfully ', '', {
                duration: 2000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
            })
            
          }
        );        
      }
    })
    
  }

  ShiftRoleOfItem(row) {
    const id = row.id; 


    this.confirmService.confirm('Confirm Update message', 'Are You Sure Switch This  User?').subscribe(result => {
      if (id&&result) {

        this.UserService.find(id).subscribe(
          res => {
            this.TraineeForm.patchValue({          
  
              id: res.id,
              userName: res.userName,            
              roleName: res.roleName,         
              firstName : res.firstName,
              lastName : res.lastName,
              phoneNumber : res.phoneNumber,
              email : res.email,   
              traineeId:res.traineeId     
            
            });   
            this.changeRole();
          }
        );
        
      }
    })
    
  }

  changeRole(){
    var userId = this.TraineeForm.get('id')?.value; 
    var currentRole = this.TraineeForm.get('roleName')?.value; 
    if( currentRole == 'Instructor'){
      this.TraineeForm.get('roleName')?.setValue('Student');
    }else if( currentRole == 'Student'){
      this.TraineeForm.get('roleName')?.setValue('Instructor');
    }
    
    this.subscription = this.UserService.update(userId,this.TraineeForm.value).subscribe(response => {
     this.getAllTrainee();
      this.snackBar.open('Information Updated Successfully ', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-success'
      });
    })
  }


}
