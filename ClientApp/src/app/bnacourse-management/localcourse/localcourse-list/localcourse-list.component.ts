import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration'
import {CourseDurationService} from '../../service/courseduration.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-localcourse-list',
  templateUrl: './localcourse-list.component.html',
  styleUrls: ['./localcourse-list.component.sass']
})
export class LocalcourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  courseTypeId=MasterData.coursetype.LocalCourse;
  groupArrays:{ baseSchoolName: string; courses: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";


  displayedColumns: string[] = ['ser', 'baseSchoolName', 'courseName', 'professional', 'noOfCandidates', 'nbcd', 'durationFrom', 'durationTo', 'remark', 'actions'];

  //displayedColumns: string[] = ['ser','baseSchoolName','courseName', 'professional','nbcd','durationFrom','durationTo', 'remark', 'actions'];

  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


   selection = new SelectionModel<CourseDuration>(true, []);

  
  constructor(private snackBar: MatSnackBar,private CourseDurationService: CourseDurationService,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
     this.getCourseDurationsByCourseType();
  }
  getCourseDurationsByCourseType(){
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseTypeId).subscribe(response => {
      this.dataSource.data = response.items; 


      // this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, courses) => {
        const schoolName = courses.baseSchoolName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((baseSchoolName) => {
        return {
          baseSchoolName,
          courses: groups[baseSchoolName]
        };
      });

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseDurationsByCourseType();
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseDurationsByCourseType();
  } 

  deleteItem(row) {
    const id = row.courseDurationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseDurationService.delete(id).subscribe(() => {
         this.getCourseDurationsByCourseType();
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
