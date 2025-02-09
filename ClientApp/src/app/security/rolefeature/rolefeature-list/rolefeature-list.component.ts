import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { RoleFeature } from '../../models/rolefeature';
import { RoleFeatureService } from '../../service/rolefeature.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { SelectedModel } from '../../../core/models/selectedModel';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';


@Component({
  selector: 'app-rolefeature',
  templateUrl: './rolefeature-list.component.html',
  styleUrls: ['./rolefeature-list.component.css']
})
export class RoleFeatureListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: RoleFeature[] = [];
  isLoading = false;
  selectedRole: any = null;
  featuresList: any[] = [];
  selectedrole:SelectedModel[];
  validationErrors: string[] = [];
  paging = {
    pageIndex: 1,
    pageSize: 1000,
    length: 1
  }
  features : RoleFeature [] = [];
  RoleFeaturesForm: FormGroup;
  searchText="";

  displayedColumns: string[] = ['ser','roleName','featureName','add','update','delete','report', 'actions'];
  dataSource: MatTableDataSource<RoleFeature> = new MatTableDataSource();
  selectedRoleId: string = '';
  filteredData: any;

   selection = new SelectionModel<RoleFeature>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private RoleFeatureService: RoleFeatureService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService,
    private fb: FormBuilder,
  ) { 
    this.RoleFeaturesForm = this.fb.group({
      featuresList: this.fb.array([])
    });
  }

  ngOnInit() {
    // this.getRoleFeatures();
    this.getselectedrole();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getRoleFeatures() {
    this.isLoading = true;
    this.subscription = this.RoleFeatureService.getRoleFeatures(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  getselectedrole(){
    this.subscription = this.RoleFeatureService.getselectedrole().subscribe(res=>{
      this.selectedrole=res;
    });
  }

  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getRoleFeatures();
 
  // }
  filterTableData() {
    if (this.selectedRoleId) {
      this.filteredData = this.dataSource.filteredData.filter(feature => String(feature.roleId) === this.selectedRoleId);

    } else {
      this.filteredData = [];
    }
  }

  getFeaturesRoleByRole(event: any) {
    const selectedRoleId = event.value; // Get selected role ID
    this.RoleFeatureService.getRoleFeaturesByRole(selectedRoleId).subscribe(res => {
      if (res.length) {
 
        this.features = res.map(feature => ({
          ...feature,
          roleId: selectedRoleId 
        }));
        this.pathFeaturesList(this.features);
      }
    });
  }
  

  get FeaturesListArray() {
    return this.RoleFeaturesForm.get('featuresList') as FormArray;
  }

  pathFeaturesList(featuresInfoList: any[]) {
    const control = this.FeaturesListArray;
    control.clear();
  
    // Sort by moduleName to keep similar modules together
    featuresInfoList.sort((a, b) => a.moduleName.localeCompare(b.moduleName));
  
    featuresInfoList.forEach(featureInfo => {
      control.push(this.fb.group({
        roleId: [featureInfo.roleId],
        roleName: [featureInfo.roleName],
        featureKey: [featureInfo.featureKey],
        featureId: [featureInfo.featureId],
        featureName: [featureInfo.featureName],
        moduleId: [featureInfo.moduleId],
        moduleName: [featureInfo.moduleName],
        menuPosition: [featureInfo.menuPosition],
        selectAll: [featureInfo.selectAll === true],
        add: [featureInfo.add === true],
        update: [featureInfo.update === true],
        delete: [featureInfo.delete === true],
        report: [featureInfo.report === true],
      }));
    });

    this.RoleFeaturesForm.markAsDirty();
  }

  
toggleAllSelection(event: any) {
  const isChecked = event.target.checked;
  this.FeaturesListArray.controls.forEach(control => {
    control.patchValue({
      add: isChecked,
      update: isChecked,
      delete: isChecked,
      report: isChecked,
      selectAll: isChecked
    });
  });
}

toggleRowSelection(index: number) {
  const control = this.FeaturesListArray.controls[index];
  const isChecked = control.get('selectAll')?.value;
  control.patchValue({
    viewStatus: isChecked,
    add: isChecked,
    update: isChecked,
    delete: isChecked,
    report: isChecked
  });
}

  
  submitFeature() {
  
    const updatedFeatures = this.FeaturesListArray.controls
      .filter(control => control.dirty) 
      .map(control => control.value);
  
    console.log('Updated Features:', updatedFeatures);
  
    if (updatedFeatures.length === 0) {
      this.snackBar.open('No changes detected', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-warning'
      });
      return;
    }
  
    this.subscription = this.confirmService
      .confirm('Confirm Update', 'Are you sure you want to update these items?')
      .subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.RoleFeatureService.updateRoleFeatures(updatedFeatures).subscribe(
            response => {
              this.router.navigateByUrl('/security/rolefeature-list');
              this.snackBar.open('Information Updated Successfully', '', {
                duration: 2000,
                verticalPosition: 'bottom',
                horizontalPosition: 'right',
                panelClass: 'snackbar-success'
              });
              this.RoleFeaturesForm.markAsPristine(); // Reset form state after update
              this.loading = false;
            },
            error => {
              this.validationErrors = error;
              this.loading = false;
            }
          );
        }
      });
  }
  
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.paging.pageIndex = 1
    this.paging.pageSize = 10
    this.getRoleFeatures();
  } 
  // applyFilter(filterValue: string) {
  //   filterValue = filterValue.trim();
  //   filterValue = filterValue.toLowerCase().replace(/\s/g,'');
  //   this.dataSource.filter = filterValue;
  // }
  deleteItem(feature) {
    const Roleid = feature.roleId; 
    const Featureid = feature.featureKey;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.RoleFeatureService.delete(Roleid,Featureid).subscribe(() => {
          this.getRoleFeatures();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
    
  }
}
