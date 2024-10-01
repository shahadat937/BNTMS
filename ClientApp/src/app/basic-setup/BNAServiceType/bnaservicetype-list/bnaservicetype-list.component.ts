import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNAServiceType } from '../../models/BNAServiceType';
import { BNAServiceTypeService } from '../../service/BNAServiceType.service';
import { MatSort } from '@angular/material/sort';
import { MatMenuTrigger } from '@angular/material/menu';
import { DataSource } from '@angular/cdk/collections';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
 

@Component({
  selector: 'app-BNAServiceType',
  templateUrl: './bnaservicetype-list.component.html',
  styleUrls: ['./bnaservicetype-list.component.sass']
})
export class BNAServiceTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAServiceType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'serviceName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<BNAServiceType> = new MatTableDataSource();

  selection = new SelectionModel<BNAServiceType>(true, []);
  
  constructor(private snackBar: MatSnackBar,private BNAServiceTypeService: BNAServiceTypeService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  
  ngOnInit() {
    this.getBNAServiceTypes();
  }
 
  getBNAServiceTypes() {
    this.isLoading = true;
    this.BNAServiceTypeService.getBNAServiceTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBNAServiceTypes();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBNAServiceTypes();
  }

  deleteItem(row) {
    const id = row.bnaServiceTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BNAServiceTypeService.delete(id).subscribe(() => {
          this.getBNAServiceTypes();
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
