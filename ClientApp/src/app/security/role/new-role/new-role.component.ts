import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { RoleService } from '../../service/role.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-role',
  templateUrl: './new-role.component.html',
  styleUrls: ['./new-role.component.sass']
})
export class NewRoleComponent implements OnInit, OnDestroy {
  buttonText:string;
  loading = false;
  pageTitle: string;
  destination:string;
  roleForm: FormGroup;
  validationErrors: string[] = [];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private roleService: RoleService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('roleId');     
    if (id) {
      this.pageTitle = 'Edit Role';
      this.destination='Edit';
      this.buttonText="Update";
      this.subscription = this.roleService.find(id).subscribe(
        res => {          
          this.roleForm.patchValue({          

            roleId: res.id,
            roleName: res.name,
            // loweredRoleName:res.loweredRoleName,
            // description:res.description,
            //menuPosition: res.menuPosition,
          
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Role';
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
    this.roleForm = this.fb.group({
      roleId: [0],
      roleName: ['', Validators.required],
      loweredRoleName:[],
      description:[],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    
    })
  }
  
  onSubmit() {
    // const id = this.roleForm.get('roleId').value;   
    const id = this.route.snapshot.paramMap.get('roleId'); 
    
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.roleService.update(id,this.roleForm.value).subscribe(response => {
            this.router.navigateByUrl('/security/role-list');
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
      this.subscription = this.roleService.submit(this.roleForm.value).subscribe(response => {
        this.router.navigateByUrl('/security/role-list');
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
