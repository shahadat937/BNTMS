import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BNAExamInstructorAssign} from '../../../exam-management/models/bnaexaminstructorassign';
import {BNAExamInstructorAssignService} from '../../../exam-management/service/bnaexaminstructorassign.service';
import { SelectionModel, DataSource } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { dashboardService } from '../services/dashboard.service'
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-centralexamcourse-list',
  templateUrl: './centralexamcourse-list.component.html',
  styleUrls: ['./centralexamcourse-list.component.sass']
})
export class CentralExamCourseListComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNAExamInstructorAssign[] = [];
  isLoading = false;
  // dataSource:BNAExamInstructorAssign[];
  baseSchoolNameId:any;
  courseNameId:any;
  courseTypeId: number;
  dbType:any;
  title:any;
  schooldash:any;
  status: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[]= ['ser','course','duration','candidate','action'];
dataSource: any;
  
  constructor(private snackBar: MatSnackBar,
    private dashboardService: dashboardService,
    private route: ActivatedRoute,
    private BNAExamInstructorAssignService: BNAExamInstructorAssignService,
    private router: Router,
    private confirmService: ConfirmService,    
    public sharedService: SharedServiceService,

  
  ) {
    super();
  }

  ngOnInit() {
    this.onModuleSelectionChangeGetsubjectList();
   
  }
 
  
 
  onModuleSelectionChangeGetsubjectList(){
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    // this.courseTypeId = Number(this.route.snapshot.paramMap.get('courseTypeId'));
    // this.schooldash=this.route.snapshot.paramMap.get('schooldash');
    // this.dbType=this.route.snapshot.paramMap.get('dbType'); 
    
    if(courseNameId !=null){
      this.title = ""
      this.dashboardService.getSpCentralCourseList(courseNameId).subscribe(res=>{
        this.dataSource=res;  
      }); 
    }
    //this.applyFilter(courseNameId)
  }
  applyFilter(filterValue: string) {
    filterValue = filterValue.trim();
    filterValue = filterValue.toLowerCase().replace(/\s/g,'');
    this.dataSource.filter = filterValue;
    
  }
}
