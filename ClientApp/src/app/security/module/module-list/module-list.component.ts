import { Component, OnInit, ViewChild,ElementRef } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Module } from '../../models/module';
import { ModuleService } from '../../service/module.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-module',
  templateUrl: './module-list.component.html',
  styleUrls: ['./module-list.component.sass']
})
export class ModuleListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Module[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = ['ser','title','moduleName','iconName','icon','isActive', 'actions'];
  dataSource: MatTableDataSource<Module> = new MatTableDataSource();


   selection = new SelectionModel<Module>(true, []);

  
  constructor(private snackBar: MatSnackBar,private ModuleService: ModuleService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { 
    super();
  }

  ngOnInit() {
    this.getModules();

    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });
    
  }
 
  getModules() {
    this.isLoading = true;
    this.ModuleService.getModules(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getModules();
 
  }
  applyFilter(searchText: any){
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1; 
    this.searchText = searchText.toLowerCase().trim();
    this.getModules();
  } 

  deleteItem(row) {
    const id = row.moduleId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.ModuleService.delete(id).subscribe(() => {
          this.getModules();
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
