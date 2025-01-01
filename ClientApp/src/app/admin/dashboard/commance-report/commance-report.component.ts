import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { dashboardService } from "../services/dashboard.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { ConfirmService } from "../../../core/service/confirm.service";

import { MatSnackBar } from "@angular/material/snack-bar";

import { DateTimeAdapter } from "ng-pick-datetime/date-time/adapter/date-time-adapter.class";
import { AuthService } from "../../../core/service/auth.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-commance-report",
  templateUrl: "./commance-report.component.html",
  styleUrls: ["./commance-report.component.sass"],
})
export class CommanceReportComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  report: any;
  groupArrays: { schoolName: string; report: any }[];
  showHideDiv = false;
  today = new Date();
  selectedDate: any;
  message: string;
  grandTotals = {
    totalOfficer: 0,
    totalMidCount: 0,
    totalCadetCount: 0,
    totalISCount: 0,
    totalSailor: 0,
    totalCivilCount: 0,
    totalForignCount: 0,
  };
  isShow = true;
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private dashboardService: dashboardService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    this.getCommenceReport(this.today);
  }

  // getCommenceReport(date) {
  //   this.message = "";
  //   let formatedDate = this.sharedService.formatDateTime(date);
  //   this.formatSelectedDate(date);
  //   this.dashboardService.getCommanceReportByStartDate(formatedDate).subscribe(res => {
  //     this.report = res;
  //     const groups = this.report.reduce((groups, report) => {
  //       const school = report.schoolName;
  //       if (!groups[school]) {
  //         groups[school] = [];
  //       }
  //       groups[school].push(report);
  //       return groups;
  //     }, {});

  //     this.groupArrays = Object.keys(groups).map((school) => {
  //       return {
  //         schoolName: school,
  //         report: groups[school]
  //       };
  //     });

  //     this.message = this.groupArrays.length? "" : "No Data Found"

  //   });
  // }

  getCommenceReport(date) {
    this.message = "";
    let formatedDate = this.sharedService.formatDateTime(date);
    this.formatSelectedDate(date);
    this.isShow = true;

    this.dashboardService
      .getCommanceReportByStartDate(formatedDate)
      .subscribe((res) => {
        this.report = res;
        // this.isShow = true;

        // Initialize the totals
        let totalOfficer = 0;
        let totalMidCount = 0;
        let totalCadetCount = 0;
        let totalISCount = 0;
        let totalSailor = 0;
        let totalCivilCount = 0;
        let totalForignCount = 0;

        const groups = this.report.reduce((groups, report) => {
          const school = report.schoolName;
          if (!groups[school]) {
            groups[school] = {
              schoolName: school,
              report: [],
              totals: {
                // Initialize totals for each group
                totalOfficer: 0,
                totalMidCount: 0,
                totalCadetCount: 0,
                totalISCount: 0,
                totalSailor: 0,
                totalCivilCount: 0,
                totalForignCount: 0,
              },
            };
          }

          groups[school].report.push(report);

          groups[school].totals.totalOfficer += report.totalOfficer || 0;
          groups[school].totals.totalMidCount += report.totalMidCount || 0;
          groups[school].totals.totalCadetCount += report.totalCadetCount || 0;
          groups[school].totals.totalISCount += report.totalISCount || 0;
          groups[school].totals.totalSailor += report.totalSailor || 0;
          groups[school].totals.totalCivilCount += report.totalCivilCount || 0;
          groups[school].totals.totalForignCount +=
            report.totalForignCount || 0;

          // Calculate the grand totals across all groups
          totalOfficer += report.totalOfficer || 0;
          totalMidCount += report.totalMidCount || 0;
          totalCadetCount += report.totalCadetCount || 0;
          totalISCount += report.totalISCount || 0;
          totalSailor += report.totalSailor || 0;
          totalCivilCount += report.totalCivilCount || 0;
          totalForignCount += report.totalForignCount || 0;

          return groups;
        }, {});

        this.groupArrays = Object.keys(groups).map((school) => {
          return groups[school];
        });

        this.grandTotals = {
          totalOfficer,
          totalMidCount,
          totalCadetCount,
          totalISCount,
          totalSailor,
          totalCivilCount,
          totalForignCount,
        };
        if (!this.groupArrays.length) {
          this.message = "No Data Found on " + this.selectedDate;
          // this.isShow = false;
        }
      });
  }

  onDateChange(event: any): void {
    const date = event.value;
    this.getCommenceReport(date);
  }

  formatSelectedDate(date) {
    if (!(date instanceof Date)) {
      console.error("Invalid date. Ensure 'date' is a Date object.");
      return;
    }

    this.selectedDate = new Intl.DateTimeFormat("en-GB", {
      weekday: "long", // Include the day name
      day: "2-digit",
      month: "short",
      year: "numeric",
    }).format(date);
  }

  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine")?.innerHTML;
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
                .header-text, td{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
                
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3><u>BN TRAINING STATE</u></h3>
          <h3><u>COURSE COMMENCE ON ${this.selectedDate}</u></h3>

         
          </div>
          <br>
          <hr>
          
          ${printContents}
        </body>
      </html>`);
    popupWin.document.close();
  }
}
