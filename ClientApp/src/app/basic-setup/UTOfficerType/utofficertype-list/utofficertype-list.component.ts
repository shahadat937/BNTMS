import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { UTOfficerType } from '../../models/UTOfficerType';
import { UTOfficerTypeService } from '../../service/UTOfficerType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-UTOfficerType',
  templateUrl: './utofficertype-list.component.html',
  styleUrls: ['./utofficertype-list.component.sass']
})
export class UTOfficerTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: UTOfficerType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'utofficerTypeName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<UTOfficerType> = new MatTableDataSource();

  selection = new SelectionModel<UTOfficerType>(true, []);

  
  constructor(private snackBar: MatSnackBar,private UTOfficerTypeService: UTOfficerTypeService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  // ngOnInit() {
  //   this.dataSource2.paginator = this.paginator;
  // }
  ngOnInit() {
    this.getUTOfficerTypes();
  }
 
  getUTOfficerTypes() {
    this.isLoading = true;
    this.UTOfficerTypeService.getUTOfficerTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getUTOfficerTypes();
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getUTOfficerTypes();
  }

  deleteItem(row) {
    const id = row.utofficerTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.UTOfficerTypeService.delete(id).subscribe(() => {
          this.getUTOfficerTypes();
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
