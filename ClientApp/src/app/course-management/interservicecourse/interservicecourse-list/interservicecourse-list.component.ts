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
  selector: 'app-interservicecourse-list',
  templateUrl: './interservicecourse-list.component.html',
  styleUrls: ['./interservicecourse-list.component.sass','./styleinterservice.component.css']
})
export class InterservicecourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  courseTypeId=MasterData.coursetype.InterService;

  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  viewStatus = 1;
  selectedFilter = 1;

  displayedColumns: string[] = ['ser','courseTitle','baseSchoolName','courseName','durationFrom','durationTo', 'actions'];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


   selection = new SelectionModel<CourseDuration>(true, []);

  
  constructor(private snackBar: MatSnackBar,private CourseDurationService: CourseDurationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
     this.getCourseDurationsByCourseType();
  }
  getCourseDurationsByCourseType(){
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseTypeId, this.viewStatus).subscribe(response => {
      this.dataSource.data = response.items; 
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

  getCoursesByViewType(viewStatus){

    if(viewStatus==1){
    //   this.selectedFilter = viewStatus;
    //  this.getCourseDurationFilterList(viewStatus)
    //  this.selectedFilter = 1;
    this.selectedFilter = 1;
    this.viewStatus = 1;
    this.getCourseDurationsByCourseType()
    }
    else if(viewStatus==2){
      // this.selectedFilter = viewStatus;
      // this.getCourseDurationFilterList(viewStatus)
      this.selectedFilter = 2;
      this.viewStatus = 2;
      this.getCourseDurationsByCourseType()
    }
    else if(viewStatus==3){
      // this.selectedFilter = 3;
      // this.selectedFilter = viewStatus;
      // this.getCourseDurationFilterList(viewStatus)
      this.selectedFilter = 3;
      this.viewStatus = 3;
      this.getCourseDurationsByCourseType()
    }
  }
}
