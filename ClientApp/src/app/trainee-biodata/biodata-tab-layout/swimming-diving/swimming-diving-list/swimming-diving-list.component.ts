import { Component, OnInit,ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SwimmingDiving } from '../../models/SwimmingDiving';
import { SwimmingDivingService } from '../../service/SwimmingDiving.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';

@Component({
  selector: 'app-swimming-diving-list',
  templateUrl: './swimming-diving-list.component.html',
  styleUrls: ['./swimming-diving-list.component.sass']
})
export class SwimmingDivingListComponent implements OnInit,OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: SwimmingDiving[] = [];
  isLoading = false;
  traineeId: string;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser', 'traineeId', 'swimmingDivingTypeId','swimmingLevelId','additionalInformation','isActive', 'actions'];
  dataSource: MatTableDataSource<SwimmingDiving> = new MatTableDataSource();

  SelectionModel = new SelectionModel<SwimmingDiving>(true, []);
  subscription: any;

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private SwimmingDivingService: SwimmingDivingService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.getSwimmingDivings();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getSwimmingDivings() {
    this.isLoading = true;
    

    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.subscription = this.SwimmingDivingService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
     this.dataSource.data=response;
    })
  }
  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSwimmingDivings();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSwimmingDivings();
  } 

  deleteItem(row) {
    const id = row.SwimmingDivingId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This SwimmingDiving Item').subscribe(result => {
      if (result) {
        this.subscription = this.SwimmingDivingService.delete(id).subscribe(() => {
          this.getSwimmingDivings();
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
