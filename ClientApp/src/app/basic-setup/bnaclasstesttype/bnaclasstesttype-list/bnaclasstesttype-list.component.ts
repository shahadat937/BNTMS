import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BnaClassTestType } from '../../models/BnaClassTestType';
import { BnaClassTestTypeService } from '../../service/BnaClassTestType.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import {MasterData} from 'src/assets/data/master-data'
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import {Subject, Subscription} from 'rxjs';
import {debounceTime, distinctUntilChanged} from 'rxjs'
import { SharedServiceService } from 'src/app/shared/shared-service.service';


 

@Component({
  selector: 'app-BnaClassTestType-list',
  templateUrl: './BnaClassTestType-list.component.html',
  styleUrls: ['./BnaClassTestType-list.component.sass']
})
export class BnaClassTestTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BnaClassTestType[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [  'sl', 'name', 'isActive', 'actions'];
  dataSource: MatTableDataSource<BnaClassTestType> = new MatTableDataSource();


  selection = new SelectionModel<BnaClassTestType>(true, []);

  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private BnaClassTestTypeService: BnaClassTestTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) { 
    super();
  }
  
  ngOnInit() {
    this.getBnaClassTestTypes();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }

  onSearchChange(seachValue:string){
    this.searchSubject.next(seachValue);
  }
 
  getBnaClassTestTypes() {
    this.isLoading = true;
    this.BnaClassTestTypeService.getBnaClassTestTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
    this.getBnaClassTestTypes();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getBnaClassTestTypes();
  } 


  deleteItem(row) {
    const id = row.bnaClassTestTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.BnaClassTestTypeService.delete(id).subscribe(() => {
          this.getBnaClassTestTypes();
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
