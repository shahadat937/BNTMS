import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TraineeNomination } from '../../../course-management/models/traineenomination'
import { TraineeNominationService } from '../../../course-management/service/traineenomination.service'
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';

import { MatSnackBar } from '@angular/material/snack-bar';
import { MasterData } from '../../../../assets/data/master-data';
import { environment } from '../../../../environments/environment';
import { Role } from '../../../core/models/role';
import { AuthService } from '../../../core/service/auth.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { CourseInstructorService } from '../../../subject-management/service/courseinstructor.service';


@Component({
  selector: 'app-traineenomination-list',
  templateUrl: './traineenomination-list.component.html',
  styleUrls: ['./traineenomination-list.component.sass']
})
export class TraineeNominationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  userRole = Role;
  loading = false;
  ELEMENT_DATA: TraineeNomination[] = [];
  isLoading = false;
  fileUrl: any = environment.fileUrl;
  courseDurationId: number;
  courseDuration: any;
  courseNameId: number;
  courseTypeId: number;
  baseSchoolNameId: any;
  dbType: any;
  dbType1: any;
  schoolName: any;
  durationForm: Date;
  durationTo: Date;
  courseType3: any;
  showHideDiv = false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";
  groupArrays: { courseName: string; courses: any; }[];
  branchId: any;
  traineeId: any;
  role: any;
  nominatedPercentageList: any;
  TraineeReportSubmittedList: any;
  courseName : string

  getCourse: any;

  displayedColumns: string[] = ['ser', 'traineeName', 'attandanceParcentage'];
  displayedInterServiceColumns: string[] = ['ser', 'traineeName', 'status', 'doc', 'attendance', 'remark'];

  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


  selection = new SelectionModel<TraineeNomination>(true, []);


  constructor(
    private route: ActivatedRoute,
    private CourseInstructorService: CourseInstructorService,
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private TraineeNominationService: TraineeNominationService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,
  ) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    this.route.paramMap.subscribe(params => {
      this.loadData();
    })
    //this.getTraineeNominations();
    //var schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
  }

  loadData() {
    this.baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.courseDuration = courseDurationId;
    this.dbType = this.route.snapshot.paramMap.get('dbType');
    this.dbType1 = this.route.snapshot.paramMap.get('dbType1');
    this.courseTypeId = Number(this.route.snapshot.paramMap.get('courseTypeId'));
    this.courseType3 = this.route.snapshot.paramMap.get('courseType3');
    this.masterData.dbType.foreignTrainingDb
    if (courseDurationId) {
      this.TraineeNominationService.findByCourseDuration(+courseDurationId).subscribe(
        res => {
          this.courseDurationId = res.courseDurationId,
          this.courseNameId = res.courseNameId
        }
      );
      if (this.role === 'Inter Seevice Course') {
        this.gettraineeNominationListByTypeCourseDurationId(courseDurationId);
      }
      this.getTraineeNominationsByCourseDurationId(courseDurationId)
    }
    var courseId = this.route.snapshot.paramMap.get("courseNameId");
    if(courseId){
      this.getTraineeNominationsByCourseId(courseId);
    }
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    const printElement = document.getElementById("print-routine");
    if (printElement) {
      printContents = printElement.innerHTML;
    }
    popupWin = window.open("", "<h3>NOMINAL ROLL</h3>", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
                .header-warning{
                  font-size:12px;
                }
                .header-warning.bottom{
                  position:absolute;
                  bottom:0;
                  left:44%;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <span class="header-warning top">CONFIDENTIAL</span>
          <h3>NOMINAL ROLL</h3>
          <h3> ${this.getCourse? this.getCourse : this.courseName}</h3>
          <h3> ${this.schoolName? this.schoolName : ""}</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          <span class="header-warning bottom">CONFIDENTIAL</span>
        </body>
      </html>`);
    popupWin.document.close();
  }



  gettraineeNominationListByTypeCourseDurationId(courseDurationId) {

    this.isLoading = true;
    this.TraineeNominationService.gettraineeNominationListByTypeCourseDurationId(courseDurationId).subscribe(response => {
      this.TraineeReportSubmittedList = response;
    });
  }

  getTraineeNominationsByCourseId (courseId){
    this.TraineeNominationService.gettraineeNominationListByCourseNameId(courseId).subscribe(
      response => {
        this.courseName = response[0].course;
        this.nominatedPercentageList = response;
      } )
  }


  getTraineeNominationsByCourseDurationId(courseDurationId) {

    this.isLoading = true;
    this.TraineeNominationService.gettraineeNominationListByCourseDurationId(courseDurationId).subscribe(response => {
      this.nominatedPercentageList = response;
    });
    this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize, this.searchText, courseDurationId).subscribe(response => {
      this.dataSource.data = response.items;
      this.schoolName = this.dataSource.data[0].schoolName;
      this.getCourse = this.dataSource.data[0].courseName + '_' + this.dataSource.data[0].courseDuration;
      // this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, courses) => {
        const courseName = courses.courseName + '-' + courses.courseDuration;
        if (!groups[courseName]) {
          groups[courseName] = [];
        }
        groups[courseName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((courseName) => {
        return {
          courseName,
          courses: groups[courseName]
        };
      });

      this.paging.length = response.totalItemsCount
      this.isLoading = false;
    })

  }

  pageChanged(event: PageEvent) {
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTraineeNominationsByCourseDurationId(courseDurationId);

  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    //this.getTraineeNominations();
  }

  deleteItem(row) {
    const id = row.traineeNominationId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.TraineeNominationService.delete(id).subscribe(() => {
          //  this.getTraineeNominations();
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
