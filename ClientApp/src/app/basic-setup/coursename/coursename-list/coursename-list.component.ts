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
 

@Component({
  selector: 'app-CourseName',
  templateUrl: './coursename-list.component.html',
  styleUrls: ['./coursename-list.component.sass']
})
export class CourseNameListComponent implements OnInit {

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

  displayedColumns: string[] = [ 'ser', 'course','courseTypeName','shortName', 'courseSyllabus', 'actions'];
  dataSource: MatTableDataSource<CourseName> = new MatTableDataSource();

  selection = new SelectionModel<CourseName>(true, []);
  
  constructor(private snackBar: MatSnackBar,private CourseNameService: CourseNameService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.getCourseNames();
  }
 
  getCourseNames() {
    this.isLoading = true;
    this.CourseNameService.getCourseNames(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseNames();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
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
