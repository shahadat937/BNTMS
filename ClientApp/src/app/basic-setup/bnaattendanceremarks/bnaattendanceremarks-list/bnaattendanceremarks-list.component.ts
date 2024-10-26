import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNAAttendanceRemarks } from '../../models/BNAAttendanceRemarks';
import { BNAAttendanceRemarksService } from '../../service/BNAAttendanceRemarks.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter'
import {Subject, Subscription} from 'rxjs'
import {debounceTime, distinctUntilChanged} from 'rxjs'
import { SharedServiceService } from 'src/app/shared/shared-service.service';



@Component({
  selector: 'app-bnaattendanceremarks-list',
  templateUrl: './bnaattendanceremarks-list.component.html',
  styleUrls: ['./bnaattendanceremarks-list.component.sass']
})
export class BNAAttendanceRemarksListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAAttendanceRemarks[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'sl',/*'bnaAttendanceRemarksId',*/ 'attendanceRemarksCause', /*'menuPosition',*/ 'isActive', 'actions'];
  dataSource: MatTableDataSource<BNAAttendanceRemarks> = new MatTableDataSource();

  selection = new SelectionModel<BNAAttendanceRemarks>(true, []);

  
  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private BNAAttendanceRemarksService: BNAAttendanceRemarksService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super()
   }
  
  ngOnInit() {
    this.getBNAAttendanceRemarkses();

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
  
  getBNAAttendanceRemarkses() {
    this.isLoading = true;
    this.BNAAttendanceRemarksService.getBNAAttendanceRemarkses(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getBNAAttendanceRemarkses();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getBNAAttendanceRemarkses();
  } 


  deleteItem(row) {
    const id = row.bnaAttendanceRemarksId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.BNAAttendanceRemarksService.delete(id).subscribe(() => {
          this.getBNAAttendanceRemarkses();
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
