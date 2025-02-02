import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { BNAExamMarkService } from '../../../central-exam/service/bnaexammark.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-examapprove-list',
  templateUrl: './examapprove-list.component.html',
  styleUrls: ['./examapprove-list.component.sass']
})
export class ExamApproveComponent implements OnInit, OnDestroy {
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
  
  traineeId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedExamEvaluationColumns: string[] = ['ser', 'course','subject','date','examStatus', 'markStatus'];
  subscription: any;

  constructor(private datepipe: DatePipe,private BNAExamMarkService: BNAExamMarkService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    
    this.courseTypeId = this.route.snapshot.paramMap.get('courseTypeId'); 
    this.courseNameId = Number(this.route.snapshot.paramMap.get('courseNameId'));
    this.traineeId = this.route.snapshot.paramMap.get('traineeId'); 
    this.getStuffClgApproveList()

    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

 
  
  getStuffClgApproveList(){
    this.destination="Stuff Collage"
    this.subscription = this.BNAExamMarkService.getCentralExamApproveList(this.masterData.coursetype.CentralExam, this.masterData.courseName.StaffCollage).subscribe(res=>{
      this.examList=res;  
    });
  }
}
