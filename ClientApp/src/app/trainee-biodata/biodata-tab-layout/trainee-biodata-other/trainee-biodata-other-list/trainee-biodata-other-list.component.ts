import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TraineeBIODataOther  } from '../../models/TraineeBIODataOther';
import { TraineeBIODataOtherService } from '../../service/TraineeBIODataOther.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-trainee-biodata-other',
  templateUrl: './trainee-biodata-other-list.component.html',
  styleUrls: ['./trainee-biodata-other-list.component.sass']
})
export class TraineeBIODataOtherListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeBIODataOther [] = [];
  isLoading = false;
  traineeId: string;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize, 
    length: 1
  }
  // searchText="";


  displayedColumns: string[] = ['ser', 'age', 'commissionDate', 'presentAddress', 'actions'];


  dataSource: MatTableDataSource<TraineeBIODataOther> = new MatTableDataSource(); 
  selection = new SelectionModel<TraineeBIODataOther>(true, []);
  subscription: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private TraineeBIODataOtherService: TraineeBIODataOtherService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.getTraineeBIODataOthers();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getTraineeBIODataOthers() {
    this.isLoading = true;
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');

    this.subscription = this.TraineeBIODataOtherService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
     
     this.dataSource.data=response;
    })
  }
  
  

  deleteItem(row) {
    const id = row.traineeBioDataOtherId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.TraineeBIODataOtherService.delete(id).subscribe(() => {
          this.getTraineeBIODataOthers();
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
