import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { TraineeMembership } from '../../models/TraineeMembership';
import { TraineeMembershipService } from '../../service/TraineeMembership.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import{MasterData} from 'src/assets/data/master-data'
import{MasterData} from '../../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-trainee-membership',
  templateUrl: './trainee-membership-list.component.html',
  styleUrls: ['./trainee-membership-list.component.sass']
})
export class TraineeMembershipListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeMembership[] = [];
  isLoading = false;
  traineeId: string;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  // searchText="";

  displayedColumns: string[] = ['ser', 'orgName','membershipType','briefAddress','appointment','durationFrom','durationTo','actions'];
  dataSource: MatTableDataSource<TraineeMembership> = new MatTableDataSource();

  selection = new SelectionModel<TraineeMembership>(true, []);

  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar, private TraineeMembershipService: TraineeMembershipService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  ngOnInit() {
    this.getTraineeMemberships();
  }
 
  getTraineeMemberships() {
    this.isLoading = true;
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');

    this.TraineeMembershipService.getdatabytraineeid(+this.traineeId).subscribe(response => {     
     this.dataSource.data=response;
    })
  }
  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getTraineeMemberships();
 
  // }
  // applyFilter(searchText: any){ 
  //   this.searchText = searchText;
  //   this.getTraineeMemberships();
  // } 

  deleteItem(row) {
    const id = row.traineeMembershipId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.TraineeMembershipService.delete(id).subscribe(() => {
          this.getTraineeMemberships();
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
