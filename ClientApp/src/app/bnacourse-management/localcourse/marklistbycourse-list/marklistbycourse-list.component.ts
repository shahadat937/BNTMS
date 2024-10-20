import { Component, OnInit  } from '@angular/core';
import { BNASubjectName } from '../../../subject-management/models/BNASubjectName';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{ MasterData } from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNAExamMarkService } from '../../../exam-management/service/bnaexammark.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-marklistbycourse',
  templateUrl: './marklistbycourse-list.component.html',
  styleUrls: ['./marklistbycourse-list.component.sass']
})
export class MarkListByCourseComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  status=1;
  marklistbycourse:any[];
  dbType:Number = 0;
  dbType1:any;
  dbType2:any;
  courseType:Number;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  
  displayedColumns: string[] ;
  //displayedColumns: string[] = ['ser','pno','name','rankposition','course','courseTitle','subjectName','totalMark','passMarkBna', 'obtaintMark'];
  //displayedColumns: string[] = ['pno','name','position','general Navigation ','instrument','relvel and Fleet Work','rule of The Road'];


   selection = new SelectionModel<BNASubjectName>(true, []);

  
  constructor(private snackBar: MatSnackBar,private BNAExamMarkService: BNAExamMarkService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit() {
   
    this.getTraineeMarkListByDuration();
    
  }
 
  getTraineeMarkListByDuration() {
    this.isLoading = true;
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.dbType = Number(this.route.snapshot.paramMap.get('dbType')); 
    this.dbType1=this.route.snapshot.paramMap.get('dbType1');
    this.dbType2=this.route.snapshot.paramMap.get('dbType2');
    this.courseType = Number(this.route.snapshot.paramMap.get('courseTypeId')); 
    this.BNAExamMarkService.getTraineeMarkListByDuration(courseDurationId).subscribe(res=>{
      this.marklistbycourse=res;  
      this.displayedColumns =[...Object.keys(this.marklistbycourse[0])];
  //displayedColumns: string[] = [...Object.keys(this.marklistbycourse[0])];
   
    
    });
  }

  
}
