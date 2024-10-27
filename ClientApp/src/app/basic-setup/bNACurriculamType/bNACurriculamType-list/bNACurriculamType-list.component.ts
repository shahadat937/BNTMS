import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BNACurriculamType } from '../../models/bNACurriculamType';
import { BNACurriculamTypeService } from '../../service/bNACurriculamType.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import {Subject, Subscription} from'rxjs';
import {debounceTime, distinctUntilChanged} from 'rxjs/operators';
import { SharedServiceService } from 'src/app/shared/shared-service.service';


@Component({
  selector: 'app-bnacurriculamtype-list',
  templateUrl: './bnacurriculamtype-list.component.html',
  styleUrls: ['./bnacurriculamtype-list.component.sass']
})
export class BNACurriculamTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNACurriculamType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'select','sl',/*'bnaCurriculumTypeId',*/ 'curriculumType',  'isActive', 'actions'];
  dataSource: MatTableDataSource<BNACurriculamType> = new MatTableDataSource();


  selection = new SelectionModel<BNACurriculamType>(true, []);
  
  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private bNACurriculamTypeService: BNACurriculamTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super();
  }
  // ngOnInit() {
  //   this.dataSource2.paginator = this.paginator;
  // }
  ngOnInit() {
    this.getBNACurriculamTypes();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }

  onSearchChange(searchValue:string){
    this.searchSubject.next(searchValue)
  }
 
  getBNACurriculamTypes() {
    this.isLoading = true;
    this.bNACurriculamTypeService.getBNACurriculamTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getBNACurriculamTypes();
 
   
  }
  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText;
    this.getBNACurriculamTypes();
  } 
  
  deleteItem(row) {
    const id = row.bnaCurriculumTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.bNACurriculamTypeService.delete(id).subscribe(() => {
          this.getBNACurriculamTypes();
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
