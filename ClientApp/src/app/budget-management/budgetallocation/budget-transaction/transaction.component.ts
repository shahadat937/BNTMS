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
    CourseBudgetAllocationForm: FormGroup;
    BudgetAllocationForm: FormGroup;
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
    traineeId: number=0;
    selectedCourseDuration: SelectedModel[];
    totalBudget: any;
    targetAmount: any;
    ELEMENT_DATA: CourseBudgetAllocation[] = [
      
    ];
    isLoading = false;

    displayedColumns: string[] = ['ser','budgetCode','budgetType','installmentAmount'];

    dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();
    
    CourseBudgetAllocation: any;

      

  constructor(private fb: FormBuilder, private router: Router, private confirmService: ConfirmService, private BudgetAllocationService: BudgetAllocationService, private AdminAuthorityService: AdminAuthorityService, private UTOfficerCategoryService: UTOfficerCategoryService, private snackBar: MatSnackBar, private CourseBudgetAllocationService: CourseBudgetAllocationService, private CourseWeekService: CourseWeekService, private route: ActivatedRoute, public sharedService: SharedServiceService) {
   super();
  }

  ngOnInit(): void {

    this.initializeForm()
    const id = this.route.snapshot.paramMap.get('budgetAllocationId');
    if(id){
      this.CourseBudgetAllocationService.find(+id).subscribe(res =>{
        this.CourseBudgetAllocationForm.patchValue({
         budgetCodeId: res.budgetCodeId,
         courseNameId: res.courseNameId,
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
    this.getCourseBudgetAllocations();
    this.getselectedPaymentType();
    }
initializeForm(){
  this.CourseBudgetAllocationForm = this.fb.group({
    budgetAllocationId: [0],
      budgetCodeId: [''],
      budgetTypeId:[],
      courseNameId:null,
      courseNamesId:[''],
      paymentTypeId:[],
      fiscalYearId:[],
      budgetCodeName:[''],
      percentage:[''],
      installmentAmount:[''],
      remarks:[''],
      paymentDate: [''],
      approveAuthority: [''],
      deskId: [''],
     traineeId:[''],
      menuPosition:[],
      isActive: [true],   
  })
}
getselectedPaymentType(){
  this.CourseBudgetAllocationService.getselectedPaymentType().subscribe(res=>{
    this.selectedPaymentType=res
   
  });
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
        this.getCourseBudgetAllocations();
        this.CourseBudgetAllocationForm.get('budgetCodeId').setValue(budgetCodeId);

        this.CourseBudgetAllocationService.getTargetAmountByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
          this.targetAmount=res[0].text; 
         });
        
    }
}


getCourseBudgetAllocations() {
  this.isLoading = true;
  console.log(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.budgetCodeId,this.paymentTypeId)
  this.CourseBudgetAllocationService.getCourseBudgetAllocations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseNameId,this.traineeId).subscribe(response => {
    console.log(response)
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
      this.getCourseBudgetAllocations();
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
   
   
    if (id) {
      this.confirmService.confirm('Confirm Update', 'Are you sure you want to update this item?').subscribe(result => {
        if (result) {
          
          
          this.loading = true;
          this.CourseBudgetAllocationService.update(+id, this.CourseBudgetAllocationForm.value).subscribe(response => {
            console.log('on confirm',this.CourseBudgetAllocationForm.value)
            this.router.navigate(['/budget-management/transaction-type'], { queryParams: { installmentAmount: this.CourseBudgetAllocationForm.get('installmentAmount').value } });
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



