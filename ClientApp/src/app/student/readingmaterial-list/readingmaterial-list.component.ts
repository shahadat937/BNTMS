import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { InstructorDashboardService } from 'src/app/teacher/services/InstructorDashboard.service';

@Component({
  selector: 'app-readingmaterial',
  templateUrl: './readingmaterial-list.component.html',
  styleUrls: ['./readingmaterial-list.component.sass']
})
export class ReadingMaterialListComponent implements OnInit, OnDestroy {
  masterData = MasterData;
  loading = false;
  userRole = Role;
  isLoading = false;
  pageTitle: any;
  fileIUrl = environment.fileUrl;
  ELEMENT_DATA: BNASubjectName[] = [];
  ReadingMaterialBySchoolAndCourse: any;
  documentTypeId: any;
  status = 1;
  baseSchoolNameId: any;

  role: any;
  traineeId: any;
  branchId: any;


  groupArrays: { readingMaterialTitle: string; courses: any; }[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";

  displayedReadingMaterialColumns: string[] = ['ser', 'readingMaterialTitle', 'documentName', 'documentLink'];


  selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;



  constructor
    (
      private snackBar: MatSnackBar,
      private authService: AuthService,
      private studentDashboardService: StudentDashboardService,
      private BNASubjectNameService: BNASubjectNameService,
      private router: Router,
      private confirmService: ConfirmService,
      private route: ActivatedRoute,
      public sharedService: SharedServiceService,
      private instructorDashboardService: InstructorDashboardService
    ) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    // const branchId =  this.authService.currentUserValue.branchId.trim();
    this.branchId = this.authService.currentUserValue.branchId ? this.authService.currentUserValue.branchId.trim() : "";

    var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    this.documentTypeId = this.route.snapshot.paramMap.get('documentTypeId');
    this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');


    if (this.role === 'Master Admin') {      
      this.setPageTitle(this.documentTypeId)
      this.getAllReadingMaterialList(this.documentTypeId);
    }
    else if (this.role === 'Super Admin') {
      this.setPageTitle(this.documentTypeId)
      this.baseSchoolNameId = this.branchId;
      this.getReadingMaterialList(this.documentTypeId);
    }
    else if (this.role === 'Instructor') {
      this.instructorDashboardService.getSpInstructorInfoByTraineeId(this.traineeId).subscribe(res => {
        if (res) {
          let infoList = res;
          this.baseSchoolNameId = infoList[0].baseSchoolNameId;
          this.setPageTitle(this.documentTypeId)
          this.getReadingMaterialList(this.documentTypeId);
        }
      });
    }
    else if (this.role === 'Student') {
      this.studentDashboardService.getSpStudentInfoByTraineeId(this.traineeId).subscribe(res => {
        if (res) {

          let infoList = res
          this.baseSchoolNameId = infoList[0].baseSchoolNameId;

        }
        if (this.documentTypeId) {
          this.setPageTitle(this.documentTypeId)
          this.getReadingMaterialList(this.documentTypeId);
          console.log(courseNameId);
        } else {
          this.pageTitle = "Course Material";
          this.getReadingMaterialBySchoolAndCourse(this.baseSchoolNameId, courseNameId);
        }

      });
    }


  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getReadingMaterialList(documentTypeId) {
    this.subscription = this.studentDashboardService.getReadingMaterialListByType(documentTypeId, this.baseSchoolNameId).subscribe(res => {
      this.ReadingMaterialBySchoolAndCourse = res;
    });
  }
  getAllReadingMaterialList(documentTypeId) {
    this.subscription = this.studentDashboardService.getAllReadingMaterialList(documentTypeId).subscribe(res => {
      this.ReadingMaterialBySchoolAndCourse = res;
    });
  }

  setPageTitle(documentTypeId) {

    if (documentTypeId == this.masterData.readingMaterial.books) {
      this.pageTitle = "Books";
    } else if (documentTypeId == this.masterData.readingMaterial.videos) {
      this.pageTitle = "Videos";
    } else if (documentTypeId == this.masterData.readingMaterial.slides) {
      this.pageTitle = "Slides";
    } else if (this.documentTypeId == this.masterData.readingMaterial.materials) {
      this.pageTitle = "Reading Material";
    } else {
      this.pageTitle = "Material";
    }

  }

  // getCourseModuleByCourseName(courseNameId){
  //   this.studentDashboardService.getSelectedCourseModulesByCourseNameId(courseNameId).subscribe(res=>{
  //     this.CourseModuleByCourseName = res;
  //   });
  // }

  getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId) {
    this.subscription = this.studentDashboardService.getReadingMAterialInfoBySchoolAndCourse(baseSchoolNameId, courseNameId).subscribe(res => {
      this.ReadingMaterialBySchoolAndCourse = res;

      const groups = this.ReadingMaterialBySchoolAndCourse.reduce((groups, courses) => {
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
    });
  }

}
