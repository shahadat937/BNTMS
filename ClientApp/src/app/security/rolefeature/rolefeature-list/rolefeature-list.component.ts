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
  paging = {
    pageIndex: 1,
    pageSize: 1000,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','roleName','featureName','add','update','delete','report', 'actions'];
  dataSource: MatTableDataSource<RoleFeature> = new MatTableDataSource();
  selectedRoleId: string = '';
  filteredData: any;

   selection = new SelectionModel<RoleFeature>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private RoleFeatureService: RoleFeatureService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.getRoleFeatures();
    this.getselectedrole();
    console.log('Data for *ngFor:', this.dataSource);
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
      console.log(this.selectedrole)
    });
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getRoleFeatures();
 
  }
  filterTableData() {
    if (this.selectedRoleId) {
      this.filteredData = this.dataSource.filteredData.filter(feature => String(feature.roleId) === this.selectedRoleId);

      console.log("filter data - ",this.filteredData)
    } else {
      this.filteredData = [];
    }
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
  deleteItem(row) {
    const Roleid = row.roleId; 
    const Featureid = row.featureKey;
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
