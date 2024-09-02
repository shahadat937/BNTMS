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

@Component({
  selector: 'app-religation-list',
  templateUrl: './religation-list.component.html',
  styleUrls: ['./religation-list.component.sass']
})
export class ReligationListComponent implements OnInit {
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
  searchText="";
  candidateCount:any;

  
  dataSource = new MatTableDataSource<any>();
  @ViewChild(MatPaginator)
  paginator!: MatPaginator;
  @ViewChild(MatSort)
  matSort!: MatSort;


  displayedColumns: string[] = ['ser', 'name', 'duration', 'action'];

  branchId:any;
  traineeId:any;
  role:any;

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private TraineeNominationService: TraineeNominationService,private CourseDurationService: CourseDurationService,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    
    this.getCourseDurationsByCourseType(this.branchId);
  }
  getCourseDurationsByCourseType(schoolId){
    this.isLoading = true;
    this.CourseDurationService.getCourseListBySchool(schoolId).subscribe(response => {
      this.CourseListBySchool = response; 
      this.dataSource = new MatTableDataSource(response);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.matSort;
    })
  }

  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase();
    this.dataSource.filter = filterValue;
  }
  
}
