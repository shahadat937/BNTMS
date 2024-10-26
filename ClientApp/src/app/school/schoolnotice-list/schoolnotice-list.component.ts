import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { SchoolDashboardService } from '../services/SchoolDashboard.service';
import { environment } from 'src/environments/environment';
import { MatSort } from '@angular/material/sort';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-schoolnotice-list.component',
  templateUrl: './schoolnotice-list.component.html',
  styleUrls: ['./schoolnotice-list.component.sass']
})
export class SchoolNoticeListComponent implements OnInit, OnDestroy {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  MaterialByCourse:any;
  NoticeForSchoolDashboard:any;
  schoolId:any;
  fileUrl:any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedReadingMaterialColumns: string[] = ['ser','course','noticeDetails','newStatus'];
  subscription: any;

  constructor(private datepipe: DatePipe,private schoolDashboardService: SchoolDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.getNoticeBySchoolId(this.schoolId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getNoticeBySchoolId(schoolId){
    let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.subscription = this.schoolDashboardService.getNoticeBySchoolId(schoolId,currentDateTime).subscribe(response => {   
      this.NoticeForSchoolDashboard=response;
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;
    })
  }
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase().replace(/\s/g,'');
    this.dataSource.filter = filterValue;
  }
}
