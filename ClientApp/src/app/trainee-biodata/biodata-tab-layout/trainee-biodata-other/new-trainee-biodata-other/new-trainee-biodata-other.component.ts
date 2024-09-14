import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeBIODataOtherService } from '../../service/TraineeBIODataOther.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';

@Component({
  selector: 'app-new-trainee-biodata-other',
  templateUrl: './new-trainee-biodata-other.component.html',
  styleUrls: ['./new-trainee-biodata-other.component.sass']
})
export class NewTraineeBIODataOtherComponent implements OnInit {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:  string;
  TraineeBIODataOtherForm: FormGroup;
  validationErrors: string[] = [];
  bnaCurriculamTypeValues:SelectedModel[];
  selectCurriculumType:SelectedModel[]; 
  selectedPresentBillet:SelectedModel[];
  selectPresentBillet:SelectedModel[];
  selectedInstructorType:SelectedModel[];
  selectInstructorType:SelectedModel[];
  selectedFailureStatus:SelectedModel[];
  selectFailureStatus:SelectedModel[]
  selectedSchoolName:SelectedModel[];
  selectedCourseName:SelectedModel[];
  selectCours:SelectedModel[];
  selectedBnaClassSectionSelection:SelectedModel[];
  selectBnaSection:SelectedModel[];
  selectedBnaPromotionStatus:SelectedModel[];
  selectPromotion:SelectedModel[]
  selectedMaritalStatus:SelectedModel[];
  selectStatus:SelectedModel[]
  selectedCountry:SelectedModel[];
  selectCountry:SelectedModel[]
  selectedCaste:SelectedModel[];
  selectedReligion:SelectedModel[];
  selectedBloodGroup:SelectedModel[];
  bnaSemesterValues:SelectedModel[]; 
  selectSemester:SelectedModel[];
  utOfficerTypeValues:SelectedModel[]; 
  selectOfficerType:SelectedModel[];
  utOfficerCategoryValues:SelectedModel[];
  selectOfficerCategory:SelectedModel[];
  bnaServiceTypeValues:SelectedModel[]; 
  selectBnaType:SelectedModel[];
  complexionValues:SelectedModel[]; 
  selectComplexionType:SelectedModel[];
  branchValues:SelectedModel[]; 
  selectBranch:SelectedModel[];
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[];
  colorOfEyeValues:SelectedModel[]; 
  nationalityValues:SelectedModel[];
  selectNationality:SelectedModel[] 
  
  nationalityToggle:string;


  constructor(private snackBar: MatSnackBar,private TraineeBIODataOtherService: TraineeBIODataOtherService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeBioDataOtherId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit  Misc Information';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.TraineeBIODataOtherService.find(+id).subscribe(
        res => {
          this.TraineeBIODataOtherForm.patchValue({          

            traineeBioDataOtherId : res.traineeBioDataOtherId,
            traineeId : res.traineeId,
            bnaCurriculumTypeId : res.bnaCurriculumTypeId,
            bnaSemesterId : res.bnaSemesterId,
            utofficerTypeId : res.utofficerTypeId,
            utofficerCategoryId : res.utofficerCategoryId,
            bnaServiceTypeId : res.bnaServiceTypeId,
            complexionId : res.complexionId,
            branchId : res.branchId,
            heightId : res.heightId,
            weightId : res.weightId,
            colorOfEyeId : res.colorOfEyeId,
            bloodGroupId : res.bloodGroupId,            
            religionId : res.religionId,   
            casteId : res.casteId,
            countryId : res.countryId,
            maritalStatusId : res.maritalStatusId,
            bnaPromotionStatusId : res.bnaPromotionStatusId,
            bnaClassSectionSelectionId : res.bnaClassSectionSelectionId,
            courseNameId : res.courseNameId,
            failureStatusId : res.failureStatusId,
            bnaInstructorTypeId : res.bnaInstructorTypeId,
            presentBilletId : res.presentBilletId,
            age : res.age,            
            commissionDate : res.commissionDate, 
            postCode : res.postCode,
            identificationMark : res.identificationMark,
            presentAddress : res.presentAddress,
            permanentAddress : res.permanentAddress,
            traineeStatus : res.traineeStatus,
            passportNo : res.passportNo,
            drivingLiccense : res.drivingLiccense,
            bankAccount : res.bankAccount,
            creditCard : res.creditCard,
            dateOfMarriage : res.dateOfMarriage,
            remarks : res.remarks,            
            placeOfBirth : res.placeOfBirth,  
            dualNationality : res.dualNationality.trim(),
            sNationalityId : res.sNationalityId,
            reasonOfMigration : res.reasonOfMigration,
            migrationDate : res.migrationDate,
            additionalInformation : res.additionalInformation,            
            relegationDate : res.relegationDate,
            relegationRemarks : res.relegationRemarks,
            relegationDocument : res.relegationDocument,
            shortCode : res.shortCode            
         
          });          
        }
      );
    } else {
      this.pageTitle = 'Create  Misc Information';
      this.destination = "Add";
      this.buttonText= "Save"
    }
     this.intitializeForm();
     this.getBNACurriculamTypeName();
     this.getselectedPresentbillet();
     this.getselectedInstructorType();
     this.getselectedfailureStatus();
     this.getselectedCourseName();
     this.getselectedBnaClassSectionSelection();
     this.getselectedBnaPromotionStatus();
     this.getselectedMaritalStatus();
     this.getselectedCountry();
     this.getselectedCaste();
     this.getselectedReligion();
     this.getselecteBloodGroup();
     this.getBNASemesterName();
     this.getUTOfficerTypeName();
     this.getUTOfficerCategoryName();
     this.getBNAServiceTypeName();
     this.getComplexionName();
     this.getBranchName();
     this.getWeightName();
     this.getHeightName();
     this.getColorOfEyeName();
     this.getNationality();
  }
  intitializeForm() {
    this.TraineeBIODataOtherForm = this.fb.group({
      traineeBioDataOtherId: [0],
      traineeId: [this.traineeId, Validators.required],
      bnaCurriculumTypeId: ['', Validators.required],
      bnaSemesterId: ['', Validators.required],
      utofficerTypeId: ['', Validators.required],
      utofficerCategoryId: ['', Validators.required],
      bnaServiceTypeId: ['', Validators.required],
      complexionId: ['', Validators.required],
      branchId: ['', Validators.required],
      heightId: [],
      weightId: [],
      colorOfEyeId: [],
      bloodGroupId: [],
      religionId: [],  
      casteId: [],
      countryId: ['', Validators.required],
      maritalStatusId: ['', Validators.required],
      bnaPromotionStatusId: ['', Validators.required],
      bnaClassSectionSelectionId: ['', Validators.required],
      courseNameId: ['', Validators.required],
      failureStatusId: ['', Validators.required],
      bnaInstructorTypeId: ['', Validators.required],
      presentBilletId: ['', Validators.required],

      age: ['', Validators.required],
      commissionDate: [],
      postCode: [''],
      identificationMark: [''], 
      presentAddress: [''],
      permanentAddress: [''],
      traineeStatus: [],
      passportNo: [''],
      drivingLiccense: [''],
      bankAccount: [''],
      creditCard: [''],
      dateOfMarriage: [],
      remarks: [''],
      placeOfBirth: [''],
      dualNationality: [''], 
      sNationalityId: [],
      reasonOfMigration: [''],
      migrationDate: [], 
      additionalInformation: [''],
      relegationDate: [],
      relegationRemarks: [''],
      relegationDocument: [''],
      shortCode: [''],
      isActive: [true],
    })
  }

  getBNACurriculamTypeName(){
    this.TraineeBIODataOtherService.getselectedbnacurriculumtype().subscribe(res=>{
      this.bnaCurriculamTypeValues=res
      this.selectCurriculumType=res
    });
  }
  filterByCurriculum(value:any){
    this.bnaCurriculamTypeValues=this.selectCurriculumType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  
  getNationality(){
    this.TraineeBIODataOtherService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
      this.selectNationality=res
    });
  }
  filterByNationality(value:any){
    this.nationalityValues=this.selectNationality.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getselectedPresentbillet(){
    this.TraineeBIODataOtherService.getselectedpresentbillet().subscribe(res=>{
   this.selectedPresentBillet=res
   this.selectPresentBillet=res
 });
}
filterByBillet(value:any){
  this.selectedPresentBillet=this.selectPresentBillet.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

getselectedInstructorType(){
  this.TraineeBIODataOtherService.getselectedBnaInstructorType().subscribe(res=>{
  this.selectedInstructorType=res
  this.selectInstructorType=res
});
}
filterByInstructor(value:any){
  this.selectedInstructorType=this.selectInstructorType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

changeNationality(e) {
  this.nationalityToggle='no';
  
  this.nationalityToggle=e.value;
}
getselectedfailureStatus(){
  this.TraineeBIODataOtherService.getselectedFailurestatus().subscribe(res=>{
  this.selectedFailureStatus=res
  this.selectFailureStatus=res
});
}
filterByfailureStatus(value:any){
  this.selectedFailureStatus=this.selectFailureStatus.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}
 

getselectedCourseName(){
  this.TraineeBIODataOtherService.getselectedCourseName().subscribe(res=>{
  this.selectedCourseName=res 
  this.selectCours=res
});
}
filterByCourseName(value:any){
  this.selectedCourseName=this.selectCours.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

getselectedBnaClassSectionSelection(){
  this.TraineeBIODataOtherService.getSelectedBnaClassSectionSelection().subscribe(res=>{
  this.selectedBnaClassSectionSelection=res 
  this.selectBnaSection=res
});
}
filterByBnaPromotion(value:any){
  this.selectedBnaClassSectionSelection=this.selectBnaSection.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

getselectedBnaPromotionStatus(){
  this.TraineeBIODataOtherService.getselectedBnaPromotionStatus().subscribe(res=>{
    this.selectedBnaPromotionStatus=res 
    this.selectPromotion=res
  });
}
filterByPromotion(value:any){
  this.selectedBnaPromotionStatus=this.selectPromotion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

getselectedMaritalStatus(){
  this.TraineeBIODataOtherService.getselectedMaritalStatus().subscribe(res=>{
    this.selectedMaritalStatus=res 
    this.selectStatus=res 
  });
}
filterByStatus(value:any){
  this.selectedMaritalStatus=this.selectStatus.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}
 
getselectedCountry(){
  this.TraineeBIODataOtherService.getselectedCountry().subscribe(res=>{
    this.selectedCountry=res
    this.selectCountry=res  
  }); 
}
filterByCountry(value:any){
  this.selectedCountry=this.selectCountry.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
}

getselectedCaste(){
  this.TraineeBIODataOtherService.getselectedCaste().subscribe(res=>{
    this.selectedCaste=res  
  }); 
} 

getselectedReligion(){
  this.TraineeBIODataOtherService.getselectedReligion().subscribe(res=>{
    this.selectedReligion=res  
  }); 
}

getselecteBloodGroup(){
  this.TraineeBIODataOtherService.getselectedBloodGroup().subscribe(res=>{
    this.selectedBloodGroup=res
  }); 
}
  

  getBNASemesterName(){
    this.TraineeBIODataOtherService.getselectedbnasemester().subscribe(res=>{
      this.bnaSemesterValues=res
      this.selectSemester=res
    });
  }
  filterBySemester(value:any){
    this.bnaSemesterValues=this.selectSemester.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getUTOfficerTypeName(){
    this.TraineeBIODataOtherService.getselectedutofficertype().subscribe(res=>{
      this.utOfficerTypeValues=res
      this.selectOfficerType=res
    });
  }
  filterByOfficer(value:any){
    this.utOfficerTypeValues=this.selectOfficerType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }


  getUTOfficerCategoryName(){
    this.TraineeBIODataOtherService.getselectedUtofficerCategory().subscribe(res=>{
      this.utOfficerCategoryValues=res
      this.selectOfficerCategory=res
    });
  }
  filterByOfficercategory(value:any){
    this.utOfficerCategoryValues=this.selectOfficerCategory.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getBNAServiceTypeName(){
    this.TraineeBIODataOtherService.getselectedbnaservicetype().subscribe(res=>{
      this.bnaServiceTypeValues=res
      this.selectBnaType=res
    });
  }
  filterByService(value:any){
    this.bnaServiceTypeValues=this.selectBnaType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getComplexionName(){
    this.TraineeBIODataOtherService.getselectedcomplexions().subscribe(res=>{
      this.complexionValues=res
      this.selectComplexionType=res
    });
  }
  filterByComplexion(value:any){
    this.complexionValues=this.selectComplexionType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getBranchName(){
    this.TraineeBIODataOtherService.getselectedbranch().subscribe(res=>{
      this.branchValues=res
      this.selectBranch=res
    });
  }
  filterByBranch(value:any){
    this.branchValues=this.selectBranch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getHeightName(){
    this.TraineeBIODataOtherService.getselectedheight().subscribe(res=>{
      this.heightValues=res
    });
  }

  getWeightName(){
    this.TraineeBIODataOtherService.getselectedweight().subscribe(res=>{
      this.weightValues=res
    });
  }

  getColorOfEyeName(){
    this.TraineeBIODataOtherService.getselectedcolorofeye().subscribe(res=>{
      this.colorOfEyeValues=res
    });
  }

   
  
  onSubmit() {
    const id = this.TraineeBIODataOtherForm.get('traineeBioDataOtherId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.TraineeBIODataOtherService.update(+id,this.TraineeBIODataOtherForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-biodata-other-details/'+this.traineeId);
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
      this.loading=true;
      this.TraineeBIODataOtherService.submit(this.TraineeBIODataOtherForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-biodata-other-details/'+this.traineeId);
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
