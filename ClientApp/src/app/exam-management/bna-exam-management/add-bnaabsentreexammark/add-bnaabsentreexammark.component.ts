import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-bnaabsentreexammark',
  templateUrl: './add-bnaabsentreexammark.component.html',
  styleUrls: ['./add-bnaabsentreexammark.component.sass']
})
export class AddBnaabsentreexammarkComponent implements OnInit {

  pageTitle : string;
  constructor() { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Absent Exam Mark';
  }

}
