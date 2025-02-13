import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { KindOfSubject } from '../../models/KindOfSubject';
import { KindOfSubjectService } from '../../service/KindOfSubject.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { MasterData} from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-kindofsubject',
  templateUrl: './kindofsubject-list.component.html',
  styleUrls: ['./kindofsubject-list.component.sass']
})
export class KindOfSubjectListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: KindOfSubject[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','kindOfSubjectName','isActive', 'actions'];
  dataSource: MatTableDataSource<KindOfSubject> = new MatTableDataSource();


   selection = new SelectionModel<KindOfSubject>(true, []);

  
  constructor(
    private snackBar: MatSnackBar,
    private KindOfSubjectService: KindOfSubjectService,
    private router: Router,
    private confirmService: ConfirmService, 
    public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.getKindOfSubjects();
    
  }
 
  getKindOfSubjects() {
    this.isLoading = true;
    this.KindOfSubjectService.getKindOfSubjects(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getKindOfSubjects();
 
  }
  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getKindOfSubjects();
  } 

  deleteItem(row) {
    const id = row.kindOfSubjectId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.KindOfSubjectService.delete(id).subscribe(() => {
          this.getKindOfSubjects();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })
    
  }
}
