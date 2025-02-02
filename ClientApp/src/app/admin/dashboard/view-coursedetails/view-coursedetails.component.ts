import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { CourseDuration } from "../../../course-management/models/courseduration";
import { CourseDurationService } from "../../../course-management/service/courseduration.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { ConfirmService } from "../../../core/service/confirm.service";
//import{MasterData} from 'src/assets/data/master-data'
import { MasterData } from "../../../../assets/data/master-data";
import { MatSnackBar } from "@angular/material/snack-bar";
import { SharedServiceService } from '../../../shared/shared-service.service';
import { Role } from "../../../core/models/role";
import { AuthService } from "../../../core/service/auth.service";
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';



@Component({
  selector: "app-view-coursedetails",
  templateUrl: "./view-coursedetails.component.html",
  styleUrls: ["./view-coursedetails.component.sass"],
})
export class ViewCourseDetailsComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  userRole = Role;
  ELEMENT_DATA: CourseDuration[] = [];
  isLoading = false;
  courseDurationId: number;
  courseNameId: number;
  courseTypeId: number;
  courseTitle: string;
  courseName: string;
  noOfCandidates: string;
  baseSchoolNameId: number;
  durationFrom: Date;
  durationTo: Date;
  professional: string;
  nbcd: string;
  remark: string;
  schoolDb: any;
  branchId: any;
  traineeId: any;
  role: any;
  showHideDiv = false;
  baseSchoolName: any;
  nbcdDurationFrom: any;
  nbcdDurationTo: any;
  // instituteName: string;
  // groupId: number;
  // group: string;
  // passingYear: string;
  // result: string;
  // outOfResult: string;
  // courseDuration: string;
  // status:number;
  // additionaInformation: string;
  // examTypeValues:SelectedModel[];
  // groupValues:SelectedModel[];
  // boardValues:SelectedModel[];

  constructor(
    private route: ActivatedRoute,
    private authService: AuthService,
    private snackBar: MatSnackBar,
    private CourseDurationService: CourseDurationService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get("courseDurationId")??0;
    this.schoolDb = Number(this.route.snapshot.paramMap.get("schoolDb"));
    this.courseTypeId = Number(
      this.route.snapshot.paramMap.get("courseTypeId")
    );
    this.CourseDurationService.find(+id).subscribe((res) => {
      (this.courseDurationId = res.courseDurationId),
        (this.courseNameId = res.courseNameId),
        (this.courseName = res.courseName),
        (this.courseTitle = res.courseTitle),
        (this.courseName = res.courseName),
        (this.noOfCandidates = res.noOfCandidates),
        (this.baseSchoolNameId = res.baseSchoolNameId),
        (this.durationFrom = res.durationFrom),
        (this.durationTo = res.durationTo),
        (this.professional = res.professional),
        (this.nbcd = res.nbcd),
        (this.remark = res.remark),
        (this.baseSchoolName = res.baseSchoolName),
        (this.nbcdDurationFrom = res.nbcdDurationFrom),
        (this.nbcdDurationTo = res.nbcdDurationTo);
      // this.groupId = res.groupId,
      // this.passingYear = res.passingYear,
      // this.result = res.result,
      // this.outOfResult = res.outOfResult,
      // this.courseDuration = res.courseDuration,
      // this.status = res.status,
      // this.additionaInformation = res.additionaInformation
    });
    // this.getExamType();
    // this.getBoard();
    // this.getGroup();
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
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
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
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Name of Course:- ${this.courseName}</h3>
          <h3>Course Details</h3>
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}
