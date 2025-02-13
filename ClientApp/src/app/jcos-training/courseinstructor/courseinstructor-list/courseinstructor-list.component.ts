import { UnsubscribeOnDestroyAdapter } from './../../../shared/UnsubscribeOnDestroyAdapter';
import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseInstructor} from '../../models/courseinstructor'
import {CourseInstructorService} from '../../service/courseinstructor.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-courseinstructor-list',
  templateUrl: './courseinstructor-list.component.html',
  styleUrls: ['./courseinstructor-list.component.sass']
})
export class CourseInstructorListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseInstructor[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','baseSchoolName','courseName','courseModule','bnaSubjectName','trainee', 'actions'];
  dataSource: MatTableDataSource<CourseInstructor> = new MatTableDataSource();


   selection = new SelectionModel<CourseInstructor>(true, []);

  
  constructor(private snackBar: MatSnackBar,private CourseInstructorService: CourseInstructorService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.getCourseInstructors();
    
  }
 
  getCourseInstructors() {
    this.isLoading = true;
    this.CourseInstructorService.getCourseInstructors(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseInstructors();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseInstructors();
  } 

  deleteItem(row) {
    const id = row.courseInstructorId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseInstructorService.delete(id).subscribe(() => {
          this.getCourseInstructors();
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
