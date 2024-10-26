import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { MatSort } from '@angular/material/sort';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

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

  constructor(private datepipe: DatePipe,private authService: AuthService,private BNAExamMarkService: BNAExamMarkService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.getQexamApproveList(this.branchId)
    
    
  }

  
  
  getQexamApproveList(baseSchoolId){
    this.destination="Exam"
    this.BNAExamMarkService.getSchoolExamApproveList(baseSchoolId).subscribe(res=>{
      this.examList=res;  
      this.dataSource = new MatTableDataSource(res);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.matSort;
    });
  }


  applyFilter(filterValue: string) {
    
    filterValue = filterValue.toLowerCase().replace(/\s/g,'');
    this.dataSource.filter = filterValue;
  }
}
