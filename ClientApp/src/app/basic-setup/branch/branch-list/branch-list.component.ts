import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Branch } from '../../models/branch';
import { BranchService } from '../../service/branch.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: "app-branch",
  templateUrl: "./branch-list.component.html",
  styleUrls: ["./branch-list.component.sass"],
})
export class BranchListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Branch[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;

  displayedColumns: string[] = [
    "ser",
    "branchName",
    "shortName",
    "isActive",
    "actions",
  ];
  dataSource: MatTableDataSource<Branch> = new MatTableDataSource();

  selection = new SelectionModel<Branch>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private branchService: BranchService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getBranchs();
    this.searchSubscription = this.searchSubject
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe((searchText) => {
        this.applyFilter(searchText);
      });
  }
  onSearchChange(searchValue: string) {
    this.searchSubject.next(searchValue);
  }

  getBranchs() {
    this.isLoading = true;
    this.branchService
      .getBranchs(this.paging.pageIndex, this.paging.pageSize, this.searchText)
      .subscribe((response) => {
        this.dataSource.data = response.items;
        this.paging.length = response.totalItemsCount;
        this.isLoading = false;
      });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getBranchs();
  }
  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText.toLowerCase().trim();
    this.getBranchs();
  }

  deleteItem(row) {
    const id = row.branchId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This  Item")
      .subscribe((result) => {
        if (result) {
          this.branchService.delete(id).subscribe(() => {
            this.getBranchs();

            this.snackBar.open("Branch Information Deleted Successfully ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }
}
