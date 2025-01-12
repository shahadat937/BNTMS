import { Component, OnDestroy, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeAssessmentMarkService } from '../../service/TraineeAssessmentMark.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-traineeassessmentmark',
  templateUrl: './new-traineeassessmentmark.component.html',
  styleUrls: ['./new-traineeassessmentmark.component.sass']
})
export class NewTraineeAssessmentMarkComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  selectedRoles:any;
  TraineeAssessmentMarkForm: FormGroup;
  validationErrors: string[] = [];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private TraineeAssessmentMarkService: TraineeAssessmentMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeAssessmentMarkId'); 
    if (id) {
      this.pageTitle = 'Edit User Manual';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.TraineeAssessmentMarkService.find(+id).subscribe(
        res => {
          this.TraineeAssessmentMarkForm.patchValue({          
            traineeAssessmentMarkId: res.traineeAssessmentMarkId,
            courseDurationId: res.courseDurationId,
            baseSchoolNameId: res.baseSchoolNameId,
            traineeNominationId: res.traineeNominationId,
            traineeId: res.traineeId,
            traineeAssessmentCreateId: res.traineeAssessmentCreateId,
            assessmentTypeId: res.assessmentTypeId,
            position: res.position,
            remarks: res.remarks,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive:res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create User Manual';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    // this.getSelectedRoles();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.TraineeAssessmentMarkForm = this.fb.group({
      
      traineeAssessmentMarkId: [0],
      courseDurationId:  [],
      baseSchoolNameId: [],
      traineeNominationId: [],
      traineeId: [],
      traineeAssessmentCreateId: [],
      assessmentTypeId: [''],
      position: [''],
      remarks: [''],
      status: [''],
      menuPosition: [''],
      isActive: [true],
    })
  }
  
  onSubmit() {
    
    const id = this.TraineeAssessmentMarkForm.get('traineeAssessmentMarkId')?.value;  
    // const formData = new FormData();
    // for (const key of Object.keys(this.TraineeAssessmentMarkForm.value)) {
    //   const value = this.TraineeAssessmentMarkForm.value[key];
    //   formData.append(key, value);
    // } 
    if (id) {
      
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.TraineeAssessmentMarkService.update(+id,this.TraineeAssessmentMarkForm.value).subscribe(response => {
            this.router.navigateByUrl('/trainee-assessment/traineeassessmentmark-list');
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
    }

    else {
      this.loading = true;
      this.subscription = this.TraineeAssessmentMarkService.submit(this.TraineeAssessmentMarkForm.value).subscribe(response => {
        this.router.navigateByUrl('/trainee-assessment/traineeassessmentmark-list');

        this.snackBar.open('Information Saved Successfully ', '', {
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
