import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from '../../models/BudgetAllocation';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-add-budget',
  templateUrl: './add-budget.component.html',
  styleUrls: ['./add-budget.component.css']
})

export class AddBudgetListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  BudgetAllocationForm: FormGroup;
  selectedFiscalYear: SelectedModel[];
  selectedBudgetType: SelectedModel[];
  buttonText: string;
  pageTitle: string;
  fiscalYearId: any;
  isLoading = false;
  isShow: boolean = false;
  loading: any;
  validationErrors: any;

  paging = {
    pageIndex: 10,
    pageSize: 10,
    length: 1
  };
  

  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private confirmService: ConfirmService,
    private BudgetAllocationService: BudgetAllocationService,
    private fb: FormBuilder,
    private route: ActivatedRoute
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('budgetAllocationId');

    if (id) {
      this.BudgetAllocationService.find(+id).subscribe(res => {
        this.BudgetAllocationForm.patchValue({
          fiscalYearId: res.fiscalYearId,
          budgetTypeId: res.budgetTypeId,
          amount: +res.amount,
          budgetAllocationId: id ,
          
        });
      });
    } else {
      this.pageTitle = 'Create Budget';
      this.buttonText = 'Save';
    }

    this.innitializeForm();
    this.getselectedFiscalYear();
    this.getselectedBudgetType();
  }

  innitializeForm() {
    this.BudgetAllocationForm = this.fb.group({
      budgetAllocationId: [0],
      budgetCodeId:[''],
      budgetTypeId:[],
      fiscalYearId:[],
      budgetCodeName:[''],
      percentage:[''],
      amount:[''],
      remarks:[''],
      menuPosition:[],
      isActive: [true],
    });
  }
  onFiscalYearSelectionChange(dropdown){
    if (dropdown.isUserInput) {
      this.isShow=true;
       this.fiscalYearId=dropdown.source.value;
        
     }
  }

  getselectedFiscalYear() {
    this.BudgetAllocationService.getselectedFiscalYear().subscribe(res => {
      this.selectedFiscalYear = res;
    });
  }

  getselectedBudgetType() {
    this.BudgetAllocationService.getselectedBudgetType().subscribe(res => {
      this.selectedBudgetType = res;
    });
  }

  onSubmit() {
    const id = this.BudgetAllocationForm.get('budgetAllocationId').value;
    console.log(this.BudgetAllocationForm.value)
    if (id) {
      this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BudgetAllocationService.update(+id, this.BudgetAllocationForm.value).subscribe(response => {
            this.router.navigateByUrl('/budget-management/add-budgetallocation');
            this.snackBar.open('Information Updated Successfully', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          });
        }
      });
    } else {
      this.loading = true;
      this.BudgetAllocationService.submit(this.BudgetAllocationForm.value).subscribe(response => {
        console.log(this.BudgetAllocationForm.value)
        this.router.navigateByUrl('/budget-management/budgetallocation-list');
        this.snackBar.open('Information Inserted Successfully', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      });
    }
  }
}
