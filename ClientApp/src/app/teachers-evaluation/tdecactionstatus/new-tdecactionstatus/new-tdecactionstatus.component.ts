import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { TdecActionStatusService } from '../../service/TdecActionStatus.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-tdecactionstatus',
  templateUrl: './new-tdecactionstatus.component.html',
  styleUrls: ['./new-tdecactionstatus.component.sass']
})
export class NewTdecActionStatusComponent implements OnInit,OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  TdecActionStatusForm: FormGroup;
  validationErrors: string[] = [];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private TdecActionStatusService: TdecActionStatusService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('tdecActionStatusId'); 
    if (id) {
      this.pageTitle = 'Edit Tdec Action Status';
      this.destination='Edit';
      this.buttonText="Update";
      this.subscription = this.TdecActionStatusService.find(+id).subscribe(
        res => {
          this.TdecActionStatusForm.patchValue({          

            tdecActionStatusId: res.tdecActionStatusId,
            name: res.name,
            mark: res.mark
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Tdec Action Status';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.TdecActionStatusForm = this.fb.group({
      tdecActionStatusId: [0],
      name: [''],
      mark: [''],
      isActive: [true]
    
    })
  }
  
  onSubmit() {
    const id = this.TdecActionStatusForm.get('tdecActionStatusId')?.value;  
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.TdecActionStatusService.update(+id,this.TdecActionStatusForm.value).subscribe(response => {
            this.router.navigateByUrl('/teachers-evaluation/tdecactionstatus-list');
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
      this.subscription = this.TdecActionStatusService.submit(this.TdecActionStatusForm.value).subscribe(response => {
        this.router.navigateByUrl('/teachers-evaluation/tdecactionstatus-list');
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
