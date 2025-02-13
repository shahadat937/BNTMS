import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-teacherevaluation',
  templateUrl: './teacherevaluation-list.component.html',
  styleUrls: ['./teacherevaluation-list.component.sass']
})
export class TeacherEvaluationListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  CourseModuleByCourseName:any;
  status=1;
  traineeId:any;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedCourseModuleColumns: string[] = ['ser','course','subjectName','name','actions'];
  subscription: any;


  
  constructor(private snackBar: MatSnackBar,private studentDashboardService: StudentDashboardService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.getTdecQuestionGroupListBySp(baseSchoolNameId,courseNameId,courseDurationId)
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getTdecQuestionGroupListBySp(baseSchoolNameId,courseNameId,courseDurationId){
    this.subscription = this.studentDashboardService.getTdecQuestionGroupListBySp(baseSchoolNameId,courseNameId,courseDurationId).subscribe(res=>{
      this.CourseModuleByCourseName = res;
    });
  }

}
