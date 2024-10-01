import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Nationality } from '../../models/nationality';
import { NationalityService } from '../../service/nationality.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';


@Component({
  selector: 'app-nationality-list',
  templateUrl: './nationality-list.component.html',
  styleUrls: ['./nationality-list.component.sass']
})
export class NationalityListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Nationality[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl',/*'nationalityId',*/ 'nationalityName', /*'menuPosition',*/ 'isActive', 'actions'];
  dataSource: MatTableDataSource<Nationality> = new MatTableDataSource();

  selection = new SelectionModel<Nationality>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private nationalityService: NationalityService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  
  ngOnInit() {
    this.getNationalities();
  }
  
  getNationalities() {
    this.isLoading = true;
    this.nationalityService.getNationalities(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getNationalities();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getNationalities();
  } 


  deleteItem(row) {
    const id = row.nationalityId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Nationality Item?').subscribe(result => {
      if (result) {
        this.nationalityService.delete(id).subscribe(() => {
          this.getNationalities();
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
