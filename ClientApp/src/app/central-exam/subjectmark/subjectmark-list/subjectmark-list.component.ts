import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SubjectMark } from '../../models/SubjectMark';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from '../../../../assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
 

@Component({
  selector: 'app-subjectmark',
  templateUrl: './subjectmark-list.component.html',
  styleUrls: ['./subjectmark-list.component.sass']
})
export class SubjectMarkListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

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
  
  constructor(private snackBar: MatSnackBar,private SubjectMarkService: SubjectMarkService,private router: Router,private confirmService: ConfirmService) {
    super();
  }
  
  ngOnInit() {
    this.getSubjectMarks();
  }
 
  getSubjectMarks() {
    this.isLoading = true;
    this.SubjectMarkService.getSubjectMarks(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
      
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
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
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
