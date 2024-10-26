import { BudgetTransactionService } from './../../service/budgettransaction.service';
// import { BudgetAllocation } from './../../../foreign-training/models/budgetallocation';
import { ConfirmService } from './../../../core/service/confirm.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
// import { BudgetAllocation } from 'src/app/foreign-training/models/BudgetAllocation';
import { BudgetAllocation } from '../../models/BudgetAllocation';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
import { AdminAuthorityService } from 'src/app/basic-setup/service/AdminAuthority.service';
import { UTOfficerCategoryService } from 'src/app/basic-setup/service/UTOfficerCategory.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseBudgetAllocationService } from '../../service/courseBudgetAllocation.service';
import { CourseWeekService } from 'src/app/course-management/service/CourseWeek.service';
import { CourseBudgetAllocation } from '../../models/courseBudgetAllocation';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';


@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})

export class BudgetTransaction extends UnsubscribeOnDestroyAdapter implements OnInit {
    selectFiscalYear: SelectedModel[];
    selectedBudgetType: SelectedModel[];
    selectedBudgetCode: SelectedModel[];
    SelectAuthority: SelectedModel[];
    selectedPaymentType: SelectedModel[];
    // CourseBudgetAllocationForm: FormGroup;
    // BudgetAllocationForm: FormGroup;
    BudgetTransactionForm: FormGroup;
    courseNameId: number=0;
    budgetCodeId:number=0;
    paymentTypeId: number=0;
   
    buttonText: string;
    pageTitle: string;
    selectDeskOfficer: SelectedModel[];
    SelectedCourse: SelectedModel[];
    paging = {
        pageIndex: 1,
        pageSize: 10,
        length: 1
      };
    searchText: string='';
    isShow: any;
    loading: any;
    validationErrors: any;
    deskAuthority: any;
    // traineeId: number=0;
    selectedCourseDuration: SelectedModel[];
    totalBudget: any;
    targetAmount: any;
    deskId: any;
    ELEMENT_DATA: CourseBudgetAllocation[] = [
      
    ];
    isLoading = false;

    displayedColumns: string[] = ['ser','budgetCode','budgetType','installmentAmount'];

    dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();
    
    CourseBudgetAllocation: any;
   budgetTypeId: any;

      

  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, private CourseWeekService: CourseWeekService, private route: ActivatedRoute, public sharedService: SharedServiceService, private BudgetTransactionService: BudgetTransactionService) {
   super();
  }

  ngOnInit(): void {

    this.initializeForm()
    const id = this.route.snapshot.paramMap.get('budgetTransactionId');
    if(id){
      this.BudgetTransactionService.find(+id).subscribe(res =>{
        this.BudgetTransactionForm.patchValue({
         budgetCodeId: res.budgetCodeId,
         budgetTypeId: res.budgetTypeId,
         
        })
      })
    }else {
      this.pageTitle = 'Create Budget';
      this.buttonText = 'Save';
    }
    this.getSelectAuthority();
    this.getSelecetedBudgetType();
    this.getselectedBudgetCode();
    this.getSelectedCourseDurationByCourseTypeId();
    this.getBudgetTransaction();

    }
initializeForm(){
  this.BudgetTransactionForm = this.fb.group({
    budgetTransactionId: [null],
      budgetCodeId: [''],
      budgetTypeId:[],
      courseName: [''],
      fiscalYearId:[],
      adminAuthority: [''],
      deskAuthority: [''],
      amount:[''],
      dateCreated:[''],
      menuPosition:[],
      isActive: [true],   
  })
}

   getSelectAuthority(){
    this.AdminAuthorityService.getselectedAdminAuthorities().subscribe(res =>{
        this.SelectAuthority = res;
    })
   }
   getselectedBudgetCode(){
    this.CourseBudgetAllocationService.getselectedBudgetCode().subscribe(res=>{
      this.selectedBudgetCode=res
      
    });
  }
  
 getTotalBudgetByBudgetCodeIdRequest(){
  this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(MasterData.coursetype.ForeignCourse).subscribe(res=>{
    this.selectedCourseDuration=res
  });
}

getSelectedCourseDurationByCourseTypeId(){
  this.CourseBudgetAllocationService.getSelectedCourseDurationByCourseTypeId(MasterData.coursetype.ForeignCourse).subscribe(res=>{
    this.selectedCourseDuration=res
   
  });
}


 
  onBudgetCodeSelectionChange(dropdown) {
    if (dropdown.isUserInput) {
        var budgetCodeId = dropdown.source.value; 
        this.getBudgetTransaction();
        this.BudgetTransactionForm.get('budgetCodeId').setValue(budgetCodeId);

        this.BudgetTransactionService.getTargetAmountByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
          this.targetAmount=res[0].text; 
         });
        
    }
}


getBudgetTransaction() {
  this.isLoading = true;
  this.BudgetTransactionService.getBudgetTransaction(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.budgetTypeId).subscribe(response => {
    this.dataSource.data = response.items; 
    console.log(response.items)
    this.paging.length = response.totalItemsCount    
    this.isLoading = false;
  })
}
  
onBudgetChange(dropdown){
  if (dropdown.isUserInput) {
    this.isShow=true;
     this.paymentTypeId=dropdown.source.value;
      this.getBudgetTransaction();
   }
}

getselectedcoursename(){
  this.CourseWeekService.getselectedcoursename().subscribe(res=>{
    this.SelectedCourse = res;
  })
}

    getSelecetedBudgetType(){
      this.BudgetTransactionService.getselectedBudgetType().subscribe(res=>{
        this.selectedBudgetType = res;
      })
    }

      reloadCurrentRoute() {
        let currentUrl = this.router.url;
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this.router.navigate([currentUrl]);
        });
      }

onSubmit() {
  const id = this.BudgetTransactionForm.get('budgetTransactionId')?.value; // Use optional chaining
  console.log(id);

  if (id) {
    // Proceed with the update logic
    this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
      if (result) {
        this.loading = true;
        this.BudgetTransactionService.update(id, this.BudgetTransactionForm.value).subscribe(response => {
          this.router.navigate(['/budget-management/transaction-type'], { queryParams: { installmentAmount: this.BudgetTransactionForm.get('installmentAmount')?.value } });
          this.reloadCurrentRoute();
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
    // Proceed with the create logic
    this.BudgetTransactionService.submit(this.BudgetTransactionForm.value).subscribe(response => {
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



