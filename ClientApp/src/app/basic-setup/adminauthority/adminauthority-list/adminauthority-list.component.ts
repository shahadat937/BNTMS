import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminAuthority } from '../../models/AdminAuthority';
import { AdminAuthorityService } from '../../service/AdminAuthority.service';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
 

@Component({
  selector: 'app-adminauthority',
  templateUrl: './adminauthority-list.component.html',
  styleUrls: ['./adminauthority-list.component.sass']
})
export class AdminAuthorityListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: AdminAuthority[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'adminAuthorityName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<AdminAuthority> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private AdminAuthorityService: AdminAuthorityService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  
  ngOnInit() {
    this.getAdminAuthorities();
  }
 
  getAdminAuthorities() {
    this.isLoading = true;
    this.AdminAuthorityService.getAdminAuthorities(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getAdminAuthorities();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAdminAuthorities();
  }

  deleteItem(row) {
    const id = row.adminAuthorityId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.AdminAuthorityService.delete(id).subscribe(() => {
          this.getAdminAuthorities();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
  }
}
