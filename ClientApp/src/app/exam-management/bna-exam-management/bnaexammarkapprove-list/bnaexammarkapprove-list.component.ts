import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-bnaexammarkapprove-list',
  templateUrl: './bnaexammarkapprove-list.component.html',
  styleUrls: ['./bnaexammarkapprove-list.component.sass']
})
export class BnaexammarkapproveListComponent implements OnInit {

  
  pageTitle : string;
  constructor() { }

  ngOnInit(): void {
    this.pageTitle = 'BNA Exam Mark Approve';
  }

}
