import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNAClassSectionSelection } from '../../models/BNAClassSectionSelection';
import { BNAClassSectionSelectionService } from '../../service/BNAClassSectionSelection.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import {Subject, Subscription} from 'rxjs'
import {debounceTime, distinctUntilChanged} from 'rxjs'
import { MasterData } from '../../../../assets/data/master-data';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';


@Component({
  selector: 'app-bnaclasssectionselection-list',
  templateUrl: './bnaclasssectionselection-list.component.html',
  styleUrls: ['./bnaclasssectionselection-list.component.sass']
})
export class BnaclasssectionselectionListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAClassSectionSelection[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;


  displayedColumns: string[] = ['ser', 'sectionName','isActive', 'actions'];
  dataSource: MatTableDataSource<BNAClassSectionSelection> = new MatTableDataSource();

  selection = new SelectionModel<BNAClassSectionSelection>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private BNAClassSectionSelectionService: BNAClassSectionSelectionService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super();
  }
  ngOnInit() {
    this.getBNAClassSectionSelections();
    
 this.searchSubscription = this.searchSubject.pipe(
  debounceTime(300), 
  distinctUntilChanged() 
).subscribe(searchText => {
  this.applyFilter(searchText);
});
  }
 
  getBNAClassSectionSelections() {
    this.isLoading = true;
    this.BNAClassSectionSelectionService.getBNAClassSectionSelections(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBNAClassSectionSelections();
 
  }
  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText;
    this.getBNAClassSectionSelections();
  } 

  deleteItem(row) {
    const id = row.bnaClassSectionSelectionId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.BNAClassSectionSelectionService.delete(id).subscribe(() => {
          this.getBNAClassSectionSelections();
          this.snackBar.open('BNAClassSectionSelection Information Deleted Successfully ', '', {
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
