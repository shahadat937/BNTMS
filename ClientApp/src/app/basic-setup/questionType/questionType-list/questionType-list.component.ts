import { SelectionModel } from '@angular/cdk/collections';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { QuestionType } from '../../models/questionType';
import { QuestionTypeService } from '../../service/questionType.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-questionType-list',
  templateUrl: './questionType-list.component.html',
  styleUrls: ['./questionType-list.component.sass']
})
export class QuestionTypeListComponent implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: QuestionType[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl',/*'questionTypeId',*/ 'question', /*'menuPosition',*/ 'isActive', 'actions'];
  dataSource: MatTableDataSource<QuestionType> = new MatTableDataSource();

  selection = new SelectionModel<QuestionType>(true, []);

  
  constructor(private route: ActivatedRoute,private snackBar: MatSnackBar,private questionTypeService: QuestionTypeService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }
  
  ngOnInit() {
    this.getQuestionTypes();
  }
  
  getQuestionTypes() {
    this.isLoading = true;
    this.questionTypeService.getQuestionTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
    this.getQuestionTypes();
  }

  applyFilter(searchText: any){ 
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getQuestionTypes();
  } 


  deleteItem(row) {
    const id = row.questionTypeId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Question Type Item').subscribe(result => {
      if (result) {
        this.questionTypeService.delete(id).subscribe(() => {
          this.getQuestionTypes();
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
