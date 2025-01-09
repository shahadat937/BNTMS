import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNAServiceType } from '../../models/BNAServiceType';
import { BNAServiceTypeService } from '../../service/BNAServiceType.service';
import { MatSort } from '@angular/material/sort';
import { MatMenuTrigger } from '@angular/material/menu';
import { DataSource } from '@angular/cdk/collections';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import {Subject, Subscription} from 'rxjs'
import {debounceTime, distinctUntilChanged} from 'rxjs';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-BNAServiceType',
  templateUrl: './bnaservicetype-list.component.html',
  styleUrls: ['./bnaservicetype-list.component.sass']
})
export class BNAServiceTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAServiceType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'ser', 'serviceName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<BNAServiceType> = new MatTableDataSource();

  selection = new SelectionModel<BNAServiceType>(true, []);
  
  constructor(
    private snackBar: MatSnackBar,
    private BNAServiceTypeService: BNAServiceTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super();
  }
  
  ngOnInit() {
    this.getBNAServiceTypes();

    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }
 
  getBNAServiceTypes() {
    this.isLoading = true;
    this.BNAServiceTypeService.getBNAServiceTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBNAServiceTypes();
  }
  
  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getBNAServiceTypes();
  }

  deleteItem(row) {
    const id = row.bnaServiceTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BNAServiceTypeService.delete(id).subscribe(() => {
          this.getBNAServiceTypes();
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
