import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseBudgetAllocation} from '../../models/CourseBudgetAllocation'
import {CourseBudgetAllocationService} from '../../service/courseBudgetAllocation.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-coursebudgetallocation-list',
  templateUrl: './coursebudgetallocation-list.component.html',
  styleUrls: ['./coursebudgetallocation-list.component.sass']
})
export class CourseBudgetAllocationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseBudgetAllocation[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','traineeId','budgetCodeId','paymentTypeId','installmentAmount','installmentDate','presentBalance','actions'];
  dataSource: MatTableDataSource<CourseBudgetAllocation> = new MatTableDataSource();


   selection = new SelectionModel<CourseBudgetAllocation>(true, []);

  
  constructor(private snackBar: MatSnackBar,private CourseBudgetAllocationService: CourseBudgetAllocationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.getCourseBudgetAllocations();
    
  }
 
  getCourseBudgetAllocations() {
    this.isLoading = true;
    this.CourseBudgetAllocationService.getCourseBudgetAllocations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseBudgetAllocations();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseBudgetAllocations();
  } 

  deleteItem(row) {
    const id = row.courseBudgetAllocationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseBudgetAllocationService.delete(id).subscribe(() => {
          this.getCourseBudgetAllocations();
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
