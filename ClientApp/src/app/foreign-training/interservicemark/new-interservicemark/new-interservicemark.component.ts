import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { SelectedModel } from '../../../core/models/selectedModel';
import { InterServiceMarkService } from '../../service/interservicemark.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { InterServiceMark } from '../../models/interservicemark';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { TraineeListforForeignCourse } from '../../models/traineeListforforeigncourse';
import { CourseDurationService } from '../../service/courseduration.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-interservicemark',
  templateUrl: './new-interservicemark.component.html',
  styleUrls: ['./new-interservicemark.component.sass']
})
export class NewInterServiceMarkComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  buttonText: string;
  pageTitle: string;
   masterData = MasterData;
  loading = false;
  destination: string;
  InterServiceMarkForm: FormGroup;
  validationErrors: string[] = [];
  courseTypeId: 18;
  selectedCourseName: SelectedModel[];
  selectedCountry: SelectedModel[];
  selectedDocument: SelectedModel[];
  selectedPno: SelectedModel[];
  selectedCourseValue: SelectedModel[];
  traineeId: number;
  courseDurationId: number;
  courseNameId: string;
  interServiceMarkList: InterServiceMark[];
  isShown: boolean = false;
  traineeList: TraineeListforForeignCourse[]
  selectedSubjectNameByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
  selectedCourseDuration: number;
  organizationNameId: number;

  durateDateForm:any;
  durationDateTo:any;
  warningMessage : string = "";

  options = [];
  filteredOptions;
  searchText = "";

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }


  displayedColumnsForTraineeList: string[] = ['sl', 'traineeName', 'coursePosition', 'obtaintMark', 'documentId', 'remarks'];
  constructor(private snackBar: MatSnackBar, private courseDurationService: CourseDurationService , private traineeNominationService: TraineeNominationService, private InterServiceMarkService: InterServiceMarkService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('interServiceMarkId');

    if (id) {
      this.pageTitle = 'Edit Foreign Course Mark Entry';
      this.destination = 'Edit';
      this.buttonText = "Update";
      this.InterServiceMarkService.find(+id).subscribe(
        res => {
          this.InterServiceMarkForm.patchValue({

            interServiceMarkId: res.interServiceMarkId,
            courseDurationId: res.courseDurationId,
            courseNameId: res.courseNameId,
            countryId:res.countryId,
            organizationNameId: res.organizationNameId,
            courseTypeId: res.courseTypeId,
            traineeNominationId: res.traineeNominationId,

          });
          this.onOrganizationNameSelectionChangeGetCourse(res.organizationNameId)
        }
      );
    } else {
      this.pageTitle = 'Create Foreign Course Mark Entry';
      this.destination = 'Add';
      this.buttonText = "Save";
    }
    this.intitializeForm();
    this.getSelectedCountry();
    this.getSelectedDocument();

  }
  intitializeForm() {
    this.InterServiceMarkForm = this.fb.group({
      interServiceMarkId: [0],
      courseDurationId: [],
      courseNameId: [],
      countryId:[],
      organizationNameId: [],
      //documentId: [],
      courseTypeId: [this.courseTypeId],
      traineeNominationId: [],
      traineeId: [],
      traineeName: [''],
      coursePosition: [''],
      obtaintMark: [''],
      remarks: [''],
      traineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      isActive: [true],
      pno: ['']
    })

  }
  getControlLabel(index: number, type: string) {
    return (this.InterServiceMarkForm.get('traineeListForm') as FormArray).at(index).get(type)?.value;
  }
  private createTraineeData() {

    return this.fb.group({

      courseDurationId: [],
      courseNameId:[],
      traineeId: [],
      countryId:[],
      traineeNominationId:[],
      traineePNo: [],
      traineeName: [],
      rankPosition: [],
      coursePosition: [],
      obtaintMark: [],
      documentId: [],
      remarks: []
    });
  }
  getTraineeListonClick() {
    const control = <FormArray>this.InterServiceMarkForm.controls["traineeListForm"];
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData());
    }
    this.InterServiceMarkForm.patchValue({ traineeListForm: this.traineeList });
  }

  clearList() {
    const control = <FormArray>this.InterServiceMarkForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }
  onOrganizationNameSelectionChangeGetCourse(countryId) {
    this.InterServiceMarkService.getCourseNameByCountryId(countryId).subscribe(res => {
      this.selectedCourseValue = res

      
    });
  }

  getInterServiceMarkByCourseDurationId (courseDurationId){
  this.InterServiceMarkService.findInterServiceMarkByCourseDurationId(courseDurationId).subscribe(res=>{
    if (!res.length){
      this.isShown = true;
      this.warningMessage = ""
      this.courseDurationService.find(this.courseDurationId).subscribe(res => {
        this.durateDateForm = res.durationFrom;
        this.durationDateTo = res.durationTo;
      });

      this.traineeNominationService.getTraineeNominationByCourseDurationId(this.courseDurationId).subscribe(res => {
        this.traineeList = res;
        if(!this.traineeList?.length){
          this.isShown = false;
          this.warningMessage = "No Trainees Have Been Nominated for the Course"
        } 
        this.clearList()
        this.getTraineeListonClick();
      });
    }
    else{
      this.isShown = false;
      this.warningMessage = "Mark Entry Already Completed"
    }
  })
  }
  onCourseNameSelectionChangeGetTraineeList(dropdown) {
    if (dropdown.isUserInput) {
      this.courseDurationId = this.InterServiceMarkForm.get('courseDurationId')?.value;
      this.courseDurationId = dropdown.source.value;

      this.InterServiceMarkForm.get('courseDurationId')?.setValue(dropdown.source.value)
      this.getInterServiceMarkByCourseDurationId(this.courseDurationId);    
    }
  }

  getSelectedCountry() {
    this.InterServiceMarkService.getSelectedCountry().subscribe(res => {
      this.selectedCountry = res
    });
  }
  getSelectedDocument() {
    this.InterServiceMarkService.getSelectedDocument().subscribe(res => {
      this.selectedDocument = res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.InterServiceMarkForm.get('interServiceMarkId')?.value;
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.InterServiceMarkService.update(+id, this.InterServiceMarkForm.value).subscribe(response => {
            this.router.navigateByUrl('/foreign-training/add-interservicemark');
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
          this.InterServiceMarkService.submit(JSON.stringify(this.InterServiceMarkForm.value)).subscribe(response => {          
            this.reloadCurrentRoute();
            this.isShown = false;
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
