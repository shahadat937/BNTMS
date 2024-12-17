import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BIODataGeneralInfo } from '../../models/BIODataGeneralInfo';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MasterData } from 'src/assets/data/master-data';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from 'src/app/shared/shared-service.service';



@Component({
  selector: 'app-biodata-general-info-list',
  templateUrl: './biodata-general-info-list.component.html',
  styleUrls: ['./biodata-general-info-list.component.sass']
})
export class BIODataGeneralInfoListComponent implements OnInit, OnDestroy {
 userRole= Role;
   masterData = MasterData;
   searchTextChanged = new Subject<string>();
   searchText:string='';
   debounceTime: 300;
  loading = false;
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription
  isLoading = false;
  @ViewChild('fileInput') fileInput!: ElementRef;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  branchId:any;
  traineeId:any;
  role:any;

  
  // searchText="";

  displayedColumns: string[] = [ 'sl','bnaPhotoUrl','pno','saylorRank','saylorBranch','mobile', 'actions'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();

  selection = new SelectionModel<BIODataGeneralInfo>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private BIODataGeneralInfoService: BIODataGeneralInfoService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
   this.traineeId =  this.authService.currentUserValue.traineeId.trim();
   // this.branchId =  this.authService.currentUserValue.branchId.trim();
   this.searchSubscription = this.searchSubject.pipe(
    debounceTime(300), // Wait for 300ms pause in events
    distinctUntilChanged() // Only emit if value is different from previous
  ).subscribe(searchText => {
    this.applyFilter(searchText);
  });
   this.branchId =  this.authService.currentUserValue.branchId  ? this.authService.currentUserValue.branchId.trim() : "";

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
  
  
  getBIODataGeneralInfos() {
    this.isLoading = true;
    this.BIODataGeneralInfoService.getBIODataGeneralInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
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
    console.log(event);
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
    
  //   this.dataSource.filter = filterValue.toLowerCase().replace(/\s/g,'');
     
  // }

  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
  }

  onFileSelected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      this.loading = true;
      this.BIODataGeneralInfoService.uploadFile(file).subscribe(
        (response: any) => {
        (event.target as HTMLInputElement).value = '';
        if(response.success){
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
          this.loading = false;
          this.getBIODataGeneralInfos();
        }
        else{
          this.snackBar.open(response.message, '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        }
        // this.loading= false; 
      },
        (error) => {
          (event.target as HTMLInputElement).value = '';
        }
      );
    }
  }

  deleteItem(row) {
    const id = row.traineeId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
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
