import {SelectionModel} from '@angular/cdk/collections';
import {MatTableDataSource} from '@angular/material/table';
import {RoleService} from '../../service/role.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { UserService } from '../../service/User.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { BIODataGeneralInfo } from '../../../../../src/app/trainee-biodata/models/BIODataGeneralInfo';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Role } from '../../../core/models/role';
import { MatSort } from '@angular/material/sort';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-new-userlist',
  templateUrl: './new-userlist.component.html',
  styleUrls: ['./new-userlist.component.sass']
})
export class NewUserListComponent implements OnInit, OnDestroy {
  // pageTitle: string;
  // destination:string;
  UserForm: FormGroup;
  userList: any[];
 
   masterData = MasterData;
  loading = false;
  userRole = Role;
  validationErrors: string[] = [];
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize:  this.masterData.paging.pageSize,
    length: 1
  }
  searchPno="";
  

  displayedColumns: string[] = ['select', 'ser', 'pno', 'name', 'mobile', 'email'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();
  selection = new SelectionModel<BIODataGeneralInfo>(true, []);
  subscription: any;

 


  constructor(
    private snackBar: MatSnackBar,
    private RoleService: RoleService,
    private confirmService: ConfirmService,
    private UserService: UserService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {      
    this.intitializeForm();
    this.getTraineeList(this.searchPno);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getTraineeList(searchPno) {
    this.isLoading = true;
      this.subscription = this.UserService.getTraineeList(searchPno, this.paging.pageSize, this.paging.pageIndex).subscribe((response:any) => {
        this.paging.length = response[0]?.totalCount? response[0].totalCount : 0;
       this.dataSource.data = response; 
       this.isLoading = false;
      })
    
  }
  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  intitializeForm() {
    this.UserForm = this.fb.group({
      id: [0],
      userName: ['', Validators.required],
      roleName: [this.userRole.Student],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],
      phoneNumber : ['', Validators.required],
      email : ['', Validators.required],
      traineeId:[]
           
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTraineeList(this.searchPno);
  }

  applyFilter(searchText: any){
    this.searchPno = searchText;
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.getTraineeList(this.searchPno);
  } 


  /** Selects all rows if they are not all selected; otherwise clear selection. */
  toggleAllRows() {
    if (this.isAllSelected()) {
      this.selection.clear();
      return;
    }

    this.selection.select(...this.dataSource.data);
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: BIODataGeneralInfo): string {
    if (!row) {
      return `${this.isAllSelected() ? 'deselect' : 'select'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.pno + 1}`;
  }

  createUserSelectedRows(){
    const userFormList: any[] = [];

    this.userList = this.selection.selected;
    this.userList.forEach(element => {
      const userInfo = {
        userName: element.pno,
        traineeId: element.traineeId,
        email: element.email,
        phoneNumber: element.mobile,
        id: 0,
        roleName: this.userRole.Student,
        password: 'Admin@123',
        confirmPassword: 'Admin@123',
        firstName: 'na',
        lastName:'na',
      };
      userFormList.push(userInfo);
    });
    this.subscription = this.UserService.submit(userFormList).subscribe((response : any) => {
          if(response.success){
            this.UserService.Users = [];
            this.snackBar.open(response.message, '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.router.navigateByUrl('/security/instructor-list');
          }
        }, error => {
          this.validationErrors = error;
    });

    // this.userList = this.selection.selected;
    // this.userList.forEach(element => {
    //   this.UserForm.get('userName').setValue(element.pno);
    //   this.UserForm.get('traineeId').setValue(element.traineeId);
    //   this.UserForm.get('email').setValue(element.email);
    //   this.UserForm.get('phoneNumber').setValue(element.mobile);
    //   console.log("User Value : ",this.UserForm.value)
    //   this.UserService.submit(this.UserForm.value).subscribe((response : any) => {
    //     if(response.success){
    //       this.snackBar.open('Information Inserted Successfully ', '', {
    //         duration: 2000,
    //         verticalPosition: 'bottom',
    //         horizontalPosition: 'right',
    //         panelClass: 'snackbar-success'
    //       });
    //       this.router.navigateByUrl('/security/instructor-list');
    //     }
    //   }, error => {
    //     this.validationErrors = error;
    //   })
    // });
  }

  
}
