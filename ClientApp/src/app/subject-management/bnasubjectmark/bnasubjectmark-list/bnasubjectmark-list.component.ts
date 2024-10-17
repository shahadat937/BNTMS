import { Component, OnInit, ViewChild,ElementRef, OnDestroy } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SubjectMark } from '../../models/SubjectMark';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
 

@Component({
  selector: 'app-bnasubjectmark',
  templateUrl: './bnasubjectmark-list.component.html',
  styleUrls: ['./bnasubjectmark-list.component.sass']
})
export class BnaSubjectMarkListComponent implements OnInit, OnDestroy {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: SubjectMark[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'ser', 'baseSchoolName', 'courseName',  'bnaSubjectName',  'courseModule', 'markType', 'remarks', 'isActive', 'actions'];
  dataSource: MatTableDataSource<SubjectMark> = new MatTableDataSource();

  selection = new SelectionModel<SubjectMark>(true, []);
  subscription: any;
  
  constructor(private snackBar: MatSnackBar,private SubjectMarkService: SubjectMarkService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  
  ngOnInit() {
    this.getSubjectMarks();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getSubjectMarks() {
    this.isLoading = true;
    this.subscription = this.SubjectMarkService.getSubjectMarks(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getSubjectMarks();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSubjectMarks();
  } 

  deleteItem(row) {
    const id = row.subjectMarkId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.SubjectMarkService.delete(id).subscribe(() => {
          this.getSubjectMarks();
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
