import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add-bnareexam',
  templateUrl: './add-bnareexam.component.html',
  styleUrls: ['./add-bnareexam.component.sass']
})
export class AddBnareexamComponent implements OnInit {

  
  pageTitle : string;
  constructor() { }

  ngOnInit(): void {
    this.pageTitle = 'Create Re-Exam Mark';
  }

}
