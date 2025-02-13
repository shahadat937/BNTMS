import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { SelectedModel } from '../../../../../../src/app/core/models/selectedModel';

import { ViewChild, ElementRef } from '@angular/core';
import { UnsubscribeOnDestroyAdapter } from '../../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';
@Component({
  selector: 'app-new-BIODataGeneralInfo',
  templateUrl: './new-biodata-general-info.component.html',
  styleUrls: ['./new-biodata-general-info.component.sass']
  //providers:[BIODataGeneralInfoService]
})
export class NewBIODataGeneralInfoComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  BIODataGeneralInfoForm: FormGroup;
  validationErrors: string[] = [];

  batchValues:SelectedModel[]; 
  rankValues:SelectedModel[]; 
  genderValues:SelectedModel[];
  divisionValues:SelectedModel[];
  branchValues:SelectedModel[];
  nationalityValues:SelectedModel[];
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[]; 
  colorOfEyeValues:SelectedModel[]; 
  bloodValues: SelectedModel[];
  religionValues: SelectedModel[];
  hairColorValues:SelectedModel[];
  selectedCastes:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectedThana:SelectedModel[];
  fileAttr = 'Choose File';
  imageUrl:string="/assets/img/icon.png";
  public files: any[];

  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { 
    super();
    this.files = [];
  }

  @ViewChild('labelImport')  labelImport: ElementRef;
  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Officer BIO Data';
      this.destination='Edit';
      this.buttonText="Update";
 
      this.BIODataGeneralInfoService.find(+id).subscribe(
        res => {
          if (res) {
            this.BIODataGeneralInfoForm.patchValue(res);
          }   
          this.onDivisionSelectionChangeGetDistrict(res.divisionId);
          this.onDistrictSelectionChangeGetThana(res.districtId);
          this.onReligionSelectionChangeGetCastes(res.religionId);

        }
      );
    } else {
      this.pageTitle = 'Create Officer BIO Data';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    this.getBatchs();
    this.getRanks();
    this.getGenders();
    this.getDivisions();
    this.getBranch();
    this.getNationalitys();
    this.getselectedheight();
    this.getselectedweight();
    this.getselectedcolorofeye();
    this.getselectedbloodgroup();
    this.getreligions();
    this.gethaircolors();
    
  }

  getBatchs(){
    this.BIODataGeneralInfoService.getselectedbnabatch().subscribe(res=>{
      this.batchValues=res
    });
  }
  getreligions(){
    this.BIODataGeneralInfoService.getselectedreligion().subscribe(res=>{
      this.religionValues=res
    });
  }
  gethaircolors(){
    this.BIODataGeneralInfoService.getselectedhaircolor().subscribe(res=>{
      this.hairColorValues=res
    });
  }  

  getselectedheight(){
    this.BIODataGeneralInfoService.getselectedheight().subscribe(res=>{
      this.heightValues=res
    });
  }

  getselectedweight(){
    this.BIODataGeneralInfoService.getselectedweight().subscribe(res=>{
      this.weightValues=res
    });
  }

  getselectedcolorofeye(){
    this.BIODataGeneralInfoService.getselectedcolorofeye().subscribe(res=>{
      this.colorOfEyeValues=res
    });
  }

  getselectedbloodgroup(){
    this.BIODataGeneralInfoService.getselectedbloodgroup().subscribe(res=>{
      this.bloodValues=res
    });
  }

  getNationalitys(){
    this.BIODataGeneralInfoService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
    });
  }

  getBranch(){
    this.BIODataGeneralInfoService.getselectedbranch().subscribe(res=>{
      this.branchValues=res
    });
  }

  getRanks(){
    this.BIODataGeneralInfoService.getselectedrank().subscribe(res=>{
      this.rankValues=res
    });
  }

  getGenders(){
    this.BIODataGeneralInfoService.getselectedgender().subscribe(res=>{
      this.genderValues=res
    });
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      // this.labelImport.nativeElement.value = file.name;
    // this.BIODataGeneralInfoForm.controls["picture"].setValue(event.target.files[0]);
      this.BIODataGeneralInfoForm.patchValue({
        image: file,
      });
    }
  }
  getDivisions(){
    this.BIODataGeneralInfoService.getselecteddivision().subscribe(res=>{
      this.divisionValues=res
    });
  }

  onDivisionSelectionChangeGetDistrict(divisionId){
    this.BIODataGeneralInfoService.getdistrictbydivision(divisionId).subscribe(res=>{
      this.selectedDistrict=res
    });
  }

  onDistrictSelectionChangeGetThana(districtId){
    this.BIODataGeneralInfoService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
    });
  }

  onReligionSelectionChangeGetCastes(religionId){
    this.BIODataGeneralInfoService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
    });
  } 

  
  intitializeForm() {
    let now = new Date();
    this.BIODataGeneralInfoForm = this.fb.group({
      traineeId: [0],
      bnaBatchId: ['', Validators.required],
      rankId: ['',Validators.required],
      branchId: ['',Validators.required],
      divisionId: [''],
      districtId: [''],
      thanaId: [''],
      heightId: ['',Validators.required],
      weightId: ['',Validators.required],
      colorOfEyeId: ['',Validators.required],
      genderId: ['',Validators.required],
      bloodGroupId: ['',Validators.required],
      nationalityId: ['',Validators.required],
      religionId: ['',Validators.required],
      casteId: ['',Validators.required],
      //maritalStatusId: [],
      hairColorId: [],
      officerTypeId: [],
      traineeStatusId:['4'],
      name: ['',Validators.required],
      nameBangla: [''],
      mobile: [''],
      fileAttr:[],
      email: [''],
      bnaPhotoUrl: [''],
      image: [''],
      bnaNo: ['',Validators.required],
      pno: ['',Validators.required],
      shortCode:[''],
      presentBillet:[''],
      dateOfBirth: [now,Validators.required],
      joiningDate: [now,Validators.required],
      identificationMark: [''],
      presentAddress: [''],
      permanentAddress: [''],
      nid: ['',Validators.required],
      remarks: [''],
      
      isActive: [true],
    
    })
  }
  
  onSubmit() {

    const id = this.BIODataGeneralInfoForm.get('traineeId')?.value; 

    this.BIODataGeneralInfoForm.get('dateOfBirth')?.setValue((new Date(this.BIODataGeneralInfoForm.get('dateOfBirth')?.value)).toUTCString()) ;
    this.BIODataGeneralInfoForm.get('joiningDate')?.setValue((new Date(this.BIODataGeneralInfoForm.get('joiningDate')?.value)).toUTCString()) ;

    const formData = new FormData();
    for (const key of Object.keys(this.BIODataGeneralInfoForm.value)) {
      const value = this.BIODataGeneralInfoForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update  Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.BIODataGeneralInfoService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/bna-trainee-biodata/trainee-biodata-tab/biodata-general-Info-list');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 3000,
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
      this.BIODataGeneralInfoService.submit(formData).subscribe(response => {
        this.router.navigateByUrl('/bna-trainee-biodata/trainee-biodata-tab/biodata-general-Info-list');

        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 3000,
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
