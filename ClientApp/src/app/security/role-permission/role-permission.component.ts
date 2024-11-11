import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { RoleFeatureService } from '../service/rolefeature.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MasterData } from 'src/assets/data/master-data';
import { SelectMode } from 'ng-pick-datetime/date-time/date-time.class';
import { MatCheckboxModule } from '@angular/material/checkbox';

@Component({
  selector: 'app-role-permission',
  templateUrl: './role-permission.component.html',
  styleUrls: ['./role-permission.component.sass']
})
export class RolePermissionComponent implements OnInit {

  RoleFeatureForm: FormGroup;
  masterData = MasterData;
  subscription: any;
  selectRole: SelectedModel[];
  selectedModel  : SelectedModel[]
  selectedrole: any;
  selectModel: any
  features: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  }
  searchText = "";

  constructor(private snackBar: MatSnackBar, private RoleFeatureService: RoleFeatureService, private router: Router, private confirmService: ConfirmService, public sharedService: SharedServiceService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.intitializeForm();
    this.getselectedrole();
    this.getModule();
  }

  intitializeForm() {
    this.RoleFeatureForm = this.fb.group({
      roleId: ['', Validators.required],
      featureKey: ['', Validators.required],
      add: [true],
      update: [true],
      delete: [true],
      report: [true],
      isActive: [true],
      moduleId : ['']

    })
  }

  getselectedrole() {
    this.subscription = this.RoleFeatureService.getselectedrole().subscribe(res => {
      this.selectedrole = res
      this.selectRole = res

    });
  }
  filterByRole(value: any) {
    this.selectedrole = this.selectRole.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, '')))
  }

  getFeatersbyModule(event: any) {
    console.log(event.value);
    this.getFeaturesbyModule(event.value)
    
  }

  getFeaturesbyModule(moduleId:number) {
    this.subscription = this.RoleFeatureService.getFeaturesbyModule(moduleId).subscribe(response => {
      this.features = response
      console.log(this.features);
    })
  }

  filterByModel(value:any){
    this.selectedModel = this.selectModel.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
    getModule(){
      this.subscription = this.RoleFeatureService.getselectedmodule().subscribe(res=>{
        this.selectedModel=res
        this.selectModel=res
      });
    }
}
