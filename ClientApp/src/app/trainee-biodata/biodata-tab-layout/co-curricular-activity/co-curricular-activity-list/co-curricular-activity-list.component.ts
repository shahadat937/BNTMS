import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CoCurricularActivity } from '../../models/CoCurricularActivity';
import { CoCurricularActivityService } from '../../service/CoCurricularActivity.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-co-curricular-activity-list',
  templateUrl: './co-curricular-activity-list.component.html',
  styleUrls: ['./co-curricular-activity-list.component.sass']
})
export class CoCurricularActivityListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CoCurricularActivity[];
  isLoading = false;
  traineeId: string;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  // searchText="";

  displayedColumns: string[] = ['ser', 'coCurricularActivityType', 'participation', 'achievement', 'actions'];
  //public dataSource = new MatTableDataSource<CoCurricularActivity>();
  dataSource: MatTableDataSource<CoCurricularActivity> = new MatTableDataSource();

  SelectionModel = new SelectionModel<CoCurricularActivity>(true, []);
  subscription: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private CoCurricularActivityService: CoCurricularActivityService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.getCoCurricularActivitys();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getCoCurricularActivitys() {
    this.isLoading = true;
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.subscription = this.CoCurricularActivityService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
     this.dataSource.data=response;
    })
  }

  deleteItem(row) {
    const id = row.coCurricularActivityId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete Item').subscribe(result => {
      if (result) {
        this.CoCurricularActivityService.delete(id).subscribe(() => {
          this.getCoCurricularActivitys();
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
