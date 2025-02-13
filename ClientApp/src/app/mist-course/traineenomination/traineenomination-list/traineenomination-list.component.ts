import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {TraineeNomination} from '../../models/traineenomination'
import {TraineeNominationService} from '../../service/traineenomination.service'
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-traineenomination-list',
  templateUrl: './traineenomination-list.component.html',
  styleUrls: ['./traineenomination-list.component.sass']
})
export class TraineeNominationListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeNomination[] = [];
  isLoading = false;
  courseDurationId:any;
  courseNameId:number;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','traineeName','courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();


   selection = new SelectionModel<TraineeNomination>(true, []);
  subscription: any;

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TraineeNominationService: TraineeNominationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.subscription = this.TraineeNominationService.findByCourseDuration(+this.courseDurationId).subscribe(
      res => {
          this.courseDurationId= res.courseDurationId, 
          this.courseNameId = res.courseNameId 
      }
    );
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId)
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  // getTraineeNominations() {
  //   this.isLoading = true;
  //   this.TraineeNominationService.getTraineeNominations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

  //     this.dataSource.data = response.items; 
  //     this.paging.length = response.totalItemsCount    
  //     this.isLoading = false;
  //   })
  // }

 getTraineeNominationsByCourseDurationId(courseDurationId) {
    this.isLoading = true;
    this.subscription = this.TraineeNominationService.getTraineeNominationsByCourseDurationId(this.paging.pageIndex, this.paging.pageSize,this.searchText,courseDurationId).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTraineeNominationsByCourseDurationId(this.courseDurationId);
  } 

  deleteItem(row) {
    const id = row.traineeNominationId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.TraineeNominationService.delete(id).subscribe(() => {
          this.getTraineeNominationsByCourseDurationId(this.courseDurationId)
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
