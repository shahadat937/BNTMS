import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { BNAPromotionStatus } from "../../models/BNAPromotionStatus";
import { BNAPromotionStatusService } from "../../service/BNAPromotionStatus.service";
import { SelectionModel } from "@angular/cdk/collections";
import { Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-BNAPromotionStatus",
  templateUrl: "./bnapromotionstatus-list.component.html",
  styleUrls: ["./bnapromotionstatus-list.component.sass"],
})
export class BNAPromotionStatusListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAPromotionStatus[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "promotionStatusName",
    "isActive",
    "actions",
  ];
  dataSource: MatTableDataSource<BNAPromotionStatus> = new MatTableDataSource();

  selection = new SelectionModel<BNAPromotionStatus>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private BNAPromotionStatusService: BNAPromotionStatusService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getBNAPromotionStatuss();
  }

  getBNAPromotionStatuss() {
    this.isLoading = true;
    this.BNAPromotionStatusService.getBNAPromotionStatuss(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getBNAPromotionStatuss();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getBNAPromotionStatuss();
  }

  deleteItem(row) {
    const id = row.bnaPromotionStatusId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This  Item")
      .subscribe((result) => {
        if (result) {
          this.BNAPromotionStatusService.delete(id).subscribe(() => {
            this.getBNAPromotionStatuss();
            this.snackBar.open("Information Deleted Successfully ", "", {
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
