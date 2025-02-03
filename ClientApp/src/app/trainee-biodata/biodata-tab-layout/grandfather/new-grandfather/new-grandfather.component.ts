import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { GrandFatherService } from '../../service/GrandFather.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { CodeValueService } from '../../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../../src/assets/data/master-data';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-grandfather',
  templateUrl: './new-grandfather.component.html',
  styleUrls: ['./new-grandfather.component.sass']
})
export class NewGrandFatherComponent implements OnInit,OnDestroy {
  buttonText:string;
  pageTitle: string;
   masterData = MasterData;
  loading = false;
  destination:string;
  traineeId:  string;
  GrandFatherForm: FormGroup;
  validationErrors: string[] = [];
  grandFatherTypeValues:SelectedModel[]; 
  selectGrandFather:SelectedModel[];
  occupationValues:SelectedModel[]; 
  selectOccupation:SelectedModel[];
  nationalityValues:SelectedModel[]; 
  selectNationality:SelectedModel[];
  selectedDeadStatus:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private CodeValueService: CodeValueService,private GrandFatherService: GrandFatherService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('grandFatherId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Grand Father';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.GrandFatherService.find(+id).subscribe(
        res => {
          this.GrandFatherForm.patchValue({          

            grandFatherId: res.grandFatherId,
            traineeId: res.traineeId,
            grandFatherTypeId: res.grandFatherTypeId,
            grandFathersName: res.grandFathersName,
            occupationId: res.occupationId,
            age: res.age,
            deadStatus: res.deadStatus,
            nationalityId: res.nationalityId,
            additionalInformation: res.additionalInformation,
            status: res.status,           
         //   menuPosition: res.menuPosition,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Grand Father';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.grendFatherType();
    this.getOccupationName();
    this.getNationalityName();
    this.getSelectedDeadStatus();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.GrandFatherForm = this.fb.group({
      grandFatherId: [0],
      traineeId: [this.traineeId, Validators.required],
      grandFatherTypeId: ['', Validators.required],
      grandFathersName: [''],
      occupationId: ['', Validators.required],
      age: [''],
      deadStatus: ['', Validators.required],
      nationalityId: ['', Validators.required],
      additionalInformation: [''],      
      status: ['2'],           
    //  menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  grendFatherType(){
    this.subscription = this.GrandFatherService.getselectedgrandfathertype().subscribe(res=>{
      this.grandFatherTypeValues=res
      this.selectGrandFather=res
    });
  }
  filterByGrandFather(value:any){
    this.grandFatherTypeValues=this.selectGrandFather.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getOccupationName(){
    this.subscription = this.GrandFatherService.getselectedoccupation().subscribe(res=>{
      this.occupationValues=res
      this.selectOccupation=res
    });
  }
  filterByOccupation(value:any){
    this.occupationValues=this.selectOccupation.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getNationalityName(){
    this.subscription = this.GrandFatherService.getselectednationality().subscribe(res=>{
      this.nationalityValues=res
      this.selectNationality=res
    });
  }
  filterByNationality(value:any){
    this.nationalityValues=this.selectNationality.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSelectedDeadStatus(){
    
    this.subscription = this.CodeValueService.getSelectedCodeValueByType(this.masterData.codevaluetype.DeadStatus).subscribe(res=>{
      this.selectedDeadStatus=res;      
    })
  }
  
  onSubmit() {
    const id = this.GrandFatherForm.get('grandFatherId')?.value;   
    
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.loading = true;
          this.subscription = this.GrandFatherService.update(+id,this.GrandFatherForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/grandfather-details/'+this.traineeId);
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
      this.subscription = this.GrandFatherService.submit(this.GrandFatherForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/grandfather-details/'+this.traineeId);
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
