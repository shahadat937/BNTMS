import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-first1',
  templateUrl: './first1.component.html',
  styleUrls: ['./first1.component.sass']
})
export class First1Component implements OnInit {

  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
  }

}
