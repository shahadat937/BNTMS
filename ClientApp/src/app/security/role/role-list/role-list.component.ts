import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Role } from '../../models/role';
import { RoleService } from '../../service/role.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-role-list',
  templateUrl: './role-list.component.html',
  styleUrls: ['./role-list.component.sass']
})
export class RoleListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Role[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  // displayedColumns: string[] = [ 'sl',/*'roleId',*/ 'roleName', 'loweredRoleName', 'description', /*'menuPosition',*/ 'isActive', 'actions'];
  displayedColumns: string[] = [ 'sl','name', 'actions'];
  dataSource: MatTableDataSource<Role> = new MatTableDataSource();

  selection = new SelectionModel<Role>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private roleService: RoleService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  
  ngOnInit() {
    this.getRoles();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  getRoles() {
    this.isLoading = true;
    this.subscription = this.roleService.getRoles(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getRoles();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText;
    this.getRoles();
  } 


  deleteItem(row) {
    const id = row.id; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.roleService.delete(id).subscribe(() => {
          this.getRoles();
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
