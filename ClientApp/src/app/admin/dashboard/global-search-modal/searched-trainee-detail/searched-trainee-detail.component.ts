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
  columnNames = ["Course", "Action"]
  traineeDetails :any ;
  loading: boolean;

  constructor(
    private globalSearchService: GlobalSearchService
  ) { 
    this.Payload = null; 
    this.traineeDetails = null;
    this.loading = false;
  }

  ngOnInit(): void {
    if(this.Payload!=null) {
      this.getTraineeDetail();
    }
  }

  getTraineeDetail() {
    this.loading = true;
    this.globalSearchService.getTraineeDetail(this.Payload.TraineeId).subscribe({
      next: response => {
        this.traineeDetails = response;
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
