import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BnaClassSchedule} from '../../models/bnaclassschedule'
import {BnaClassScheduleService} from '../../service/bnaclassschedule.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-bnaclassschedule-list',
  templateUrl: './bnaclassschedule-list.component.html',
  styleUrls: ['./bnaclassschedule-list.component.sass']
})
export class BnaClassScheduleListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BnaClassSchedule[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','bnaSemester', 'date', 'classPeriod',  'bnaSubjectName', 'classLocation','bnaClassSectionSelection', 'traineeId', 'actions'];
  dataSource: MatTableDataSource<BnaClassSchedule> = new MatTableDataSource();


   selection = new SelectionModel<BnaClassSchedule>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private BnaClassScheduleService: BnaClassScheduleService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.getBnaClassSchedules();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getBnaClassSchedules() {
    this.isLoading = true;
    this.subscription = this.BnaClassScheduleService.getBnaClassSchedules(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBnaClassSchedules();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBnaClassSchedules();
  } 

  deleteItem(row) {
    const id = row.bnaClassScheduleId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.BnaClassScheduleService.delete(id).subscribe(() => {
          this.getBnaClassSchedules();
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
