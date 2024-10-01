import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {ClassRoutine} from '../../models/classroutine'
import {ClassRoutineService} from '../../service/classroutine.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';

@Component({
  selector: 'app-classroutine-list',
  templateUrl: './classroutine-list.component.html',
  styleUrls: ['./classroutine-list.component.sass']
})
export class ClassRoutineListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ClassRoutine[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','baseSchoolName', 'courseName',   'courseModule', 'classPeriod','bnaSubjectName', 'actions'];
  dataSource: MatTableDataSource<ClassRoutine> = new MatTableDataSource();


   selection = new SelectionModel<ClassRoutine>(true, []);

  
  constructor(private snackBar: MatSnackBar,private ClassRoutineService: ClassRoutineService,private router: Router,private confirmService: ConfirmService) {
    super();
  }

  ngOnInit() {
    this.getClassRoutines();
    
  }
 
  getClassRoutines() {
    this.isLoading = true;
    this.ClassRoutineService.getClassRoutines(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getClassRoutines();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getClassRoutines();
  } 

  deleteItem(row) {
    const id = row.classRoutineId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.ClassRoutineService.delete(id).subscribe(() => {
          this.getClassRoutines();
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
