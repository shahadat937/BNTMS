import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { AdminAuthority } from '../../models/AdminAuthority';
import { AdminAuthorityService } from '../../service/AdminAuthority.service';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
 

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
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'ser', 'adminAuthorityName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<AdminAuthority> = new MatTableDataSource();
  
  constructor(
    private snackBar: MatSnackBar,
    private AdminAuthorityService: AdminAuthorityService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super();
  }
  
  ngOnInit() {
    this.getAdminAuthorities();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }

  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
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
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
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
