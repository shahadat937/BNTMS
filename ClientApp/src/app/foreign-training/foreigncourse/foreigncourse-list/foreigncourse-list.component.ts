import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CourseDuration } from '../../models/courseduration'
import { CourseDurationService } from '../../service/courseduration.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-foreigncourse-list',
  templateUrl: './foreigncourse-list.component.html',
  styleUrls: ['./foreigncourse-list.component.sass']
})
export class ForeigncourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  dayCount: any;
  courseTypeId = MasterData.coursetype.ForeignCourse;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['ser', 'courseTitle', 'courseName', 'durationTo', 'country', 'dayCount', 'actions'];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


  selection = new SelectionModel<CourseDuration>(true, []);


  constructor(private snackBar: MatSnackBar, private CourseDurationService: CourseDurationService, private router: Router, private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.isAllPassingOutCourseComplete();
    this.getCourseDurationsByCourseType();
  }
  getCourseDurationsByCourseType() {
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseTypeId(this.paging.pageIndex, this.paging.pageSize, this.searchText, this.courseTypeId).subscribe(response => {
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
  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getCourseDurationsByCourseType();
  }

  getDaysfromDate(dateFrom: any, dateTo: any) {
    //Date dateTime11 = Convert.ToDateTime(dateFrom);  
    var date1 = new Date(dateFrom);
    var date2 = new Date(dateTo);
    var Time = date2.getTime() - date1.getTime();
    var Days = Time / (1000 * 3600 * 24);
    this.dayCount = Days + 1;
    return this.dayCount;
  }

  isAllPassingOutCourseComplete() {
    this.CourseDurationService.isAllpassingOutCourseCompleted(this.courseTypeId).subscribe(res => {
      if (res === false) {
        this.CourseDurationService.makeAllPassingOutCourseComplete(this.courseTypeId).subscribe(res => {

        })
      }
    })

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

