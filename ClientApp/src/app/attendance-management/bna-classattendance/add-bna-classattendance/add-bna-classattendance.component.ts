import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Role } from 'src/app/core/models/role';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { AuthService } from 'src/app/core/service/auth.service';
import { MasterData } from 'src/assets/data/master-data';
import { AttendanceService } from '../../service/attendance.service';
import { DatePipe } from '@angular/common';
import { IDropdownSettings } from 'ng-multiselect-dropdown';

@Component({
  selector: 'app-add-bna-classattendance',
  templateUrl: './add-bna-classattendance.component.html',
  styleUrls: ['./add-bna-classattendance.component.sass']
})
export class AddBnaClassattendanceComponent implements OnInit {
  masterData = MasterData;
  loading = false;
  myModel = true;
  userRole = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  BnaAttendanceForm: FormGroup;
  role: any;
  traineeId: any;
  branchId: any;
  baseSchoolId: any;
  bnaSubjectCurriculam: SelectedModel[];
  courseSection: SelectedModel[];
  courseTitle: SelectedModel[];
  bnaSemester: SelectedModel[];
  classPeriod: SelectedModel[];

  selectedbnaSubjectCurriculam: any;
  selectedcourseSection: any;
  selectedcourseTitle: any;
  selectedbnaSemester: any;
  selectedclassPeriod: any;
  selectedDate: any;

  attendanceTraineeList : SelectedModel[];


  routinManagementdropdownSettingsSingle: IDropdownSettings;



  constructor(private authService: AuthService, private AttendanceService: AttendanceService, private datepipe: DatePipe,) { }

  ngOnInit(): void {
    this.pageTitle = 'Create Attendance';
    this.destination = "Add";
    this.buttonText = "Save";

    this.role = this.authService.currentUserValue.role.trim();
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();

    this.getSelectedSubjectCurriculum();
    this.getselectedcourseTitle();
    this.getSelectedBnaSemester();
    this.getDropdownCourseSection();
    this.getSelectedClassPeriod();


    this.routinManagementdropdownSettingsSingle = {
      singleSelection: true,
      idField: 'value',
      textField: 'text',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
  }


  getSelectedSubjectCurriculum() {
    this.AttendanceService.getSelectedSubjectCurriculum().subscribe(res => {
      this.bnaSubjectCurriculam = res
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


  onBnaSubjectCurriculamStatus(dropdown) {
    this.selectedbnaSubjectCurriculam = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onBnaSubjectCurriculamDeSelect(dropdown) {
    this.selectedbnaSubjectCurriculam = null;
    this.ViewTraineeListForAttendance();
  }

  onCourseTitleStatus(dropdown) {
    this.selectedcourseTitle = dropdown.value;
    this.ViewTraineeListForAttendance();
  }
  onCourseTitleDeSelect(dropdown) {
    this.selectedcourseTitle = null;
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

  onDateSelectionChange(event){
    this.selectedDate = this.datepipe.transform(event.value, 'yyyy-MM-dd')+ " 18:00:00.000";
    this.ViewTraineeListForAttendance();
  }

  ViewTraineeListForAttendance() {
    if (this.selectedbnaSubjectCurriculam != null && this.selectedcourseTitle != null && this.selectedbnaSemester != null && this.selectedcourseSection != null && this.selectedclassPeriod != null && this.selectedDate != null) {
      this.AttendanceService.getAttendanceTraineeList(this.baseSchoolId, this.selectedbnaSubjectCurriculam, this.selectedcourseTitle, this.selectedbnaSemester, this.selectedcourseSection, this.selectedclassPeriod, this.selectedDate).subscribe(res => {
        this.attendanceTraineeList = res;
        console.log("Response : ", this.attendanceTraineeList);
      });
    }
  }
}
