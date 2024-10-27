import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CourseName } from '../../models/CourseName';
import { CourseNameService } from '../../service/CourseName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-CourseName',
  templateUrl: './coursename-list.component.html',
  styleUrls: ['./coursename-list.component.sass']
})
export class CourseNameListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseName[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'ser', 'course','courseTypeName','shortName', 'courseSyllabus', 'actions'];
  dataSource: MatTableDataSource<CourseName> = new MatTableDataSource();

  selection = new SelectionModel<CourseName>(true, []);
  
  constructor(
    private snackBar: MatSnackBar,
    private CourseNameService: CourseNameService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getCourseNames();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }
 
  getCourseNames() {
    this.isLoading = true;
    this.CourseNameService.getCourseNames(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
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
    this.getCourseNames();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.toLowerCase().trim();
    this.getCourseNames();
  } 

  deleteItem(row) {
    const id = row.courseNameId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      if (result) {
        this.CourseNameService.delete(id).subscribe(() => {
          this.getCourseNames();
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
