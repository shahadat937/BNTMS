import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { InterServiceMark } from '../../models/interservicemark';
import { InterServiceMarkService } from '../../service/interservicemark.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-interservicemark-list',
  templateUrl: './interservicemark-list.component.html',
  styleUrls: ['./interservicemark-list.component.sass']
})
export class InterServiceMarkListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: InterServiceMark[] = [];
  isLoading = false;
  courseTypeId=MasterData.coursetype.InterService;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','courseDuration','organizationName',  'coursePosition',  'obtaintMark',  'remarks', 'document',  'actions'];
  dataSource: MatTableDataSource<InterServiceMark> = new MatTableDataSource();

  selection = new SelectionModel<InterServiceMark>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private InterServiceMarkService: InterServiceMarkService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getInterServiceMarks();
  }
  
  getInterServiceMarks() {
    this.isLoading = true;
    this.InterServiceMarkService.getInterServiceMarks(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
    this.getInterServiceMarks();
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getInterServiceMarks();
  }
  deleteItem(row) {
    const id = row.interServiceMarkId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.InterServiceMarkService.delete(id).subscribe(() => {
          this.getInterServiceMarks();
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
