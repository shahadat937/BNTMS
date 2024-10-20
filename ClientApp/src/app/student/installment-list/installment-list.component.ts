import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BNASubjectName } from '../../subject-management/models/BNASubjectName';
import { BNASubjectNameService } from '../../subject-management/service/BNASubjectName.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-installment',
  templateUrl: './installment-list.component.html',
  styleUrls: ['./installment-list.component.sass']
})
export class InstallmentListComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  isLoading = false;
  ELEMENT_DATA: BNASubjectName[] = [];
  ReadingMaterialBySchoolAndCourse:any;
  status=1;
  traineeRemittanceNotification:any;

  groupArrays:{ readingMaterialTitle: string; courses: any; }[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedForeignRemittanceColumns: string[] = ['ser','installmentAmount','paymentType','nextInstallmentDate','status', 'receivedStatus'];

  
   selection = new SelectionModel<BNASubjectName>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private studentDashboardService: StudentDashboardService,private BNASubjectNameService: BNASubjectNameService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit() {
    const role = this.authService.currentUserValue.role.trim();
    const traineeId =  this.authService.currentUserValue.traineeId.trim();
    // const branchId =  this.authService.currentUserValue.branchId.trim();
    const branchId =  this.authService.currentUserValue.branchId  ? this.authService.currentUserValue.branchId.trim() : "";


    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    this.getTraineeRemittanceNotification(traineeId, courseDurationId)
  }

  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getTraineeRemittanceNotification(traineeId,courseDurationId){
    this.subscription = this.studentDashboardService.getRemittanceNotificationForStudent(traineeId,courseDurationId).subscribe(res=>{
      this.traineeRemittanceNotification=res;  
    });
  }

  inActiveItem(row){
    const id = row.courseBudgetAllocationId; 
          this.subscription = this.confirmService.confirm('Confirm Accepted message', 'Are You Sure Accepted This Item').subscribe(result => {
            if (result) {
          this.studentDashboardService.acceptedCourseBudget(id).subscribe(() => {
            //this.getselectedPresentStocks(row.departmentNameId,this.searchText);
            // getselectedPresentStocks(departmentId)
            // this.reloadCurrentRoute();
            this.snackBar.open('Information Accepted Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    
}


}
