import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ReadingMaterialTitle } from '../../models/ReadingMaterialTitle';
import { ReadingMaterialTitleService } from '../../service/ReadingMaterialTitle.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-readingmaterialtitle-list',
  templateUrl: './readingmaterialtitle-list.component.html',
  styleUrls: ['./readingmaterialtitle-list.component.sass']
})
export class ReadingmaterialtitleListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ReadingMaterialTitle[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','title','actions'];
  dataSource: MatTableDataSource<ReadingMaterialTitle> = new MatTableDataSource();


   selection = new SelectionModel<ReadingMaterialTitle>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private ReadingMaterialTitleService: ReadingMaterialTitleService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.getReadingMaterialTitles();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getReadingMaterialTitles() {
    this.isLoading = true;
    this.subscription = this.ReadingMaterialTitleService.getReadingMaterialTitles(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getReadingMaterialTitles();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getReadingMaterialTitles();
  } 

  deleteItem(row) {
    const id = row.readingMaterialTitleId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.ReadingMaterialTitleService.delete(id).subscribe(() => {
          this.getReadingMaterialTitles();

          this.snackBar.open('ReadingMaterialTitle Information Deleted Successfully ', '', {
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
