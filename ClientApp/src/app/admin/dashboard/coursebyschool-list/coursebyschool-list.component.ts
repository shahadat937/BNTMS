import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { dashboardService } from '../services/dashboard.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { ActivatedRoute,Router } from '@angular/router';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-coursebyschool-list',
  templateUrl: './coursebyschool-list.component.html',
  styleUrls: ['./coursebyschool-list.component.sass']
})
export class CoursebySchoolListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  courseList:any;
  schoolName:any;
  schoolNameTitle:any='';
  
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','course','duration', 'officer','mid','cadet','is','sailor','civil','foreign', 'total'];

  
  constructor(
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private datepipe: DatePipe,
    private dashboardService: dashboardService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService  
  ) {
    super();
  }

  ngOnInit() {
    var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.getBnaClassTests(baseSchoolNameId);

    if(Number(baseSchoolNameId) == 0){
      this.schoolName = "Foreign Courses";
    }else{
      this.dashboardService.getSchoolNameById(baseSchoolNameId).subscribe(response => {     
        this.schoolNameTitle="School Name:";
        this.schoolName = response.schoolName; 
      });
    }
    
    
    
  }
 
  getBnaClassTests(baseSchoolNameId) {
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.isLoading = true;
    this.dashboardService.getSpCourseListBySchool(baseSchoolNameId,currentDateTime).subscribe(response => {     
      this.courseList = response;   
      this.isLoading = false;
    });
  }

  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getBnaClassTests();
 
  // }
  // applyFilter(searchText: any){ 
  //   this.searchText = searchText;
  //   this.getBnaClassTests();
  // } 

  // deleteItem(row) {
  //   const id = row.bnaClassTestId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
  //     if (result) {
  //       this.BnaClassTestService.delete(id).subscribe(() => {
  //         this.getBnaClassTests();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 3000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
    
  // }
}
