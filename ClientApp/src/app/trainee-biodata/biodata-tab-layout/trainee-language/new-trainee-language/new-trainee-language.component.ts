import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { TraineeLanguageService } from '../../service/TraineeLanguage.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-trainee-language',
  templateUrl: './new-trainee-language.component.html',
  styleUrls: ['./new-trainee-language.component.sass']
})
export class NewTraineeLanguageComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  TraineeLanguageForm: FormGroup; 
  validationErrors: string[] = [];
  traineeId: string;
  districtValues:SelectedModel[]; 
  selectedLanguages:SelectedModel[]; 
  selectLanguage:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private TraineeLanguageService: TraineeLanguageService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('traineeLanguageId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Languages';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.TraineeLanguageService.find(+id).subscribe(
        res => {
          this.TraineeLanguageForm.patchValue({          

            traineeLanguageId: res.traineeLanguageId,
            traineeId: res.traineeId,
            languageId: res.languageId,
            speaking:res.speaking,
            writing:res.writing,
            reading:res.reading,
            additionalInformation: res.additionalInformation,
            //status: res.status,
           // menuPosition:res.menuPosition,
            isActive: true
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Languages';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getLanguages();
    //this.getDistrict();
    //this.getThana();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.TraineeLanguageForm = this.fb.group({
      traineeLanguageId: [0],
      traineeId: [this.traineeId, Validators.required],
      languageId: ['', Validators.required],
      speaking: ['', Validators.required], 
      writing: ['', Validators.required],
      reading: ['', Validators.required],
      additionalInformation: [''],
    // status: ['', Validators.required],
     // menuPosition: ['', Validators.required],
      isActive: [true],
    })
  }

  getLanguages(){
    this.subscription = this.TraineeLanguageService.getselectedLanguage().subscribe(res=>{
      this.selectedLanguages=res
      this.selectLanguage=res
    });
  }
  filterByLanguage(value:any){
    this.selectedLanguages=this.selectLanguage.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  

  
  onSubmit() {
    const id = this.TraineeLanguageForm.get('traineeLanguageId')?.value;   
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.TraineeLanguageService.update(+id,this.TraineeLanguageForm.value).subscribe(response => {
            this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-language-details/'+this.traineeId);
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
      this.subscription = this.TraineeLanguageService.submit(this.TraineeLanguageForm.value).subscribe(response => {
        this.router.navigateByUrl('trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/trainee-language-details/'+this.traineeId);
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
