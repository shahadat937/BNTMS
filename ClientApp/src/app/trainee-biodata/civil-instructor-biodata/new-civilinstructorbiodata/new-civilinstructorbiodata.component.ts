import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';

import { ViewChild, ElementRef } from '@angular/core';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { Role } from '../../../../../src/app/core/models/role';
@Component({
  selector: 'app-new-civilinstructorbiodata',
  templateUrl: './new-civilinstructorbiodata.component.html',
  styleUrls: ['./new-civilinstructorbiodata.component.sass']
  //providers:[BIODataGeneralInfoService]
})
export class NewCivilInstructorBioDataInfoComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
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
  bloodValues: SelectedModel[];
  religionValues: SelectedModel[];
  hairColorValues:SelectedModel[];
  selectedCastes:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectedThana:SelectedModel[];
  fileAttr = 'Choose File';
  imageUrl:string="/assets/img/icon.png";
  public files: any[];
  traineePhoto: string;
  userRoles = Role;

  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { 
    super();
    this.files = [];
  }

  @ViewChild('labelImport')  labelImport: ElementRef;
  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit  Civil Instructor BIO Data';
      this.destination='Edit';
      this.buttonText="Update";
 
      this.BIODataGeneralInfoService.find(+id).subscribe(
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
      this.pageTitle = 'Create Civil Instructor BIO Data';
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

  getselectedCountry(){
    this.BIODataGeneralInfoService.getselectedCountry().subscribe(res=>{
      this.cuntryValues=res
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
      pno: [''],
      name: [''],
      email: ['',[Validators.email]],
      nid: [''],
      passportNo:[''],
      mobile: [''],
      genderId: [''],
      shortCode:[''],
      presentBillet:[''],
      dateOfBirth: [],
      joiningDate: [],
      presentAddress: [''],
      permanentAddress: [''],
      remarks: [''],
      
      fileAttr:[],
      bnaPhotoUrl: [''],
      image: [''],

      officerTypeId: [3], //officerTypeId  for Civil Instructor
      traineeStatusId:['6'], // for Civil Instructor
      userName: [''],
      roleName: [this.userRoles.Student],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],

      // bnaBatchId: [''],
      // rankId: [''],
      // branchId: [''],
      // //divisionId: [''],
      // //districtId: [''],
      // //thanaId: [''],
      // bloodGroupId: [''],
      // countryId:[''],
      // //nationalityId: [''],
      // religionId: [''],
      // casteId: [''],
      // //maritalStatusId: [],
      // hairColorId: [],
      
      // traineeStatusId:['4'],
      
      
      // //bnaNo: [''],
      
      localNominationStatus:[0],
      
      isActive: [true],
    
    })
  }
  
  onSubmit() {

    const id = this.BIODataGeneralInfoForm.get('traineeId')?.value; 

    if(this.BIODataGeneralInfoForm.get('dateOfBirth')?.value){
      const dateOfBirth = this.sharedService.formatDateTime(this.BIODataGeneralInfoForm.get('dateOfBirth')?.value)
      this.BIODataGeneralInfoForm.get('dateOfBirth')?.setValue(dateOfBirth);
    }

    if(this.BIODataGeneralInfoForm.get('joiningDate')?.value){
      const joiningDate = this.sharedService.formatDateTime(this.BIODataGeneralInfoForm.get('joiningDate')?.value)
      this.BIODataGeneralInfoForm.get('joiningDate')?.setValue(joiningDate);
    }

    // this.BIODataGeneralInfoForm.get('dateOfBirth').setValue((new Date(this.BIODataGeneralInfoForm.get('dateOfBirth').value)).toUTCString()) ;
    // this.BIODataGeneralInfoForm.get('joiningDate').setValue((new Date(this.BIODataGeneralInfoForm.get('joiningDate').value)).toUTCString()) ;

    const formData = new FormData();
    if(!this.traineePhoto){
      this.BIODataGeneralInfoForm.value.bnaPhotoUrl = null;
    }
    for (const key of Object.keys(this.BIODataGeneralInfoForm.value)) {
      let value = this.BIODataGeneralInfoForm.value[key];
      if(value === null || value === undefined){
      value = ""

      }
      formData.append(key, value);
    }

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update  Item?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BIODataGeneralInfoService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/civilinstructorbiodata-list');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
            this.loading = false;
          })
        }
      })
    }else {
      this.loading = true;
      this.BIODataGeneralInfoService.submit(formData).subscribe(response => {
        this.router.navigateByUrl('/trainee-biodata/civilinstructorbiodata-list');

        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 3000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
        this.loading = false;
      })
    }
   
  }
  whiteSpaceRemove(value){
    this.BIODataGeneralInfoForm.get('email')?.patchValue(this.BIODataGeneralInfoService.whiteSpaceRemove(value))
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
