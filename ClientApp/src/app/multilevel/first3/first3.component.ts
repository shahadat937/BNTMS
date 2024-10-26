import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-first3',
  templateUrl: './first3.component.html',
  styleUrls: ['./first3.component.sass']
})
export class First3Component implements OnInit {

  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
  }

}
