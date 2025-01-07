

import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { dashboardService } from "../services/dashboard.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { Role } from "../../../core/models/role";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
import jsPDF from 'jspdf';
import html2canvas from 'html2canvas'; 
import * as html2pdf from 'html2pdf.js';
import 'jspdf-autotable';

@Component({
  selector: "app-school-list",
  templateUrl: "./school-list.component.html",
  styleUrls: ["./school-list.component.scss"],
})
export class SchoolListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit {
  masterData = MasterData;
  loading = false;
  userRole = Role;
  schoolList: any;
  isLoading = false;
  showHideDiv = false;
  @ViewChild('contentToConvert', { static: true }) contentToConvert!: ElementRef;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  branchId: any;
  traineeId: any;
  role: any;
  totalCount: any;

  groupArrays: { baseName: string; schools: any }[];

  displayedColumns: string[] = ["ser", "schoolName", "courseCount"];

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

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    this.getBnaClassTests();
  }

  getBnaClassTests() {
    this.isLoading = true;
    this.dashboardService.getSpCourseCountBySchool().subscribe((response) => {
      this.schoolList = response;

      // this gives an object with dates as keys
      const groups = this.schoolList.reduce((groups, schools) => {
        const baseName = schools.baseName;
        if (!groups[baseName]) {
          groups[baseName] = [];
        }
        groups[baseName].push(schools);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((baseName) => {
        return {
          baseName,
          schools: groups[baseName],
        };
      });

      this.getCourseTotalCountInfo();

      this.isLoading = false;
    });
  }

  getCourseTotalCountInfo() {
    this.dashboardService.getSpCourseTotalCountBySchool().subscribe((res) => {
      this.totalCount = res;
    });
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    // this.getCourseDurationsByCourseType();
    this.getBnaClassTests();
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  print() {
    let today = new Date();

    const formatedDate = new Intl.DateTimeFormat("en-Gb", {
      day: "2-digit",
      month: "short",
      year: "numeric",
    }).format(today);

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
          <h3><u>Date : ${formatedDate}</u></h3>

         
          </div>
          <br>
          <hr>
          
          ${printContents}
        </body>
      </html>`);
    popupWin.document.close();
  }
  downloadPDF(): void {
    const element = document.getElementById('contentToConvert');
    if (element) {
      const options = {
        margin: [30, 10, 30, 10], // Adjust margins if needed
        filename: 'download.pdf',
        image: { type: 'jpeg', quality: 0.98 }, // Use JPEG for better rendering
        html2canvas: { 
          scale: 2, // Increase scale for better resolution
          useCORS: true, // Allow cross-origin images if any
          scrollX: 0, 
          scrollY: 0 
        },
        jsPDF: { 
          unit: 'mm', 
          format: 'a4', 
          orientation: 'landscape' // Use landscape for wide tables
        },
      };
  
      html2pdf().set(options).from(element).save();
    }
  }


// downloadPDF(): void {
//   const element = document.getElementById('contentToConvert');
//   if (element) {
//     const pdf = new jsPDF({
//       orientation: 'landscape',
//       unit: 'mm',
//       format: 'a4',
//     });

//     const tables = element.querySelectorAll('table');
//     tables.forEach((table, index) => {
//       const rows = Array.from(table.rows).map(row => 
//         Array.from(row.cells).map(cell => cell.innerText)
//       );

//       const columnWidths = [30, 50, 40, 60]; // Adjust widths to fit your table columns

//       pdf.autoTable({
//         head: [rows[0]],  // First row as header
//         body: rows.slice(1),  // Body of the table
//         startY: index === 0 ? 20 : pdf.lastAutoTable.finalY + 10,  // Adjust vertical position
//         columnStyles: {
//           0: { cellWidth: columnWidths[0] },
//           1: { cellWidth: columnWidths[1] },
//           2: { cellWidth: columnWidths[2] },
//           3: { cellWidth: columnWidths[3] },
//         },
//         theme: 'grid',  // Ensures a grid-style border for the table
//       });
//     });

//     pdf.save('download-table.pdf');
//   }
// }

  

  // pageChanged(event: PageEvent) {

  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getBnaClassTests();

  // }
  // applyFilter(searchText: any){
  //   this.searchText = searchText;
  //   this.getBnaClassTests();
  // }

  // deleteItem(row) {
  //   const id = row.bnaClassTestId;
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
  //     if (result) {
  //       this.BnaClassTestService.delete(id).subscribe(() => {
  //         this.getBnaClassTests();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 3000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })

  // }
}
