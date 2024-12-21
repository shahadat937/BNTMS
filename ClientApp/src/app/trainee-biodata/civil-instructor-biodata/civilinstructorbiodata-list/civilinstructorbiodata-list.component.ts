import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BIODataGeneralInfo } from '../../models/BIODataGeneralInfo';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MasterData } from 'src/assets/data/master-data';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { environment } from '../../../../environments/environment';


@Component({
  selector: 'app-civilinstructorbiodata-list',
  templateUrl: './civilinstructorbiodata-list.component.html',
  styleUrls: ['./civilinstructorbiodata-list.component.scss']
})
export class CivilInstructorBioDataInfoListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  isLoading = false;
  @ViewChild('fileInput') fileInput!: ElementRef;
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  officerTypeId = 3 ; // 3 is for civil officer type Id
  officerStausId = 0; // there is no statusId for Civil  

  displayedColumns: string[] = [ 'sl','bnaPhotoUrl','pno','type', 'actions'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();

  selection = new SelectionModel<BIODataGeneralInfo>(true, []);

  
  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
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
    this.BIODataGeneralInfoService.getCivilInstructorBIOData(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
 
  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
  }

  onFileSelected(event: Event) {
    this.isLoading = true;
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      // this.loading = true;
      this.BIODataGeneralInfoService.uploadExcelBioDataFileForOfficersAndCivil(file, 0, this.officerTypeId).subscribe(
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
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBIODataGeneralInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText.toLowerCase().trim().replace(/\s/g,'');
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.getBIODataGeneralInfos();
  } 
  // applyFilter(filterValue: string) {
  //   filterValue = filterValue.trim();
  //   filterValue = filterValue.toLowerCase().replace(/\s/g,'');
  //   this.dataSource.filter = filterValue;
  // }


  deleteItem(row) {
    const id = row.traineeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.BIODataGeneralInfoService.delete(id).subscribe(() => {
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
