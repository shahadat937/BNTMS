import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-second1',
  templateUrl: './second1.component.html',
  styleUrls: ['./second1.component.sass']
})
export class Second1Component implements OnInit {

  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
  }

}
