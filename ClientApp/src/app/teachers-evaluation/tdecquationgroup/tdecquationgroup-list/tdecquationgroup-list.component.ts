import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TdecQuationGroup } from '../../models/TdecQuationGroup';
import { TdecQuationGroupService } from '../../service/TdecQuationGroup.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-tdecquationgroup-list',
  templateUrl: './tdecquationgroup-list.component.html',
  styleUrls: ['./tdecquationgroup-list.component.sass']
})
export class TdecQuationGroupListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TdecQuationGroup[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','schoolName', 'courseName','subjectName','tdecQuestionName', 'actions'];
  dataSource: MatTableDataSource<TdecQuationGroup> = new MatTableDataSource();

  selection = new SelectionModel<TdecQuationGroup>(true, []);
  subscription: any;

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TdecQuationGroupService: TdecQuationGroupService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  
  ngOnInit() {
    this.getTdecQuationGroups();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  
  getTdecQuationGroups() {
    this.isLoading = true;
    this.subscription = this.TdecQuationGroupService.getTdecQuationGroups(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTdecQuationGroups();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTdecQuationGroups();
  } 


  deleteItem(row) {
    const id = row.tdecQuationGroupId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.TdecQuationGroupService.delete(id).subscribe(() => {
          this.getTdecQuationGroups();
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
