import { ConfirmService } from './../../../core/service/confirm.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BudgetAllocation } from 'src/app/foreign-training/models/BudgetAllocation';
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



@Component({
  selector: 'app-add-budget',
  templateUrl: './transaction.component.html',
  styleUrls: ['./transaction.component.css']
})
export class BudgetTransaction implements OnInit {
    selectFiscalYear: SelectedModel[];
    selectedBudgetType: SelectedModel[];
    selectedBudgetCode: SelectedModel[];
    SelectAuthority: SelectedModel[];
    CourseBudgetAllocationForm: FormGroup;
    budgetCodeId: any;
    budgetTypeId: any;
    buttonText: string;
    pageTitle: string;
    selectDeskOfficer: SelectedModel[];
    SelectedCourse: SelectedModel[];
    paging = {
        pageIndex: 10,
        pageSize: 10,
        length: 1
      };
      searchText: any;
    isShow: any;
    loading: any;
    validationErrors: any;
    selectedCourseDuration: SelectedModel[];
    totalBudget: any;
    ELEMENT_DATA: CourseBudgetAllocation[] = [
      
    ];
    isLoading = false;

    // displayedColumns: string[] = ['ser','budgetCode','budgetType','actions','courseNamesId'];
    displayedColumns: string[] = ['ser', 'budgetCode', 'budgetType', 'date', 'amount', 'adminAuthority', 'courseName', 'actions'];


    dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();
    selection = new SelectionModel<CourseBudgetAllocation>(true, []);
  CourseBudgetAllocation: any;
      

  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, private CourseWeekService: CourseWeekService, private route: ActivatedRoute) {
   
  }

  ngOnInit(): void {

    this.initializeForm()
    const id = this.route.snapshot.paramMap.get('budgetAllocationId');
    if(id){
      this.CourseBudgetAllocationService.find(+id).subscribe(res =>{
        this.CourseBudgetAllocationForm.patchValue({
        //  budgetCodeId: res.budgetCodeId,
         budgetTypeId: res.budgetTypeId,
          
          budgetAllocationId: id ,
        })
      })
    }else {
      this.pageTitle = 'Create Budget';
      this.buttonText = 'Save';
    }
    this.getSelectAuthority();
    this.getselectedBudgetType();
    this.getselectedBudgetCode();
    this.getSelectedCourseDurationByCourseTypeId();
   
    }
initializeForm(){
  this.CourseBudgetAllocationForm = this.fb.group({
    budgetAllocationId: [0],
      budgetCodeId: [],
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

        this.CourseBudgetAllocationForm.get('budgetCodeId').setValue(budgetCodeId);

        this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res => {
            this.totalBudget = res[0].text; 
        });

        
    }
}

getBudgetAllocations() {
  this.isLoading = true;
  this.CourseBudgetAllocation.getBudgetAllocations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.budgetTypeId).subscribe(response => {
    this.dataSource.data = response.items; 
    this.paging.length = response.totalItemsCount    
    this.isLoading = false;
  })
}
onBudgetChange(dropdown){
  if (dropdown.isUserInput) {
    this.isShow=true;
     this.budgetTypeId=dropdown.source.value;
      this.getBudgetAllocations();
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
          console.log(this.CourseBudgetAllocationForm.value)
          this.loading = true;
          this.CourseBudgetAllocationService.update(+id, this.CourseBudgetAllocationForm.value).subscribe(response => {
            
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
      this.loading = false;
      this.CourseBudgetAllocationService.submit(this.CourseBudgetAllocationForm.value).subscribe(response => {
        console.log(this.CourseBudgetAllocationForm.value)
        this.reloadCurrentRoute();
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



