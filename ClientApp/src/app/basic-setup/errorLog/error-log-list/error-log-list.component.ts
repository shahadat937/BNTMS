import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ErrorLog } from '../../models/ErrorLog';
import { ErrorLogService } from '../../service/error-log.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-error-log-list',
  templateUrl: './error-log-list.component.html',
  styleUrls: ['./error-log-list.component.sass']
})
export class ErrorLogListComponent extends UnsubscribeOnDestroyAdapter  implements OnInit {

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ErrorLog[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser', 'subject','failureCount', 'fileUrl', 'createdDate', 'actions'];
  dataSource: MatTableDataSource<ErrorLog> = new MatTableDataSource();



  
  constructor(
    private snackBar: MatSnackBar,
    private ErrorLogService: ErrorLogService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getErrorLog();
  }
 
  getErrorLog() {
    this.isLoading = true;
    this.ErrorLogService.getErrorLog(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
    this.dataSource.data = response.items; 
    this.paging.length = response.totalItemsCount    
    this.isLoading = false;
    })
  }


 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getErrorLog();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getErrorLog();
  } 


  deleteItem(row) {
    const id = row.errorLogId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.ErrorLogService.delete(id).subscribe(() => {
          this.getErrorLog();
          this.snackBar.open('Information Delete Successfully ', '', {
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
