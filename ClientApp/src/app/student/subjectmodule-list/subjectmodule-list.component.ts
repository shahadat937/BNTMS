import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-subjectmodule',
  templateUrl: './subjectmodule-list.component.html',
  styleUrls: ['./subjectmodule-list.component.sass']
})
export class SubjectModuleListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  CourseModuleByCourseName:any;
  status=1;
  SelectedsubjectsBySchoolAndCourse:BNASubjectName[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedCourseModuleColumns: string[] = ['ser','moduleName','nameOfModule', 'actions'];


   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private studentDashboardService: StudentDashboardService,private BNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    this.getCourseModuleByCourseName(courseNameId)
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getCourseModuleByCourseName(courseNameId){
    this.subscription = this.studentDashboardService.getSelectedCourseModulesByCourseNameId(courseNameId).subscribe(res=>{
      this.CourseModuleByCourseName = res;
    });
  }

}
