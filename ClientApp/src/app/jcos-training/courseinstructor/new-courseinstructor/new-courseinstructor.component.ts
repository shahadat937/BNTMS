import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {CourseInstructorService} from '../../../jcos-training/service/courseinstructor.service'
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { CourseInstructor } from '../../../jcos-training/models/courseinstructor';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { BNAExamMarkService } from '../../../../../src/app/central-exam/service/bnaexammark.service';
import { BNASubjectNameService } from '../../../../../src/app/central-exam/service/BNASubjectName.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-courseinstructor',
  templateUrl: './new-courseinstructor.component.html',
  styleUrls: ['./new-courseinstructor.component.sass']
})
export class NewCourseInstructorComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  CourseInstructorForm: FormGroup;
  validationErrors: string[] = [];
  coursesByBaseSchoolId: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectCourse: SelectedModel[];
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
  selectSubject: SelectedModel[];
  GetInstructorByParameters: CourseInstructor[];
  isShown: boolean = false;
  courseDurationIdForList: number;
  courseDurationId:any;
  courseNameId:any;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  selectedCourseDurationByCourseTypeAndCourseName:SelectedModel[];
  selectMarkType : any;
  subscription : any;

  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser','bnaSubjectName', 'trainee', 'status', 'actions'];

  constructor(private snackBar: MatSnackBar,private subjectNameService:BNASubjectNameService,  private BNAExamMarkService:BNAExamMarkService ,private authService: AuthService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private CourseInstructorService: CourseInstructorService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    const id = this.route.snapshot.paramMap.get('courseInstructorId');
    if (id) {
      this.pageTitle = 'Update JCOs Examminer Assign';
      this.destination = "Update";
      this.buttonText = "Update"

      this.CourseInstructorService.find(+id).subscribe(
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

          });

        }
      );
    } else {
      this.pageTitle = 'Create JCOs Examminer Assign';
      this.destination = "Assign";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    this.getselectedschools();
    this.getSelectedCourseDurationByCourseTypeIdAndCourseNameId();
    this.getSelectedModule();
  }

  intitializeForm() {
    this.CourseInstructorForm = this.fb.group({
      courseInstructorId: [0],
      courseDurationId: [''],
      baseSchoolNameId: [''],
      courseModuleId: [''],
      bnaSubjectNameId: [''],
      traineeId: [''],
      markTypeId : [''],
      subjectMarkId : [''],
      courseName: [''],
      traineeName: [''],
      courseNameId: [''],
      status: [],
      isActive: [true],
    })

    //autocomplete
    this.CourseInstructorForm.get('traineeName')?.valueChanges
      .subscribe(value => {

        this.getSelectedTraineeByPno(value);

      })

  }
  getSelectedCourseDurationByCourseTypeIdAndCourseNameId(){
    this.BNAExamMarkService.getSelectedCourseDurationByCourseTypeIdAndCourseNameId(MasterData.coursetype.CentralExam,MasterData.courseName.JCOsTraining).subscribe(res => {
      this.selectedCourseDurationByCourseTypeAndCourseName = res;
      this.selectCourse = res
    });
  }
  filterByCourse(value:any){
    this.selectedCourseDurationByCourseTypeAndCourseName=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  onCourseNameSelectionChangeGetSubjectList(dropdown){
    if (dropdown.isUserInput) {
      var courseNameArr = dropdown.source.value.value.split('_');
      this.courseDurationId = courseNameArr[0];
      this.courseNameId = courseNameArr[1];

      this.CourseInstructorForm.get('courseNameId')?.setValue(this.courseNameId);
      this.CourseInstructorForm.get('courseDurationId')?.setValue(this.courseDurationId);

      this.subjectNameService.getSelectedSubjectNameByCourseNameId(this.courseNameId).subscribe(res => {
        this.selectedSubjectNameByCourseNameId = res;
        this.selectSubject = res
      });
    }
  }
  filterBySubject(value:any){
    this.selectedSubjectNameByCourseNameId=this.selectSubject.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  //autocomplete
  getSelectedTraineeByPno(pno) {
    this.CourseInstructorService.getSelectedTraineeByPno(pno).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  stopCourseInstructor(element) {
    this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
        this.CourseInstructorService.stopCourseInstructor(element.courseInstructorId).subscribe(() => {
          var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
          var courseNameId = this.CourseInstructorForm.value['courseNameId'];
          var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];

          this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
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

  //autocomplete
  onTraineeSelectionChanged(item) {
    this.CourseInstructorForm.get('traineeId')?.setValue(item.value);
    this.CourseInstructorForm.get('traineeName')?.setValue(item.text);
  }

  onBaseNameSelectionChangeGetModule(dropdown) {

    if (dropdown.isUserInput) {

      var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.source.value.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];

      this.CourseInstructorForm.get('courseName')?.setValue(dropdown.text);
      this.CourseInstructorForm.get('courseNameId')?.setValue(courseNameId);
      this.CourseInstructorForm.get('courseDurationId')?.setValue(courseDurationId);


      if (baseSchoolNameId != null && courseNameId != null) {
        this.CourseInstructorService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {
          this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;
        });
      }
    }
  }

  getSelectedModule() {
    this.CourseInstructorService.getSelectedModule().subscribe(res => {
      this.selectedModule = res
    });
  }

  getselectedschools() {
    this.CourseInstructorService.getselectedschools().subscribe(res => {
      this.selectedSchool = res
    });
  }
  getselectedcourseduration() {
    this.CourseInstructorService.getselectedcourseduration().subscribe(res => {
      this.selectedcourseduration = res;
    });
  }

  getselectedbnasubjectname() {
    var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    var courseModuleId = this.CourseInstructorForm.value['courseModuleId'];
    this.CourseInstructorService.getselectedbnasubjectnamebyparameters(baseSchoolNameId, courseNameId, courseModuleId).subscribe(res => {
      this.selectedsubjectname = res;
    });
  }

  onModuleSelectionChangeGetInstructorList() {
    var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
    var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];
    this.isShown = true;

      this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
        this.GetInstructorByParameters = res;
      });

      this.subscription = this.CourseInstructorService.getselectedmarktype(bnaSubjectNameId).subscribe(res=>{
        this.selectMarkType=res
      });
  }

  onSubjectMarkSelectionGetMarkType(event){

    let subjectMarkId = event.source.value;   
      this.CourseInstructorService.findSubjectMark(subjectMarkId).subscribe(res=>{
       this.CourseInstructorForm.get('markTypeId')?.setValue(res.markTypeId);
      });
   
    }
  GetInstructorListAfterDelete(baseSchoolNameId, bnaSubjectNameId, courseModuleId, courseNameId, courseDurationId) {
    this.isShown = true;
    if (baseSchoolNameId != null && bnaSubjectNameId != null && courseModuleId != null && courseNameId != null) {

      this.CourseInstructorService.getInstructorByParameters(baseSchoolNameId,bnaSubjectNameId, courseModuleId, courseNameId,courseDurationId).subscribe(res => {
        this.GetInstructorByParameters = res;
      });
    }
  }

  deleteItem(row) {
    const id = row.courseInstructorId;
    var bnaSubjectNameId = row.bnaSubjectNameId;
    var courseNameId = row.courseNameId;
    var courseDurationId = row.courseDurationId;
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.CourseInstructorService.delete(id).subscribe(() => {
          this.CourseInstructorService.getCourseInstructorByCourseDurationIdANdSubjectNameId(bnaSubjectNameId, courseDurationId, courseNameId).subscribe(res => {
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
    const id = this.CourseInstructorForm.get('courseInstructorId')?.value;
    this.CourseInstructorForm.get('status')?.setValue(0);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.CourseInstructorService.update(+id, this.CourseInstructorForm.value).subscribe(response => {
            this.router.navigateByUrl('/subject-management/add-subjectinstructor');
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.loading=false;
          }, error => {
            this.validationErrors = error;
            this.loading=false;
          })
        }
      })
    }

    else {
      this.loading=true;
      this.CourseInstructorService.submit(this.CourseInstructorForm.value).subscribe(response => {
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
        this.loading=false;
      }, error => {
        this.validationErrors = error;
        this.loading = false;
      })
    }

  }
}
