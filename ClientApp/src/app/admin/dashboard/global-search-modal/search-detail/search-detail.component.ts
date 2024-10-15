import { ChangeDetectionStrategy, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { GlobalSearchService } from '../../services/global-search.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-search-detail',
  templateUrl: './search-detail.component.html',
  styleUrls: ['./search-detail.component.sass'],

})
export class SearchDetailComponent implements OnInit, OnDestroy {

  @Input() Payload: any ;
  IsExpanded : boolean
  subscription: Subscription = new Subscription();
  detailedData: any;
  loading:boolean;
  constructor(
    private globalSearchService: GlobalSearchService
  ) { 
    this.IsExpanded = false;
    this.Payload = null;
    this.loading = false;
  }

  ngOnInit(): void {
  }

  ngOnDestroy(): void {
    if(this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  setPanelStatus(panelStatus:boolean) {
    this.IsExpanded = panelStatus;
  }

  getSearchTag() {
    if(this.Payload==null) {
      return "Instructor";
    } else if(this.Payload.Type=="Trainee") {
      return "Student";
    } else if(this.Payload.Type=="Instructor") {
      return "Instructor";
    } else if(this.Payload.Type=="Course") {
      return "Course";
    }
  }

  getPanelTitle() {
    if(this.Payload.Type=="Trainee"||this.Payload.Type=="Instructor") {
      return this.Payload.Name + ` (${this.Payload.Pno})`;
    } else {
      return this.Payload.Course + ` (${this.Payload.CourseTitle})`;
    }
  }

  getCourseStatus() {

    const from = new Date(this.Payload.DurationFrom);
    const to = new Date(this.Payload.DurationTo);
    const curDate = new Date();
    if(curDate>=from&&curDate<=to) {
      return 0; // running course
    } else if(to<curDate) {
      return -1; // previous course
    } else {
      return 1; // upcoming course
    }
  }
}
