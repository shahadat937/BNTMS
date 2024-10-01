
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { Subscription } from 'rxjs';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
 
@Component({
  selector: 'app-new-BIODataGeneralInfo',
  templateUrl: './new-biodata-general-info.component.html',
  styleUrls: ['./new-biodata-general-info.component.sass']
  //providers:[BIODataGeneralInfoService]
})
export class NewBIODataGeneralInfoComponent extends UnsubscribeOnDestroyAdapter implements OnInit,OnDestroy {
  masterData = MasterData;
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  BIODataGeneralInfoForm: FormGroup;
  validationErrors: string[] = [];
  rankValues:SelectedModel[]; 
  selectedSaylorBranch:SelectedModel[]; 
  sailorBranch:SelectedModel[];
  selectedSaylorRank:SelectedModel[];
  selectedSaylorSubBranch:SelectedModel[];
  selectSubBranch:SelectedModel[];
  genderValues:SelectedModel[];
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[]; 
  colorOfEyeValues:SelectedModel[]; 
  selectEyeColor:SelectedModel[];
  bloodValues: SelectedModel[];
  religionValues: SelectedModel[];
  casteValues:SelectedModel[];
  hairColorValues:SelectedModel[];
  selectHairColor:SelectedModel[];
  maritialStatusValues:SelectedModel[];
  selectedCastes:SelectedModel[];
  selectCastes:SelectedModel[];
  selectedBaseName:SelectedModel[];
  filteredSelectedBaseName: SelectedModel[];
  filterSailorRank: SelectedModel[];
  filterSailorBranch: SelectedModel[];
  selectedWeight: SelectedModel[];
  filterweight: SelectedModel[];
  selectheight: SelectedModel[];
  filterheight: SelectedModel[];
  selectBloodGroup: SelectedModel[];
  filterbloodgroup: SelectedModel[];
  filterByReligion: SelectedModel[];
  selectedReligion: SelectedModel[];
  selectRank:SelectedModel[];

  private subscription: Subscription;
  imageUrl:string="/assets/img/icon.png";
  public files: any[];
  selectedSailorRank: SelectedModel[];

  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) { 
    super();
    this.files = [];
  }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Sailor BIO Data';
      this.destination='Edit';
      this.buttonText="Update";
 
      this.BIODataGeneralInfoService.find(+id).subscribe(
        res => {
          if (res) {
            this.BIODataGeneralInfoForm.patchValue(res);
          }  
          this.onReligionSelectionChangeGetCastes(res.religionId);  
          this.onBranchSelectionChangegetSubBranch(res.saylorBranchId)  
        }
      );
    } else {
      this.pageTitle = 'Create Sailor BIO Data';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    this.getRanks();
    this.getGenders();
    this.getselectedheight();
    this.getselectedweight();
    this.getselectedcolorofeye();
    this.getselectedbloodgroup();
    this.getreligions();
    this.getselectedcaste();
    this.gethaircolors();
    this.getMaritialStatus();
    this.getselectedSaylorBranch();
    this.getselectedSaylorRank();
    this.getselectedSailorRank();
    //this.getselectedSaylorSubBranch();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
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

  getreligions(){
    this.subscription =this.BIODataGeneralInfoService.getselectedreligion().subscribe(res=>{
      this.religionValues=res
      this.selectedReligion=res
    });
  }
  gethaircolors(){
    this.subscription = this.BIODataGeneralInfoService.getselectedhaircolor().subscribe(res=>{
      this.hairColorValues=res
      this.selectHairColor=res
    
    });
  }
  filterByHairColor(value:any){
    this.hairColorValues=this.selectHairColor.filter(x=> x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedcaste(){
    this.BIODataGeneralInfoService.getselectedcaste().subscribe(res=>{
      this.casteValues=res
    
    });
  }
  filterBaseName(value:any) {
    console.log(value);
    this.filteredSelectedBaseName = this.selectedBaseName.filter(x=> x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }
  getselectedheight(){
    this.subscription = this.BIODataGeneralInfoService.getselectedheight().subscribe(res=>{
      this.heightValues=res
    
    });
  }

  getselectedweight(){
    this.subscription = this.BIODataGeneralInfoService.getselectedweight().subscribe(res=>{
      this.weightValues=res
      this.selectedWeight=res
    });
  }
  filterSaylorRank(value:any) {
    this.selectedSailorRank = this.selectRank.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }

  filterSaylorBranch(value:any){
    this.sailorBranch = this.selectedSaylorBranch.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  // filterWeight(value:any){
  //   this.weightValues = this.selectedWeight.filter(x=>x.value)
  // }
  
  // filterHeight(value:any){
  //   this.filterheight = this.selectedWeight.filter(x=>x.value)
  // }
  
  filterBloodgroup(value:any){
    this.bloodValues = this.selectBloodGroup.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  filterbyReligion(value:any){
    this.religionValues = this.selectedReligion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().filter(/\s/g,'')))
  }

  getselectedcolorofeye(){
    this.subscription = this.BIODataGeneralInfoService.getselectedcolorofeye().subscribe(res=>{
      this.colorOfEyeValues=res
      this.selectEyeColor=res
    
    });
  }
  filterByEyeCoor(value:any){
    this.colorOfEyeValues=this.selectEyeColor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedbloodgroup(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbloodgroup().subscribe(res=>{
      this.bloodValues=res
      this.selectBloodGroup=res
    });
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
  getselectedSaylorBranch(){
    this.subscription = this.BIODataGeneralInfoService.getselectedSaylorBranch().subscribe(res=>{
      this.sailorBranch=res
      this.selectedSaylorBranch=res
     
    });
  }
  getselectedSaylorRank(){
    this.subscription = this.BIODataGeneralInfoService.getselectedSaylorRank().subscribe(res=>{
      this.selectedSaylorRank=res
     
    });
  }
  getselectedSailorRank(){
    this.subscription = this.BIODataGeneralInfoService.getselectedSailorRank().subscribe(res=>{
      this.selectedSailorRank=res
     this.selectRank=res
    });
  }
  onBranchSelectionChangegetSubBranch(saylorBranchId){
    var saylorBranchId
    this.subscription = this.BIODataGeneralInfoService.getselectedSaylorSubBranch(saylorBranchId).subscribe(res=>{
      this.selectedSaylorSubBranch=res
      this.selectSubBranch=res
    });
  }
  filterBySubBranch(value:any){
    this.selectedSaylorSubBranch=this.selectSubBranch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getMaritialStatus(){
    this.subscription = this.BIODataGeneralInfoService.getselectedmaritialstatus().subscribe(res=>{
      this.maritialStatusValues=res
     
    });
  }

  onReligionSelectionChangeGetCastes(religionId){
    this.subscription = this.BIODataGeneralInfoService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
      this.selectCastes=res
    });
  } 

  filterByCastes(value:any){
    this.selectedCastes=this.selectCastes.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  intitializeForm() {
    this.BIODataGeneralInfoForm = this.fb.group({
      traineeId: [0],
      traineeStatusId: ['5'],
      //rankId: [],
      heightId: [''],
      weightId: [''],
      colorOfEyeId: [],
      genderId: [],
      bloodGroupId: [],
      religionId: [],
      saylorBranchId:[''],
      saylorRankId:[''],
      saylorSubBranchId:[''],
      casteId: [],
      maritalStatusId: [],
      hairColorId: [],
      bnaPhotoUrl:[''],
      image: [''],
      name: [''],
      nameBangla: [''],
      nickName: [''],
      localNo: [''],
      chestNo: [''],
      idCardNo: [''],
      shoeSize: [''],
      pantSize: [''],
      nominee: [''],
      closeRelative: [''],
      relativeRelation: [''],
      mobile: [''],
      email: [''],
      pno: [''],
      dateOfBirth: [''],
      joiningDate: [],
      identificationMark: [''],
      presentAddress: [''],
      permanentAddress: [''],
      passportNo: [''],
      nid: [''],
      remarks: [''],
      localNominationStatus:[0],
      isActive: [true],

      // traineeId:[],
      //bnaBatchId:[],
      //rankId:[],
      //branchId:[],
      //divisionId:[],
      //districtId:[],
      //thanaId:[],
      // heightId:[],
      // weightId:[],
      // colorOfEyeId:[],
      // genderId:[],
      // bloodGroupId:[],
      //nationalityId:[],
       //countryId:[],    // countryId = 1 for Bangladesh
      // religionId:[],
      // casteId:[],
      // maritalStatusId:[''],
      // hairColorId:[],
      //officerTypeId:[],
      // saylorBranchId:[''],
      // saylorRankId:[''],
      // saylorSubBranchId:[''],
      // name:[],
      // nickName:[],
      // nameBangla:[],
      // chestNo:[],
      // localNo :[],
      // idCardNo:[],
      // shoeSize:[],
      // pantSize:[],
      // nominee:[],
      // closeRelative:[],
      // relativeRelation:[],
      // mobile:[],
      // email:[],
      // bnaPhotoUrl:[],
      bnaNo:[],
      // pno:[],
      shortCode:[],
      presentBillet:[],
      // dateOfBirth:[],
      // joiningDate:[],
      // identificationMark:[],
      // presentAddress:[],
      // permanentAddress:[],
      // traineeStatusId:[],
      // passportNo:[],
      // nid:[],
      // remarks :[],
      // menuPosition :[],
      // isActive :[],
      // localNominationStatus:[],
    
    })
  }
  
  onSubmit() {

    const id = this.BIODataGeneralInfoForm.get('traineeId').value; 

    this.BIODataGeneralInfoForm.get('dateOfBirth').setValue((new Date(this.BIODataGeneralInfoForm.get('dateOfBirth').value)).toUTCString()) ;
    this.BIODataGeneralInfoForm.get('joiningDate').setValue((new Date(this.BIODataGeneralInfoForm.get('joiningDate').value)).toUTCString()) ;
    
    var traineeStatusId = this.BIODataGeneralInfoForm.get('traineeStatusId').value; 
    if(traineeStatusId == this.masterData.TraineeStatus.sailor){
      // this.BIODataGeneralInfoForm.get('bnaBatchId').setValue(282);
      // this.BIODataGeneralInfoForm.get('branchId').setValue(17);
      // this.BIODataGeneralInfoForm.get('countryId').setValue(217);
      // this.BIODataGeneralInfoForm.get('districtId').setValue(1105);
      // this.BIODataGeneralInfoForm.get('divisionId').setValue(1033);
      // this.BIODataGeneralInfoForm.get('nationalityId').setValue(25);
      // this.BIODataGeneralInfoForm.get('officerTypeId').setValue(1);
      // this.BIODataGeneralInfoForm.get('rankId').setValue("NULL");
      // this.BIODataGeneralInfoForm.get('thanaId').setValue(504);
    }

    const formData = new FormData();
    for (const key of Object.keys(this.BIODataGeneralInfoForm.value)) {
      const value = this.BIODataGeneralInfoForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.BIODataGeneralInfoService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/sailor-biodata-tab/biodata-general-Info-list');
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
        this.router.navigateByUrl('/trainee-biodata/sailor-biodata-tab/biodata-general-Info-list');
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
  whiteSpaceRemove(value){
    this.BIODataGeneralInfoForm.get('email').patchValue(this.BIODataGeneralInfoService.whiteSpaceRemove(value))
   }
   
}
