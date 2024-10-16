import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-first2',
  templateUrl: './first2.component.html',
  styleUrls: ['./first2.component.sass']
})
export class First2Component implements OnInit {

  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
  }

}
