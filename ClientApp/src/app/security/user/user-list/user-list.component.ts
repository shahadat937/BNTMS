import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { User } from '../../models/User';
import { UserService } from '../../service/User.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-user',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.sass']
})
export class UserListComponent implements OnInit, OnDestroy {
  masterData = MasterData;
  loading = false;
  InstructorForm: FormGroup;
  ELEMENT_DATA: User[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";


  displayedColumns: string[] = ['ser', 'userName', 'firstName', 'role', 'phoneNumber', 'email', 'actions'];
  dataSource: MatTableDataSource<User> = new MatTableDataSource();


  selection = new SelectionModel<User>(true, []);
  subscription: any;

  constructor(private snackBar: MatSnackBar, private fb: FormBuilder, private UserService: UserService, private router: Router, private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  // ngOnInit() {
  //   this.dataSource2.paginator = this.paginator;
  // }
  ngOnInit() {
    // this.getUsers();
    this.getEastablishmentUsers();
    this.intitializeForm();
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
      firstName: [''],
      lastName: [''],
      phoneNumber: ['', Validators.required],
      email: ['', Validators.required],
      traineeId: []

    })
  }

  getUsers() {
    this.isLoading = true;
    this.subscription = this.UserService.getUsers(this.paging.pageIndex, this.paging.pageSize, this.searchText).subscribe(response => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount
      this.isLoading = false;

    })
  }
  getEastablishmentUsers() {
    this.isLoading = true;
    this.subscription = this.UserService.getEastablishmentUsers(this.paging.pageIndex, 2000, this.searchText).subscribe(response => {

      var eistablishmentUsers = response.body;
      this.sharedService.groupedData = this.sharedService.groupBy(eistablishmentUsers, (eistablishmentUsers) => eistablishmentUsers.commandingArea)
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
  addNew() {

  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getUsers();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    // this.getUsers();
    this.getEastablishmentUsers();
  }


  deleteItem(row) {
    const id = row.id;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.UserService.delete(id).subscribe(() => {
          // this.getUsers();
          this.getEastablishmentUsers();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
    //this.UserService.delete(id).subscribe();

    // const dialogRef = this.dialog.open(DeleteDialogComponent, {
    //   data: row,
    //   direction: tempDirection,
    // });
    // this.subs.sink = dialogRef.afterClosed().subscribe((result) => {
    //   if (result === 1) {
    //     const foundIndex = this.exampleDatabase.dataChange.value.findIndex(
    //       (x) => x.id === this.id
    //     );

    //     this.exampleDatabase.dataChange.value.splice(foundIndex, 1);
    //     this.refreshTable();
    //     this.showNotification(
    //       'snackbar-danger',
    //       'Delete Record Successfully...!!!',
    //       'bottom',
    //       'center'
    //     );
    //   }
    //});
  }

  PasswordUpdate(row) {
    const id = row.id;
    this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Resetting This  User Password?').subscribe(result => {

      if (result) {

        if (id) {
          this.UserService.find(id).subscribe(
            res => {
              this.InstructorForm.patchValue({

                id: res.id,
                userName: res.userName,
                roleName: res.roleName,
                firstName: res.firstName,
                lastName: res.lastName,
                phoneNumber: res.phoneNumber,
                email: res.email,
                traineeId: res.traineeId

              });
              this.subscription = this.UserService.resetPassword(id, this.InstructorForm.value).subscribe(response => {
                // this.router.navigateByUrl('/security/instructor-list');
                // this.getUsers();
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
      }

    }
    )

  }
}
