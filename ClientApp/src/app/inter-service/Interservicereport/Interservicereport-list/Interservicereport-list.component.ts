import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { InterserviceReport } from '../../models/interservicereport';
import { InterserviceReportService } from '../../service/interservicereport.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-Interservicereport-list',
  templateUrl: './Interservicereport-list.component.html',
  styleUrls: ['./Interservicereport-list.component.sass']
})
export class InterserviceReportListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: InterserviceReport[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl', 'courseName','documentName',  'documentUpload',   'actions'];
  dataSource: MatTableDataSource<Document> = new MatTableDataSource();

  selection = new SelectionModel<Document>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private interserviceReportService: InterserviceReportService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getDocuments();
  }
  
  getDocuments() {
    this.isLoading = true;
    // this.interserviceReportService.getInterServiceCourseReports(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
    //   this.dataSource.data = response.items; 
    //   this.paging.length = response.totalItemsCount    
    //   this.isLoading = false;
    // })
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
    this.getDocuments();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getDocuments();
  } 


  deleteItem(row) {
    const id = row.interServiceCourseReportid; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.interserviceReportService.delete(id).subscribe(() => {
          this.getDocuments();
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
