import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { BIODataGeneralInfo } from '../../models/BIODataGeneralInfo';
import { MatTableDataSource } from '@angular/material/table';
import { debounceTime, distinctUntilChanged, Subject, Subscription } from 'rxjs';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

import { PageEvent } from '@angular/material/paginator';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from '../../../../assets/data/master-data';
import { SharedServiceService} from '../../../../app/shared/shared-service.service';
import { environment } from '../../../../environments/environment';

@Component({
  selector: 'app-i-s-biodatainfo-list',
  templateUrl: './i-s-biodatainfo-list.component.html',
  styleUrls: ['./i-s-biodatainfo-list.component.sass']
})
export class ISBiodatainfoListComponent implements OnInit, OnDestroy {

  @ViewChild('fileInput') fileInput!: ElementRef;
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  isLoading = false;
  officerStatusId = 8; // for I/S 

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'sl','bnaPhotoUrl','pno','bnaNo','bnaBatch','joiningDate', 'actions'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();

  selection = new SelectionModel<BIODataGeneralInfo>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { 
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }
  

  ngOnInit() {
    this.getBIODataGeneralInfos();

  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    if (this.searchSubscription) {
      this.searchSubscription.unsubscribe();
    }
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  // getBIODataGeneralInfos() {
  //   this.isLoading = true;
  //   this.BIODataGeneralInfoService.getBIODataGeneralInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
  //     this.dataSource.data = response.items; 
  //     this.paging.length = response.totalItemsCount    
  //     this.isLoading = false;
  //   })
  // }
  getBIODataGeneralInfos() {
    this.isLoading = true;
    this.BIODataGeneralInfoService. getBIODataGeneralInfosForIs(this.paging.pageIndex, this.paging.pageSize, this.searchText)
      .subscribe(
        response => {
          this.dataSource.data = response.items; 
          this.paging.length = response.totalItemsCount;    
          this.isLoading = false;
        },
        error => {
          this.isLoading = false;
          this.snackBar.open('Error fetching data', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        }
      );
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
    this.getBIODataGeneralInfos();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.getBIODataGeneralInfos();
  } 

  // applyFilter(filterValue: string) {
  //   filterValue = filterValue.trim();
  //   filterValue = filterValue.toLowerCase().replace(/\s/g,'');
  //   this.dataSource.filter = filterValue;
  // }

  
  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
  }

  onFileSelected(event: Event) {
    this.isLoading = true;
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      // this.loading = true;
      this.BIODataGeneralInfoService.uploadFile(file, this.officerStatusId).subscribe(
        (response: any) => {
        (event.target as HTMLInputElement).value = '';
        if(response.success){
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
           this.isLoading = false;
          this.getBIODataGeneralInfos();
        }
        else{
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
          this.isLoading = false;
        }
        // this.loading= false; 
      },
        (error) => {
          (event.target as HTMLInputElement).value = '';
          this.isLoading = false;
        }
      );
    }
  }
  downloadExcelFile(){
    const url = environment.fileUrl + '/files/biodata-excel-file/New_Biodata _Entry_Info.xlsx'
    const a = document.createElement('a');
    a.href = url;
    a.download = 'New_Biodata _Entry_Info.xlsx';
    document.body.appendChild(a);
    a.click();
    document.body.removeChild(a);
  }
  
  deleteItem(row) {
    const id = row.traineeId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.BIODataGeneralInfoService.delete(id).subscribe(() => {
          this.getBIODataGeneralInfos();
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
