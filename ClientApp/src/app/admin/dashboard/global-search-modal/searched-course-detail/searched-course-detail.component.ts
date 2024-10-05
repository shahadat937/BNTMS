import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { GlobalSearchService } from '../../services/global-search.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-searched-course-detail',
  templateUrl: './searched-course-detail.component.html',
  styleUrls: ['./searched-course-detail.component.sass']
})
export class SearchedCourseDetailComponent implements OnInit, OnDestroy {

  @Input() Payload: any;
  courseDetail: any;
  subscription:Subscription = new Subscription();
  loading: boolean


  constructor(
    private globalSearchService: GlobalSearchService
  ) { 
    this.Payload = null;
    this.courseDetail = null;
    this.loading = false;
  }

  ngOnInit(): void {
    if(this.Payload!=null) {
      this.getCourseDetail();
    }
  }

  ngOnDestroy(): void {
    if(this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getCourseDetail() {
    this.loading = true;
    this.globalSearchService.getCourseDetail(this.Payload.CourseDurationId).subscribe({
      next: response => {
        this.courseDetail = response;
      },
      error: err => {
        this.loading = false;
      },
      complete: () => {
        this.loading = false;
      }
    })
  }

}
