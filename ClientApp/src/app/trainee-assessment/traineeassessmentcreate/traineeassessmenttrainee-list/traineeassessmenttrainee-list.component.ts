import { Component, OnInit, ViewChild,ElementRef, OnDestroy  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {TraineeAssessmentCreate} from '../../models/TraineeAssessmentCreate'
import {TraineeAssessmentCreateService} from '../../service/TraineeAssessmentCreate.service'
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import {MasterData} from '../../../../../src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import {Location} from '@angular/common';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-traineeassessmenttrainee-list',
  templateUrl: './traineeassessmenttrainee-list.component.html',
  styleUrls: ['./traineeassessmenttrainee-list.component.sass']
})
export class TraineeAssessmentTraineeListComponent implements OnInit,OnDestroy {
   masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeAssessmentCreate[] = [];
  isLoading = false;
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  role:any;
  traineeId:any;
  branchId:any;


  courseDurationId:any;
  traineeAssessmentCreateId:any;
  traineeAssessmentGroupList:any[];

  //groupArrays:{ readingMaterialTitle: string; courses: any; }[];

  displayedColumns: string[] = ['ser','course','assessmentName','startDate','endDate','status', 'actions'];
  dataSource: MatTableDataSource<TraineeAssessmentCreate> = new MatTableDataSource();


   selection = new SelectionModel<TraineeAssessmentCreate>(true, []);
  subscription: any;

  
  constructor(private snackBar: MatSnackBar, private _location: Location,private authService: AuthService,  private route: ActivatedRoute,private TraineeAssessmentCreateService: TraineeAssessmentCreateService,private readonly sanitizer: DomSanitizer,private router: Router,private confirmService: ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit() {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.courseDurationId = this.route.snapshot.paramMap.get('courseDurationId'); 
    this.traineeAssessmentCreateId = this.route.snapshot.paramMap.get('traineeAssessmentCreateId'); 

    this.getTraineeAssessmentGroupListByAssessment(this.searchText);
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

 
  getTraineeAssessmentGroupListByAssessment(search) {
    this.isLoading = true;
    this.TraineeAssessmentCreateService.getTraineeAssessmentGroupListByAssessment(this.courseDurationId, this.subscription = this.traineeAssessmentCreateId,search).subscribe(response => {
      this.traineeAssessmentGroupList = response;
    })
  }
  backClicked() {
    this._location.back();
  }
  // pageChanged(event: PageEvent) {
  
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getTraineeAssessmentCreates();
 
  // }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getTraineeAssessmentGroupListByAssessment(this.searchText);
  } 

  // safeUrlPic(url: any){ 
  //   var specifiedUrl = this.sanitizer.bypassSecurityTrustUrl(url); 
  //   return specifiedUrl;
  // }

  // inActiveItem(row){
  //   const id = row.traineeAssessmentCreateId;    
  //   //var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
  //   if(row.status == 0){
  //     this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Stop This Assessment').subscribe(result => {
  //       if (result) {
  //         //this.runningload = true;
  //         this.TraineeAssessmentCreateService.ChangeAssessmentStatus(id,1).subscribe(() => {
  //         //  this.getBulletins(baseSchoolNameId);
  //         this.getTraineeAssessmentCreates();
  //           this.snackBar.open('Assessment Stopped!', '', {
  //             duration: 3000,
  //             verticalPosition: 'bottom',
  //             horizontalPosition: 'right',
  //             panelClass: 'snackbar-warning'
  //           });
  //         })
  //       }
  //     })
  //   }
  //   else{
      
  //     this.confirmService.confirm('Confirm Active message', 'Are You Sure Run This Assessment').subscribe(result => {
  //       if (result) {
  //         //this.runningload = true;
  //         this.TraineeAssessmentCreateService.ChangeAssessmentStatus(id,0).subscribe(() => {
  //         //  this.getBulletins(baseSchoolNameId);
  //         this.getTraineeAssessmentCreates();
  //           this.snackBar.open('Assessment Running!', '', { 
  //             duration: 3000,
  //             verticalPosition: 'bottom',
  //             horizontalPosition: 'right',
  //             panelClass: 'snackbar-success'
  //           });
  //         })
  //       }
  //     })
  //   }
  // }

  // deleteItem(row) {
  //   const id = row.traineeAssessmentCreateId; 
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
  //     if (result) {
  //       this.TraineeAssessmentCreateService.delete(id).subscribe(() => {
  //         this.getTraineeAssessmentCreates();
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
