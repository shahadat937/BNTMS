import { Component, OnInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseTermService } from '../../basic-setup/service/course-term.service';
import { ExamResultService } from '../service/exam-result.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CourseLevelService } from '../../basic-setup/service/course-level.service';
import { BaseSchoolNameService } from '../../basic-setup/service/BaseSchoolName.service';
import { MasterData } from 'src/assets/data/master-data';
import { ExamResultList } from '../models/exam-result-list';
import { CourseDurationService } from '../service/courseduration.service';
import { TraineeNominationService } from '../service/traineenomination.service';
import { TraineeNomination } from '../models/traineenomination';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-exam-result-nomenee-list',
  templateUrl: './exam-result-nomenee-list.component.html',
  styleUrls: ['./exam-result-nomenee-list.component.sass']
})
export class ExamResultNomeneeListComponent implements OnInit {
  pageTitle: string;
  loading = false;
  destination: string;
  btnText: string;
  ExamResultForm: FormGroup;
  validationErrors: string[] = [];
  traineeList: any = [];
  selectedSchool: SelectedModel[];
  SelectedCourseLevel: SelectedModel[];
  SelectedCourseTerm: SelectedModel[];
  selectedCourseduration: any;
  CourseNomeneeResult: any[] = [];
  TraineeNominations: TraineeNomination[] = [];
  traineeNominationListForMIST: TraineeNomination[];
  isShown: boolean = false;
  userRole = Role;
  courseDurationId: any;

  role: any;

  masterData = MasterData;
  isLoading = false;
  branchId: any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  };
  searchText = "";

  displayedColumns: string[] = ['ser','course','courseTitle', 'pno', 'name','cgpa'];
  dataSource: MatTableDataSource<ExamResultList> = new MatTableDataSource();

  constructor(
    private authService: AuthService,
    private TraineeNominationService: TraineeNominationService,
    private examResultService: ExamResultService,
    private baseSchoolNameService: BaseSchoolNameService,
    private CourseLevelService: CourseLevelService,
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private CourseTermService: CourseTermService,
    private fb: FormBuilder, private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.pageTitle = ' Course Result';
    this.destination = "Add";
    this.btnText = 'Save';
    this.branchId = this.authService.currentUserValue.branchId.trim();
    this.role = this.authService.currentUserValue.role.trim();

    this.getSelectedCourseduration(this.branchId);
  }

  getSelectedCourseduration(id: number): void {
    console.log('Course Duration ' + id);
    this.examResultService.GetCourseDuration(id).subscribe(res => {
      this.selectedCourseduration = res;
    });
  }

  FindCourseResult(dropdown): void {
    const courseNameArr = dropdown.source.value.value.split('_');
    const courseDurationsId = courseNameArr[0];
    const courseNameId = courseNameArr[1];
    console.log("FindCourseResultDurationID is " + courseDurationsId );
    this.examResultService.FindCourseResultDurationID(this.branchId, courseDurationsId).subscribe(res => {
      this.CourseNomeneeResult = res;
      this.isShown = true;
      console.log("FindCourseResultDurationID is " + JSON.stringify(this.CourseNomeneeResult));
    });
  }
}
