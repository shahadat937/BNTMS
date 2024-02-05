import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CodeValue } from '../../models/codevalue';
import { CodeValueService } from '../../service/codevalue.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';

@Component({
  selector: 'app-codevalue',
  templateUrl: './codevalue-list.component.html',
  styleUrls: ['./codevalue-list.component.sass']
})
export class CodeValueListComponent implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: CodeValue[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','code','codeValueType','typeValue','additonalValue','displayCode','remarks','isActive', 'actions'];
  dataSource: MatTableDataSource<CodeValue> = new MatTableDataSource();


   selection = new SelectionModel<CodeValue>(true, []);

  
  constructor(private snackBar: MatSnackBar,private CodeValueService: CodeValueService,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    this.getCodeValues();
  }
 
  getCodeValues() {
    this.isLoading = true;
    this.CodeValueService.getCodeValues(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCodeValues();
 
  }
  
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCodeValues();
  } 

  deleteItem(row) {
    const id = row.codeValueId; 

    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {

      if (result) {
        this.CodeValueService.delete(id).subscribe(() => {
          this.getCodeValues();
          this.snackBar.open('CodeValue Information Deleted Successfully ', '', {
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
