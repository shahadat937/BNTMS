import { Component, ElementRef, Input, OnChanges, OnDestroy, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup,FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { TraineeNominationService } from '../../service/traineenomination.service';

import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Observable, of, Subscription } from 'rxjs';
import { tap, startWith, debounceTime, distinctUntilChanged, switchMap, map, delay, concatMap } from 'rxjs/operators';
import { BIODataGeneralInfoService } from '../../../../../src/app/trainee-biodata/service/BIODataGeneralInfo.service';
import { CourseDurationService } from '../../service/courseduration.service';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { TraineeNomination } from '../../models/traineenomination';
import { Location } from '@angular/common';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { environment } from '../../../../../src/environments/environment';
import { SelectedModel } from '../../../core/models/selectedModel';

@Component({
  selector: 'app-new-traineenomination',
  templateUrl: './new-traineenomination.component.html',
  styleUrls: ['./new-traineenomination.component.sass']
}) 
export class NewTraineeNominationComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  subscription: Subscription = new Subscription();
  masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  TraineeNominationForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse:SelectedModel[];
  selectedcoursestatus:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selecteddoc:SelectedModel[];
  selectedTrainee:SelectedModel[];
  traineeId:number;
  traineeInfoById:any;
  courseDurationId:string;
  courseNameId:any;
  isLoading = false;
  nominatedPercentageList:any[];
  showHideDiv= false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  schoolName:any;
  courseName:any;
  courseTitle:any;
  runningWeek:any;
  totalWeek:any;
  selectedItems: any[] = [];
  //formGroup : FormGroup;

  options = [];
  @ViewChild('fileInput') fileInput!: ElementRef;

  filteredOptions;
  displayedColumns: string[] = ['ser','traineeName','courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


   selection = new SelectionModel<TraineeNomination>(true, []);

  

  constructor(private location: Location,private snackBar: MatSnackBar,private bioDataGeneralInfoService: BIODataGeneralInfoService,private courseDurationService: CourseDurationService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private TraineeNominationService: TraineeNominationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }
 
  ngOnInit(): void {
   
    let id; 
    this.route.paramMap.subscribe(param=> {
      id = param.get('traineeNominationId')
    })

    this.route.paramMap.subscribe(param => {
      this.courseDurationId = param.get('courseDurationId');

      this.onUpdate();
    })
    // this.courseNameId = this.route.snapshot.paramMap.get('courseNameId');  
    //this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    //---------------------------------------------------------------------------
    //this.courseDurationService.find(Number(this.courseDurationId)).subscribe(res=>{
    //  this.courseNameId = res.courseNameId;
    //  this.schoolName = res.baseSchoolName;
    //  this.courseName = res.courseName;
    //  this.courseTitle = res.courseTitle;
    //});
    //this.TraineeNominationService.findByCourseDuration(+this.courseDurationId).subscribe(
    //  res => {
    //    this.TraineeNominationForm.patchValue({          
    //      traineeNominationId:res.traineeNominationId, 
    //      courseDurationId: res.courseDurationId, 
    //      courseNameId:res.courseNameId, 
    //      traineeId:res.traineeId, 
    //      traineeCourseStatusId:res.traineeCourseStatusId, 
    //      saylorRankId:res.saylorRankId,
    //      rankId:res.rankId,
    //      saylorBranchId:res.saylorBranchId,
    //      saylorSubBranchId:res.saylorSubBranchId,
    //      branchId:res.branchId,
    //      withdrawnDocId:res.withdrawnDocId,
    //      withdrawnRemarks:res.withdrawnRemarks,
    //      withdrawnDate:res.withdrawnDate,
    //      status:res.status,
    //      menuPosition: res.menuPosition,
    //      isActive: res.isActive,
    //    });   
    //  }
    //);

    if (id) {
      this.pageTitle = 'Edit Trainee Nomination'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.TraineeNominationService.find(+id).subscribe(
        res => {
          this.TraineeNominationForm.patchValue({          
            traineeNominationId:res.traineeNominationId, 
            courseDurationId: res.courseDurationId, 
            courseNameId:res.courseNameId, 
            traineeId:res.traineeId, 
            traineeCourseStatusId:res.traineeCourseStatusId, 
            saylorRankId:res.saylorRankId,
            rankId:res.rankId,
            saylorBranchId:res.saylorBranchId,
            saylorSubBranchId:res.saylorSubBranchId,
            branchId:res.branchId,
            withdrawnDocId:res.withdrawnDocId,
            withdrawnRemarks:res.withdrawnRemarks,
            withdrawnDate:res.withdrawnDate,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Trainee Nomination';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
  
  }



  onUpdate() {
    this.courseDurationService.find(Number(this.courseDurationId)).subscribe(res=>{
      this.courseNameId = res.courseNameId;
      this.schoolName = res.baseSchoolName;
      this.courseName = res.courseName;
      this.courseTitle = res.courseTitle;
    });
    this.TraineeNominationService.findByCourseDuration(+this.courseDurationId).subscribe(
      res => {
        this.TraineeNominationForm.patchValue({          
          traineeNominationId:res.traineeNominationId, 
          courseDurationId: res.courseDurationId, 
          courseNameId:res.courseNameId, 
          traineeId:res.traineeId, 
          traineeCourseStatusId:res.traineeCourseStatusId, 
          saylorRankId:res.saylorRankId,
          rankId:res.rankId,
          saylorBranchId:res.saylorBranchId,
          saylorSubBranchId:res.saylorSubBranchId,
          branchId:res.branchId,
          withdrawnDocId:res.withdrawnDocId,
          withdrawnRemarks:res.withdrawnRemarks,
          withdrawnDate:res.withdrawnDate,
          status:res.status,
          menuPosition: res.menuPosition,
          isActive: res.isActive,
        });   
      }
    );

    this.intitializeForm();
    this.getselectedcoursename();
    this.getselectedTraineeCourseStatus();
    this.getselectedWithdrawnDoc();
    this.getSelectedTrainee();
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);

  }



  intitializeForm() {
    this.TraineeNominationForm = this.fb.group({
      traineeNominationId: [0],
      courseDurationId:[''],
      courseNameId:[''],
      traineeId:[''],
      traineeName:[''],
      traineeCourseStatusId:[],
      saylorRankId:[],
      rankId:[],
      saylorBranchId:[],
      saylorSubBranchId:[],
      branchId:[],
      courseAttendState:[0],
      withdrawnDocId:[],    
      withdrawnRemarks:[''],
      withdrawnDate:[], 
      status:[1],
      isActive: [true],    
    })

    //autocomplete
    this.TraineeNominationForm.get('traineeName')?.valueChanges
    .subscribe(value => {
        this.getSelectedTraineeByPno(value,this.courseDurationId,this.courseNameId);
    })
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
   
    this.traineeId = item.value
    this.TraineeNominationForm.get('traineeId')?.setValue(item.value);
    this.TraineeNominationForm.get('traineeName')?.setValue(item.text);
    this.getTraineeInfoByTraineeId(this.traineeId);
  }
  
//autocomplete
getSelectedTraineeByPno(pno,courseDurationId,courseNameId){
  const source$ = of (pno);
  const delay$ = source$.pipe (
    delay(700)
  );

  if(this.subscription) {
    this.subscription.unsubscribe();
  }

  if(pno.trim()=="") {
    this.options = [];
    this.filteredOptions = [];
    return;
  }

  this.subscription = delay$.subscribe(data => {
    this.TraineeNominationService.getSelectedTraineeByparameterRequest(data,courseDurationId,courseNameId).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  })
}

//autocomplete
//   filterData(enteredData){
//     this.filteredOptions = this.options.filter(item => {
//       return item.text.toLowerCase().includes(enteredData)
//     })
// }


  getSelectedTrainee(){
    this.TraineeNominationService.getSelectedTrainee().subscribe(res=>{
      this.selectedTrainee=res
    });
  } 

  getselectedcoursename(){
    this.TraineeNominationService.getselectedcoursename().subscribe(res=>{
      this.selectedcourse=res
    });
  } 

  getselectedWithdrawnDoc(){
    this.TraineeNominationService.getselectedWithdrawnDoc().subscribe(res=>{
      this.selecteddoc=res
    });
  } 

  getTraineeInfoByTraineeId(traineeId){
    this.bioDataGeneralInfoService.find(traineeId).subscribe(res=>{
      this.traineeInfoById=res;
      this.TraineeNominationForm.get('saylorRankId')?.setValue(res.saylorRankId);
      this.TraineeNominationForm.get('rankId')?.setValue(res.rankId);
      this.TraineeNominationForm.get('saylorBranchId')?.setValue(res.saylorBranchId);
      this.TraineeNominationForm.get('saylorSubBranchId')?.setValue(res.saylorSubBranchId);
      this.TraineeNominationForm.get('branchId')?.setValue(res.branchId);
      this.TraineeNominationForm.get('courseDurationId')?.setValue(this.courseDurationId);
      this.TraineeNominationForm.get('courseNameId')?.setValue(this.courseNameId);
    });
  }

  downloadExcelFile(){
    const url = environment.fileUrl + '/files/biodata-excel-file/Service_Instructor_Biodata_UploadFile.xlsx'
    const a = document.createElement('a');
    a.href = url;
    a.download = 'Trainee Nomination.xlsx';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
  }
  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
  }

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      const courseDurationId = Number(this.courseDurationId)
      this.TraineeNominationService.uploadFile(file, courseDurationId, this.courseNameId).subscribe(
        (response: any) => {
        (event.target as HTMLInputElement).value = '';
        if(response.success){
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
          this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
        }
        else{
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        }
      },
        (error) => {
          (event.target as HTMLInputElement).value = '';
        }
      );
    }
  }
  
  goBack() {
    this.location.back(); // This will navigate back to the previous route
  }
  getselectedTraineeCourseStatus(){
    this.TraineeNominationService.getselectedTraineeCourseStatus().subscribe(res=>{
      this.selectedcoursestatus=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  isAllSelected(): boolean {
    return this.nominatedPercentageList && this.selectedItems.length === this.nominatedPercentageList.length;
  }

  isSelected(id: any): boolean {
    return this.selectedItems.includes(id);
  }

  updateSelectedItems(id: any, event: any): void {
    if (event.target.checked) {
      this.selectedItems.push(id);
    } else {
      const index = this.selectedItems.indexOf(id);
      if (index > -1) {
        this.selectedItems.splice(index, 1);
      }
    }
  }

  toggleSelectAll(event: any): void {
    if (event.target.checked) {
      this.selectedItems = this.nominatedPercentageList.map(data => data.traineeNominationId);
    } else {
      this.selectedItems = [];
    }
  }

  deleteSelectedItems(): void {
    this.TraineeNominationService.deleteMultiple(this.selectedItems).subscribe((res: any) => {
      this.snackBar.open(res.message, '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-danger'
      });
      this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
    });
  }

  onSubmit() {
    const id = this.TraineeNominationForm.get('traineeNominationId')?.value;   
  
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.TraineeNominationService.update(+id,this.TraineeNominationForm.value).subscribe(response => {

            // this.router.navigateByUrl('/course-management/traineenomination-list/'+this.courseDurationId);
            this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
            //this.reloadCurrentRoute();
            this.snackBar.open('Information Updated Successfully ', '', {
              
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.loading = false;
          }, error => {
            this.validationErrors = error;
            this.loading = false;
          })
        }
      })
    }
    else {
      this.loading = true;
    
      this.TraineeNominationService.submit(this.TraineeNominationForm.value).subscribe((response: any) => {
        // this.router.navigateByUrl('/course-management/traineenomination-list/'+this.courseDurationId);
        this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
        //this.reloadCurrentRoute();
        if(response.success){
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        }
        else{
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        }
        this.loading = false;
      }, error => {
        this.validationErrors = error;
        this.loading = false;
      })
    }
 
  }

  getTraineeNominationsByCourseDurationId(courseDurationId) {
    this.isLoading = true;
    this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize,this.searchText,courseDurationId).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
    this.TraineeNominationService.gettraineeNominationListByCourseDurationId(courseDurationId).subscribe(response => {    
      this.nominatedPercentageList=response;
    });
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
  } 

  deleteItem(row) {
    const id = row.traineeNominationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.TraineeNominationService.delete(id).subscribe(() => {
          this.getTraineeNominationsByCourseDurationId(this.courseDurationId)
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

  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine")?.innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                  
                    table tr .hide{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <h3>School:- ${this.schoolName}</h3>
            <h3>Course:- ${this.courseName} - ${this.courseTitle}</h3>
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}
