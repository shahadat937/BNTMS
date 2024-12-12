import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

import { ViewChild, ElementRef } from '@angular/core';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import {  Role } from 'src/app/core/models/role';
@Component({
  selector: 'app-new-foreignbiodatainfo',
  templateUrl: './new-foreignbiodatainfo.component.html',
  styleUrls: ['./new-foreignbiodatainfo.component.sass']
  //providers:[BIODataGeneralInfoService]
})
export class NewForeignBIODataInfoComponent implements OnInit, OnDestroy {
  @ViewChild('fileInput') fileInput!: ElementRef<HTMLInputElement>; 
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
  cuntryValues:SelectedModel[];
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[]; 
  colorOfEyeValues:SelectedModel[]; 
  selectColor:SelectedModel[]
  bloodValues: SelectedModel[];
  selectBlood:SelectedModel[];
  religionValues: SelectedModel[];
  selectReligion:SelectedModel[];
  hairColorValues:SelectedModel[];
  selectHairColor:SelectedModel[];
  selectedCastes:SelectedModel[];
  selectCastes:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectBranch:SelectedModel[];
  selectRank:SelectedModel[];
  selectedThana:SelectedModel[];
  selectBatchValue: SelectedModel[];
  selectCountry:SelectedModel[];
  fileAttr = 'Choose File';
  imageUrl:string="/assets/img/icon.png";
  public files: any[];
  subscription: any;
  traineePhoto: string;
  userRole = Role;

  constructor(
    private snackBar: MatSnackBar,
    private BIODataGeneralInfoService: BIODataGeneralInfoService,
    private fb: FormBuilder, private router: Router, 
    private route: ActivatedRoute,private confirmService: ConfirmService,
    public sharedService: SharedServiceService
    
    ) { 
    this.files = [];
  }

  @ViewChild('labelImport')  labelImport: ElementRef;
  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit  Foreign Officer BIO Data';
      this.destination='Edit';
      this.buttonText="Update";
 
      this.subscription = this.BIODataGeneralInfoService.find(+id).subscribe(
        res => {
          if (res) {
            this.BIODataGeneralInfoForm.patchValue(res);
          }   
          this.traineePhoto = res.bnaPhotoUrl;
          this.onDivisionSelectionChangeGetDistrict(res.divisionId);
          this.onDistrictSelectionChangeGetThana(res.districtId);
          this.onReligionSelectionChangeGetCastes(res.religionId);

        }
      );
    } else {
      this.pageTitle = 'Create Foreign Officer BIO Data';
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
    this.getselectedCountry();
    this.getselectedheight();
    this.getselectedweight();
    this.getselectedcolorofeye();
    this.getselectedbloodgroup();
    this.getreligions();
    this.gethaircolors();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getBatchs(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbnabatch().subscribe(res=>{
      this.batchValues=res
      this.selectBatchValue=res
    });
  }
filterBna(value:any){
  this.batchValues= this.selectBatchValue.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}

  getreligions(){
    this.subscription = this.BIODataGeneralInfoService.getselectedreligion().subscribe(res=>{
      this.religionValues=res
      this.selectReligion=res
    });
  }
  filterByReligion(value:any){
    this.religionValues=this.selectReligion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  gethaircolors(){
    this.subscription = this.BIODataGeneralInfoService.getselectedhaircolor().subscribe(res=>{
      this.hairColorValues=res
      this.selectHairColor=res
    });
  }  
  filterByHairColor(value:any){
    this.hairColorValues=this.selectHairColor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedheight(){
    this.subscription = this.BIODataGeneralInfoService.getselectedheight().subscribe(res=>{
      this.heightValues=res
    });
  }

  getselectedweight(){
    this.subscription = this.BIODataGeneralInfoService.getselectedweight().subscribe(res=>{
      this.weightValues=res
    });
  }

  getselectedcolorofeye(){
    this.subscription = this.BIODataGeneralInfoService.getselectedcolorofeye().subscribe(res=>{
      this.colorOfEyeValues=res
      this.selectColor=res
    });
  }

  filterByColor(value:any){
    this.colorOfEyeValues=this.selectColor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedbloodgroup(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbloodgroup().subscribe(res=>{
      this.bloodValues=res
      this.selectBlood=res
    });
  }
  filterByBloodGroup(value:any){
    this.bloodValues=this.selectBlood.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getNationalitys(){
    this.subscription = this.BIODataGeneralInfoService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
    });
  }

filterCountry(value:any){
  this.cuntryValues = this.selectCountry.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}

  getselectedCountry(){
    this.subscription = this.BIODataGeneralInfoService.getselectedCountry().subscribe(res=>{
      this.cuntryValues=res
      this.selectCountry= res
    });
  }

  filterBranch(value:any){
    this.branchValues= this.selectBranch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getBranch(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbranch().subscribe(res=>{
      this.branchValues=res
      this.selectBranch=res
    });
  }


  rankFilter(value:any){
  this.rankValues=this.selectRank.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}



  getRanks(){
    this.subscription = this.BIODataGeneralInfoService.getselectedrank().subscribe(res=>{
      this.rankValues=res
      this.selectRank=res
    });
  }

  getGenders(){
    this.subscription = this.BIODataGeneralInfoService.getselectedgender().subscribe(res=>{
      this.genderValues=res
    });
  }

  // onFileChanged(event) {
  //   if (event.target.files.length > 0) {
  //     const file = event.target.files[0];
  //     // this.labelImport.nativeElement.value = file.name;
  //   // this.BIODataGeneralInfoForm.controls["picture"].setValue(event.target.files[0]);
  //     this.BIODataGeneralInfoForm.patchValue({
  //       image: file,
  //     });
  //   }
  // }

  onFileChanged(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      const file = input.files[0];
      const reader = new FileReader();
  
      reader.onload = () => {
        this.traineePhoto = reader.result as string; // Set traineePhoto to the image data URL
      };
  
      reader.readAsDataURL(file); // Read file as data URL
  
      // Update form control with the file
      if (this.BIODataGeneralInfoForm && this.BIODataGeneralInfoForm.controls['image']) {
        this.BIODataGeneralInfoForm.patchValue({
          image: file,
        });
      }
    }
  }

  

  getDivisions(){
    this.subscription = this.BIODataGeneralInfoService.getselecteddivision().subscribe(res=>{
      this.divisionValues=res
    });
  }

  onDivisionSelectionChangeGetDistrict(divisionId){
    this.subscription = this.subscription = this.BIODataGeneralInfoService.getdistrictbydivision(divisionId).subscribe(res=>{
      this.selectedDistrict=res
    });
  }

  onDistrictSelectionChangeGetThana(districtId){
    this.subscription = this.BIODataGeneralInfoService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
    });
  }

  onReligionSelectionChangeGetCastes(religionId){
    this.subscription = this.BIODataGeneralInfoService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
      this.selectCastes=res
    });
  } 
  filterByCaste(value:any){
    this.selectedCastes=this.selectCastes.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  // getMaritalStatus(){
  //   this.BIODataGeneralInfoService.getselectedMaritialStatus().subscribe(res=>{
  //     this.maritalValues=res
  //   });
  // }

  // uploadFileEvt(imgFile: any) {
  //   if (imgFile.target.files && imgFile.target.files[0]) {
  //     this.fileAttr = '';
  //     Array.from(imgFile.target.files).forEach((file: any) => {
  //       this.fileAttr += file.name + ' - ';
  //     });
  //     const file = imgFile.target.files[0].name;
  //     // this.labelImport.nativeElement.innerText = file.name;
  //     this.BIODataGeneralInfoForm.patchValue({
  //       image: file,
  //     });
  //     // HTML5 FileReader API
  //     // let reader = new FileReader();
  //     // reader.onload = (e: any) => {
  //     //   let image = new Image();
  //     //   image.src = e.target.result;
  //     //   image.onload = (rs) => {
  //     //     let imgBase64Path = e.target.result;
  //     //   };
  //     // };
  //     // reader.readAsDataURL(imgFile.target.files[0]);
  //     // // Reset if duplicate image uploaded again
  //      this.fileInput.nativeElement.value = '';
  //   } else {
  //     this.fileAttr = 'Choose File';
  //   }
  // }

  intitializeForm() {
    let now = new Date();
    this.BIODataGeneralInfoForm = this.fb.group({
      traineeId: [0],
      bnaBatchId: [''],
      rankId: [''],
      branchId: [''],
      //divisionId: [''],
      //districtId: [''],
      //thanaId: [''],
      heightId: [''],
      weightId: [''],
      colorOfEyeId: [''],
      genderId: [''],
      bloodGroupId: [''],
      countryId:[''],
      //nationalityId: [''],
      religionId: [''],
      casteId: [''],
      //maritalStatusId: [],
      hairColorId: [],
      officerTypeId: [2], //officerTypeId  for Foreign
      traineeStatusId:['4'],
      name: [''],
      nameBangla: [''],
      mobile: [''],
      passportNo:[''],
      fileAttr:[],
      email: ['', [Validators.email]],
      bnaPhotoUrl: [''],
      image: [''],
      //bnaNo: [''],
      pno: [''],
      shortCode:[''],
      presentBillet:[''],
      dateOfBirth: [null],
      joiningDate: [null],
      identificationMark: [''],
      presentAddress: [''],
      permanentAddress: [''],
      nid: [''],
      remarks: [''],
      //localNominationStatus:[""],
      isActive: [true],
      userName: [''],
      roleName: [this.userRole.Student],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],
    
    })
  }
  
  onSubmit() {

    const id = this.BIODataGeneralInfoForm.get('traineeId').value; 

    if(this.BIODataGeneralInfoForm.get('dateOfBirth').value){
      const dateOfBirth = this.sharedService.formatDateTime(this.BIODataGeneralInfoForm.get('dateOfBirth').value)
      this.BIODataGeneralInfoForm.get('dateOfBirth')?.setValue(dateOfBirth);
    }

    // this.BIODataGeneralInfoForm.get('dateOfBirth').setValue((new Date(this.BIODataGeneralInfoForm.get('dateOfBirth').value)).toUTCString()) ;
    // this.BIODataGeneralInfoForm.get('joiningDate').setValue((new Date(this.BIODataGeneralInfoForm.get('joiningDate').value)).toUTCString()) ;

    const formData = new FormData();

    if(!this.traineePhoto){
      this.BIODataGeneralInfoForm.value.bnaPhotoUrl = null;
    }

    for (const key of Object.keys(this.BIODataGeneralInfoForm.value)) {
      
      let value = this.BIODataGeneralInfoForm.value[key];
      if(value=== null || value === undefined){
        value = ""
      }
      formData.append(key, value);
    }

    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update  Item?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BIODataGeneralInfoService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/foreignbiodatainfo-list');
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
      this.loading = true;
      this.subscription = this.BIODataGeneralInfoService.submit(formData).subscribe(response => {
        this.router.navigateByUrl('/trainee-biodata/foreignbiodatainfo-list');

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
  whiteSpaceRemove(value){
    this.BIODataGeneralInfoForm.get('email').patchValue(this.BIODataGeneralInfoService.whiteSpaceRemove(value))
   }
   removeImage(event: Event) {
    event.preventDefault(); 

   
    this.traineePhoto = '';

   
    if (this.fileInput && this.fileInput.nativeElement) {
      this.fileInput.nativeElement.value = ''; 
    }
  }

  handleImageError() {
    this.traineePhoto = ''; 
  }
}
