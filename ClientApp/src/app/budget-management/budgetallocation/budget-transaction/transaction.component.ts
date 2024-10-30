// import { BudgetTransaction } from './../../models/budgettransaction';
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
import { CourseGradingEntryService } from 'src/app/basic-setup/service/CourseGradingEntry.service';
import { PageEvent } from '@angular/material/paginator';


@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})

export class BudgetTransaction extends UnsubscribeOnDestroyAdapter implements OnInit {

  masterData = MasterData;
    selectFiscalYear: SelectedModel[];
    selectedBudgetType: SelectedModel[];
    selectedBudgetCode: SelectedModel[];
    SelectAuthority: SelectedModel[];
    selectedPaymentType: SelectedModel[];
    BudgetTransactionForm: FormGroup;
    courseNameId: number=0;
    budgetCodeId:number=0;
    courseName: number = 0;
    deskAuthorityName: string;
    fiscalYearId: number = 0;
    buttonText: string;
    pageTitle: string;
    selectDeskOfficer: SelectedModel[];
    SelectedCourse: SelectedModel[];
    paging = {
      pageIndex: this.masterData.paging.pageIndex,
      pageSize: this.masterData.paging.pageSize,
      length: 1
    }
    searchText: string='';
    isShow: boolean = false;
    loading: any;
    validationErrors: any;
    deskAuthority: number = 0;
    
    selectedCourseDuration: SelectedModel[];
    totalBudget: any;
    isLoading = false;

    displayedColumns: string[] = ['ser','dateCreated','budgetCodeName','amount','actions'];

    dataSource: MatTableDataSource<BudgetTransaction> = new MatTableDataSource();
    
    CourseBudgetAllocation: any;
   budgetTypeId: number=0;
   budgetCodeName: string;
   selectedBudgetCodeName: SelectedModel[];
   selectedCourseNames: SelectedModel[];
  destination: string;
 
  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, private CourseWeekService: CourseWeekService, private route: ActivatedRoute, public sharedService: SharedServiceService, private BudgetTransactionService: BudgetTransactionService, private CourseGradingEntryService: CourseGradingEntryService) {
   super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('budgetTransactionId');
    this.initializeForm()
    if(id){
      this.pageTitle = 'Edit Budget Transaction'; 
      this.destination = "Edit"; 
      this.buttonText= "Update"
      this.BudgetTransactionService.find(+id).subscribe(res =>{
        this.BudgetTransactionForm.patchValue({
          budgetTransactionId: res.budgetTransactionId,
          fiscalYearId: res.fiscalYearId,
          budgetTypeId: res.budgetTypeId,
          amount: +res.amount,
          budgetCodeName: res.budgetCodeName,
          budgetCodeId: res.budgetCodeId,
          couresName: +res.courseName,
          deskAuthorityName: res.deskAuthorityName,
         
        })
      })
    }else {
      this.pageTitle = 'Create Budget Transaction';
      this.destination = "Add"; 
      this.buttonText= "Save";
    }
    this.getSelectAuthority();
    this.getSelecetedBudgetType();
    this.getselectedBudgetCode();
    // this.getSelectedCourseDurationByCourseTypeId();
    this.getselectedCourseNames();
    this.getBudgetTransaction();

    }
initializeForm(){
  this.BudgetTransactionForm = this.fb.group({
    budgetTransactionId: [0],
      budgetCodeId: [''],
      budgetTypeId:[],
      courseName: [0],
      fiscalYearId:[''],
      adminAuthority: [''],
      deskAuthority: [''],
      amount:[''],
      budgetCodeName:[''],
      dateCreated:[''],
      menuPosition:[''],
      deskAuthorityName:[''],
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
  


getselectedCourseNames(){
  this.CourseGradingEntryService.getselectedCourseNames().subscribe(res=>{
    this.selectedCourseNames=res
   
  });
}



onBudgetTypeChange(dropdown){
  if (dropdown.isUserInput) {
    var budgetCodeId = dropdown.source.value; 

    this.BudgetTransactionForm.get('budgetCodeId').setValue(budgetCodeId);

    this.BudgetTransactionService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
    this.totalBudget=res[0].text; 
    console.log(this.totalBudget)
   });
  }
}


onBudgetCodeSelectionChange(dropdown) {
  if (dropdown.isUserInput) {
    this.budgetCodeId = dropdown.source.value;
    this.getBudgetTransaction(); 
    this.BudgetTransactionService.getSelectedBudgetCodeNameByBudgetCodeId(dropdown.source.value).subscribe(res => {
      this.selectedBudgetCodeName = res;
      this.budgetCodeName = res[0].text;
      
      this.BudgetTransactionForm.get('budgetCodeName').setValue(this.budgetCodeName);
      
    });
  }
}





getBudgetTransaction() {
  this.isLoading = true;

  this.BudgetTransactionService.getBudgetTransaction(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.budgetTypeId).subscribe(response => {
    console.log(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.budgetTypeId)
    this.dataSource.data = response.items; 
    this.paging.length = response.totalItemsCount;    
    this.isLoading = false;
  });
}


onBudgetChange(dropdown){
  console.log("hello")
  if (dropdown.isUserInput) {
    this.isShow=true;
     this.budgetTypeId=dropdown.source.value;
     this.getBudgetTransaction();
     console.log('budget type',this.budgetTypeId)
   }
   
}

onFiscalYearSelectionChange(dropdown){
  if (dropdown.isUserInput) {
    this.isShow=true;
     this.budgetTypeId=dropdown.source.value;
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

      // pageChanged(event: PageEvent) {
  
      //   this.paging.pageIndex = event.pageIndex
      //   this.paging.pageSize = event.pageSize
      //   this.paging.pageIndex = this.paging.pageIndex + 1
      //   this.getBudgetTransaction();
     
      // }
      pageChanged(event: PageEvent) {
        this.paging.pageIndex = event.pageIndex; // Directly set the pageIndex without incrementing
        this.paging.pageSize = event.pageSize;
        this.getBudgetTransaction();
      }
      

      deleteItem(row) {
        const id = row.budgetTransactionId; 
        this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
          if (result) {
            this.BudgetAllocationService.delete(id).subscribe(() => {
            //  this.getBudgetAllocations();
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
  const id = this.BudgetTransactionForm.get('budgetTransactionId').value;
  
  if (id) {
    this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
      if (result) {
        this.loading = false;
        this.BudgetTransactionService.update(+id, this.BudgetTransactionForm.value).subscribe(response => {
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
    this.loading = false;
   
    this.BudgetTransactionService.submit(this.BudgetTransactionForm.value).subscribe(response => { 
      console.log('on submit - budget transaction', this.BudgetTransactionForm.value, response)
      
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



