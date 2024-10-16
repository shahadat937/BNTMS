import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-add-bnaabsentreexammark',
  templateUrl: './add-bnaabsentreexammark.component.html',
  styleUrls: ['./add-bnaabsentreexammark.component.sass']
})
export class AddBnaabsentreexammarkComponent implements OnInit {

  pageTitle : string;
  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Absent Exam Mark';
  }

}
