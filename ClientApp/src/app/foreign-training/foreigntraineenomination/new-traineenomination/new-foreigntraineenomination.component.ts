import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Observable, of, Subscription } from 'rxjs';
import { tap, startWith, debounceTime, distinctUntilChanged, switchMap, map } from 'rxjs/operators';
import { BIODataGeneralInfoService } from '../../../../../src/app/trainee-biodata/service/BIODataGeneralInfo.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-foreigntraineenomination',
  templateUrl: './new-foreigntraineenomination.component.html',
  styleUrls: ['./new-foreigntraineenomination.component.sass']
}) 
export class NewForeignTraineeNominationComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  foreigntraineenominationForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse:SelectedModel[];
  selectedduration:SelectedModel[];
  selectedcoursestatus:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selecteddoc:SelectedModel[];
  selectedTrainee:SelectedModel[];
  traineeInfoById:any;
  traineeId:number;
  courseDurationId:string;
  courseNameId : string;

  //formGroup : FormGroup;

  options = [];

  filteredOptions;

  constructor(private snackBar: MatSnackBar,private bioDataGeneralInfoService: BIODataGeneralInfoService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private TraineeNominationService: TraineeNominationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }
 
  ngOnInit(): void {
   
    const id = this.route.snapshot.paramMap.get('traineeNominationId');  
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId') ?? ""; 
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId') ?? ""; 
    this.TraineeNominationService.findByCourseDuration(+this.courseDurationId).subscribe(
      res => {
        this.foreigntraineenominationForm.patchValue({          
          traineeNominationId:res.traineeNominationId, 
          courseDurationId: res.courseDurationId, 
          courseNameId:res.courseNameId, 
          traineeId:res.traineeId, 
          familyAllowId:res.familyAllowId,
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
      this.pageTitle = 'Edit Foreign Course Trainee Nomination'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.TraineeNominationService.find(+id).subscribe(
        res => {
          this.foreigntraineenominationForm.patchValue({          
            traineeNominationId:res.traineeNominationId, 
            courseDurationId: res.courseDurationId, 
            courseNameId:res.courseNameId, 
            traineeId:res.traineeId, 
            familyAllowId:res.familyAllowId,
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
      this.pageTitle = 'Create Foreign Course Trainee Nomination';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedcoursename();
    // this.getselectedcourseduration();
    this.getselectedTraineeCourseStatus();
    this.getselectedWithdrawnDoc();
    this.getSelectedTrainee();
  }

  intitializeForm() {
    this.foreigntraineenominationForm = this.fb.group({
      traineeNominationId: [0],
      courseDurationId:[''],
      courseNameId:[''],
      traineeId:[''],
      traineeName:[''],
      familyAllowId:[''],
      traineeCourseStatusId:[''],
      saylorRankId:[''],
      rankId:[''],
      saylorBranchId:[''],
      saylorSubBranchId:[''],
      branchId:[''],
      withdrawnDocId:[''],    
      withdrawnRemarks:[''],
      withdrawnDate:[''], 
      status:[1],
      isActive: [true],    
    })

    //autocomplete
    this.foreigntraineenominationForm.get('traineeName')?.valueChanges
    .subscribe(value => {
     
        this.getSelectedTraineeByPno(value);
     
    })
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    this.foreigntraineenominationForm.get('traineeId')?.setValue(item.value);
    this.foreigntraineenominationForm.get('traineeName')?.setValue(item.text);
    this.getTraineeInfoByTraineeId(item.value);
  }



//autocomplete
getSelectedTraineeByPno(pno){
    this.TraineeNominationService.getSelectedTraineeByPno(pno).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

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

  getselectedcourseduration(){
    this.TraineeNominationService.getselectedcourseduration().subscribe(res=>{
      this.selectedduration=res
    });
  }

  getselectedTraineeCourseStatus(){
    this.TraineeNominationService.getselectedTraineeCourseStatus().subscribe(res=>{
      this.selectedcoursestatus=res
    });
  }

  getTraineeInfoByTraineeId(traineeId){
    this.bioDataGeneralInfoService.find(traineeId).subscribe(res=>{
      this.traineeInfoById=res;
      this.foreigntraineenominationForm.get('saylorRankId')?.setValue(res.saylorRankId);
      this.foreigntraineenominationForm.get('rankId')?.setValue(res.rankId);
      this.foreigntraineenominationForm.get('saylorBranchId')?.setValue(res.saylorBranchId);
      this.foreigntraineenominationForm.get('saylorSubBranchId')?.setValue(res.saylorSubBranchId);
      this.foreigntraineenominationForm.get('branchId')?.setValue(res.branchId);
    });
  }

  onSubmit() {
    const id = this.foreigntraineenominationForm.get('traineeNominationId')?.value; 
    this.foreigntraineenominationForm.get('courseDurationId')?.setValue(this.courseDurationId); 
    this.foreigntraineenominationForm.get('courseNameId')?.setValue(this.courseNameId); 
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.TraineeNominationService.update(+id,this.foreigntraineenominationForm.value).subscribe(response => {

            this.router.navigateByUrl('/foreign-training/foreigntraineenomination-list/'+this.courseDurationId);
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
      this.TraineeNominationService.submit(this.foreigntraineenominationForm.value).subscribe(response => {
        this.router.navigateByUrl('/foreign-training/foreigntraineenomination-list/'+this.courseDurationId);
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
