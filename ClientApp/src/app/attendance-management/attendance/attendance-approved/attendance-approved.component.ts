import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { AttendanceService } from "../../service/attendance.service";
import { CodeValueService } from "../../../basic-setup/service/codevalue.service";
import { MatSnackBar } from "@angular/material/snack-bar";
import { TraineeList } from "../../models/traineeList";
import { DatePipe } from "@angular/common";
import { MasterData } from "../../../../assets/data/master-data";
import { CheckboxSelectedModel } from "../../../core/models/checkboxSelectedModel";
import { SelectedModel } from "../../../core/models/selectedModel";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { TraineeNominationService } from "../../../course-management/service/traineenomination.service";
import { ClassRoutineService } from "../../../routine-management/service/classroutine.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
@Component({
  selector: "app-attendance-approved",
  templateUrl: "./attendance-approved.component.html",
  styleUrls: ["./attendance-approved.component.sass"],
})
export class AttendanceApprovedComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  AttendanceForm: FormGroup;
  validationErrors: string[] = [];
  selectedclassroutine: SelectedModel[];
  selectedbaseschools: SelectedModel[];
  selectedcoursename: SelectedModel[];
  selectedbnasubjectname: SelectedModel[];
  selectedclassperiod: SelectedModel[];
  selectedbnaattendanceremark: SelectedModel[];
  selectedCourse: SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameId: SelectedModel[];
  selectedCourseDurationByParameterRequest: number;
  traineeNominationListForAttendance: TraineeList[];
  selectedvalues: CheckboxSelectedModel[];
  traineeForm: FormGroup;
  subjectNamefromClassRoutine: SelectedModel[];
  selectedClassPeriodByBaseSchoolNameIdAndCourseNameIdforAttendanceApprove: SelectedModel[];
  subjectName: string;
  bnaSubjectNameId: number;
  classRoutineId: number;
  isShown: boolean = false;
  courseDurationId: any;
  courseNameId: any;
  role: any;
  traineeId: any;
  branchId: any;
  baseSchoolId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";
  displayedColumns: string[] = [
    "ser",
    "traineePNo",
    "attendanceStatus",
    "bnaAttendanceRemarksId",
  ];
  dataSource;
  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private classRoutineService: ClassRoutineService,
    private datepipe: DatePipe,
    private confirmService: ConfirmService,
    private traineeNominationService: TraineeNominationService,
    private CodeValueService: CodeValueService,
    private AttendanceService: AttendanceService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    this.branchId = this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get("attendanceId");
    if (id) {
      this.pageTitle = "Edit Attendance";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.AttendanceService.find(+id).subscribe((res) => {
        this.AttendanceForm.patchValue({
          attendanceId: res.attendanceId,
          classRoutineId: res.classRoutineId,
          baseSchoolNameId: res.baseSchoolNameId,
          courseNameId: res.courseNameId,
          bnaSubjectNameId: res.bnaSubjectNameId,
          classPeriodId: res.classPeriodId,
          attendanceDate: res.attendanceDate,
          classLeaderName: res.classLeaderName,
          isApproved: res.isApproved,
          approvedUser: res.approvedUser,
          approvedDate: res.approvedDate,
          status: res.status,
          menuPosition: res.menuPosition,
          isActive: res.isActive,
        });
      });
    } else {
      this.pageTitle = "Approve Attendance";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    if (this.role === "Super Admin") {
      this.AttendanceForm.get("baseSchoolNameId")?.setValue(this.branchId);
      this.onBaseSchoolNameSelectionChangeGetCourse(this.branchId);
    }
    this.getselectedclassroutine();
    this.getselectedbaseschools();
    this.getselectedcoursename();
    this.getselectedbnasubjectname();
    this.getselectedclassperiod();
    this.getselectedbnaattendanceremark();
    // this.getAttendanceListForUpdate();
  }
  intitializeForm() {
    this.AttendanceForm = this.fb.group({
      attendanceId: [0],
      baseSchoolNameId: [""],
      courseNameId: [""],
      classPeriodId: [""],
      attendanceDate: [],
      traineeListForm: this.fb.array([this.createTraineeData()]),
    });
  }

  getControlLabel(index: number, type: string) {
    return (this.AttendanceForm.get("traineeListForm") as FormArray)
      ?.at(index)
      ?.get(type)?.value;
  }

  private createTraineeData() {
    return this.fb.group({
      attendanceId: [],
      baseSchoolNameId: [""],
      courseNameId: [""],
      classPeriodId: [""],
      bnaSubjectNameId: [""],
      classRoutineId: [""],
      courseDurationId: [""],
      attendanceDate: [],
      attendanceStatus: [""],
      bnaAttendanceRemarksId: [""],
      traineeId: [""],
      traineePNo: [""],
      traineeName: [""],
      classLeaderName: [""],
      rankPosition: [""],
      dateCreated: [],
      createdBy: [],
    });
  }
  clearList() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }
  getTraineeListonClick() {
    const control = <FormArray>this.AttendanceForm.controls["traineeListForm"];

    for (let i = 0; i < this.dataSource.length; i++) {
      control.push(this.createTraineeData());
    }
    this.AttendanceForm.patchValue({ traineeListForm: this.dataSource });
  }

  onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId) {
    this.AttendanceService.getCourseByBaseSchoolNameId(
      baseSchoolNameId
    ).subscribe((res) => {
      this.selectedCourse = res;
    });
  }
  get f() {
    return this.AttendanceForm.controls;
  }
  get t() {
    return this.f.traineeLists as FormArray;
  }

  onClassPeriodSelectionChangeGetCourseDuration() {
    var baseSchoolNameId = this.AttendanceForm.value["baseSchoolNameId"];
    var courseNameId = this.AttendanceForm.value["courseNameId"];
    var classPeriodId = this.AttendanceForm.value["classPeriodId"];
    var date = this.AttendanceForm.value["attendanceDate"];

    var formatedDate = this.datepipe.transform(date, "MM/dd/yyyy");

    this.classRoutineService
      .getSelectedRoutineId(baseSchoolNameId, this.courseNameId, classPeriodId)
      .subscribe((res) => {
        this.classRoutineId = res;
      });

    if (
      baseSchoolNameId != null &&
      courseNameId != null &&
      classPeriodId != null
    ) {
      this.AttendanceService.getSelectedCourseDurationByParameterRequestFromClassRoutine(
        baseSchoolNameId,
        this.courseNameId,
        classPeriodId
      ).subscribe((res) => {
        this.selectedCourseDurationByParameterRequest = res;
        this.traineeNominationService
          .getTraineeNominationByCourseDurationId(
            this.selectedCourseDurationByParameterRequest,
            0
          )
          .subscribe((res) => {
            this.traineeNominationListForAttendance = res;
          });
      });
    }
    this.isShown = true;
    this.clearList();
    this.AttendanceService.getAttendanceListForUpdate(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText,
      baseSchoolNameId,
      this.courseNameId,
      classPeriodId
    ).subscribe((response) => {
      this.dataSource = response.items;
      this.paging.length = response.totalItemsCount;
      this.getTraineeListonClick();
    });
  }

  onDateSelectionChange(event) {
    var date = this.datepipe.transform(event.value, "MM/dd/yyyy");
    var baseSchoolNameId = this.AttendanceForm.value["baseSchoolNameId"];
    var courseName = this.AttendanceForm.value["courseNameId"];

    var courseNameArr = courseName.split("_");
    this.courseDurationId = courseNameArr[0];
    this.courseNameId = courseNameArr[1];
    if (baseSchoolNameId != null && this.courseNameId != null) {
      this.AttendanceService.getSelectedClassPeriodByBaseSchoolNameIdAndCourseNameIdforAttendances(
        baseSchoolNameId,
        this.courseNameId,
        this.courseDurationId,
        date
      ).subscribe((res) => {
        this.selectedClassPeriodByBaseSchoolNameIdAndCourseNameIdforAttendanceApprove =
          res;
      });
    }
  }

  onCourseNameSelectionChangeGetClassPeriod() {}

  getselectedclassroutine() {
    this.AttendanceService.getselectedclassroutine().subscribe((res) => {
      this.selectedclassroutine = res;
    });
  }

  getselectedbaseschools() {
    this.AttendanceService.getselectedbaseschools().subscribe((res) => {
      this.selectedbaseschools = res;
    });
  }

  getselectedcoursename() {
    this.AttendanceService.getselectedcoursename().subscribe((res) => {
      this.selectedcoursename = res;
    });
  }

  getselectedbnasubjectname() {
    this.AttendanceService.getselectedbnasubjectname().subscribe((res) => {
      this.selectedbnasubjectname = res;
    });
  }
  getselectedclassperiod() {
    this.AttendanceService.getselectedclassperiod().subscribe((res) => {
      this.selectedclassperiod = res;
    });
  }

  getselectedbnaattendanceremark() {
    this.AttendanceService.getselectedbnaattendanceremark().subscribe((res) => {
      this.selectedbnaattendanceremark = res;
    });
  }

  onSubmit() {
    const id = this.AttendanceForm.get("attendanceId")?.value;

    // if (id) {
    this.confirmService
      .confirm("Confirm Update message", "Are You Sure Update This  Item")
      .subscribe((result) => {
        if (result) {
          this.loading = true;
          this.AttendanceService.updateAttendanceList(
            JSON.stringify(this.AttendanceForm.value)
          ).subscribe(
            (response) => {
              this.router.navigateByUrl(
                "/attendance-management/add-attendance"
              );
              this.snackBar.open("Information Updated Successfully ", "", {
                duration: 2000,
                verticalPosition: "bottom",
                horizontalPosition: "right",
                panelClass: "snackbar-success",
              });
            },
            (error) => {
              this.validationErrors = error;
            }
          );
        }
      });
    // }
    //   else {
    //     this.AttendanceService.updateAttendanceList(JSON.stringify(this.AttendanceForm.value)).subscribe(response => {

    //       this.snackBar.open('Information Inserted Successfully ', '', {
    //         duration: 2000,
    //         verticalPosition: 'bottom',
    //         horizontalPosition: 'right',
    //         panelClass: 'snackbar-success'
    //       });
    //     }, error => {
    //       this.validationErrors = error;
    //     })
    //   }

    // }
  }
}
