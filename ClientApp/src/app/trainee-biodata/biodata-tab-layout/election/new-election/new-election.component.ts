import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ElectionService } from '../../../biodata-tab-layout/service/Election.service';
import { SelectedModel } from '../../../../core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { SharedServiceService } from '../../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-new-Election',
  templateUrl: './new-election.component.html',
  styleUrls: ['./new-election.component.sass']
})
export class NewElectionComponent implements OnInit, OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  traineeId:  string;
  ElectionForm: FormGroup;
  validationErrors: string[] = [];
  electedValues:SelectedModel[]; 
  selectElectedValue:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private ElectionService: ElectionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('electionId'); 
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    if (id) {
      this.pageTitle = 'Edit Election';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.ElectionService.find(+id).subscribe(
        res => {
          this.ElectionForm.patchValue({          

            electionId: res.electionId,
            traineeId: res.traineeId,
            instituteName: res.instituteName,
            electedId: res.electedId,
            appointmentName: res.appointmentName,
            durationFrom: res.durationFrom,
            durationTo: res.durationTo,
            additionalInformation: res.additionalInformation,            
         //   menuPosition: res.menuPosition,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Election';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getElectedName();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.ElectionForm = this.fb.group({
      electionId: [0],
      traineeId: [this.traineeId, Validators.required],
      instituteName: [],
      electedId: ['', Validators.required],
      appointmentName: [],
      durationFrom: [],
      durationTo: [],
      additionalInformation: [],      
    //  menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }

  getElectedName(){
    this.subscription = this.ElectionService.getselectedelected().subscribe(res=>{
      this.electedValues=res
      this.selectElectedValue=res
    });
  }
  filterByElectedValue(value:any){
    this.electedValues=this.selectElectedValue.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  
  onSubmit() {
    const id = this.ElectionForm.get('electionId')?.value;   
    

    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.ElectionService.update(+id,this.ElectionForm.value).subscribe(response => {
            this.router.navigateByUrl('/trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/election-details/'+this.traineeId);
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
      this.subscription = this.ElectionService.submit(this.ElectionForm.value).subscribe(response => {
        this.router.navigateByUrl('/trainee-biodata/trainee-biodata-tab/main-tab-layout/main-tab/election-details/'+this.traineeId);
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
