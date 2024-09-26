import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-update-BIODataGeneralInfo',
  templateUrl: './update-traineebiodatageneralinfo.component.html',
  styleUrls: ['./update-traineebiodatageneralinfo.component.sass']
  //providers:[BIODataGeneralInfoService]
})
export class UpdateTraineeBIODataGeneralInfoComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:string;
  BIODataGeneralInfoForm: FormGroup;
  validationErrors: string[] = [];

  batchValues:SelectedModel[]; 
  selectBatch:SelectedModel[];
  rankValues:SelectedModel[]; 
  selectRank:SelectedModel[];
  genderValues:SelectedModel[];
  divisionValues:SelectedModel[];
  selectDivision:SelectedModel[];
  branchValues:SelectedModel[];
  selectBranch:SelectedModel[];
  nationalityValues:SelectedModel[];
  selectNationality:SelectedModel[];
  heightValues:SelectedModel[]; 
  weightValues:SelectedModel[]; 
  colorOfEyeValues:SelectedModel[]; 
  selectEyeColor:SelectedModel[];
  bloodValues: SelectedModel[];
  selectBloodGroup:SelectedModel[];
  religionValues: SelectedModel[];
  selectReligion:SelectedModel[];
  hairColorValues:SelectedModel[];
  selectHairColor:SelectedModel[]
  selectedCastes:SelectedModel[];
  selectCaste:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectDistrict:SelectedModel[];
  selectedThana:SelectedModel[];
  selectThana:SelectedModel[]

  imageUrl:string="/assets/img/icon.png";
  public files: any[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) { 
    this.files = [];
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Update General Information';
      this.destination='Update';
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

  getBatchs(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbnabatch().subscribe(res=>{
      this.batchValues=res
      this.selectBatch=res
    });
  }
  filterByBatch(value:any){
    this.batchValues=this.selectBatch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
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
      this.selectEyeColor=res
    });
  }

  filterByEyeColoe(value:any){
    this.colorOfEyeValues=this.selectEyeColor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedbloodgroup(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbloodgroup().subscribe(res=>{
      this.bloodValues=res
      this.selectBloodGroup=res
    });
  }
  filterByBloodGroup(value:any){
    this.bloodValues=this.selectBloodGroup.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getNationalitys(){
    this.subscription = this.BIODataGeneralInfoService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
      this.selectNationality=res
    });
  }
  filterByNationality(value:any){
    this.nationalityValues=this.selectNationality.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getBranch(){
    this.subscription = this.BIODataGeneralInfoService.getselectedbranch().subscribe(res=>{
      this.branchValues=res
      this.selectBranch=res
    });
  }
  filterByBranch(value:any){
    this.branchValues=this.selectBranch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getRanks(){
    this.subscription = this.BIODataGeneralInfoService.getselectedrank().subscribe(res=>{
      this.rankValues=res
      this.selectRank=res
    });
  }
  filterByRank(value:any){
    this.rankValues=this.selectRank.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getGenders(){
    this.subscription = this.BIODataGeneralInfoService.getselectedgender().subscribe(res=>{
      this.genderValues=res
    });
  }

  getDivisions(){
    this.subscription = this.BIODataGeneralInfoService.getselecteddivision().subscribe(res=>{
      this.divisionValues=res
      this.selectDivision=res
    });
  }
  filterByDivision(value:any){
    this.divisionValues=this.selectDivision.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onDivisionSelectionChangeGetDistrict(divisionId){
    this.subscription = this.BIODataGeneralInfoService.getdistrictbydivision(divisionId).subscribe(res=>{
      this.selectedDistrict=res
      this.selectDistrict=res
    });
  }
  filterByDistrict(value:any){
    this.selectedDistrict=this.selectDistrict.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onReligionSelectionChangeGetCastes(religionId){
    this.subscription = this.BIODataGeneralInfoService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
      this.selectCaste=res
    });
  }
  filterByCaste(value:any){
    this.selectedCastes=this.selectCaste.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onDistrictSelectionChangeGetThana(districtId){
    this.subscription = this.BIODataGeneralInfoService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
      this.selectThana=res
    });
   }
   filterByThana(value:any){
    this.selectedThana=this.selectThana.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
   }

  // getMaritalStatus(){
  //   this.BIODataGeneralInfoService.getselectedMaritialStatus().subscribe(res=>{
  //     this.maritalValues=res
  //   });
  // }


  intitializeForm() {
    this.BIODataGeneralInfoForm = this.fb.group({
      traineeId: [0],
      bnaBatchId: ['', Validators.required],
      rankId: ['',Validators.required],
      branchId: ['',Validators.required],
      divisionId: ['',Validators.required],
      districtId: ['',Validators.required],
      thanaId: ['',Validators.required],
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
      traineeStatusId:['4'],
      name: ['',Validators.required],
      nameBangla: [''],
      mobile: [''],
      email: [''],
      bnaPhotoUrl: [''],
      //image: ['1.jpg'],
      bnaNo: ['',Validators.required],
      pno: ['',Validators.required],
      dateOfBirth: ['',Validators.required],
      joiningDate: ['',Validators.required],
      identificationMark: [''],
      presentAddress: [''],
      permanentAddress: [''],
      nid: ['',Validators.required],
      remarks: [''],
      
      isActive: [true],
    
    })
  }
  
  onSubmit() {

    this.traineeId = this.BIODataGeneralInfoForm.get('traineeId').value;   

    if (this.traineeId) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.BIODataGeneralInfoService.update(+this.traineeId,this.BIODataGeneralInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/update-traineebiodatageneralinfo/'+this.traineeId);
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
    }
  }

}
