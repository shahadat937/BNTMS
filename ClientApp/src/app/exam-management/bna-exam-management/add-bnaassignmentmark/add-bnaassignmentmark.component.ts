import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-add-bnaassignmentmark',
  templateUrl: './add-bnaassignmentmark.component.html',
  styleUrls: ['./add-bnaassignmentmark.component.sass']
})
export class AddBnaassignmentmarkComponent implements OnInit {

  
  pageTitle : string;
  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Assignment Mark';
  }

}
