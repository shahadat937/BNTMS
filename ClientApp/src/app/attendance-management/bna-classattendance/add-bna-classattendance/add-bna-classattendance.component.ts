import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { Role } from 'src/app/core/models/role';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AuthService } from 'src/app/core/service/auth.service';
import { MasterData } from 'src/assets/data/master-data';
import { AttendanceService } from '../../service/attendance.service';
import { DatePipe } from '@angular/common';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { ActivatedRoute, Router } from '@angular/router';
import { bnaAttendanceList } from 'src/app/attendance-management/models/bnaAttendanceList';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-add-bna-classattendance',
  templateUrl: './add-bna-classattendance.component.html',
  styleUrls: ['./add-bna-classattendance.component.sass']
})
export class AddBnaClassattendanceComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  masterData = MasterData;
  loading = false;
  myModel = true;
  userRole = Role;
  buttonText: string;
  pageTitle: string;
  destination = "Attendance";
  role: any;
  traineeId: any;
  branchId: any;
  baseSchoolId: any;
  bnaSubjectCurriculum: SelectedModel[];
  courseSection: SelectedModel[];
  courseTitle: SelectedModel[];
  bnaSemester: SelectedModel[];
  classPeriod: SelectedModel[];

  selectedbnaSubjectCurriculum: any;
  selectedcourseSection: any;
  selectedcourseName: any;
  selectedcourseDuration: any;
  selectedbnaSemester: any;
  selectedclassPeriod: any;
  selectedDate: any;

  BnaAttendanceForm: FormGroup;
  validationErrors: string[] = [];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  actionStatus: any;
  searchText = "";
  checked = false;
  isShown: boolean = false;
  isShownForTraineeList: boolean = false;
  updateStatus: boolean;

  attendanceTraineeList: bnaAttendanceList[];
  subjectName: any;
  instructorName: any;


  routinManagementdropdownSettingsSingle: IDropdownSettings;



  constructor(
    private authService: AuthService, 
    private AttendanceService: AttendanceService, 
    private datepipe: DatePipe, 
    private fb: FormBuilder, 
    private snackBar: MatSnackBar, 
    private confirmService: ConfirmService, 
    private router: Router, 
    private route: ActivatedRoute,
    public sharedService: SharedServiceService,) {
    super();
  }

  ngOnInit(): void {

    this.routinManagementdropdownSettingsSingle = {
      singleSelection: true,
      idField: 'value',
      textField: 'text',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };

    this.pageTitle = 'Create Attendance';

    this.role = this.authService.currentUserValue.role.trim();
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();

    this.getSelectedSubjectCurriculum();
    this.getselectedcourseTitle();
    this.getSelectedBnaSemester();
    this.getDropdownCourseSection();
    this.getSelectedClassPeriod();


    this.intitializeForm();


  }

  intitializeForm() {
    this.BnaAttendanceForm = this.fb.group({
      bnaClassAttendanceId: [0],
      bnaSubjectCurriculumId: [''],
      courseNameId: [''],
      courseDurationId: [''],
      bnaSemesterId: [''],
      baseSchoolNameId: this.baseSchoolId,
      courseSectionId: [''],
      classPeriodId: [''],
      date: [''],
      studentAttendanceForm: this.fb.array([this.createTraineeListData()]),
    });
  }

  private createTraineeListData() {
    return this.fb.group({
      traineeId: [],
      traineeName: [],
      subjectId: [],
      subjectName: [],
      instructorId: [],
      instructorName: [],
      attendance: false,
      remark: [],
    });
  }


  getControlLabel(index: number, type: string) {
    return (this.BnaAttendanceForm.get('studentAttendanceForm') as FormArray).at(index).get(type).value;
  }
  getTraineeListonClick() {
    const control = <FormArray>this.BnaAttendanceForm.controls["studentAttendanceForm"];
    for (let i = 0; i < this.attendanceTraineeList.length; i++) {
      control.push(this.createTraineeListData());
    }
    this.BnaAttendanceForm.patchValue({ studentAttendanceForm: this.attendanceTraineeList });
  }
  clearList() {
    const control = <FormArray>this.BnaAttendanceForm.controls["studentAttendanceForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }


  ViewTraineeListForAttendance() {
    if (this.selectedbnaSubjectCurriculum != null && this.selectedcourseName != null && this.selectedcourseDuration != null && this.selectedbnaSemester != null && this.selectedcourseSection != null && this.selectedclassPeriod != null && this.selectedDate != null) {
      // this.intitializeForm();
      this.subjectName = null;
      this.instructorName = null;
      this.updateStatus = false;
      this.AttendanceService.getAttendanceTraineeList(this.baseSchoolId, this.selectedbnaSubjectCurriculum, this.selectedcourseName, this.selectedcourseDuration, this.selectedbnaSemester, this.selectedcourseSection, this.selectedclassPeriod, this.selectedDate).subscribe(res => {
        this.attendanceTraineeList = res;
        res.forEach(element => {
          this.subjectName = element.subjectName;
          this.instructorName = element.instructorName;
          this.updateStatus = element.updateStatus;
        });
        if (this.updateStatus == false) {
          this.destination = "Add";
          this.buttonText = "Save";
          this.actionStatus = 'S';
        }
        else {
          this.destination = "Update";
          this.buttonText = "Update";
          this.actionStatus = 'U';
        }
        this.isShownForTraineeList = true
        this.clearList();
        this.getTraineeListonClick();
      });
      
    }
  }

  getSelectedSubjectCurriculum() {
    this.AttendanceService.getSelectedSubjectCurriculum().subscribe(res => {
      this.bnaSubjectCurriculum = res
    });
  }

  getselectedcourseTitle() {
    this.AttendanceService.getselectedcourseTitle(this.baseSchoolId).subscribe(res => {
      this.courseTitle = res;
    });
  }

  getSelectedBnaSemester() {
    this.AttendanceService.getSelectedBnaSemester().subscribe(res => {
      this.bnaSemester = res
    });
  }


  getDropdownCourseSection() {
    this.AttendanceService.getDropdownCourseSection(this.baseSchoolId).subscribe(res => {
      this.courseSection = res
    });
  }


  getSelectedClassPeriod() {
    this.AttendanceService.getDropdownClassPeriod(this.baseSchoolId).subscribe(res => {
      this.classPeriod = res;
    });
  }


  onBnaSubjectCurriculumStatus(dropdown) {
    this.selectedbnaSubjectCurriculum = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onBnaSubjectCurriculumDeSelect(dropdown) {
    this.selectedbnaSubjectCurriculum = null;
    this.ViewTraineeListForAttendance();
  }

  onCourseTitleStatus(dropdown) {
    var courseNameArr = dropdown.value.split('_');
    this.selectedcourseName = courseNameArr[1].toString();
      this.selectedcourseDuration = courseNameArr[0].toString();
    this.ViewTraineeListForAttendance();
  }
  onCourseTitleDeSelect(dropdown) {
    this.selectedcourseName = null;
    this.selectedcourseDuration = null;
    this.ViewTraineeListForAttendance();
  }

  onBnaSemesterStatus(dropdown) {
    this.selectedbnaSemester = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onBnaSemesterDeSelect(dropdown) {
    this.selectedbnaSemester = null;
    this.ViewTraineeListForAttendance();
  }

  onCourseSectionStatus(dropdown) {
    this.selectedcourseSection = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onCourseSectionDeSelect(dropdown) {
    this.selectedcourseSection = null;
    this.ViewTraineeListForAttendance();
  }

  onClassPeriodStatus(dropdown) {
    this.selectedclassPeriod = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onClassPeriodDeSelect(dropdown) {
    this.selectedclassPeriod = null;
    this.ViewTraineeListForAttendance();
  }

  onDateSelectionChange(event) {
    this.selectedDate = this.datepipe.transform(event.value, 'yyyy-MM-dd') + " 18:00:00.000";
    this.ViewTraineeListForAttendance();
  }


  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {

    console.log(this.BnaAttendanceForm.value);

    this.BnaAttendanceForm.value.bnaSubjectCurriculumId = this.selectedbnaSubjectCurriculum;
    this.BnaAttendanceForm.value.courseNameId = this.selectedcourseName;
    this.BnaAttendanceForm.value.courseDurationId = this.selectedcourseDuration;
    this.BnaAttendanceForm.value.bnaSemesterId = this.selectedbnaSemester;
    this.BnaAttendanceForm.value.courseSectionId = this.selectedcourseSection;
    this.BnaAttendanceForm.value.classPeriodId = this.selectedclassPeriod;
    // this.BnaAttendanceForm.value.date = this.selectedDate;
    if (this.actionStatus == 'S') {
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Inserted This Records?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.AttendanceService.bnaAttendanceSubmit(this.BnaAttendanceForm.value).subscribe(response => {

            this.reloadCurrentRoute();
            this.snackBar.open('Information Inserted Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
    else if (this.actionStatus == 'U'){
      this.confirmService.confirm('Confirm Save message', 'Are You Sure Update This Records?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.AttendanceService.bnaAttendanceUpdate(this.BnaAttendanceForm.value).subscribe(response => {

            this.reloadCurrentRoute();
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
  }
}
