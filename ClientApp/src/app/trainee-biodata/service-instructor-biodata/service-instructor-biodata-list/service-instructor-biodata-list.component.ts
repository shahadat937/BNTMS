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
import { UserService } from '../../../security/service/User.service';
import { Role } from '../../../core/models/role';
import { AuthService } from '../../../core/service/auth.service';

@Component({
  selector: 'app-service-instructor-biodata-list',
  templateUrl: './service-instructor-biodata-list.component.html',
  styleUrls: ['./service-instructor-biodata-list.component.sass']
})
export class ServiceInstructorBiodataListComponent implements OnInit {

  @ViewChild('fileInput') fileInput!: ElementRef;
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BIODataGeneralInfo[] = [];
  isLoading = false;

  serviceInstructorBioData : any
  serviceInstructorBioDataGroupBy : any;
  branchId : any;
  userRoles = Role;
  role: any
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  warningMessage = ""
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [ 'sl','bnaPhotoUrl','pno','email','mobile','joiningDate', 'actions'];
  dataSource: MatTableDataSource<BIODataGeneralInfo> = new MatTableDataSource();

  selection = new SelectionModel<BIODataGeneralInfo>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private BIODataGeneralInfoService: BIODataGeneralInfoService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService, public UserService: UserService, private authService: AuthService) { 
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }
  

  ngOnInit() {
    this.branchId = this.authService.currentUserValue.branchId;
    this.role = this.authService.currentUserValue.role;
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
    let branch : any ;
    if(this.role === this.userRoles.SuperAdmin){
      branch = this.branchId
    }
    else{
      branch = "";
    }

    this.BIODataGeneralInfoService. getServiceInstructorBioData(this.paging.pageIndex, this.paging.pageSize, this.searchText, branch)
      .subscribe(
        response => {
          this.serviceInstructorBioData = response 
          this.sharedService.groupedData = this.sharedService.groupBy(this.serviceInstructorBioData, (bioData)=> bioData.schoolName );
          console.log( this.sharedService.groupedData);       
            this.warningMessage = this.serviceInstructorBioData.length ? "" : "No Instructor Found"
          
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
   
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBIODataGeneralInfos();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getBIODataGeneralInfos();
  } 

   
  triggerFileSelect() {
    this.fileInput.nativeElement.click(); // Triggers the file selection dialog
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

  releseInstractor(userId){
    this.confirmService.confirm('Confirm Update message', 'Are You Sure Switch This  User?').subscribe(result => {
      if (result) {
        this.UserService.releseServiceInstructor(userId).subscribe(response => {
          this.getBIODataGeneralInfos();
          this.snackBar.open('Information Updated Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        })
      }
    })

  }


}
