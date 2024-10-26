import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoleFeatureService } from '../../service/rolefeature.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-edit-rolefeature',
  templateUrl: './new-rolefeature.component.html',
  styleUrls: ['./new-rolefeature.component.sass'] 
})
export class NewRoleFeatureComponent implements OnInit, OnDestroy {
  pageTitle: string; 
  loading = false;
  destination:string;
  btnText:string;
  Roleid:string;
  Featureid:number;
  RoleFeatureForm: FormGroup;
  buttonText:string;
  validationErrors: string[] = [];
  selectedModel:SelectedModel[];
  selectedrole:SelectedModel[];
  selectRole:SelectedModel[];
  selectedfeature:SelectedModel[];
  selectFeature:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private RoleFeatureService: RoleFeatureService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.Roleid = this.route.snapshot.paramMap.get('roleId'); 
    // this.Roleid = Number(rid);
    const fid = this.route.snapshot.paramMap.get('featureKey'); 
    this.Featureid = Number(fid)
   console.log(this.Roleid , this.Featureid )
    if (this.Roleid && this.Featureid) {
      this.pageTitle = 'Edit RoleFeature';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription =  this.RoleFeatureService.find(this.Roleid, this.Featureid).subscribe(
        (res : any) => {
          
          this.RoleFeatureForm.patchValue({          
            roleId: res.roleId,
            featureKey: res.featureKey,
            add: res.add,
            update:res.update,
            delete:res.delete,
            report:res.report,
            isActive:res.isActive
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create RoleFeature';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    this.intitializeForm();
    this.getselectedrole();
    this.getselectedfeature();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.RoleFeatureForm = this.fb.group({
      roleId:['', Validators.required],
      featureKey: ['', Validators.required],
      add: [true],
      update: [true],
      delete: [true],
      report: [true],
      isActive: [true],
    
    })
  }
  filterByRole(value:any){
    this.selectedrole=this.selectRole.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedrole(){
    this.subscription = this.RoleFeatureService.getselectedrole().subscribe(res=>{
      this.selectedrole=res
      this.selectRole=res
     
    });
  }
  filterByFeature(value:any){
    this.selectedfeature=this.selectFeature.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedfeature(){
    this.subscription = this.RoleFeatureService.getselectedfeature().subscribe(res=>{
      this.selectedfeature=res
      this.selectFeature=res
      console.log(this.selectedfeature);
    });
  }

  onSubmit() {
    const rid = this.route.snapshot.paramMap.get('roleId'); 
    //this.Roleid = Number(rid);
    const fid = this.route.snapshot.paramMap.get('featureKey'); 
    this.Featureid = Number(fid)
    if (this.Roleid && this.Featureid) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.RoleFeatureService.update(this.Roleid,this.Featureid,this.RoleFeatureForm.value).subscribe(response => {
            this.router.navigateByUrl('/security/rolefeature-list');
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
      console.log(this.RoleFeatureForm.value)
      this.loading=true;
      this.subscription = this.RoleFeatureService.submit(this.RoleFeatureForm.value).subscribe(response => {
        
        this.router.navigateByUrl('/security/rolefeature-list');
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
