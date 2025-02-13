import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Observable, of, Subscription } from 'rxjs';
import { tap, startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { BIODataGeneralInfoService } from '../../../../../src/app/trainee-biodata/service/BIODataGeneralInfo.service';
import { CourseDurationService } from '../../service/courseduration.service';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { TraineeNomination } from '../../models/traineenomination';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-traineenomination',
  templateUrl: './new-traineenomination.component.html',
  styleUrls: ['./new-traineenomination.component.sass']
}) 
export class NewTraineeNominationComponent implements OnInit, OnDestroy {
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
  nominatedPercentageListCount:number;
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
  //formGroup : FormGroup;

  options = [];

  filteredOptions;
  displayedColumns: string[] = ['ser','traineeName','courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


   selection = new SelectionModel<TraineeNomination>(true, []);
  subscription: any;

  

  constructor(private snackBar: MatSnackBar,private bioDataGeneralInfoService: BIODataGeneralInfoService,private courseDurationService: CourseDurationService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private TraineeNominationService: TraineeNominationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) { }
 
  ngOnInit(): void {
   
    const id = this.route.snapshot.paramMap.get('traineeNominationId');  
    // this.courseNameId = this.route.snapshot.paramMap.get('courseNameId');  
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 

    this.subscription = this.courseDurationService.find(Number(this.courseDurationId)).subscribe(res=>{
      this.courseNameId = res.courseNameId;
      this.schoolName = res.baseSchoolName;
      this.courseName = res.courseName;
      this.courseTitle = res.courseTitle;
    });
    this.subscription = this.TraineeNominationService.findByCourseDuration(+this.courseDurationId).subscribe(
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

    if (id) {
      this.pageTitle = 'Edit Trainee Nomination'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.subscription = this.TraineeNominationService.find(+id).subscribe(
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
    this.intitializeForm();
    this.getselectedcoursename();
    this.getselectedTraineeCourseStatus();
    this.getselectedWithdrawnDoc();
    this.getSelectedTrainee();
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
   // this.getSelectedTraineeByPno();
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
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
    this.subscription = this.TraineeNominationForm.get('traineeName')?.valueChanges
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
  this.subscription = this.TraineeNominationService.getSelectedTraineeByparameterRequest(pno,courseDurationId,courseNameId).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}

//autocomplete
//   filterData(enteredData){
//     this.filteredOptions = this.options.filter(item => {
//       return item.text.toLowerCase().includes(enteredData)
//     })
// }


  getSelectedTrainee(){
    this.subscription = this.TraineeNominationService.getSelectedTrainee().subscribe(res=>{
      this.selectedTrainee=res
    });
  } 

  getselectedcoursename(){
    this.subscription = this.TraineeNominationService.getselectedcoursename().subscribe(res=>{
      this.selectedcourse=res
    });
  } 

  getselectedWithdrawnDoc(){
    this.subscription = this.TraineeNominationService.getselectedWithdrawnDoc().subscribe(res=>{
      this.selecteddoc=res
    });
  } 

  getTraineeInfoByTraineeId(traineeId){
    this.subscription = this.bioDataGeneralInfoService.find(traineeId).subscribe(res=>{
      this.traineeInfoById=res;
      this.TraineeNominationForm.get('saylorRankId')?.setValue(res.saylorRankId);
      this.TraineeNominationForm.get('rankId')?.setValue(res.rankId);
      this.TraineeNominationForm.get('saylorBranchId')?.setValue(res.saylorBranchId);
      this.TraineeNominationForm.get('saylorSubBranchId')?.setValue(res.saylorSubBranchId);
      this.TraineeNominationForm.get('branchId')?.setValue(res.branchId);
    });
  }
  

  getselectedTraineeCourseStatus(){
    this.subscription = this.TraineeNominationService.getselectedTraineeCourseStatus().subscribe(res=>{
      this.selectedcoursestatus=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.TraineeNominationForm.get('traineeNominationId')?.value;   
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.TraineeNominationService.update(+id,this.TraineeNominationForm.value).subscribe(response => {

            // this.router.navigateByUrl('/mist-course/traineenomination-list/'+this.courseDurationId);
            this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
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
      this.loading = true;
      this.subscription = this.TraineeNominationService.submit(this.TraineeNominationForm.value).subscribe(response => {
        // this.router.navigateByUrl('/mist-course/traineenomination-list/'+this.courseDurationId);
        this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
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

  getTraineeNominationsByCourseDurationId(courseDurationId) {
    this.isLoading = true;
    this.subscription = this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize,this.searchText,courseDurationId).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })

    this.subscription = this.TraineeNominationService.gettraineeNominationListByCourseDurationId(courseDurationId).subscribe(response => {
      this.nominatedPercentageList=response;
      this.nominatedPercentageListCount=response.length;
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
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.TraineeNominationService.delete(id).subscribe(() => {
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
