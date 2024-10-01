import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeVisitedAboardService } from '../../../biodata-tab-layout/service/TraineeVisitedAboard.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';


@Component({
  selector: 'app-new-trainee-visited-abroad',
  templateUrl: './new-trainee-visited-abroad.component.html',
  styleUrls: ['./new-trainee-visited-abroad.component.sass']
})
export class NewTraineeVisitedAboardComponent extends UnsubscribeOnDestroyAdapter implements OnInit, OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:  string;
  TraineeVisitedAboardForm: FormGroup;
  validationErrors: string[] = [];
  countryValues:SelectedModel[]; 
  selectCountry:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private TraineeVisitedAboardService: TraineeVisitedAboardService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeVisitedAboardId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Trainee Visited Abroad';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.TraineeVisitedAboardService.find(+id).subscribe(
        res => {
          this.TraineeVisitedAboardForm.patchValue({          

            traineeVisitedAboardId: res.traineeVisitedAboardId,
            traineeId: res.traineeId,
            countryId: res.countryId,
            purposeOfVisit: res.purposeOfVisit,
            durationFrom: res.durationFrom,
            durationTo: res.durationTo,
            additionalInformation: res.additionalInformation,  
           // status: res.status,            
         //   menuPosition: res.menuPosition,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Trainee Visited Aboard';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
   this.getCountry();
  }
  intitializeForm() {
    this.TraineeVisitedAboardForm = this.fb.group({
      traineeVisitedAboardId: [0],
      traineeId: [this.traineeId, Validators.required],
      countryId: ['', Validators.required],
      purposeOfVisit: ['', Validators.required],
      durationFrom: ['', Validators.required],
      durationTo: ['', Validators.required],
      additionalInformation: [''], 
    //  status: [''],      
      //  menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getCountry(){
    this.subscription = this.TraineeVisitedAboardService.getselectedcountry().subscribe(res=>{
      this.countryValues=res
      this.selectCountry=res
    });
  }
  filterByCountry(value:any){
    this.countryValues=this.selectCountry.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  
  onSubmit() {
    const id = this.TraineeVisitedAboardForm.get('traineeVisitedAboardId').value;   
    

    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.TraineeVisitedAboardService.update(+id,this.TraineeVisitedAboardForm.value).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-visited-aboard-details/'+this.traineeId);
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
      this.subscription = this.TraineeVisitedAboardService.submit(this.TraineeVisitedAboardForm.value).subscribe(response => {
        this.router.navigateByUrl('/trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-visited-aboard-details/'+this.traineeId);
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
