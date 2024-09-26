import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ParentRelativeService } from '../../service/ParentRelative.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';

@Component({
  selector: 'app-new-family-info',
  templateUrl: './new-family-info.component.html',
  styleUrls: ['./new-family-info.component.sass']
})
export class NewParentRelativeComponent implements OnInit,OnDestroy {
  buttonText:string;
   masterData = MasterData;
  loading = false;
  pageTitle: string;
  traineeId:  string;
  destination:string;
  ParentRelativeForm: FormGroup;
  validationErrors: string[] = [];
  relationTypeValues:SelectedModel[]; 
  selectRealation:SelectedModel[];
  maritialStatusValues:SelectedModel[]; 
  genderValues:SelectedModel[];
  nationalityValues:SelectedModel[]; 
  selectedNationality:SelectedModel[];
  selectNationality:SelectedModel[];
  religionValues:SelectedModel[]; 
  selectReligion:SelectedModel[];
  casteValues:SelectedModel[]; 
  occupationValues:SelectedModel[]; 
  selectPreviousOccupation:SelectedModel[];
  selectOccupation:SelectedModel[];
  divisionValues:SelectedModel[]; 
  selectDivision:SelectedModel[];
  districtValues:SelectedModel[]; 
  thanaValues:SelectedModel[]; 
  defenseTypeValues:SelectedModel[]; 
  selectDefenceType:SelectedModel[]
  rankValues:SelectedModel[]; 
  selectRank:SelectedModel[];
  selectedDeadStatus:SelectedModel[];

  selectedCastes:SelectedModel[];
  selectcaste:SelectedModel[];
  selectedDistrict:SelectedModel[];
  selectDistrict:SelectedModel[];
  selectedThana:SelectedModel[];
  selectThana:SelectedModel[];


  nationalityToggle:string;
  defenseToggle:string;
  deadStatusToggle:string;

  defensehidevalue:string;
  subscription: any;

  constructor(private snackBar: MatSnackBar,private CodeValueService: CodeValueService,private ParentRelativeService: ParentRelativeService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('parentRelativeId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Family Information';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.ParentRelativeService.find(+id).subscribe(
        res => {
          this.ParentRelativeForm.patchValue({          

            parentRelativeId: res.parentRelativeId,
            traineeId: res.traineeId,
            relationTypeId: res.relationTypeId,
            nameInFull: res.nameInFull,
            dateOfBirth: res.dateOfBirth,
            maritalStatusId: res.maritalStatusId,
            genderId:res.genderId,
            dateOfMarriage: res.dateOfMarriage,
            age: res.age,
            deadStatus: res.deadStatus,
            dateOfExpiry: res.dateOfExpiry,
            nationalityId: res.nationalityId,
            religionId: res.religionId,
            casteId: res.casteId,            
            occupationId: res.occupationId,   
            occupationDetail: res.occupationDetail,   
            educationQualification: res.educationQualification,            
            previousOccupationId: res.previousOccupationId,   
            monthlyIncome: res.monthlyIncome,   
            divisionId: res.divisionId,   
            districtId: res.districtId,   
            thanaId: res.thanaId,   
            postCode: res.postCode,   
            presentAddress: res.presentAddress,   
            parmanentAddress: res.parmanentAddress,   
            mobile: res.mobile,   
            email: res.email,   
            remarks: res.remarks,   
            isDefenceJobExperience: res.isDefenceJobExperience.trim(),              
            defenseTypeId: res.defenseTypeId,   
            rankId: res.rankId,   
            retiredDate: res.retiredDate,   
            placeOfBirth: res.placeOfBirth,   
            dualNationality: res.dualNationality.trim(),   
            secondNationalityId: res.secondNationalityId,   
            reasonOfMigration: res.reasonOfMigration,   
            migrationDate: res.migrationDate,   
            additionalInformation: res.additionalInformation,   
            status: res.status,   
            //   menuPosition: res.menuPosition,
            isActive: res.isActive, 
             
          });  
          this.onReligionSelectionChangeGetCastes(res.religionId);
          this.onDivisionSelectionChangeGetDistrict(res.divisionId);
          this.onDistrictSelectionChangeGetThana(res.districtId);
        }
        
      );
    } else {
      this.pageTitle = 'Create Family Information';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getRelationType();
    this.getMaritialStatus();
    this.getNationality();
    this.getReligion();
    this.getCaste();
    this.getOccupation();
    this.getDivision();
    this.getDistrict();
    this.getThana();
    this.getDefenseType();
    this.getRank();
    this.getGenders();
    this.getSelectedDeadStatus();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.ParentRelativeForm = this.fb.group({
      
      parentRelativeId: [0],
      traineeId: [this.traineeId, Validators.required],
      relationTypeId: ['', Validators.required],
      nameInFull: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      maritalStatusId: ['', Validators.required],
      genderId: ['', Validators.required],
      dateOfMarriage: [],
      age: ['', Validators.required],
      deadStatus: [''],
      dateOfExpiry: [],
      nationalityId: ['', Validators.required],
      religionId: ['', Validators.required],
      casteId: ['', Validators.required],           
      occupationId: ['', Validators.required],  
      occupationDetail: [''], 
      educationQualification: [''],            
      previousOccupationId: [], 
      monthlyIncome: [''],   
      divisionId: [],   
      districtId: [],  
      thanaId: [], 
      postCode: [''],   
      presentAddress: [''], 
      parmanentAddress: [''],   
      mobile: [''],  
      email: [''],  
      remarks: [''],   
      isDefenceJobExperience: [''],
      defenseTypeId: [],   
      rankId: [],    
      retiredDate: [], 
      placeOfBirth: [''],   
      dualNationality: [''], 
      secondNationalityId: [],  
      reasonOfMigration: [''],   
      migrationDate: [],   
      additionalInformation: [''], 
      status: ['1'],   
      //   menuPosition: res.menuPosition,
      isActive: [true],
    
    })
  }



  changeNationality(e) {
    
    this.nationalityToggle=e.value;
  }

  onDeadStatusSelectionChangeDivClass(text){
    let status = text;
    this.deadStatusToggle='no';
    if(text == 15){
      this.deadStatusToggle = 'yes';
    }
    
  }

  changedefenseExperience(e) {
    this.defenseToggle=e.value;
  }

  getRelationType(){
    this.subscription = this.ParentRelativeService.getselectedrelationtype().subscribe(res=>{
      this.relationTypeValues=res
      this.selectRealation=res
    });
  }
  filterByRelation(value:any){
    this.relationTypeValues=this.selectRealation.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getGenders(){
    this.subscription = this.ParentRelativeService.getselectedgender().subscribe(res=>{
      this.genderValues=res
    });
  }
  getMaritialStatus(){
    this.subscription = this.ParentRelativeService.getselectedmaritialstatus().subscribe(res=>{
      this.maritialStatusValues=res
    });
  }

  getNationality(){
    this.subscription = this.ParentRelativeService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
      this.selectNationality=res
      this.selectedNationality=res
    });
  }
  filterByNationality(value:any){
    this.nationalityValues=this.selectNationality.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  filterByDualNationality(value:any){
    this.nationalityValues=this.selectedNationality.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getReligion(){
    this.subscription = this.ParentRelativeService.getselectedreligion().subscribe(res=>{
      this.religionValues=res
      this.selectReligion=res
    });
  }
  filterByReligion(value:any){
    this.religionValues=this.selectReligion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getCaste(){
    this.subscription = this.ParentRelativeService.getselectedcaste().subscribe(res=>{
      this.casteValues=res
    });
  }

  getOccupation(){
    this.subscription = this.ParentRelativeService.getselectedoccupation().subscribe(res=>{
      this.occupationValues=res
      this.selectOccupation=res
      this.selectPreviousOccupation=res
    });
  }
  filterByPreviousOccupation(value:any){
    this.occupationValues=this.selectPreviousOccupation.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  filterByOccupation(value:any){
    this.occupationValues=this.selectOccupation.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getDivision(){
    this.subscription = this.ParentRelativeService.getselecteddivision().subscribe(res=>{
      this.divisionValues=res
      this.selectDivision=res
    });
  }
  filterByDivision(value:any){
    this.divisionValues=this.selectDivision.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getDistrict(){
    this.subscription = this.ParentRelativeService.getselecteddistrict().subscribe(res=>{
      this.districtValues=res
    });
  }

  getThana(){
    this.subscription = this.ParentRelativeService.getselectedthana().subscribe(res=>{
      this.thanaValues=res
    });
  }

  getDefenseType(){
    this.subscription = this.ParentRelativeService.getselecteddefensetype().subscribe(res=>{
      this.defenseTypeValues=res
      this.selectDefenceType=res
    });
  }
  filterByDefence(value:any){
    this.defenseTypeValues=this.selectDefenceType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getRank(){
    this.subscription = this.ParentRelativeService.getselectedrank().subscribe(res=>{
      this.rankValues=res
      this.selectRank=res
    });
  }
  filterByRank(value:any){
    this.rankValues=this.selectRank.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSelectedDeadStatus(){
    
    this.subscription = this.CodeValueService.getSelectedCodeValueByType(this.masterData.codevaluetype.DeadStatus).subscribe(res=>{
      this.selectedDeadStatus=res;      
    })
  }


  onReligionSelectionChangeGetCastes(religionId){
    this.subscription = this.ParentRelativeService.getcastebyreligion(religionId).subscribe(res=>{
      this.selectedCastes=res
      this.selectcaste=res
    });
  }
  filterByCaste(value:any){
    this.selectedCastes=this.selectcaste.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onDivisionSelectionChangeGetDistrict(divisionId){
    this.subscription = this.ParentRelativeService.getdistrictbydivision(divisionId).subscribe(res=>{
      this.selectedDistrict=res
      this.selectDistrict=res
    });
  }
  filterByDistrict(value:any){
    this.selectedDistrict=this.selectDistrict.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onDistrictSelectionChangeGetThana(districtId){
    this.subscription = this.ParentRelativeService.getthanaByDistrict(districtId).subscribe(res=>{
      this.selectedThana=res
      this.selectThana=res
    });
  }
  filterByThana(value:any){
    this.selectedThana=this.selectThana.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  
  onSubmit() {
    const id = this.ParentRelativeForm.get('parentRelativeId').value;   
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) { 
          this.loading = true;
          this.subscription = this.ParentRelativeService.update(+id,this.ParentRelativeForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/family-info-details/'+this.traineeId);
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
      this.subscription = this.ParentRelativeService.submit(this.ParentRelativeForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/family-info-details/'+this.traineeId);
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
