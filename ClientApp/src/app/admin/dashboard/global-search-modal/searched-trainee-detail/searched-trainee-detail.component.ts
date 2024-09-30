import { Component, Input, OnInit } from '@angular/core';
import { GlobalSearchService } from '../../services/global-search.service';
import { nextSortDir } from '@swimlane/ngx-datatable';

@Component({
  selector: 'app-searched-trainee-detail',
  templateUrl: './searched-trainee-detail.component.html',
  styleUrls: ['./searched-trainee-detail.component.sass']
})
export class SearchedTraineeDetailComponent implements OnInit {
  @Input() Payload: any;
  constructor(
    private globalSearchService: GlobalSearchService
  ) { 
    this.Payload = null; 
  }

  ngOnInit(): void {
    this.getTraineeDetail();
  }

  getTraineeDetail() {
    console.log("Hello World");
    this.globalSearchService.getTraineeDetail(this.Payload.TraineeId).subscribe({
      next: response => {
        console.log(response);
      }
    })
  }

}
