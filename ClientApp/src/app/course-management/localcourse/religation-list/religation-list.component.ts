import { scheduled } from 'rxjs';
import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration'
import {CourseDurationService} from '../../service/courseduration.service'
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { TraineeNominationService } from '../../service/traineenomination.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { MatSort } from '@angular/material/sort';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-religation-list',
  templateUrl: './religation-list.component.html',
  styleUrls: ['./religation-list.component.css']
})
export class ReligationListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  @ViewChild("InitialOrderMatSort", { static: true }) InitialOrdersort: MatSort;
  @ViewChild("InitialOrderMatPaginator", { static: true }) InitialOrderpaginator: MatPaginator;
  dataSource = new MatTableDataSource();
   masterData = MasterData;
  loading = false;
  CourseListBySchool: CourseDuration[] = [];
  isLoading = false;
  fileUrl = environment.fileUrl;
  courseTypeId=MasterData.coursetype.LocalCourse;
  groupArrays:{ baseSchoolName: string; courses: any; }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: 100,
    length: 1
  }
  searchTerm="";
  // sear
  candidateCount:any;

  
  // dataSource = new MatTableDataSource<any>();
  // @ViewChild(MatPaginator)
  // paginator!: MatPaginator;
  // @ViewChild(MatSort)
  // matSort!: MatSort;


  displayedColumns: string[] = ['ser', 'name', 'duration', 'action'];

  branchId:any;
  traineeId:any;
  role:any;

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private TraineeNominationService: TraineeNominationService,private CourseDurationService: CourseDurationService,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    
    this.getCourseDurationsByCourseType(this.branchId, this.searchTerm);
  }
  getCourseDurationsByCourseType(schoolId, searchTerm){
    this.isLoading = true;
    this.CourseDurationService.getCourseListBySchool(schoolId, searchTerm).subscribe(response => {
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.sort = this.InitialOrdersort;
      this.dataSource.paginator = this.InitialOrderpaginator;

      this.CourseListBySchool = response; 
      // this.dataSource = new MatTableDataSource(response);
    
    })
  }

  applyFilter(searchTerm: any) {
    // filterValue = filterValue.toLowerCase().replace(/\s/g, "");
    // console.log(filterValue)
    // this.dataSource.filter = filterValue;
    this.searchTerm = searchTerm;
    this.getCourseDurationsByCourseType(this.branchId, this.searchTerm)
  }
  
}
