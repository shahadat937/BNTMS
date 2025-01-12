import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BnaAttendancePeriod } from '../../models/BnaAttendancePeriod';
import { BnaAttendancePeriodService } from '../../service/BnaAttendancePeriod.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter'
import {Subject, Subscription} from 'rxjs'
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

 

@Component({
  selector: 'app-BnaAttendancePeriod-list',
  templateUrl: './BnaAttendancePeriod-list.component.html',
  styleUrls: ['./BnaAttendancePeriod-list.component.sass']
})
export class BnaAttendancePeriodListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BnaAttendancePeriod[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [  'sl', 'periodName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<BnaAttendancePeriod> = new MatTableDataSource();


  selection = new SelectionModel<BnaAttendancePeriod>(true, []);

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private BnaAttendancePeriodService: BnaAttendancePeriodService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) { 
    super();
  }
  
  ngOnInit() {
    this.getBnaAttendancePeriods();

    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
    
  }
  onSearchChange(searchValue:string){
    this.searchSubject.next(searchValue);
  }
 
  getBnaAttendancePeriods() {
    this.isLoading = true;
    this.BnaAttendancePeriodService.getBnaAttendancePeriods(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
    this.getBnaAttendancePeriods();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getBnaAttendancePeriods();
  } 


  deleteItem(row) {
    const id = row.bnaAttendancePeriodId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BnaAttendancePeriodService.delete(id).subscribe(() => {
          this.getBnaAttendancePeriods();
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
