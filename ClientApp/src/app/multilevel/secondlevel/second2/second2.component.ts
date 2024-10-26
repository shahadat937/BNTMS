import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-second2',
  templateUrl: './second2.component.html',
  styleUrls: ['./second2.component.sass']
})
export class Second2Component implements OnInit {

  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
  }

}
