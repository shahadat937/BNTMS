import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BNAExamAttendance} from '../../models/bnaexamattendance'
import {BNAExamAttendanceService} from '../../service/bnaexamattendance.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-bnaexamattendance-list',
  templateUrl: './bnaexamattendance-list.component.html',
  styleUrls: ['./bnaexamattendance-list.component.sass']
})
export class BNAExamAttendanceListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAExamAttendance[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','bnaSemesterDurationId','bnaSemester','bnaBatch'
  ,'bnaSubjectName', 'traineeId', 'examType', 'examDate',  'actions'];
  dataSource: MatTableDataSource<BNAExamAttendance> = new MatTableDataSource();


   selection = new SelectionModel<BNAExamAttendance>(true, []);

  
  constructor(private snackBar: MatSnackBar,private BNAExamAttendanceService: BNAExamAttendanceService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.getBNAExamAttendances();
    
  }
 
  getBNAExamAttendances() {
    this.isLoading = true;
    this.BNAExamAttendanceService.getBNAExamAttendances(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBNAExamAttendances();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBNAExamAttendances();
  } 

  deleteItem(row) {
    const id = row.bnaExamAttendanceId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BNAExamAttendanceService.delete(id).subscribe(() => {
          this.getBNAExamAttendances();
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
