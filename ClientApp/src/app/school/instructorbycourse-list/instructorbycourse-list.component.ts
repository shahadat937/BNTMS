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
import { MatSort } from '@angular/material/sort';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-instructorbycourse-list',
  templateUrl: './instructorbycourse-list.component.html',
  styleUrls: ['./instructorbycourse-list.component.sass']
})
export class InstructorByCourseListComponent implements OnInit, OnDestroy {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
   masterData = MasterData;
  loading = false;
  isLoading = false;
  destination:string;
  courseName:any;
  InstructorByCourse:any;
  schoolId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedRoutineColumns: string[] = ['ser', 'subject', 'name'];
  subscription: any;
// dataSource: any;

  constructor(private datepipe: DatePipe,private schoolDashboardService: SchoolDashboardService,private route: ActivatedRoute,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    //this.getTraineeNominations();
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.subscription = this.schoolDashboardService.getInstructorDetailByCourse(courseNameId,this.schoolId,courseDurationId).subscribe(response => {    
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;     
      this.courseName = response[0].course+'-'+response[0].courseTitle;
      this.InstructorByCourse=response;
    })
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
