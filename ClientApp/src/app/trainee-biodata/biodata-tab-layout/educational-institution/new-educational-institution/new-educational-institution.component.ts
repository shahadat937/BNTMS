import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EducationalInstitutionService } from '../../service/EducationalInstitution.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-educational-institution',
  templateUrl: './new-educational-institution.component.html',
  styleUrls: ['./new-educational-institution.component.sass']
})
export class NewEducationalInstitutionComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:  string;
  EducationalInstitutionForm: FormGroup;
  validationErrors: string[] = [];
  districtValues:SelectedModel[];
  selectDistrict:SelectedModel[]; 
  selectedThana:SelectedModel[]; 
  selectThana:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private EducationalInstitutionService: EducationalInstitutionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('educationalInstitutionId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Educational Institution';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.EducationalInstitutionService.find(+id).subscribe(
        res => {
          this.EducationalInstitutionForm.patchValue({          

            educationalInstitutionId: res.educationalInstitutionId,
            traineeId: res.traineeId,
            instituteName: res.instituteName,
            address: res.address,
            districtId: res.districtId,
            thanaId: res.thanaId,
            classStudiedFrom: res.classStudiedFrom,
            classStudiedTo: res.classStudiedTo,
            yearFrom: res.yearFrom,
            yearTo: res.yearTo,
            additionaInformation: res.additionaInformation,
            status: res.status,                        
         //   menuPosition: res.menuPosition,
          });    
          this.onDistrictSelectionChangeGetThana(res.districtId);      
        }
      );
    } else {
      this.pageTitle = 'Create Educational Institution';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getDistrict();
    //this.getThana();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.EducationalInstitutionForm = this.fb.group({
      educationalInstitutionId: [0],
      traineeId: [this.traineeId, Validators.required],
      instituteName: ['', Validators.required],
      address: ['', Validators.required],
      districtId: ['', Validators.required],
      thanaId: ['', Validators.required],
      classStudiedFrom: ['', Validators.required],
      classStudiedTo: ['', Validators.required],
      yearFrom: ['', Validators.required],
      yearTo: ['', Validators.required],
      additionaInformation: [],
      status: ['2'],           
    //  menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  getDistrict(){
    this.subscription = this.EducationalInstitutionService.getselecteddistrict().subscribe(res=>{
      this.districtValues=res
      this.selectDistrict=res
    });
  }
  filterByDistrict(value:any){
    this.districtValues=this.selectDistrict.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  // getThana(){
  //   this.EducationalInstitutionService.getselectedthana().subscribe(res=>{
  //     this.thanaValues=res
  //   });
  // }

  onDistrictSelectionChangeGetThana(districtId){
    this.subscription = this.EducationalInstitutionService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
      this.selectThana=res
    });
  }

  filterByThana(value:any){
    this.selectedThana=this.selectThana.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  
  onSubmit() {
    const id = this.EducationalInstitutionForm.get('educationalInstitutionId')?.value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This EducationalInstitution Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.EducationalInstitutionService.update(+id,this.EducationalInstitutionForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/educational-institution-details/'+this.traineeId);
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
    } else {
      this.loading = true;
      this.subscription = this.EducationalInstitutionService.submit(this.EducationalInstitutionForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/educational-institution-details/'+this.traineeId);
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
