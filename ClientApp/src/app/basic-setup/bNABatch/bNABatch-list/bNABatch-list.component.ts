import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNABatch } from '../../models/bNABatch';
import { BNABatchService } from '../../service/bNABatch.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-BNABatch-list',
  templateUrl: './bnabatch-list.component.html',
  styleUrls: ['./bnabatch-list.component.sass']
})
export class BNABatchListComponent implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNABatch[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl',/*'bnaBatchId',*/ 'batchName', 'startDate', 'completeStatus', /*'menuPosition',*/ 'isActive', 'actions'];
  dataSource: MatTableDataSource<BNABatch> = new MatTableDataSource();

  selection = new SelectionModel<BNABatch>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private bNABatchService: BNABatchService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getBNABatchs();
  }
  
  getBNABatchs() {
    this.isLoading = true;
    this.bNABatchService.getBNABatchs(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getBNABatchs();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBNABatchs();
  } 


  deleteItem(row) {
    const id = row.bnaBatchId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.bNABatchService.delete(id).subscribe(() => {
          this.getBNABatchs();
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
