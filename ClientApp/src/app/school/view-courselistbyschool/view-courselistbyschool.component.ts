import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { ActivatedRoute, Router } from "@angular/router";
import { ConfirmService } from "../../../../src/app/core/service/confirm.service";
import { MasterData } from "../../../../src/assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DatePipe } from "@angular/common";
import { SchoolDashboardService } from "../services/SchoolDashboard.service";
import { environment } from "../../../../src/environments/environment";
import { AuthService } from "../../../../src/app/core/service/auth.service";
import { Role } from "../../../../src/app/core/models/role";
import { MatSort } from "@angular/material/sort";
import { SharedServiceService } from "../../../../src/app/shared/shared-service.service";

@Component({
  selector: "app-view-courselistbyschool.component",
  templateUrl: "./view-courselistbyschool.component.html",
  styleUrls: ["./view-courselistbyschool.component.sass"],
})
export class ViewCourseListBySchoolComponent implements OnInit, OnDestroy {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
  masterData = MasterData;
  loading = false;
  userRole = Role;
  isLoading = false;
  destination: string;
  MaterialByCourse: any;
  CourseNamesList: any;
  schoolId: any;
  branchId: any;
  traineeId: any;
  role: any;
  showHideDiv= false;
  fileUrl: any = environment.fileUrl;

  groupArrays: { schoolname: string; courses: any }[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedCourseNamesColumns: string[] = ["ser", "course", "actions"];
  subscription: any;

  constructor(
    private datepipe: DatePipe,
    private authService: AuthService,
    private schoolDashboardService: SchoolDashboardService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {}

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    // this.branchId =  this.authService.currentUserValue.branchId.trim();
    this.branchId = this.authService.currentUserValue.branchId ? this.authService.currentUserValue.branchId.trim() : "";

    this.schoolId = this.route.snapshot.paramMap.get("baseSchoolNameId");
    if (this.role == this.userRole.CO || this.role == this.userRole.TrainingOffice || this.role == this.userRole.TC || this.role == this.userRole.TCO) {
      this.getCourseListByBase(this.branchId);
    } else {
      this.getCourseListBySchool(this.schoolId);
    }
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  getCourseListBySchool(schoolId) {
    this.schoolDashboardService
      .getCourseNamesBySchool(schoolId, this.searchText)
      .subscribe((response) => {
        this.CourseNamesList = response;
        // const groups = this.CourseNamesList.reduce((groups, courses) => {
        //   const schoolname = courses.schoolname;
        //   if (!groups[schoolname]) {
        //     groups[schoolname] = [];
        //   }
        //   groups[schoolname].push(courses);
        //   return groups;
        // }, {});

        // Edit: to add it in the array format instead
        // this.groupArrays = Object.keys(groups).map((schoolname) => {
        //   return {
        //     schoolname,
        //     courses: groups[schoolname],
        //   };
        // });
        this.sharedService.groupedData = this.sharedService.groupBy(
          this.CourseNamesList,
          (school)=> school.schoolname
        )
      });
     

  }
  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }

  print(){ 
     
    let printContents, popupWin;
    printContents = document.getElementById('print-routine')?.innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
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
                    .tbl-by-group.db-li-s-in tr .btn-tbl-view {
                      display:none;
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
          
          </div>
          <br>
          <hr>
          ${printContents}
          <span class="header-warning bottom">CONFIDENTIAL</span>
        </body>
      </html>`
    );
    popupWin.document.close();

}
  getCourseListByBase(schoolId) {
   this.subscription = this.schoolDashboardService.getCourseNamesByBase(schoolId, this.searchText).subscribe((response) => {
      this.dataSource = new MatTableDataSource(response);
      
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;
      
      
        this.CourseNamesList = response;
        // this.CourseNamesList = new MatTableDataSource(response)
        // const groups = this.CourseNamesList.reduce((groups, courses) => {
        //   const schoolname = courses.schoolname;
        //   if (!groups[schoolname]) {
        //     groups[schoolname] = [];
        //   }
        //   groups[schoolname].push(courses);
        //   return groups;
        // }, {});

        // // Edit: to add it in the array format instead
        // this.groupArrays = Object.keys(groups).map((schoolname) => {
        //   return {
        //     schoolname,
        //     courses: groups[schoolname],
        //   };
        // });
        this.sharedService.groupedData = this.sharedService.groupBy(
          this.CourseNamesList,
          (school)=> school.schoolname
        )
      });

  }
 
  applyFilter(searchText: string) {
   this.searchText = searchText;
   if (this.role == this.userRole.CO || this.role == this.userRole.TrainingOffice || this.role == this.userRole.TC || this.role == this.userRole.TCO) {
    this.getCourseListByBase(this.branchId);
  } else {
    this.getCourseListBySchool(this.schoolId);
  }
  }
}
