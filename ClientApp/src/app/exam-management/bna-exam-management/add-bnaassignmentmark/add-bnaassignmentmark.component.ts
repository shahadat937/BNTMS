import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-bnaassignmentmark',
  templateUrl: './add-bnaassignmentmark.component.html',
  styleUrls: ['./add-bnaassignmentmark.component.sass']
})
export class AddBnaassignmentmarkComponent implements OnInit {

  
  pageTitle : string;
  constructor() { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Assignment Mark';
  }

}
