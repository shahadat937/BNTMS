import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class BudgetTransaction implements OnInit {

  addBudgetForm: FormGroup;

  constructor(private fb: FormBuilder) {
   
  }

  ngOnInit(): void {}

}
