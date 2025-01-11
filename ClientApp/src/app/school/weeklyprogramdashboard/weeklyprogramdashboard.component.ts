import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DatePipe } from '@angular/common';
import { SchoolDashboardService } from '../services/SchoolDashboard.service';
import { environment } from '../../../../src/environments/environment';
import { MatSort } from '@angular/material/sort';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-weeklyprogramdashboard.component',
  templateUrl: './weeklyprogramdashboard.component.html',
  styleUrls: ['./weeklyprogramdashboard.component.sass']
})

export class WeeklyProgramDashboardComponent implements OnInit, OnDestroy {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  MaterialByCourse:any;
  ReadIngMaterialList:any;
  RoutineByCourse:any;
  schoolId:any;
  fileUrl:any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  displayedRoutineCountColumns: string[] = ['ser','course','courseDuration','actions'];
  subscription: any;

  constructor(private datepipe: DatePipe,private schoolDashboardService: SchoolDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    //this.getTraineeNominations();
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    // this.schoolDashboardService.getReadingMetarialByCourse(courseNameId,schoolId).subscribe(response => {         
    //   this.MaterialByCourse=response;
    // })
    this.getRoutineInfoByCourse(this.schoolId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getRoutineInfoByCourse(schoolId){
    this.subscription = this.schoolDashboardService.getRoutineByCourse(schoolId).subscribe(response => {     
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;    
      this.RoutineByCourse=response;
    })
  }
  applyFilter(filterValue: string) {
    filterValue = filterValue.toLowerCase().replace(/\s/g,'');
    this.dataSource.filter = filterValue;
  }
}
