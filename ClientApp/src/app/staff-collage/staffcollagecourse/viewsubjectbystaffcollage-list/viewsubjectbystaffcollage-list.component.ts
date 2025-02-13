import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
//import { BNASubjectName } from '../../../subject-management/models/BNASubjectName';
//import { BNASubjectNameService } from '../../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import{MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNASubjectName } from '../../models/BNASubjectName';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-viewsubjectbystaffcollage',
  templateUrl: './viewsubjectbystaffcollage-list.component.html',
  styleUrls: ['./viewsubjectbystaffcollage-list.component.sass']
})
export class ViewSubjectListByStaffCollageComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  isLoading = false;
  status=1;
  subjectNameList: BNASubjectName[];
  courseNameId:any;
  mainDb:any;
  //SelectedsubjectsBySchoolAndCourse:BNASubjectName[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['paperNo', 'subjectName', 'totalMark', 'passMarkBna'];


   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private BNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    this.courseNameId=this.route.snapshot.paramMap.get('courseNameId'); 
    this.mainDb=this.route.snapshot.paramMap.get('mainDb'); 
    this.onBranchSelectionChange();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  onBranchSelectionChange() {
    this.isLoading = true;
    //this.isShown = true;
    this.subscription = this.BNASubjectNameService.getselectedSubjectNameByBranchId().subscribe(res => {
      this.subjectNameList = res
    });
  }
 
  // getSubjectNames() {
  //   this.isLoading = true;
  //   var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
  //   var courseNameId = this.route.snapshot.paramMap.get('courseNameId'); 
  //   this.BNASubjectNameService.getSelectedsubjectsBySchoolAndCourse(Number(baseSchoolNameId),Number(courseNameId)).subscribe(res=>{
  //     this.SelectedsubjectsBySchoolAndCourse=res;  
  //   });
  // }

  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getBNASubjectNames();
 
  // }
  // applyFilter(searchText: any){ 
  //   this.searchText = searchText;
  //   this.getBNASubjectNames();
  // } 

  // deleteItem(row) {
  //   const id = row.bnaSubjectNameId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This BNASubjectName Item').subscribe(result => {
  //     if (result) {
  //       this.BNASubjectNameService.delete(id).subscribe(() => {
  //         this.getBNASubjectNames();
  //         this.snackBar.open('Information Deleted Successfully ', '', {
  //           duration: 3000,
  //           verticalPosition: 'bottom',
  //           horizontalPosition: 'right',
  //           panelClass: 'snackbar-danger'
  //         });
  //       })
  //     }
  //   })
    
  // }
}
