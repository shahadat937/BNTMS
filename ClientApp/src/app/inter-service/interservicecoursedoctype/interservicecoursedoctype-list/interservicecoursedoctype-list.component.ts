import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { InterServiceCourseDocType } from '../../models/InterServiceCourseDocType';
import { InterServiceCourseDocTypeService } from '../../service/InterServiceCourseDocType.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-interservicecoursedoctype-list',
  templateUrl: './interservicecoursedoctype-list.component.html',
  styleUrls: ['./interservicecoursedoctype-list.component.sass']
})
export class InterServiceCourseDocTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: InterServiceCourseDocType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','name', 'actions'];
  dataSource: MatTableDataSource<InterServiceCourseDocType> = new MatTableDataSource();

  selection = new SelectionModel<InterServiceCourseDocType>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private InterServiceCourseDocTypeService: InterServiceCourseDocTypeService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getInterServiceCourseDocTypes();
  }
  
  getInterServiceCourseDocTypes() {
    this.isLoading = true;
    this.InterServiceCourseDocTypeService.getInterServiceCourseDocTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getInterServiceCourseDocTypes();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getInterServiceCourseDocTypes();
  } 


  deleteItem(row) {
    const id = row.interServiceCourseDocTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      if (result) {
        this.InterServiceCourseDocTypeService.delete(id).subscribe(() => {
          this.getInterServiceCourseDocTypes();
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
