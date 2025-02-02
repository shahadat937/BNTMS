import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseBudgetAllocationService } from '../../service/courseBudgetAllocation.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { CourseWeekService } from '../../../../../src/app/course-management/service/CourseWeek.service';
import { CourseBudgetAllocation } from '../../models/CourseBudgetAllocation';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-scheduleinstallment-list.component',
  templateUrl: './scheduleinstallment-list.component.html',
  styleUrls: ['./scheduleinstallment-list.component.sass'] 
}) 
export class ScheduleInstallmentListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  CourseBudgetAllocationForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools:SelectedModel[];
  selectedcoursename:SelectedModel[];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectedBudgetCode:SelectedModel[];
  selectedBudgetType:SelectedModel[];
  selectedFiscalYear:SelectedModel[];
  selectedPaymentType:SelectedModel[];
  selectedCourseDuration:SelectedModel[];
  selectCourse:SelectedModel[];
  selectedTrainee:SelectedModel[];
  totalBudget:any;
  availableAmount:any;
  traineeId:any;
  courseNameId:any;
  targetAmount:any;
  courseDurationId:any;
  budgetCodes:any[];
  isShown: boolean = false;

  ELEMENT_DATA: CourseBudgetAllocation[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  groupArrays:{ baseSchoolName: string; courses: any; }[];
  displayedColumnsBudgetCode: string[] = ['sl', 'budgetCodes', 'name', 'availableAmount','targetAmount'];
  displayedColumns: string[] = ['ser','traineeName','budgetCode','paymentType','installmentAmount','nextInstallmentDate','actions'];
  dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();


   selection = new SelectionModel<CourseBudgetAllocation>(true, []);

  constructor(private snackBar: MatSnackBar,private CourseWeekService: CourseWeekService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private CourseBudgetAllocationService: CourseBudgetAllocationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('courseBudgetAllocationId'); 
    if (id) {
      this.pageTitle = 'Edit Schedule Installment'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.CourseBudgetAllocationService.find(+id).subscribe(
        res => {
          this.CourseBudgetAllocationForm.patchValue({          
            courseBudgetAllocationId:res.courseBudgetAllocationId,
            courseTypeId:res.courseTypeId,
            courseNameId:res.courseNameId,
            courseDurationId:res.courseDurationId,
            traineeId:res.traineeId,
            budgetCodeId:res.budgetCodeId,
            paymentTypeId:res.paymentTypeId,
            installmentAmount:res.installmentAmount,
            installmentDate: res.installmentDate,
            nextInstallmentDate:res.nextInstallmentDate,
            presentBalance: res.presentBalance,
            menuPosition: res.menuPosition,
            isActive: res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Schedule Installment List';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedBudgetCode();
    this.getselectedBudgetType();
    this.getselectedFiscalYear();
    this.getselectedcoursename();
    this.getselectedPaymentType();
    this.getSelectedCourseDurationByCourseTypeId();
  }
  intitializeForm() {
    this.CourseBudgetAllocationForm = this.fb.group({
      courseBudgetAllocationId: [0],
      courseTypeId:[this.masterData.coursetype.ForeignCourse],
      courseNameId:[''],
      courseNamesId:[''],
      courseDurationId:[''],
      traineeId:[''],
      budgetCodeId:[''],
      budgetCodesId:[''],
      paymentTypeId:[''],
      installmentAmount:[''],
      nextInstallmentDate:[],
      installmentDate:[],
      presentBalance: [],  
      menuPosition: [],  
      isActive:[true]
    })
  }
  
  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseBudgetAllocationList();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseBudgetAllocationList();
  } 

  onTraineeSelectionChange(dropdown){
    if (dropdown.isUserInput) {
      this.traineeId=dropdown.source.value;
      this.courseNameId =  this.CourseBudgetAllocationForm.get('courseNameId')?.value;
      this.getCourseBudgetAllocationList();
    }
  }

  onBudgetCodeSelectionChange(dropdown){
    if (dropdown.isUserInput) {
       var budgetCodeId = dropdown.source.value.value; 

       this.CourseBudgetAllocationForm.get('budgetCodeId')?.setValue(budgetCodeId);

       this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
       this.totalBudget=res[0].text; 
      });

      this.CourseBudgetAllocationService.getAvailableAmountByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
        this.availableAmount=res[0].text; 
       });

       this.CourseBudgetAllocationService.getTargetAmountByBudgetCodeIdRequest(budgetCodeId).subscribe(res=>{
        this.targetAmount=res[0].text; 
       });
     }
  }

  onCourseNameSelectionChange(dropdown){
    if (dropdown.isUserInput) {
      this.isShown=true;
      var courseNameArr = dropdown.source.value.split('_');
      this.courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];
      this.getCourseBudgetAllocationListByCourseDurationIdAndPaymentTypeId();

          // getBudgetCodeList
    this.CourseBudgetAllocationService.getBudgetCodeList().subscribe(res=>{
      this.budgetCodes=res 
     });
    }
}

  getCourseBudgetAllocationList(){
    this.isLoading = true;
      this.CourseBudgetAllocationService.getCourseBudgetAllocations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseNameId,this.traineeId).subscribe(response => {
        this.dataSource.data = response.items; 
        this.paging.length = response.totalItemsCount    
        this.isLoading = false;
      })
  }

  getCourseBudgetAllocationListByCourseDurationIdAndPaymentTypeId(){
    this.isLoading = true;
      this.CourseBudgetAllocationService.getCourseBudgetAllocationListByCourseDurationIdAndPaymentTypeId(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.courseDurationId).subscribe(response => {
        this.dataSource.data = response.items.filter(x=>x.status===0); 


           //   this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, courses) => {
        const schoolName = courses.traineeName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((baseSchoolName) => {
        return {
          baseSchoolName,
          courses: groups[baseSchoolName]
        };
      });
      
        this.paging.length = response.totalItemsCount    
        this.isLoading = false;
      })
  }

  

  getselectedcoursename(){
    this.CourseWeekService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res
    });
  }

  // getSelectedTraineeByCourseDurationId(){

  // }
  getTotalBudgetByBudgetCodeIdRequest(){
    this.CourseBudgetAllocationService.getTotalBudgetByBudgetCodeIdRequest(MasterData.coursetype.ForeignCourse).subscribe(res=>{
      this.selectedCourseDuration=res
    });
  }

  getSelectedCourseDurationByCourseTypeId(){
    this.CourseBudgetAllocationService.getSelectedCourseDurationByCourseTypeId(MasterData.coursetype.ForeignCourse).subscribe(res=>{
      this.selectedCourseDuration=res
      this.selectCourse=res
    });
  }
  fileterByCourse(value:any){
    this.selectedCourseDuration=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  // getSelectedCourseName(){
  //   this.CourseBudgetAllocationService.getselectedBudgetCode().subscribe(res=>{
  //     this.selectedBudgetCode=res
  //   });
  // } 

      // getBudgetCodeList
      // this.CourseBudgetAllocationService.getBudgetCodeList().subscribe(res=>{
      //   this.budgetCodes=res 
      //  });

  getselectedBudgetCode(){
    this.CourseBudgetAllocationService.getselectedBudgetCode().subscribe(res=>{
      this.selectedBudgetCode=res
    });
  } 
  getselectedPaymentType(){
    this.CourseBudgetAllocationService.getselectedPaymentType().subscribe(res=>{
      this.selectedPaymentType=res
    });
  }

  getselectedBudgetType(){
    this.CourseBudgetAllocationService.getselectedBudgetType().subscribe(res=>{
      this.selectedBudgetType=res
    });
  } 
  getselectedFiscalYear(){
    this.CourseBudgetAllocationService.getselectedFiscalYear().subscribe(res=>{
      this.selectedFiscalYear=res
    });
  } 

  inActiveItem(row){
    const id = row.courseBudgetAllocationId;    
    //var baseSchoolNameId=this.CourseBudgetAllocationForm.value['baseSchoolNameId'];
    if(row.status == 0){
      this.confirmService.confirm('Confirm Payment message', 'Are You Sure Paid This Installment').subscribe(result => {
        if (result) {
          this.CourseBudgetAllocationService.ChangeCourseBudgetAllocationStatus(id,1).subscribe(() => {
           // this.getBulletins(baseSchoolNameId);
           this.getCourseBudgetAllocationListByCourseDurationIdAndPaymentTypeId();
            this.snackBar.open('Payment Successfully!', '', { 
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          })
        }
      })
    }
    // else{
    //   this.confirmService.confirm('Confirm Active message', 'Are You Sure Run This Bulletin').subscribe(result => {
    //     if (result) {
    //       this.bulletinService.ChangeBulletinStatus(id,0).subscribe(() => {
    //         this.getBulletins(baseSchoolNameId);
    //         this.snackBar.open('Bulletin Running!', '', { 
    //           duration: 3000,
    //           verticalPosition: 'bottom',
    //           horizontalPosition: 'right',
    //           panelClass: 'snackbar-success'
    //         });
    //       })
    //     }
    //   })
    // }
  }

  deleteItem(row) {
    const id = row.courseBudgetAllocationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseBudgetAllocationService.delete(id).subscribe(() => {
          this.reloadCurrentRoute();
         // this.getCourseBudgetAllocations();
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

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.CourseBudgetAllocationForm.get('courseBudgetAllocationId')?.value; 
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.CourseBudgetAllocationService.update(+id,this.CourseBudgetAllocationForm.value).subscribe(response => {
            // this.router.navigateByUrl('/budget-management/coursebudgetallocation-list');
            this.reloadCurrentRoute();
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }else {
      this.loading=true;
      this.CourseBudgetAllocationService.submit(this.CourseBudgetAllocationForm.value).subscribe(response => {
        // this.router.navigateByUrl('/budget-management/coursebudgetallocation-list');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
}
