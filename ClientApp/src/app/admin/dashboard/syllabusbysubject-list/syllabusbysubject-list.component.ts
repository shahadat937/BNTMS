import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { dashboardService } from '../services/dashboard.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-syllabusbysubject',
  templateUrl: './syllabusbysubject-list.component.html',
  styleUrls: ['./syllabusbysubject-list.component.sass']
})
export class SyllabusbySubjectListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  TrainingSyllabusList:any;
  traineeId:any;
  baseSchoolNameId:any;
  courseNameId:any;
  bnaSubjectNameId:any;
  courseDurationId:any;
  traineeDb:any;
  role:any;
  status=1;
  groupArrays:{ taskDetail: string; syllabus: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  constructor(private snackBar: MatSnackBar, private authService: AuthService, private dashboardService: dashboardService , private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute) {
    super();
  }

  ngOnInit() {
    this.traineeDb=1;
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    const branchId =  this.authService.currentUserValue.branchId.trim();
    this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.bnaSubjectNameId = this.route.snapshot.paramMap.get('bnaSubjectNameId');
    this.getTrainingSyllabusListByParams(this.baseSchoolNameId,this.courseNameId,this.bnaSubjectNameId)
  }

  getTrainingSyllabusListByParams(baseSchoolNameId,courseNameId,bnaSubjectNameId){
    this.dashboardService.getTrainingSyllabusListByParams(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      this.TrainingSyllabusList = res;

      // this gives an object with dates as keys
      const groups = this.TrainingSyllabusList.reduce((groups, syllabus) => {
        const taskDetails = syllabus.taskDetail;
        if (!groups[taskDetails]) {
          groups[taskDetails] = [];
        }
        groups[taskDetails].push(syllabus);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((taskDetail) => {
        return {
          taskDetail,
          syllabus: groups[taskDetail]
        };
      });
    });
  }


  // getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId){    
  //   this.studentDashboardService.getReadingMAterialInfoBySchoolAndCourse(baseSchoolNameId, courseNameId).subscribe(res=>{
  //     this.ReadingMaterialBySchoolAndCourse = res;
  //   });
  // }

}
