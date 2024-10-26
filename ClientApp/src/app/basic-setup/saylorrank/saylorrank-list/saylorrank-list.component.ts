import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SaylorRank } from '../../models/SaylorRank';
import { SaylorRankService } from '../../service/SaylorRank.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-saylorrank-list',
  templateUrl: './saylorrank-list.component.html',
  styleUrls: ['./saylorrank-list.component.sass']
})
export class SaylorRankListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: SaylorRank[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'sl', 'name',  'actions'];
  dataSource: MatTableDataSource<SaylorRank> = new MatTableDataSource();

  selection = new SelectionModel<SaylorRank>(true, []);

  
  constructor(private snackBar: MatSnackBar,private SaylorRankService: SaylorRankService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getSaylorRanks();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }

  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  
  getSaylorRanks() {
    this.isLoading = true;
    this.SaylorRankService.getSaylorRanks(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getSaylorRanks();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getSaylorRanks();
  } 


  deleteItem(row) {
    const id = row.saylorRankId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.SaylorRankService.delete(id).subscribe(() => {
          this.getSaylorRanks();
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
