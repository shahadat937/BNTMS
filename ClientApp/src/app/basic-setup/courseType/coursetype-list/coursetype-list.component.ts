import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseType} from '../../models/CourseType';
import {CourseTypeService} from '../../service/CourseType.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-coursetype-list',
  templateUrl: './coursetype-list.component.html',
  styleUrls: ['./coursetype-list.component.sass']
})
export class CoursetypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'sl','courseTypeName','isActive', 'actions'];
  dataSource: MatTableDataSource<CourseType> = new MatTableDataSource();

  selection = new SelectionModel<CourseType>(true, []);

  
  constructor(
    private snackBar: MatSnackBar,
    private CourseTypeService:CourseTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getCourseTypes();

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
  
  getCourseTypes() {
    this.isLoading = true;
    this.CourseTypeService.getCourseTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getCourseTypes();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim();
    this.getCourseTypes();
  } 
  deleteItem(row) {
    const id = row.courseTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) { 
        this.CourseTypeService.delete(id).subscribe(() => {
          this.getCourseTypes();
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
