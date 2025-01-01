import {
  Component,
  OnInit,
  ViewChild,
  ElementRef,
  OnDestroy,
} from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";

import { MatSnackBar } from "@angular/material/snack-bar";
import { DatePipe } from "@angular/common";
import { SchoolDashboardService } from "../services/SchoolDashboard.service";

import { MasterData } from "../../../assets/data/master-data";
import { environment } from "../../../environments/environment";
import { SharedServiceService } from '../../shared/shared-service.service';
import { ConfirmService } from '../../core/service/confirm.service';

@Component({
  selector: "app-absentlist-dashboard.component",
  templateUrl: "./absentlist-dashboard.component.html",
  styleUrls: ["./absentlist-dashboard.component.sass"],
})
export class AbsentlistDashboardComponent implements OnInit, OnDestroy {
  masterData = MasterData;
  loading = false;
  isLoading = false;
  destination: string;
  MaterialByCourse: any;
  ReadIngMaterialList: any;
  TraineeAbsentList: any;
  TodayAttendanceList: any;
  RoutineByCourse: any;
  dbType: any;
  TodayRoutineList: any;
  schoolId: any;
  fileUrl: any = environment.fileUrl;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedRoutineAbsentColumns: string[] = [
    "ser",
    "course",
    "nominated",
    "actions",
  ];
  subscription: any;

  constructor(
    private datepipe: DatePipe,
    private schoolDashboardService: SchoolDashboardService,
    private route: ActivatedRoute,
    private snackBar: MatSnackBar,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {}

  ngOnInit() {
    this.schoolId = this.route.snapshot.paramMap.get("baseSchoolNameId");
    // this.getTraineeAbsentList(this.schoolId);
    this.getCurrentAttendanceBySchool(this.schoolId);
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  getCurrentAttendanceBySchool(schoolId) {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.subscription = this.schoolDashboardService
      .getCurrentAttendanceBySchool(currentDateTime, schoolId)
      .subscribe((response) => {
        this.TodayAttendanceList = response;
      });
  }
}
