import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {CourseInstructorService} from '../../../subject-management/service/courseinstructor.service'
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { CourseInstructor } from '../../../subject-management/models/courseinstructor';
import { AuthService } from 'src/app/core/service/auth.service';
import { BNAExamMarkService } from 'src/app/central-exam/service/bnaexammark.service';
import { BNASubjectNameService } from 'src/app/central-exam/service/BNASubjectName.service';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-courseinstructor',
  templateUrl: './new-courseinstructor.component.html',
  styleUrls: ['./new-courseinstructor.component.sass']
})
export class NewCourseInstructorComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  CourseInstructorForm: FormGroup;
  validationErrors: string[] = [];
  coursesByBaseSchoolId: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectedSchool: SelectedModel[];
  selectedBatch: SelectedModel[];
  selectedRank: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selectedsubjectname: SelectedModel[];
  selectedcourseduration: SelectedModel[];
  selectedSubjectNameByCourseNameId:SelectedModel[];
  selectedModule: SelectedModel[];
  selectedCourseInstructor: CourseInstructor;
  selectedCourseModuleByBaseSchoolAndCourseNameId: SelectedModel[];
  GetInstructorByParameters: CourseInstructor[];
  isShown: boolean = false;
  isIdPresent:boolean =false;
  courseDurationIdForList: number;
  courseDurationId:any;
  courseNameId:any;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  selectedCourseDurationByCourseTypeAndCourseName:SelectedModel[];

  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser','bnaSubjectName', 'trainee', 'status', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private subjectNameService:BNASubjectNameService,  private BNAExamMarkService:BNAExamMarkService ,private authService: AuthService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private CourseInstructorService: CourseInstructorService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    const id = this.route.snapshot.paramMap.get('courseInstructorId');
    if (id) {
      this.pageTitle = 'Update Course Instructor Assign';
      this.destination = "Update";
      this.buttonText = "Update"
       this.isIdPresent=true;
      this.subscription = this.CourseInstructorService.find(+id).subscribe(
        res => {
          this.CourseInstructorForm.patchValue({
            courseInstructorId: res.courseInstructorId,
            courseDurationId: res.courseDurationId,
            courseNameId: res.courseNameId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseModuleId: res.courseModuleId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            traineeId: res.traineeId,
            status: res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
            courseName:res.courseName+'_'+res.courseDuration
          });
          //this.CourseInstructorForm.get("courseName").setValue(res.courseName+'_'+res.courseDuration);

          this.getSelectedCourseDurationByCourseTypeIdAndCourseNameId();
        }
      //  onCourseNameSelectionChangeGetSubjectList(res.courseNameId)
      );
    } else {
      this.pageTitle = 'Course Instructor Assign';
      this.destination = "Assign";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    this.getselectedschools();
    this.getSelectedCourseDurationByCourseTypeIdAndCourseNameId();
    this.getSelectedModule();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  intitializeForm() {
    this.CourseInstructorForm = this.fb.group({
      courseInstructorId: [0],
      courseDurationId: [''],
      baseSchoolNameId: [''],
      courseModuleId: [''],
      bnaSubjectNameId: [''],
      traineeId: [''],
      courseName: [''],
      traineeName: [''],
      courseNameId: [''],
      status: [],
      isActive: [true],
    })

    //autocomplete
    this.subscription = this.CourseInstructorForm.get('traineeName').valueChanges
      .subscribe(value => {

        this.getSelectedTraineeByPno(value);

      })

  }
  getSelectedCourseDurationByCourseTypeIdAndCourseNameId(){
    this.subscription = this.BNAExamMarkService.getSelectedCourseDurationByCourseTypeIdAndCourseNameId(MasterData.coursetype.CentralExam,MasterData.courseName.StaffCollage).subscribe(res => {
      this.selectedCourseDurationByCourseTypeAndCourseName = res;
    });
  }

  onCourseNameSelectionChangeGetSubjectList(dropdown){
    if (dropdown.isUserInput) {
      var courseNameArr = dropdown.source.value.value.split('_');
      this.courseDurationId = courseNameArr[0];
      this.courseNameId = courseNameArr[1];

      this.CourseInstructorForm.get('courseNameId').setValue(this.courseNameId);
      this.CourseInstructorForm.get('courseDurationId').setValue(this.courseDurationId);

      this.subscription = this.subjectNameService.getSelectedSubjectNameByCourseNameId(this.courseNameId).subscribe(res => {
        this.selectedSubjectNameByCourseNameId = res;
      });
    }
  }

  //autocomplete
  getSelectedTraineeByPno(pno) {
    this.subscription = this.CourseInstructorService.getSelectedTraineeByPno(pno).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  stopCourseInstructor(element) {
    if(element.status === 0){
      this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
        if (result) {
          this.subscription = this.CourseInstructorService.stopCourseInstructor(element.courseInstructorId).subscribe(() => {
            var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
            var courseNameId = this.CourseInstructorForm.value['courseNameId'];
            var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];
  
            this.subscription = this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
              this.GetInstructorByParameters = res;
            });
  
            this.snackBar.open('Information Stop Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-warning'
            });
          })
        }
      })
    }
    else{
      this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
        if (result) {
          this.subscription = this.CourseInstructorService.RunningCourseInstructor(element.courseInstructorId).subscribe(() => {
            var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
            var courseNameId = this.CourseInstructorForm.value['courseNameId'];
            var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];
  
            this.subscription = this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
              this.GetInstructorByParameters = res;
            });
  
            this.snackBar.open('Information Running!', '', { 
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          })
        }
      })
    }
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    this.CourseInstructorForm.get('traineeId').setValue(item.value);
    this.CourseInstructorForm.get('traineeName').setValue(item.text);
  }

  onBaseNameSelectionChangeGetModule(dropdown) {

    if (dropdown.isUserInput) {

      var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.source.value.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];

      this.CourseInstructorForm.get('courseName').setValue(dropdown.text);
      this.CourseInstructorForm.get('courseNameId').setValue(courseNameId);
      this.CourseInstructorForm.get('courseDurationId').setValue(courseDurationId);


      if (baseSchoolNameId != null && courseNameId != null) {
        this.CourseInstructorService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {
          this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;
        });
      }
    }
  }

  getSelectedModule() {
    this.subscription = this.CourseInstructorService.getSelectedModule().subscribe(res => {
      this.selectedModule = res
    });
  }

  getselectedschools() {
    this.subscription = this.CourseInstructorService.getselectedschools().subscribe(res => {
      this.selectedSchool = res
    });
  }
  getselectedcourseduration() {
    this.subscription = this.CourseInstructorService.getselectedcourseduration().subscribe(res => {
      this.selectedcourseduration = res;
    });
  }

  getselectedbnasubjectname() {
    var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    var courseModuleId = this.CourseInstructorForm.value['courseModuleId'];
    this.subscription = this.CourseInstructorService.getselectedbnasubjectnamebyparameters(baseSchoolNameId, courseNameId, courseModuleId).subscribe(res => {
      this.selectedsubjectname = res;
    });
  }

  onModuleSelectionChangeGetInstructorList() {
    var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
    var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];
    this.isShown = true;

    this.subscription = this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
        this.GetInstructorByParameters = res;
      });
  }
  GetInstructorListAfterDelete(baseSchoolNameId, bnaSubjectNameId, courseModuleId, courseNameId, courseDurationId) {
    this.isShown = true;
    if (baseSchoolNameId != null && bnaSubjectNameId != null && courseModuleId != null && courseNameId != null) {

      // this.CourseInstructorService.getInstructorByParameters(baseSchoolNameId,bnaSubjectNameId, courseModuleId, courseNameId,courseDurationId).subscribe(res => {
      //   this.GetInstructorByParameters = res;
      // });
    }
  }

  deleteItem(row) {
    const id = row.courseInstructorId;
    var bnaSubjectNameId = row.bnaSubjectNameId;
    var courseNameId = row.courseNameId;
    var courseDurationId = row.courseDurationId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseInstructorService.delete(id).subscribe(() => {
          this.subscription = this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
            this.GetInstructorByParameters = res;
          });
         
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })

  }

  onSubmit() {
    const id = this.CourseInstructorForm.get('courseInstructorId').value;
    this.CourseInstructorForm.get('status').setValue(0);
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.CourseInstructorService.update(+id, this.CourseInstructorForm.value).subscribe(response => {
            this.router.navigateByUrl('/staff-collage/add-subjectinstructor');
            // staff-collage/update-staffcollagecourse/3149
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

    else {
      this.loading=true;
      this.subscription = this.CourseInstructorService.submit(this.CourseInstructorForm.value).subscribe(response => {
        this.onModuleSelectionChangeGetInstructorList();
        this.CourseInstructorForm.reset();
        this.CourseInstructorForm.get('courseInstructorId')?.setValue(0);
        this.CourseInstructorForm.get('isActive')?.setValue(true);
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
          
        });
        this.loading = false;
      }, error => {
        this.validationErrors = error;
        this.loading = false;
      })
    }

  }
}
