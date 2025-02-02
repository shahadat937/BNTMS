import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { TraineeNomination } from "../../../course-management/models/traineenomination";
import { TraineeNominationService } from "../../../course-management/service/traineenomination.service";
import { SpOfficerDetails } from "../models/spofficerdetails";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { DatePipe } from "@angular/common";
import { dashboardService } from "../services/dashboard.service";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
// import { serialize } from "v8";

@Component({
  selector: "app-countedofficers-list",
  templateUrl: "./countedofficers-list.component.html",
  styleUrls: ["./countedofficers-list.component.sass"],
})
export class CountedOfficersListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit {
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: TraineeNomination[] = [];
  isLoading = false;
  Countedlist: any[];
  destination: string;
  dbType: any;
  officerTypeId: any;
  groupArrays: { courseName: string; courses: any }[];
  traineeStatusId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = ["ser", "name", "course", "duration"];
  dataSource: any;

  constructor(
    private datepipe: DatePipe,
    private dashboardService: dashboardService,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {

    this.traineeStatusId = this.route.snapshot.paramMap.get("traineeStatusId");
    this.officerTypeId = this.route.snapshot.paramMap.get("officerTypeId");
    this.dbType = this.route.snapshot.paramMap.get("dbType");
    // console.log( this.masterData.TraineeStatus.civil);


    if (Number(this.traineeStatusId) === this.masterData.TraineeStatus.civil || Number(this.traineeStatusId) === this.masterData.TraineeStatus.civilInstructor) {
      this.getRunningCivilTrainee();
    }
     else if (this.traineeStatusId) {
      this.getRunningTrainee();
    }
    else{
      this.getAllRunningTrainee();
    }


    // let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy") || '';
    // if (Number(this.traineeStatusId) == this.masterData.TraineeStatus.officer) {
    //   this.destination = "Officer";
    //   this.dashboardService
    //     .getrunningCourseTotalOfficerListfromprocedureRequest(
    //       currentDateTime,
    //       this.masterData.TraineeStatus.officer
    //     )
    //     .subscribe((response) => {
    //       this.Countedlist = response;
    //       console.log(response);
    //       // this gives an object with dates as keys
    //       const groups = this.Countedlist.reduce((groups, courses) => {
    //         const schoolName = courses.course;
    //         if (!groups[schoolName]) {
    //           groups[schoolName] = [];
    //         }
    //         groups[schoolName].push(courses);
    //         return groups;
    //       }, {});

    //       // Edit: to add it in the array format instead
    //       this.groupArrays = Object.keys(groups).map((courseName) => {
    //         return {
    //           courseName,
    //           courses: groups[courseName],
    //         };
    //       });
    //     });
    // } else if (
    //   Number(this.traineeStatusId) == this.masterData.TraineeStatus.sailor
    // ) {
    //   this.destination = "Sailor";
    //   this.dashboardService
    //     .getrunningCourseTotalOfficerListfromprocedureRequest(
    //       currentDateTime,
    //       this.masterData.TraineeStatus.sailor
    //     )
    //     .subscribe((response) => {
    //       console.log(response);
    //       this.Countedlist = response;
    //       // this gives an object with dates as keys
    //       const groups = this.Countedlist.reduce((groups, courses) => {
    //         const schoolName =
    //           courses.course + "_(" + courses.courseTitle + ")";
    //         if (!groups[schoolName]) {
    //           groups[schoolName] = [];
    //         }
    //         groups[schoolName].push(courses);
    //         return groups;
    //       }, {});

    //       // Edit: to add it in the array format instead
    //       this.groupArrays = Object.keys(groups).map((courseName) => {
    //         return {
    //           courseName,
    //           courses: groups[courseName],
    //         };
    //       });
    //     });
    // } else if (Number(this.traineeStatusId) == this.masterData.TraineeStatus.civil) {
    //   this.destination = "Civil";
    //   this.dashboardService
    //     .getrunningCourseTotalOfficerListfromprocedureRequest(
    //       currentDateTime,
    //       this.masterData.TraineeStatus.civil
    //     )
    //     .subscribe((response) => {
    //       this.Countedlist = response;
    //       // this gives an object with dates as keys
    //       const groups = this.Countedlist.reduce((groups, courses) => {
    //         const schoolName =
    //           courses.course + "_(" + courses.courseTitle + ")";
    //         if (!groups[schoolName]) {
    //           groups[schoolName] = [];
    //         }
    //         groups[schoolName].push(courses);
    //         return groups;
    //       }, {});

    //       // Edit: to add it in the array format instead
    //       this.groupArrays = Object.keys(groups).map((courseName) => {
    //         return {
    //           courseName,
    //           courses: groups[courseName],
    //         };
    //       });
    //     });
    // } else {
    //   this.destination = "Trainee";
    //   this.dashboardService
    //     .getnominatedCourseListFromSpRequest(currentDateTime)
    //     .subscribe((response) => {
    //       this.Countedlist = response;

    //       // this gives an object with dates as keys
    //       const groups = this.Countedlist.reduce((groups, courses) => {
    //         const schoolName =
    //           courses.course + "_(" + courses.courseTitle + ")";
    //         if (!groups[schoolName]) {
    //           groups[schoolName] = [];
    //         }
    //         groups[schoolName].push(courses);
    //         return groups;
    //       }, {});

    //       // Edit: to add it in the array format instead
    //       this.groupArrays = Object.keys(groups).map((courseName) => {
    //         return {
    //           courseName,
    //           courses: groups[courseName],
    //         };
    //       });
    //     });
    // }
  }
  applyFilter(search: any) {
    this.searchText = search;

    if (Number(this.traineeStatusId) === this.masterData.TraineeStatus.civil || Number(this.traineeStatusId) === this.masterData.TraineeStatus.civilInstructor) {
      this.getRunningCivilTrainee();
    }
     else if (this.traineeStatusId) {
      this.getRunningTrainee();
    }
    else{
      this.getAllRunningTrainee();
    }
  }
  // pageChanged(event: PageEvent) {
  //   this.paging.pageIndex = event.pageIndex;
  //   this.paging.pageSize = event.pageSize;
  //   this.paging.pageIndex = this.paging.pageIndex + 1;
  //   // this.getCourseDurationsByCourseType();
  // }

  getRunningTrainee() {
    this.dashboardService.getRunningTeaineeInfo(this.traineeStatusId, this.officerTypeId, this.searchText).subscribe(res => {
      const trainee = res;
      if (trainee?.length) {
        this.sharedService.groupedData = this.sharedService.groupBy(trainee, (trainee) => trainee.course)
      }

    })
  }

  getRunningCivilTrainee() {
    this.dashboardService.getRunningCivilTeaineeInfo(this.searchText).subscribe(res => {
      const trainee = res;
      if (trainee?.length) {
        this.sharedService.groupedData = this.sharedService.groupBy(trainee, (trainee) => trainee.course)
      }
    })
  }

  getAllRunningTrainee() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy") || '';
    this.destination = "Trainee";
    this.dashboardService
      .getnominatedCourseListFromSpRequest(currentDateTime, this.searchText)
      .subscribe((response) => {
       
        var trainee = response;
        if(trainee){
          this.sharedService.groupedData = this.sharedService.groupBy(trainee, (trainee) => trainee.course)
        }
       
      });
  }
}


