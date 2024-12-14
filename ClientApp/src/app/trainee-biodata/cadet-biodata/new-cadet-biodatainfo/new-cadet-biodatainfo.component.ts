import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SelectedModel } from '../../../core/models/selectedModel';
import { Role } from '../../../core/models/role';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';

@Component({
  selector: 'app-new-cadet-biodatainfo',
  templateUrl: './new-cadet-biodatainfo.component.html',
  styleUrls: ['./new-cadet-biodatainfo.component.sass']
})
export class NewCadetBiodatainfoComponent implements OnInit {

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
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[]; 
  colorOfEyeValues:SelectedModel[]; 
  bloodValues: SelectedModel[];
  religionValues: SelectedModel[];
  hairColorValues:SelectedModel[];
  selectedCastes:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectedThana:SelectedModel[];
  selectrank: SelectedModel[];
  selectDivision: SelectedModel[];
  selectBranch: SelectedModel[];
  selectBatch: SelectedModel[];
  selectDistric:SelectedModel[];
  selectThana: SelectedModel[];
  selectReligion: SelectedModel[];
  selectcaste: SelectedModel[];
  selectBloodGroup:SelectedModel[];
  userRole = Role;
  fileAttr = 'Choose File';
  imageUrl:string="/assets/img/icon.png";
  public files: any[];
  subscription: any;
  traineePhoto: string;

  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { 
    this.files = [];
  }

  @ViewChild('labelImport')  labelImport: ElementRef;
  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Cadet BIO Data';
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
      this.pageTitle = 'Cadet BIO Data';
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
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  filterByBatch(value:any){
    this.batchValues = this.selectBatch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getBatchs(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbnabatch().subscribe(res=>{
      this.batchValues=res
      this.selectBatch=res
    });
  }
  filterByReligion(value:any){
    this.religionValues = this.selectReligion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getreligions(){
    this.subscription = this.BIODataGeneralInfoService.getselectedreligion().subscribe(res=>{
      this.religionValues=res
      this.selectReligion=res
    });
  }
  gethaircolors(){
    this.subscription = this.BIODataGeneralInfoService.getselectedhaircolor().subscribe(res=>{
      this.hairColorValues=res
    });
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
    });
  }
  filterBloodGroup(value:any){
    this.bloodValues = this.selectBloodGroup.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedbloodgroup(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbloodgroup().subscribe(res=>{
      this.bloodValues=res
      this.selectBloodGroup=res
    });
  }

  getNationalitys(){
    this.subscription = this.BIODataGeneralInfoService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
    });
  }
  filterByBranch(value:any){
    this.branchValues = this.selectBranch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getBranch(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbranch().subscribe(res=>{
      this.branchValues=res
      this.selectBranch=res
    });
  }

  filterByRank(value:any){
    this.rankValues=this.selectrank.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getRanks(){
    this.subscription = this.BIODataGeneralInfoService.getselectedrank().subscribe(res=>{
      this.rankValues=res
      this.selectrank=res
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


  filterDivision(value:any){
      this.divisionValues=this.selectDivision.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getDivisions(){
    this.subscription = this.BIODataGeneralInfoService.getselecteddivision().subscribe(res=>{
      this.divisionValues=res
      this.selectDivision=res
    });
  }

  filterByDistric(value:any){
    this.selectedDistrict=this.selectDistric.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onDivisionSelectionChangeGetDistrict(divisionId){
    this.subscription = this.BIODataGeneralInfoService.getdistrictbydivision(divisionId).subscribe(res=>{
      this.selectedDistrict=res
      this.selectDistric=res
    });
  }

  filterByThana(value:any){
    this.selectedThana = this.selectThana.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onDistrictSelectionChangeGetThana(districtId){
    this.subscription = this.BIODataGeneralInfoService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
      this.selectThana=res
    });
  }
filterByCaste(value:any){
  this.selectedCastes = this.selectcaste.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  onReligionSelectionChangeGetCastes(religionId){
    this.subscription = this.BIODataGeneralInfoService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
      this.selectcaste=res
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
      bnaBatchId: [''],
      rankId: [''],
      branchId: [''],
      divisionId: [''],
      districtId: [''],
      thanaId: [''],
      countryId:[1],
      heightId: [''],
      weightId: [''],
      colorOfEyeId: [''],
      genderId: [''],
      bloodGroupId: [''],
      //nationalityId: [''],
      religionId: [''],
      casteId: [''],
      //maritalStatusId: [],
      hairColorId: [],
      officerTypeId: [1], //officerTypeId 1 For Bangladesh
      traineeStatusId:['9'], // for Cadet
      name: ['',Validators.required],
      nameBangla: [''],
      mobile: [''],
      fileAttr:[],
      email: ['', [Validators.email]],
      bnaPhotoUrl: [''],
      image: [''],
      bnaNo: ['',Validators.required],
      pno: ['', Validators.required],
      shortCode:[''],
      presentBillet:[''],
      dateOfBirth: [],
      joiningDate: [],
      identificationMark: [''],
      presentAddress: [''],
      permanentAddress: [''],
      nid: [''],
      remarks: [''],
      localNominationStatus:[0],
      isActive: [true],
      id: [0],
      userName: [''],
      roleName: [this.userRole.Student],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName:['na'],

      //traineeId:[],
      //bnaBatchId:[],
      //rankId:[],
      //branchId:[],
      //divisionId:[],
      //districtId:[],
      //thanaId:[],
      //heightId:[],
      //weightId:[],
      //colorOfEyeId:[],
      //genderId:[],
      //bloodGroupId:[],
      //nationalityId:[],
      //countryId:[],
      //religionId:[],
      //casteId:[],
      //maritalStatusId:[''],
      //hairColorId:[],
      //officerTypeId:[],
      //saylorBranchId:[''],
      //saylorRankId:[''],
      //saylorSubBranchId:[''],
      //name:[],
      nickName:[],
      //nameBangla:[],
      chestNo:[],
      localNo :[],
      idCardNo:[],
      shoeSize:[],
      pantSize:[],
      nominee:[],
      closeRelative:[],
      relativeRelation:[],
      //mobile:[],
      //email:[],
      //bnaPhotoUrl:[],
      //bnaNo:[],
      //pno:[],
      //shortCode:[],
      //presentBillet:[],
      //dateOfBirth:[],
      //joiningDate:[],
      //identificationMark:[],
      //presentAddress:[],
      //permanentAddress:[],
      //traineeStatusId:[],
      passportNo:[],
      //nid:[],
      //remarks :[],
      //menuPosition :[],
      //isActive :[],
      //localNominationStatus:[],
    
    })
  }
  
  onSubmit() {

    const id = this.BIODataGeneralInfoForm.get('traineeId')?.value; 

    if(this.BIODataGeneralInfoForm.get('joiningDate')?.value){
      const joiningDate = this.sharedService.formatDateTime(this.BIODataGeneralInfoForm.get('joiningDate')?.value)
      this.BIODataGeneralInfoForm.get('joiningDate')?.setValue(joiningDate);
    }
    if(this.BIODataGeneralInfoForm.get('dateOfBirth')?.value){
      const dateOfBirth = this.sharedService.formatDateTime(this.BIODataGeneralInfoForm.get('dateOfBirth')?.value)
      this.BIODataGeneralInfoForm.get('dateOfBirth')?.setValue(dateOfBirth);
    }    

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
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BIODataGeneralInfoService.update(+id,formData).subscribe(response => {
            this.sharedService.goBack();
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
      this.subscription = this.BIODataGeneralInfoService.submit(formData).subscribe(response => {
        this.sharedService.goBack();

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
