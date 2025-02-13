import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BIODataGeneralInfo } from '../../models/BIODataGeneralInfo';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { environment } from '../../../../environments/environment';



@Component({
  selector: 'app-foreignbiodatainfo-list',
  templateUrl: './foreignbiodatainfo-list.component.html',
  styleUrls: ['./foreignbiodatainfo-list.component.sass']
})
export class ForeignBIODataInfoListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  @ViewChild('fileInput') fileInput!: ElementRef;

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  isLoading = false;

  officerTypeId = 2 //  Forign Officer Type
  officerStatusId = 4; // for Forign Officer

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedColumns: string[] = ['sl', 'bnaPhotoUrl', 'pno', 'country', 'actions'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();

  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  selection = new SelectionModel<BIODataGeneralInfo>(true, []);
  subscription: any;


  constructor(private snackBar: MatSnackBar, private BIODataGeneralInfoService: BIODataGeneralInfoService, private router: Router, private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }


  ngOnInit() {
    this.getBIODataGeneralInfos();

    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), // Wait for 300ms pause in events
      distinctUntilChanged() // Only emit if value is different from previous
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }
  
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }

  getBIODataGeneralInfos() {
    this.isLoading = true;
    this.BIODataGeneralInfoService.getBIODataGeneralInfos(this.paging.pageIndex, this.paging.pageSize, this.subscription = this.searchText).subscribe(response => {
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
  addNew() {

  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBIODataGeneralInfos();
  }

  applyFilter(searchText: any) {

    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.trim().toLowerCase().replace(/\s/g, '');
    this.getBIODataGeneralInfos();
  }
  

  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
  }

  onFileSelected(event: Event) {
    this.isLoading = true;
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      // this.loading = true;
      this.BIODataGeneralInfoService.uploadExcelBioDataFileForOfficersAndCivil(file, this.officerStatusId, this.officerTypeId).subscribe(
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
