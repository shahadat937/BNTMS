import { Component, OnInit } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-add-bnareexam',
  templateUrl: './add-bnareexam.component.html',
  styleUrls: ['./add-bnareexam.component.sass']
})
export class AddBnareexamComponent implements OnInit {

  
  pageTitle : string;
  constructor(public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.pageTitle = 'Create Re-Exam Mark';
  }

}
