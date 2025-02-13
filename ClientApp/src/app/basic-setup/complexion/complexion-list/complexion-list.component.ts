import { Component, OnInit,ViewChild,ElementRef} from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { Complexion } from '../../models/complexion';
import { ComplexionService } from '../../service/complexion.service';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: "app-complexion-list",
  templateUrl: "./complexion-list.component.html",
  styleUrls: ["./complexion-list.component.sass"],
})
export class ComplexionListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: Complexion[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = ["ser", "complexionName", "isActive", "actions"];
  dataSource: MatTableDataSource<Complexion> = new MatTableDataSource();

  selection = new SelectionModel<Complexion>(true, []);
  constructor(
    private snackBar: MatSnackBar,
    private complexionService: ComplexionService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }
  ngOnInit() {
    this.getComplexions();
  }

  getComplexions() {
    this.isLoading = true;
    this.complexionService
      .getComplexions(
        this.paging.pageIndex,
        this.paging.pageSize,
        this.searchText
      )
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
    this.getComplexions();
  }
  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getComplexions();
  }

  deleteItem(row) {
    const id = row.complexionId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This  Item")
      .subscribe((result) => {
        if (result) {
          this.complexionService.delete(id).subscribe(() => {
            this.getComplexions();
            this.snackBar.open(
              "Complexion Information Deleted Successfully ",
              "",
              {
                duration: 2000,
                verticalPosition: "bottom",
                horizontalPosition: "right",
                panelClass: "snackbar-danger",
              }
            );
          });
        }
      });
  }
}
