import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MilitaryTraining } from '../../models/MilitaryTraining';
import { MilitaryTrainingService } from '../../service/MilitaryTraining.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-military-training-list',
  templateUrl: './military-training-list.component.html',
  styleUrls: ['./military-training-list.component.sass']
})
export class MilitaryTrainingListComponent implements OnInit, OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: MilitaryTraining[] = [];
  isLoading = false;
  traineeId: string;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser', 'dateAttended','locationOfTrg','detailsOfCourse','remarks','actions'];
  dataSource: MatTableDataSource<MilitaryTraining> = new MatTableDataSource();

  SelectionModel = new SelectionModel<MilitaryTraining>(true, []);
  subscription: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private MilitaryTrainingService: MilitaryTrainingService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.getMilitaryTrainings();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getMilitaryTrainings() {
    this.isLoading = true;
    this.traineeId= this.route.snapshot.paramMap.get('traineeId');
    this.subscription = this.MilitaryTrainingService.getMilitaryTrainingByTraineeId(+this.traineeId).subscribe(response => {     
     this.dataSource.data=response;
    })
  }
  
  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getMilitaryTrainings();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getMilitaryTrainings();
  } 

  deleteItem(row) {
    const id = row.militaryTrainingId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.MilitaryTrainingService.delete(id).subscribe(() => {
          this.getMilitaryTrainings();
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
