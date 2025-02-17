import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { AuthService } from '../../../core/service/auth.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { dashboardService } from "../services/dashboard.service";
import { Router } from '@angular/router';

@Component({
  selector: 'app-course-report',
  templateUrl: './course-report.component.html',
  styleUrls: ['./course-report.component.sass']
})
export class CourseReportComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  from: any;
  to: any;
  courseReport: any;
  isShow = false;
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
  }


  getCourseReport() {
    this.isShow = false;
    if (this.from && this.to) {
      this.dashboardService.getCourseReport(this.from, this.to).subscribe(res => {
        this.courseReport = res;
        this.sharedService.groupedData = this.sharedService.groupBy(this.courseReport, (report)=> report.base);
        this.isShow = true;
      })
    }
  }

  fromDateChange(event) {
    this.to = this.sharedService.formatDateTime(event.value);
    this.getCourseReport();
  }
  toDateChange(event) {
    this.from = this.sharedService.formatDateTime(event.value);
    this.getCourseReport();
  }

  printSingle() {
    // this.showHideDiv = false;
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
            body {
              width: 99%;
              font-family: Arial, sans-serif;
            }
            label {
              font-weight: 400;
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
            .header-text, td {
              text-align: center;
            }
            .header-text h3 {
              margin: 0;
            }
  
            /* Custom styles for printing */
            @media print {
              /* Prevent page breaks inside rows */
              tr {
                page-break-inside: avoid;
              }
  
              /* Prevent page breaks between Base/Institute and its courses */
              .base-institute-group {
                page-break-inside: avoid; /* Don't break between Base and courses */
              }
  
              /* Allow breaks after the group, but keep rows together */
              .course-row {
                page-break-after: auto; /* Allow row to break, but courses will stay together */
              }
  
              /* Custom styles for better printing */
              body {
                font-size: 12px;
                line-height: 1.4;
              }
  
              /* Add padding to table cells for readability */
              td, th {
                padding: 4px;
              }
  
              /* Ensure content fits on a page */
              .base-institute {
                page-break-before: auto; /* Only break before the Base/Institute name if needed */
              }
            }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <h3><u>Course Report</u></h3>         
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
      </html>`);
    popupWin.document.close();
  }
  
}
