import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ExamType } from '../../models/examType';
import { ExamTypeService } from '../../service/examType.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-examType-list',
  templateUrl: './examType-list.component.html',
  styleUrls: ['./examType-list.component.sass']
})
export class ExamTypeListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ExamType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl',/*'examTypeId',*/ 'examTypeName', /*'menuPosition',*/ 'isActive', 'actions'];
  dataSource: MatTableDataSource<ExamType> = new MatTableDataSource();

  selection = new SelectionModel<ExamType>(true, []);

  
  constructor(
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private examTypeService: ExamTypeService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,) {
    super();
  }
  
  ngOnInit() {
    this.getExamTypes();
  }
  
  getExamTypes() {
    this.isLoading = true;
    this.examTypeService.getExamTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getExamTypes();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getExamTypes();
  } 


  deleteItem(row) {
    const id = row.examTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Exam Type Item').subscribe(result => {
      if (result) {
        this.examTypeService.delete(id).subscribe(() => {
          this.getExamTypes();
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
