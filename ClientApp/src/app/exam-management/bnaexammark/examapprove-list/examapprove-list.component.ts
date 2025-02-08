import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { MatSort } from '@angular/material/sort';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-examapprove-list',
  templateUrl: './examapprove-list.component.html',
  styleUrls: ['./examapprove-list.component.sass']
})
export class ExamApproveComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  InstructorByCourse:any;
  PendingExamEvaluation:any;
  localCourseCount:number;
  InstructorList:any;
  examList:any;
  courseNameId:any;
  courseTypeId:any;
  // groupArrays:{ key: string; courses: any; }[];

  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  matSort!: MatSort;

  role:any;
  traineeId:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedExamEvaluationColumns: string[] = ['ser', 'course','subject','date','examStatus', 'markStatus'];

  groupArrays: any[] = [];         // Filtered array
  originalGroupArrays: any[] = [];

  constructor(private datepipe: DatePipe,private authService: AuthService,private BNAExamMarkService: BNAExamMarkService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.getQexamApproveList(this.branchId)

    
    
  }

  
  
  // getQexamApproveList(baseSchoolId){
  //   this.destination="Exam"
  //   this.BNAExamMarkService.getSchoolExamApproveList(baseSchoolId).subscribe(res=>{
  //     this.examList=res;  
  //     const group = this.examList.reduce((groups, item) => {
       
  //       const key = `${item.course} - ${item.courseTitle}`; 
    
  //       if (!groups[key]) {
  //         groups[key] = [];
  //       }
    
  //       groups[key].push(item);
  //       return groups;
  //     }, {});
    
  //     this.groupArrays = Object.keys(group).map((key) => {
  //       return {
  //         key,
  //         courses: group[key]
  //       };
  //     });
  //     // this.dataSource = new MatTableDataSource(res);
  //     // this.dataSource.paginator = this.paginator;
  //     // this.dataSource.sort = this.matSort;       
  //   });
  // }


  // applyFilter(filterValue: string) {
    
  //   filterValue = filterValue.toLowerCase().replace(/\s/g,'');
  //   this.dataSource.filter = filterValue;
  //   this.searchText = filterValue;
  // }

  getQexamApproveList(baseSchoolId: string) {
    this.destination = "Exam";
    this.BNAExamMarkService.getSchoolExamApproveList(baseSchoolId).subscribe(res => {
      this.examList = res;
      this.dataSource = new MatTableDataSource(res);
   
          this.sharedService.groupedData = this.sharedService.groupBy(
            this.dataSource.data,
            (courses) => courses.course + '-'+ courses.courseTitle
          );
      // Store the original data for resetting the filter
      this.originalGroupArrays = [...this.groupArrays];  // Keep a copy of the original data
    });
    
  }

  
  applyFilter(filterValue: string) {
    const processedFilter = this.normalizeString(filterValue); // Normalize the filter input
    
    // If the filter value is empty, show all records
    if (!processedFilter) {
      this.groupArrays = [...this.originalGroupArrays]; // Reset to original data
    } else {
      // Filter groups by normalized key if there's a filter value
      this.groupArrays = this.originalGroupArrays.filter(group =>
        this.normalizeString(group.key).includes(processedFilter) // Compare normalized key
      );
    }
    
  }

  // Utility function to normalize strings by removing spaces and unwanted characters
  normalizeString(str: string): string {
    return str.toLowerCase().replace(/\s/g, '').replace(/[^a-z0-9]/g, ''); // Remove spaces and non-alphanumeric characters
  }
  

  
}
