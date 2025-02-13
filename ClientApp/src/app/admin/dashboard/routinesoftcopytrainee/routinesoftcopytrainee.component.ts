import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DatePipe } from "@angular/common";
import { dashboardService } from "../services/dashboard.service";
import { MasterData } from "../../../../assets/data/master-data";
import { environment } from "../../../../environments/environment.prod";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
//import { SchoolDashboardService } from '../services/SchoolDashboard.service';

@Component({
  selector: "app-routinesoftcopytrainee.component",
  templateUrl: "./routinesoftcopytrainee.component.html",
  styleUrls: ["./routinesoftcopytrainee.component.sass"],
})
export class RoutineSoftcopyTraineeComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  isLoading = false;
  destination: string;
  materialList: any;
  MaterialByCourse: any;
  traineeId: any;
  ReadIngMaterialList: any;
  schoolId: any;
  role: any;
  //traineeId:any;
  branchId: any;
  fileUrl: any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedReadingMaterialColumns: string[] = [
    "ser",
    "course",
    "documentName",
    "documentLink",
  ];
  constructor(
    private datepipe: DatePipe,
    private authService: AuthService,
    private dashboardService: dashboardService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    //  this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    //  this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    //this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.getRoutineSoftCopyByTrainee(this.traineeId);
  }
  getRoutineSoftCopyByTrainee(id) {
    this.dashboardService.getRoutineSoftCopyByTrainee(id).subscribe((res) => {
      this.materialList = res;
    });
  }
}
