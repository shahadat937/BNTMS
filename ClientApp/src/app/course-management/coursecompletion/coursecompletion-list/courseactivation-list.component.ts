// import { AuthService } from 'src/app/core/service/auth.service';
import { AuthService } from '../../../core/service/auth.service';
import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration';
import {CourseDurationService} from '../../service/courseduration.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
// import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ConfirmService } from '../../../core/service/confirm.service';
// import {MasterData} from 'src/assets/data/master-data'
import { MasterData } from '../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe, formatDate } from '@angular/common';
import {Inject, LOCALE_ID } from '@angular/core';
// import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs';
// import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { Role } from '../../../../../src/app/core/models/role';

@Component({
  selector: 'app-courseactivation-list',
  templateUrl: './courseactivation-list.component.html',
  styleUrls: ['./courseactivation-list.component.sass'] 
})
export class CourseActivationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  
  
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  completeStatus :boolean = false;
  btnText:string;
  currentDateTime:any;
  
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  dateTo:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 1000,
    length: 1
  }
  searchText="";
  groupArrays:{ baseSchoolName: string; courses: any; }[];

  displayedColumns: string[] = ['ser','baseSchoolName','courseName','durationFrom','durationTo', 'actions'];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();
  baseSchoolNameId: string | null = null;
  // dataSource = { data: [] }

   selection = new SelectionModel<CourseDuration>(true, []);
    userRole= Role;
  branchId: any;
  roleName: any;

  
  constructor(@Inject(LOCALE_ID) public locale: string,private datepipe: DatePipe,private snackBar: MatSnackBar,private CourseDurationService: CourseDurationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService, private route: ActivatedRoute, private authService: AuthService) {
    super();
  }

  ngOnInit() {
    this.currentDateTime =this.datepipe.transform((new Date), 'dd/MM/YYYY');
    this.branchId =  this.authService.currentUserValue.branchId 
    this.roleName =  this.authService.currentUserValue.role 
    // this.getCourseDurations();
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300),
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
    this.route.paramMap.subscribe(params => {
      this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');

      if ( this.roleName === this.userRole.SuperAdmin) {
        
        this.getCourseDuraionByBaseName();
      } else {
        this.getCourseDurations();
      }
    });
    
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }
  getCourseStatus(data){
    this.currentDateTime =this.datepipe.transform((new Date), 'dd/MM/YYYY');
    this.dateTo =this.datepipe.transform(data.durationTo, 'dd/MM/YYYY');

    // this.currentDateTime =new Date();
    // this.dateTo =data.durationTo;
    
    if(new Date(this.dateTo).getTime() > new Date(this.currentDateTime).getTime())
    {
      this.completeStatus = false;
    }else{
      this.completeStatus = true;
    }
  }
  getCourseDurations() {
    this.isLoading = true;
    this.CourseDurationService.getCourseDurations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {       
      this.dataSource.data = response.items; 
      this.sharedService.groupedData = this.sharedService.groupBy(
        this.dataSource.data,
        (courses) => courses.baseSchoolName
      );

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      // for (var val of  response.items) {
        
      //   if(val.isActive = true){
      //     this.btnText="De Active"
      //   }
      //   else{
      //     this.btnText="Active"
      //   }
      // }
    })
  }
  getCourseDuraionByBaseName() {
    this.isLoading = true;
    this.CourseDurationService.getCourseDuraionByBaseName(this.branchId, this.paging.pageIndex, this.paging.pageSize).subscribe(response => {
      // this.dataSource.data = response;
      this.dataSource.data = response.items; 
      this.sharedService.groupedData = this.sharedService.groupBy(
        this.dataSource.data,
        (courses) => courses.baseSchoolName
      );
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    });
  }

  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getCourseDurations();
 
  // }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseDurations();
  }  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  inActiveItem(row) {
    const id = row.courseDurationId;    
    if (row.isActive) {
      this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Deactive This Item').subscribe(result => {
        if (result) {
          this.CourseDurationService.deactiveCourseDuration(id).subscribe(() => {
           
            row.isCompletedStatus = 1; 
  
            this.snackBar.open('Information Deactive Successfully', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          });
          
          // this.reloadCurrentRoute();
        }
      });
    }
  }
  
  deleteItem(row) {
    const id = row.courseDurationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseDurationService.delete(id).subscribe(() => {
          this.getCourseDurations();
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
