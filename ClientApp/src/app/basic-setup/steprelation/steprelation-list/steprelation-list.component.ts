import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { StepRelation } from '../../models/StepRelation';
import { StepRelationService } from '../../service/StepRelation.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-StepRelation',
  templateUrl: './steprelation-list.component.html',
  styleUrls: ['./steprelation-list.component.sass']
})
export class StepRelationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: StepRelation[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'stepRelationType', 'isActive', 'actions'];
  dataSource: MatTableDataSource<StepRelation> = new MatTableDataSource();

  selection = new SelectionModel<StepRelation>(true, []);
  
  constructor(private snackBar: MatSnackBar,private StepRelationService: StepRelationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getStepRelations();
  }
 
  getStepRelations() {
    this.isLoading = true;
    this.StepRelationService.getStepRelations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getStepRelations();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getStepRelations();
  } 

  deleteItem(row) {
    const id = row.stepRelationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.StepRelationService.delete(id).subscribe(() => {
          this.getStepRelations();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })    
  }
}
