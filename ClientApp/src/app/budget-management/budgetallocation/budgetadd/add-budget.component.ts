// import { CourseBudgetAllocationService } from './../../service/coursebudgetallocation.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from '../../models/BudgetAllocation';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';
import { CourseBudgetAllocationService } from '../../service/courseBudgetAllocation.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-add-budget',
  templateUrl: './add-budget.component.html',
  styleUrls: ['./add-budget.component.css']
})

export class AddBudgetListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  BudgetAllocationForm: FormGroup;
  selectedFiscalYear: SelectedModel[];
  selectedBudgetType: SelectedModel[];
  selectedBudgetCode: SelectedModel[];
  buttonText: string;
  pageTitle: string;
  fiscalYearId: number = 0;
  isLoading = false;
  isShow: boolean = false;
  loading: any;
  validationErrors: any;
  budgetCodeId: number = 0;
  searchText: string = '';
  selectedBudgetCodeName: SelectedModel[];
  budgetCodeName: string;
  totalBudget: any;

  paging = {
    pageIndex: 1,
    pageSize: 10,
    length: 1
  };
  
  displayedColumns: string[] = ['ser','budgetCode','budgetType','fiscalYear','amount','actions'];

  dataSource: MatTableDataSource<BudgetAllocation> = new MatTableDataSource();

  constructor(
    private snackBar: MatSnackBar,
    private router: Router,
    private confirmService: ConfirmService,
    private BudgetAllocationService: BudgetAllocationService,
    private CourseBudgetAllocationService: CourseBudgetAllocationService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('budgetAllocationId');
    this.innitializeForm();
    if (id) {
      this.pageTitle = 'Edit Budget Allocation'; 
      this.buttonText= "Update" 
      this.BudgetAllocationService.find(+id).subscribe(res => {
        this.BudgetAllocationForm.patchValue({
          fiscalYearId: res.fiscalYearId,
          budgetTypeId: res.budgetTypeId,
          amount: +res.amount,
          budgetAllocationId: id ,
          budgetCodeName: res.budgetCodeName,
          budgetCodeId: res.budgetCodeId,
        });
      });
    } else {
      this.pageTitle = 'Create Budget';
      this.buttonText = 'Save';
    }
    this.getselectedFiscalYear();
    this.getselectedBudgetType();
    this.getselectedBudgetCode();
    this.getBudgetAllocations();
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

  getBudgetAllocations() {
    this.isLoading = true;
    console.log(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.fiscalYearId)
    this.BudgetAllocationService.getBudgetAllocations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.fiscalYearId).subscribe(response => {
      console.log(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.fiscalYearId)
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
 }

  onFiscalYearSelectionChange(dropdown){
    if (dropdown.isUserInput) {
      this.isShow=true;
       this.fiscalYearId=dropdown.source.value;
       this.getBudgetAllocations();
     }
  }

  onBudgetCodeSelectionChange(dropdown){
    if (dropdown.isUserInput) {
     this.budgetCodeId = dropdown.source.value;
     this.getBudgetAllocations();
      this.BudgetAllocationService.getSelectedBudgetCodeNameByBudgetCodeId(dropdown.source.value).subscribe(res=>{
        this.selectedBudgetCodeName=res
        this.budgetCodeName = res[0].text;
        this.BudgetAllocationForm.get('budgetCodeName').setValue(this.budgetCodeName);
      });
    }
  } 

  onBudgetTypeChange(dropdown){
  if (dropdown.isUserInput) {
    var budgetCodeId = dropdown.source.value; 

    this.BudgetAllocationForm.get('budgetCodeId').setValue(budgetCodeId);

    this.BudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
    this.totalBudget=res[0].text; 
   });
  }
}

  getselectedFiscalYear() {
    this.BudgetAllocationService.getselectedFiscalYear().subscribe(res => {
      this.selectedFiscalYear = res;
    });
  }
  getselectedBudgetCode(){
    this.CourseBudgetAllocationService.getselectedBudgetCode().subscribe(res=>{
      this.selectedBudgetCode=res
      
    });
  }

  getselectedBudgetType() {
    this.BudgetAllocationService.getselectedBudgetType().subscribe(res => {
      this.selectedBudgetType = res;
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  deleteItem(row) {
    const id = row.budgetAllocationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BudgetAllocationService.delete(id).subscribe(() => {
        this.reloadCurrentRoute();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
    
  }

  onSubmit() {
    const id = this.BudgetAllocationForm.get('budgetAllocationId').value;
   
    if (id) {
      this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
        if (result) {
          this.loading = false;
          this.BudgetAllocationService.update(+id, this.BudgetAllocationForm.value).subscribe(response => {
           
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
        
 
        this.reloadCurrentRoute();
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
