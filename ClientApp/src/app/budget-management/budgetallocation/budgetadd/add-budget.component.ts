// import { BudgetAllocation } from './../../../foreign-training/models/budgetallocation';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input'
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from '../../models/BudgetAllocation';

@Component({

  selector: 'app-add-budget',
  templateUrl: './add-budget.component.html',
  styleUrls: ['./add-budget.component.css']
  
})



export class AddBudgetListComponent implements OnInit {

  BudgetAllocationForm : FormGroup;
  selectedFiscalYear: SelectedModel[];
  selectFiscalYear: SelectedModel[];
  selectedAmmount: SelectedModel[];
  selectedBudgetType: SelectedModel[];
  buttonText:string;
  pageTitle: string;
  destination:string;

  ELEMENT_DATA: BudgetAllocation[] = [];
  isLoading = false;
  
  masterData: any;
loading: any;
  
  constructor( private router: Router, private confirService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private fb:FormBuilder, private route: ActivatedRoute) {

}
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('budgetAllocationId')

    if(id){
      this.BudgetAllocationService.find(+id).subscribe(
        res=>{
          this.BudgetAllocationForm.patchValue(
            {
              fiscalYearId: res.fiscalYearId,
              budgetType: res.budgetTypeId
            }
          )
        }
      )
    }
    else{
      this.pageTitle =  'Create title';
      this.buttonText = 'Save';
      this.destination = "Next Page"
    }
    this.innitializeForm();
    this.getselectedFiscalYear();
    this.getselectedBudgetType();
  }

  innitializeForm(){
    this.BudgetAllocationForm = this.fb.group({
      fiscalYearId: [],
      budgetTypeId: [],
    })
  }

  getselectedFiscalYear(){
    this.BudgetAllocationService.getselectedFiscalYear().subscribe(res=>{
      this.selectedFiscalYear=res
      this.selectFiscalYear=res
    });
  } 
  getselectedBudgetType(){
    this.BudgetAllocationService.getselectedBudgetType().subscribe(res=>{
      this.selectedBudgetType=res
    });
  } 
  // getBudgetType(){
  //   this.BudgetAllocationService.getBudgetType().subscribe(res=>{
  //     this.selectedBudgetType = res
  //   })
  // }
  onSubmit(){

  }
}
