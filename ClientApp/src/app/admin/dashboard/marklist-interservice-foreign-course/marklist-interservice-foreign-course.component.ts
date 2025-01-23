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
  selector: 'app-marklist-interservice-foreign-course',
  templateUrl: './marklist-interservice-foreign-course.component.html',
  styleUrls: ['./marklist-interservice-foreign-course.component.sass']
})
export class MarklistInterserviceForeignCourseComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeNomination[] = [];
  isLoading = false;
  courseDuration: any;
  courseNameId: number;
  showHideDiv = false;
  nominatedPercentageList: any;
  courseName : string;
  organizationName : string;
  isShow : boolean = false;
  warningMessage = "";
  countryName ;

  displayedColumns: string[] = ['ser', 'traineeName', 'attandanceParcentage'];
  displayedInterServiceColumns: string[] = ['ser', 'traineeName', 'status', 'doc', 'attendance', 'remark'];

  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


  selection = new SelectionModel<TraineeNomination>(true, []);


  constructor(
    private route: ActivatedRoute,
    private TraineeNominationService: TraineeNominationService,
    public sharedService: SharedServiceService,
  ) {
    super();
  }

  ngOnInit() {

    this.courseDuration = this.route.snapshot.paramMap.get('courseDurationId');
    this.loadData();
    
  }

  loadData() {

  
    console.log(this.courseDuration);
    this.TraineeNominationService.getMarkListByCourseDurationId(this.courseDuration).subscribe(res=>{
     
      if(!res?.length){
        this.warningMessage = "No Trainee Information Found";
        this.isShow = false;
        
      }
      else{
        this.nominatedPercentageList = res;
        this.courseName = res[0]?.course
         this.organizationName = res[0]?.orgName;
         this.countryName = res[0]?.countryName;
         this.warningMessage = "";
         this.isShow = true;
      }
      
    })


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
                  a {
            color: black; /* Ensure anchor text is black */
            text-decoration: none; /* Remove underline from anchor tags */
          }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <span class="header-warning top">CONFIDENTIAL</span>
          <h3>NOMINAL ROLL</h3>
          <h3>Course :  ${this.courseName}</h3>
          <h3> ${this.organizationName?? this.countryName ?? "-"}</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          <span class="header-warning bottom">CONFIDENTIAL</span>
        </body>
      </html>`);
    popupWin.document.close();
  }



}
