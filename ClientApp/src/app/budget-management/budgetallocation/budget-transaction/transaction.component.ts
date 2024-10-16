import { ConfirmService } from './../../../core/service/confirm.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from 'src/app/foreign-training/models/BudgetAllocation';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
// import { id } from '@swimlane/ngx-datatable';
import { AdminAuthorityService } from 'src/app/basic-setup/service/AdminAuthority.service';
import { UTOfficerCategoryService } from 'src/app/basic-setup/service/UTOfficerCategory.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseBudgetAllocationService } from '../../service/courseBudgetAllocation.service';
import { CourseWeekService } from 'src/app/course-management/service/CourseWeek.service';
import { CourseBudgetAllocation } from '../../models/courseBudgetAllocation';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute } from '@angular/router';



@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class BudgetTransaction implements OnInit {
    selectFiscalYear: SelectedModel[];
    selectedBudgetType: SelectedModel[];
    SelectAuthority: SelectedModel[];
    CourseBudgetAllocationForm: FormGroup;
    budgetCodeId: any;
    buttonText: string;
    pageTitle: string;
    selectDeskOfficer: SelectedModel[];
    SelectedCourse: SelectedModel[];
    paging = {
        pageIndex: 10,
        pageSize: 10,
        length: 1
      };
    isShow: any;
    loading: any;
    validationErrors: any;
    totalBudget: any;
    ELEMENT_DATA: CourseBudgetAllocation[] = [];

    dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();
    selection = new SelectionModel<CourseBudgetAllocation>(true, []);
      

  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, private CourseWeekService: CourseWeekService, private route: ActivatedRoute) {
   
  }

  ngOnInit(): void {

    this.initializeForm()
    const id = this.route.snapshot.paramMap.get('budgetAllocationId');
    if(id){
      this.CourseBudgetAllocationService.find(+id).subscribe(res =>{
        this.CourseBudgetAllocationForm.patchValue({
         budgetCodeId: res.budgetCodeId,
          // budgetTypeId: res.budgetTypeId,
          

        })
      })
    }else {
      this.pageTitle = 'Create Budget';
      this.buttonText = 'Save';
    }
    this.getSelectAuthority();
    this.getselectedBudgetType();
   
    }
initializeForm(){
  this.CourseBudgetAllocationForm = this.fb.group({
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
  })
}

   getSelectAuthority(){
    this.AdminAuthorityService.getselectedAdminAuthorities().subscribe(res =>{
        this.SelectAuthority = res;
    })
   }
  //  onBudgetCodeSelectionChange(dropdown){
  //   if (dropdown.isUserInput) {
  //      var budgetCodeId = dropdown.source.value.value; 
  //      this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
  //      this.totalBudget=res[0].text; 
  //     });

  //    }
  // }
  onBudgetCodeSelectionChange(dropdown){
    if (dropdown.isUserInput) {
       var budgetCodeId = dropdown.source.value.value; 

       this.CourseBudgetAllocationForm.get('budgetCodeId').setValue(budgetCodeId);

       this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
       this.totalBudget=res[0].text; 
      });

     }
  }
  

getselectedcoursename(){
  this.CourseWeekService.getselectedcoursename().subscribe(res=>{
    this.SelectedCourse = res;
  })
}
    getselectedBudgetType() {
        this.CourseBudgetAllocationService.getselectedBudgetType().subscribe(res => {
          this.selectedBudgetType = res;
        });
      }

      reloadCurrentRoute() {
        let currentUrl = this.router.url;
        this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
            this.router.navigate([currentUrl]);
        });
      }
     onSubmit() {
    const id = this.CourseBudgetAllocationForm.get('budgetAllocationId').value;
    console.log(this.CourseBudgetAllocationForm.value)
    if (id) {
      this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
        console.log('add')
        if (result) {
          console.log('add')
          this.loading = true;
          this.CourseBudgetAllocationService.update(+id, this.CourseBudgetAllocationForm.value).subscribe(response => {
            // this.router.navigateByUrl('/budget-management/transaction-type');
            // this.router.navigate(['/budget-management/transaction-type'], { queryParams: { amount: this.BudgetAllocationForm.get('amount').value } });
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
      this.loading = true;
      this.CourseBudgetAllocationService.submit(this.CourseBudgetAllocationForm.value).subscribe(response => {
        console.log(this.CourseBudgetAllocationForm.value)
        // this.router.navigateByUrl('/budget-management/transaction-type');
        // this.router.navigate(['/budget-management/transaction-type'], { queryParams: { amount: this.BudgetAllocationForm.get('amount').value } });

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



