import { Component, OnInit, OnDestroy, AfterViewInit, ViewChild } from '@angular/core';
import { Subject } from 'rxjs';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CourseDuration } from '../../models/courseduration';
import { CourseDurationService } from '../../service/courseduration.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router, NavigationEnd, ActivatedRoute, RouterEvent } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { DatePipe } from '@angular/common';
import { dashboardService } from 'src/app/admin/dashboard/services/dashboard.service';

import { ScrollService } from 'src/app/course-management/bnalocalcourse/scroll-position.service';
import { filter, takeUntil } from 'rxjs/operators';

@Component({
  selector: 'app-bnalocalcourse-list',
  templateUrl: './bnalocalcourse-list.component.html',
  styleUrls: ['./bnalocalcourse-list.component.sass']
})
export class BnaLocalcourseListComponent implements OnInit, OnDestroy, AfterViewInit {
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  fileUrl = environment.fileUrl;
  courseTypeId = MasterData.coursetype.LocalCourse;
  groupArrays: { schoolName: string; courses: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  };
  searchText = '';
  candidateCount: any;
  passOutStatus: any;
  localCourseList: any;

  displayedColumns: string[] = ['ser', 'baseSchoolName', 'courseName', 'professional', 'noOfCandidates', 'nbcd', 'durationFrom', 'durationTo', 'remark', 'actions'];

  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();

  selection = new SelectionModel<CourseDuration>(true, []);

  private destroy$: Subject<void> = new Subject<void>();
  private navigationEnd$: Subject<void> = new Subject<void>();

  @ViewChild('table', { static: false }) table: any;

  constructor(
    private datepipe: DatePipe,
    private dashboardService: dashboardService,
    private snackBar: MatSnackBar,
    private TraineeNominationService: TraineeNominationService,
    private CourseDurationService: CourseDurationService,
    private router: Router,
    private confirmService: ConfirmService,
    private scrollService: ScrollService,
    private activatedRoute: ActivatedRoute
  ) {
    this.router.events.pipe(
      filter((event: RouterEvent) => event instanceof NavigationEnd),
      takeUntil(this.destroy$)
    ).subscribe(() => {
      this.saveScrollPosition();
    });
  }

  ngOnInit() {
    this.getCourseDurationFilterList(1);
  }

  ngOnDestroy(): void {
    this.destroy$.next();
    this.destroy$.complete();
  }

  ngAfterViewInit(): void {
    this.restoreScrollPosition();
  }

  private saveScrollPosition(): void {
    const scrollPosition = window.scrollY || document.documentElement.scrollTop || 0;
    const url = this.router.url + this.activatedRoute.snapshot.url.map(segment => `/${segment.path}`).join('');
    this.scrollService.saveScrollPosition(url, scrollPosition);

    // Save to history.state
    const state = { ...window.history.state, scrollPosition };
    this.router.navigateByUrl(this.router.url, { state });
  }

  private restoreScrollPosition(): void {
    const url = this.router.url + this.activatedRoute.snapshot.url.map(segment => `/${segment.path}`).join('');
    const savedPosition = this.scrollService.getScrollPosition(url);

    if (savedPosition !== null) {
      window.scrollTo({ top: savedPosition, behavior: 'smooth' });
    } else {
      // If no saved position, check history.state
      const state = window.history.state;
      if (state && state.scrollPosition) {
        window.scrollTo({ top: state.scrollPosition, behavior: 'smooth' });
      }
    }
  }

  getCoursesByViewType(viewStatus) {
    if (viewStatus === 1) {
      this.getCourseDurationFilterList(viewStatus);
    } else if (viewStatus === 2) {
      this.getCourseDurationFilterList(viewStatus);
    } else if (viewStatus === 3) {
      let currentDateTime = this.datepipe.transform(new Date(), 'MM/dd/yyyy');
      this.dashboardService.getUpcomingCourseListForBnaByBase(currentDateTime, 0).subscribe(response => {
        this.localCourseList = response;
        const groups = this.localCourseList.reduce((groups, courses) => {
          const schoolName = courses.schoolName;
          if (!groups[schoolName]) {
            groups[schoolName] = [];
          }
          groups[schoolName].push(courses);
          return groups;
        }, {});
        this.groupArrays = Object.keys(groups).map(schoolName => {
          return {
            schoolName,
            courses: groups[schoolName]
          };
        });
      });
    }
    this.saveScrollPosition();
  }

  getCourseDurationFilterList(viewStatus) {
    this.CourseDurationService.getCourseDurationFilterForBna(viewStatus, this.masterData.coursetype.LocalCourse).subscribe(response => {
      this.localCourseList = response;
      const groups = this.localCourseList.reduce((groups, courses) => {
        const schoolName = courses.schoolName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});
      this.groupArrays = Object.keys(groups).map(schoolName => {
        return {
          schoolName,
          courses: groups[schoolName]
        };
      });
    });
  }

  getDateComparision(obj) {
    var currentDate = this.datepipe.transform(new Date(), 'MM/dd/yyyy');
    var current = new Date(currentDate);
    var date2 = new Date(obj.durationTo);

    if (current > date2) {
      this.passOutStatus = 1;
    } else {
      this.passOutStatus = 0;
    }
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.saveScrollPosition();
  }

  deleteItem(row) {
    const id = row.courseDurationId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseDurationService.delete(id).subscribe(() => {
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        });
      }
    });
  }
}
