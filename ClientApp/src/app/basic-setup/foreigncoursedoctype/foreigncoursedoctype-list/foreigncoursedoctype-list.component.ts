import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ForeignCourseDocType } from '../../models/ForeignCourseDocType';
import { ForeignCourseDocTypeService } from '../../service/ForeignCourseDocType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-foreigncoursedoctype',
  templateUrl: './foreigncoursedoctype-list.component.html',
  styleUrls: ['./foreigncoursedoctype-list.component.sass']
})
export class ForeignCourseDocTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ForeignCourseDocType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'name','actions'];
  dataSource: MatTableDataSource<ForeignCourseDocType> = new MatTableDataSource();

  selection = new SelectionModel<ForeignCourseDocType>(true, []);
  
  constructor(
    private snackBar: MatSnackBar,
    private ForeignCourseDocTypeService: ForeignCourseDocTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getForeignCourseDocTypes();
  }
 
  getForeignCourseDocTypes() {
    this.isLoading = true;
    this.ForeignCourseDocTypeService.getForeignCourseDocType(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getForeignCourseDocTypes();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getForeignCourseDocTypes();
  } 

  deleteItem(row) {
    const id = row.foreignCourseDocTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.ForeignCourseDocTypeService.delete(id).subscribe(() => {
          this.getForeignCourseDocTypes();
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
