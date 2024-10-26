import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {ReadingMaterial} from '../../models/readingmaterial'
import {ReadingMaterialService} from '../../service/readingmaterial.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import {Role} from 'src/app/core/models/role'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import { AuthService } from 'src/app/core/service/auth.service';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-readingmaterial-list',
  templateUrl: './readingmaterial-list.component.html',
  styleUrls: ['./readingmaterial-list.component.sass']
})
export class ReadingMaterialListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  ELEMENT_DATA: ReadingMaterial[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  role:any;
  traineeId:any;
  branchId:any;

  groupArrays:{ readingMaterialTitle: string; courses: any; }[];

  displayedColumns: string[] = ['ser','readingMaterialTitle','courseName','documentName','documentLink', 'actions'];
  dataSource: MatTableDataSource<ReadingMaterial> = new MatTableDataSource();


   selection = new SelectionModel<ReadingMaterial>(true, []);
  subscription: any;

  
  constructor
  (
    private snackBar: MatSnackBar, 
    private authService: AuthService,
    private ReadingMaterialService: ReadingMaterialService,
    private readonly sanitizer: DomSanitizer,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) 
  { }

  ngOnInit() {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    if(this.role == this.userRole.MasterAdmin){
      this.branchId = 0;
    }
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });

    this.getReadingMaterials();
    
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
 
  getReadingMaterials() {
    this.isLoading = true;
    this.ReadingMaterialService.getReadingMaterialsBySchool(this.paging.pageIndex, this.paging.pageSize,this.subscription = this.searchText, this.branchId).subscribe(response => {
    
      this.dataSource.data = response.items; 

      const groups = this.dataSource.data.reduce((groups, courses) => {
        const materialTitle = courses.readingMaterialTitle;
        if (!groups[materialTitle]) {
          groups[materialTitle] = [];
        }
        groups[materialTitle].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((readingMaterialTitle) => {
        return {
          readingMaterialTitle,
          courses: groups[readingMaterialTitle]
        };
      });

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getReadingMaterials();
 
  // }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getReadingMaterials();
  } 

  safeUrlPic(url: any){ 
    var specifiedUrl = this.sanitizer.bypassSecurityTrustUrl(url); 
    return specifiedUrl;
  }

  deleteItem(row) {
    const id = row.readingMaterialId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.ReadingMaterialService.delete(id).subscribe(() => {
          this.getReadingMaterials();
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
