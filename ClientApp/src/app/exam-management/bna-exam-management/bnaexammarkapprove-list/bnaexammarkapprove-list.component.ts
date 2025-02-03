import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-bnaexammarkapprove-list',
  templateUrl: './bnaexammarkapprove-list.component.html',
  styleUrls: ['./bnaexammarkapprove-list.component.sass']
})
export class BnaexammarkapproveListComponent implements OnInit {

  
  pageTitle : string;
  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.pageTitle = 'BNA Exam Mark Approve';
  }

}
