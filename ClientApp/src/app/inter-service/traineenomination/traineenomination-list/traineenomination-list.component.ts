import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {TraineeNomination} from '../../models/traineenomination'
import {TraineeNominationService} from '../../service/traineenomination.service'
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-traineenomination-list',
  templateUrl: './traineenomination-list.component.html',
  styleUrls: ['./traineenomination-list.component.sass']
})
export class TraineeNominationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeNomination[] = [];
  isLoading = false;
  courseDurationId:number;
  courseNameId:number;
  courseName: string;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','traineeName','courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


   selection = new SelectionModel<TraineeNomination>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TraineeNominationService: TraineeNominationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.courseDurationId = Number(this.route.snapshot.paramMap.get('courseDurationId')); 
    this.TraineeNominationService.findByCourseDuration(this.courseDurationId ).subscribe(
      res => {
          this.courseDurationId= res[0].courseDurationId, 
          this.courseNameId = res[0].courseNameId 
      }
    );
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId )
  }
 getTraineeNominationsByCourseDurationId(courseDurationId) {
    this.isLoading = true;
    this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize,this.searchText,courseDurationId).subscribe(response => {
   
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      if(response.items.length){
        this.courseName = response.items[0].courseName
      }
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
  } 

  printSingle() {
    // this.showHideDiv = false;
    this.print();
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print")?.innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body { width: 99%; }
          label { font-weight: 400; font-size: 13px; padding: 2px; margin-bottom: 5px; }
          table, td, th { border: 1px solid silver; padding: 5px; }
          table td { font-size: 13px; }
          table th { font-size: 13px; }
          table { border-collapse: collapse; width: 98%; }
          th { height: 26px; }
          .header-text { text-align: center; }
          .header-text h3 { margin: 0; }
          a { text-decoration: none; color: black; }
          
          /* Hide Action column */
          th:nth-child(4), td:nth-child(4) {
            display: none;
          }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <h3>Trainee Nomination (Interservice Course)</h3>
            <h3>${this.courseName}}</h3>
          </div>
          <br>
          <hr>
          ${printContents}
        </body>
      </html>`);
    popupWin.document.close();
  }

  deleteItem(row) {
    const id = row.traineeNominationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.TraineeNominationService.delete(id).subscribe(() => {
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
          this.getTraineeNominationsByCourseDurationId(this.courseDurationId )
        })

      }
    })
    
  }
}
