import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-viewsubjectbymodule',
  templateUrl: './viewsubjectbymodule-list.component.html',
  styleUrls: ['./viewsubjectbymodule-list.component.sass']
})
export class ViewSubjectListByModuleComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  courseNameId:any;
  status=1;
  SelectedsubjectsBySchoolAndCourse:BNASubjectName[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','subjectName','subjectTypeName','totalPeriod','totalMark','passMarkBNA','actions'];


   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private BNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.getSubjectNames();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
 
  getSubjectNames() {
    this.isLoading = true;
    var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    this.courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
    var courseModuleId = this.route.snapshot.paramMap.get('courseModuleId'); 
    this.subscription = this.BNASubjectNameService.getbnaSubjectListForStudentDashboard(baseSchoolNameId,this.courseNameId,courseModuleId).subscribe(res=>{
      this.SelectedsubjectsBySchoolAndCourse=res;  
    });
  }

}
