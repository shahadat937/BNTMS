import { Component, OnInit } from '@angular/core';
import { Role } from 'src/app/core/models/role';
import { MasterData } from 'src/assets/data/master-data';
import { OnlineLibraryMaterial } from '../models/onlinelibrarymaterial';
import { debounceTime, distinctUntilChanged, Subject, Subscription } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { OnlinelibraryService } from '../service/onlinelibrary.service'
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-online-library-meterial-list',
  templateUrl: './online-library-meterial-list.component.html',
  styleUrls: ['./online-library-meterial-list.component.sass']
})
export class OnlineLibraryMeterialListComponent implements OnInit {
  masterData = MasterData;
  loading = false;
  userRole = Role;
  ELEMENT_DATA: OnlineLibraryMaterial[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  }
  searchText = "";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;
  displayedColumns: string[] = ['ser','baseSchoolName','documentName','documentLink', 'actions'];

  role: any;
  traineeId: any;
  branchId: any;
  selection = new SelectionModel<OnlineLibraryMaterial>(true, []);
  subscription: any;

  dataSource: MatTableDataSource<OnlineLibraryMaterial> = new MatTableDataSource();
  groupArrays:{ schoolName: string; documentsName: any; }[];

  constructor(private snackBar: MatSnackBar,
    private authService: AuthService,
    private readonly sanitizer: DomSanitizer,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,
    private onlineLibraryService: OnlinelibraryService) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();
    this.getOnlineLibraryMetarials()
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
  }


  getOnlineLibraryMetarials() {

    this.onlineLibraryService.getOnlineLibraryMaterials(this.paging.pageIndex, this.paging.pageSize, this.subscription = this.searchText).subscribe(response => {

      this.dataSource.data = response.items;
     
       // this gives an object with dates as keys
    const groups = this.dataSource.data.reduce((groups, courses) => { 
      const schoolName = courses.baseSchoolName ? courses.baseSchoolName : "Admin";
      if (!groups[schoolName]) {
        groups[schoolName] = [];
      }
      groups[schoolName].push(courses);
      return groups;
    }, {});

    // Edit: to add it in the array format instead
    this.groupArrays = Object.keys(groups).map((schoolName) => {
      return {
        schoolName,
        documentsName: groups[schoolName]
      };
    });
    
      this.paging.length = response.totalItemsCount
     
    })
    
  }

  onSearchChange(value: string){

  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getOnlineLibraryMetarials();
  }

  deleteItem(row) {
    const id = row.onlineLibraryId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.onlineLibraryService.delete(id).subscribe(() => {
          this.getOnlineLibraryMetarials();

          this.snackBar.open('Online Library Information Deleted Successfully ', '', {
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


