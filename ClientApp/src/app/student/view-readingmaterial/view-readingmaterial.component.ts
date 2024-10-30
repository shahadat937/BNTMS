import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { DomSanitizer } from '@angular/platform-browser';
import { AuthService } from 'src/app/core/service/auth.service';
import { StudentDashboardService } from '../services/StudentDashboard.service';
import { environment } from 'src/environments/environment';
import { ActivatedRoute } from '@angular/router';
import { SharedServiceService } from 'src/app/shared/shared-service.service';
import { InstructorDashboardService } from 'src/app/teacher/services/InstructorDashboard.service';

@Component({
  selector: 'app-view-readingmaterial',
  templateUrl: './view-readingmaterial.component.html',
  styleUrls: ['./view-readingmaterial.component.sass']
})

export class ViewReadingMaterialComponent implements OnInit, OnDestroy {
  masterData = MasterData;
  loading = false;
  isLoading = false;
  @ViewChild('videoPlayer') videoplayer: ElementRef;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";
  fileIUrl = environment.fileUrl;
  bookList: any = [];
  countbooks: any;
  videoList: any = [];
  countvideos: any;
  slideList: any = [];
  countslides: any;
  materialList: any = [];
  countmaterial: any;
  role: any;
  traineeId: any;
  branchId: any;


  groupArrays: { readingMaterialTitle: string; courses: any; }[];
  subscription: any;
  baseSchoolNameId: any;
  instractor: any;
  cousrseId : number;


  constructor(
    private snackBar: MatSnackBar,
    private studentDashboardService: StudentDashboardService,
    private authService: AuthService,
    private readonly sanitizer: DomSanitizer,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService,
    private instructorDashboardService: InstructorDashboardService
  ) { }

  ngOnInit() {

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId ? this.authService.currentUserValue.branchId.trim() : "";

    if (this.authService.currentUserValue.role === 'Student') {
      this.studentDashboardService.getSpStudentInfoByTraineeId(this.traineeId).subscribe(res => {
        if (res) {
          let infoList = res
          this.baseSchoolNameId = infoList[0].baseSchoolNameId;
          
          this.cousrseId = infoList[0].courseNameId;     
                   
          this.getReadingMaterialsForStudents();
        }

      });

    }
    else if (this.authService.currentUserValue.role === 'Master Admin') {
      this.getAllReadingMaterialList()
    }
    else if (this.authService.currentUserValue.role === 'Instructor') {
      this.instructorDashboardService.getSpInstructorInfoByTraineeId(this.traineeId).subscribe(res => {
        if (res) {
          let infoList = res;
          this.baseSchoolNameId = infoList[0].baseSchoolNameId          
          this.getReadingMaterials();
        }
      });

    }
    else if (this.authService.currentUserValue.role === 'Super Admin') {
      this.baseSchoolNameId = this.branchId = this.authService.currentUserValue.branchId
      this.getReadingMaterials();

    }

  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getReadingMaterials() {
    this.subscription = this.studentDashboardService.getReadingMaterialListByType(this.masterData.readingMaterial.books, this.baseSchoolNameId).subscribe(res => {
      this.bookList = res;
      this.countbooks = this.bookList.length;
    })
      ;
    this.subscription = this.studentDashboardService.getReadingMaterialListByType(this.masterData.readingMaterial.videos, this.baseSchoolNameId).subscribe(res => {
      this.videoList = res;
      this.countvideos = this.videoList.length;
    });
    this.subscription = this.studentDashboardService.getReadingMaterialListByType(this.masterData.readingMaterial.slides, this.baseSchoolNameId).subscribe(res => {
      this.slideList = res;
      this.countslides = this.slideList.length;
    });
    this.subscription = this.studentDashboardService.getReadingMaterialListByType(this.masterData.readingMaterial.materials, this.baseSchoolNameId).subscribe(res => {
      this.materialList = res;
      this.countmaterial = this.materialList.length;
    });
  }

  getAllReadingMaterialList() {
    this.subscription = this.studentDashboardService.getAllReadingMaterialList(this.masterData.readingMaterial.books).subscribe(res => {
      this.bookList = res;
      this.countbooks = this.bookList.length;
    })
      ;
    this.subscription = this.studentDashboardService.getAllReadingMaterialList(this.masterData.readingMaterial.videos).subscribe(res => {
      this.videoList = res;
      this.countvideos = this.videoList.length;
    });
    this.subscription = this.studentDashboardService.getAllReadingMaterialList(this.masterData.readingMaterial.slides).subscribe(res => {
      this.slideList = res;
      this.countslides = this.slideList.length;
    });
    this.subscription = this.studentDashboardService.getAllReadingMaterialList(this.masterData.readingMaterial.materials).subscribe(res => {
      this.materialList = res;
      this.countmaterial = this.materialList.length;
    });
  }

  getReadingMaterialsForStudents(){
    this.subscription = this.studentDashboardService.getReadingMaterialListForStudens(this.masterData.readingMaterial.books, this.baseSchoolNameId,this.cousrseId).subscribe(res => {
      this.bookList = res;
      this.countbooks = this.bookList.length;
    })

    this.subscription = this.studentDashboardService.getReadingMaterialListForStudens(this.masterData.readingMaterial.videos, this.baseSchoolNameId,this.cousrseId).subscribe(res => {
      this.videoList = res;
      this.countvideos = this.videoList.length;
    });

    this.subscription = this.studentDashboardService.getReadingMaterialListForStudens(this.masterData.readingMaterial.slides, this.baseSchoolNameId,this.cousrseId).subscribe(res => {
      this.slideList = res;
      this.countslides = this.slideList.length;
    });

    this.subscription = this.studentDashboardService.getReadingMaterialListForStudens(this.masterData.readingMaterial.materials, this.baseSchoolNameId,this.cousrseId).subscribe(res => {
      this.materialList = res;
      this.countmaterial = this.materialList.length;
    });

  }

  pageChanged(event: PageEvent) {

    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getReadingMaterials();

  }
  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getReadingMaterials();
  }

  safeUrlPic(url: any) {
    var specifiedUrl = this.sanitizer.bypassSecurityTrustUrl(url);
    return specifiedUrl;
  }

  toggleVideo(event: any) {
    this.videoplayer.nativeElement.play();
  }

  deleteItem(row) {
    const id = row.readingMaterialId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        // this.ReadingMaterialService.delete(id).subscribe(() => {
        //   this.getReadingMaterials();
        //   this.snackBar.open('Information Deleted Successfully ', '', {
        //     duration: 3000,
        //     verticalPosition: 'bottom',
        //     horizontalPosition: 'right',
        //     panelClass: 'snackbar-danger'
        //   });
        // })
      }
    })

  }





}
