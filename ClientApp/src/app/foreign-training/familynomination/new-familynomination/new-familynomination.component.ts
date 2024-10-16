import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { FamilyNominationService } from '../../service/familynomination.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { FamilyInfoListforFamilyNomination } from '../../models/familyinfoListforfamilynomination';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-familynomination',
  templateUrl: './new-familynomination.component.html',
  styleUrls: ['./new-familynomination.component.sass']
})
export class NewFamilyNominationComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  courseDurationId:any;
  traineeId: any;
  FamilyNominationForm: FormGroup;
  validationErrors: string[] = [];
  selectedFundingDetail: SelectedModel[];
  relationTypeValues: SelectedModel[];
  traineeList: FamilyInfoListforFamilyNomination[]

  displayedColumnsForFamilyInfoList: string[] = ['sl', 'fullName', 'relationType', 'status'];
  constructor(private snackBar: MatSnackBar, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private FamilyNominationService: FamilyNominationService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('familyNominationId');
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    if (id) {
      this.pageTitle = 'Edit Family Nomination';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.FamilyNominationService.find(+id).subscribe(
        res => {
          this.FamilyNominationForm.patchValue({
            familyNominationId: res.familyNominationId,
            traineeId: res.traineeId,
            courseDurationId: res.courseDurationId,
            familyInfoId:res.familyInfoId,
            traineeNominationId: res.traineeNominationId,
            fundingDetailId: res.fundingDetailId,
            relationTypeId: res.relationTypeId,
            remarks: res.remarks,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });

        }
      );
    } else {
      this.pageTitle = 'Create Family Nomination';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    this.getfamilyInfoListByTraineeId()

  }
  intitializeForm() {
    this.FamilyNominationForm = this.fb.group({
      familyNominationId: [0],
      traineeId: [],
      courseDurationId: [],
      familyInfoId:[],
      traineeNominationId: [],
      fundingDetailId: [],
      relationTypeId: [],
      remarks: [''],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      status: [],
      isActive: [true],
    })
  }
  getControlLabel(index: number, type: string) {
    return (this.FamilyNominationForm.get('traineeListForm') as FormArray).at(index).get(type).value;
  }
  private createTraineeData() {

    return this.fb.group({
      courseDurationId: [this.courseDurationId],
      traineeNominationId: [],
      familyInfoId:[],
      relationTypeId: [],
      traineeId: [],
      fullName: [],
      relationType: [],
      status: ['']
    });
  }
  getTraineeListonClick() {
    const control = <FormArray>this.FamilyNominationForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData());
    }
    this.FamilyNominationForm.patchValue({ traineeListForm: this.traineeList });
  }

  clearList() {
    const control = <FormArray>this.FamilyNominationForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }
  getfamilyInfoListByTraineeId() {
    
    this.FamilyNominationForm.get('traineeId').setValue(this.traineeId)
    this.FamilyNominationService.getfamilyInfoListByTraineeId(this.traineeId).subscribe(res => {
      //this.relationTypeValues=res
      this.traineeList = res;
      this.clearList()
      this.getTraineeListonClick();
    });
  }
  onCheckboxChange(index, event) {
    this.traineeList[index]["isActive"] = event.checked;
  }
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.FamilyNominationForm.get('familyNominationId').value;
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.FamilyNominationService.update(+id, this.FamilyNominationForm.value).subscribe(response => {
            this.router.navigateByUrl('/foreign-training/familynomination-list');
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
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.FamilyNominationService.submit(JSON.stringify(this.FamilyNominationForm.value)).subscribe(response => {
            this.reloadCurrentRoute();
            //this.router.navigateByUrl("['/foreign-training/foreigntraineenomination-list/']");
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
      })
    }

  }
}
