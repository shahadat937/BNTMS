import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SubjectClassification } from '../../models/SubjectClassification';
import { SubjectClassificationService } from '../../service/SubjectClassification.service';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-subjectclassification',
  templateUrl: './subjectclassification-list.component.html',
  styleUrls: ['./subjectclassification-list.component.sass']
})
export class SubjectClassificationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: SubjectClassification[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'subjectClassificationName', 'isActive', 'actions'];
  dataSource: MatTableDataSource<SubjectClassification> = new MatTableDataSource();
  
  constructor(private snackBar: MatSnackBar,private SubjectClassificationService: SubjectClassificationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }
  
  ngOnInit() {
    this.getSubjectClassifications();
  }
 
  getSubjectClassifications() {
    this.isLoading = true;
    this.SubjectClassificationService.getSubjectClassifications(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSubjectClassifications();
  }
  
  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getSubjectClassifications();
  }

  deleteItem(row) {
    const id = row.subjectClassificationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This SubjectClassification Item').subscribe(result => {
      if (result) {
        this.SubjectClassificationService.delete(id).subscribe(() => {
          this.getSubjectClassifications();
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
