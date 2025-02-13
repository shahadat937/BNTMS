import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { ClassRoutine } from "../../../routine-management/models/classroutine";
import { ClassRoutineService } from "../../../routine-management/service/classroutine.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-classroutine-list",
  templateUrl: "./classroutine-list.component.html",
  styleUrls: ["./classroutine-list.component.sass"],
})
export class ClassRoutineListComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ClassRoutine[] = [];
  isLoading = false;
  selectedRoutineByParameters: ClassRoutine[];
  courseTypeId: number;
  baseSchoolNameId: any;
  dbType: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "date",
    "courseModule",
    "classPeriod",
    "bnaSubjectName",
    "totalPeriod",
  ];

  constructor(
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private ClassRoutineService: ClassRoutineService,
    private router: Router,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.getClassRoutines();
  }

  getClassRoutines() {
    this.isLoading = true;
    this.baseSchoolNameId =
      this.route.snapshot.paramMap.get("baseSchoolNameId");
    var courseNameId = this.route.snapshot.paramMap.get("courseNameId");
    var courseDurationId = this.route.snapshot.paramMap.get("courseDurationId");
    this.courseTypeId = Number(
      this.route.snapshot.paramMap.get("courseTypeId")
    );
    this.dbType = this.route.snapshot.paramMap.get("dbType");
    this.ClassRoutineService.classRoutineBySchoolCourseDuration(
      this.baseSchoolNameId,
      courseNameId,
      courseDurationId
    ).subscribe((res) => {
      this.selectedRoutineByParameters = res;
    });
  }

  // pageChanged(event: PageEvent) {

  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getClassRoutines();

  // }
  // applyFilter(searchText: any){
  //   this.searchText = searchText;
  //   this.getClassRoutines();
  // }

  // deleteItem(row) {
  //   const id = row.classRoutineId;
  //   this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
  //     if (result) {
  //       this.ClassRoutineService.delete(id).subscribe(() => {
  //         this.getClassRoutines();
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
