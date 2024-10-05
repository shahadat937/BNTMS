import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TdecActionStatus } from '../../models/TdecActionStatus';
import { TdecActionStatusService } from '../../service/TdecActionStatus.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-tdecactionstatus-list',
  templateUrl: './tdecactionstatus-list.component.html',
  styleUrls: ['./tdecactionstatus-list.component.sass']
})
export class TdecActionStatusListComponent implements OnInit, OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TdecActionStatus[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 5,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','name', 'mark', 'actions'];
  dataSource: MatTableDataSource<TdecActionStatus> = new MatTableDataSource();

  selection = new SelectionModel<TdecActionStatus>(true, []);
  subscription: any;

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TdecActionStatusService: TdecActionStatusService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getTdecActionStatuses();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  
  getTdecActionStatuses() {
    this.isLoading = true;
    this.subscription = this.TdecActionStatusService.getTdecActionStatuses(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getTdecActionStatuses();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTdecActionStatuses();
  } 


  deleteItem(row) {
    const id = row.tdecActionStatusId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.TdecActionStatusService.delete(id).subscribe(() => {
          this.getTdecActionStatuses();
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
