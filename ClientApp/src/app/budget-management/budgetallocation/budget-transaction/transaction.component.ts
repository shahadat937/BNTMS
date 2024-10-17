import { ConfirmService } from './../../../core/service/confirm.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from 'src/app/foreign-training/models/BudgetAllocation';
import { BudgetAllocationService } from '../../service/BudgetAllocation.service';
import { id } from '@swimlane/ngx-datatable';
import { AdminAuthorityService } from 'src/app/basic-setup/service/AdminAuthority.service';
import { UTOfficerCategoryService } from 'src/app/basic-setup/service/UTOfficerCategory.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { CourseBudgetAllocationService } from '../../service/courseBudgetAllocation.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class BudgetTransaction implements OnInit {
    selectFiscalYear: SelectedModel[];
    selectedBudgetType: SelectedModel[];
    SelectAuthority: SelectedModel[];
    BudgetAllocationForm: FormGroup;
    buttonText: string;
    pageTitle: string;
    selectDeskOfficer: SelectedModel[];

    paging = {
        pageIndex: 10,
        pageSize: 10,
        length: 1
      };
isShow: any;
loading: any;
    validationErrors: any;
totalBudget: any;
      

  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, public sharedService: SharedServiceService) {
   
  }

  ngOnInit(): void {

    if(id){
        this.BudgetAllocationService.find(+id).subscribe(res => {
            this.BudgetAllocationForm.patchValue({
              
              budgetTypeId: res.budgetTypeId,
              amount: +res.amount,
              budgetAllocationId: id ,
              
            });
          });
        }else{
            this.pageTitle = 'Create Budget';
            this.buttonText = 'Save';
        } 
        this.getselectedBudgetType();
        this.getSelectAuthority();
        // this.getDeskOfficer();
    }
   getSelectAuthority(){
    this.AdminAuthorityService.getselectedAdminAuthorities().subscribe(res =>{
        this.SelectAuthority = res;
    })
   }
   onBudgetCodeSelectionChange(dropdown){
    if (dropdown.isUserInput) {
       var budgetCodeId = dropdown.source.value.value; 
       this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
       this.totalBudget=res[0].text; 
      });

     }
  }
//    getDeskOfficer(){
//     this.UTOfficerCategoryService.getDeskOfficer().subscribe(res=>{
//         this.selectDeskOfficer = res;
//     })
//    }
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
                this.router.navigateByUrl('/budget-management/transaction-type');
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
            this.router.navigateByUrl('/budget-management/transaction-type');
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



