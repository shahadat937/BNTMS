import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseInstructorService } from '../../service/courseinstructor.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { CourseInstructor } from '../../models/courseinstructor';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { ClassRoutineService } from '../../../routine-management/service/classroutine.service';
import { Role } from '../../../../../src/app/core/models/role';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-bnacourseinstructor',
  templateUrl: './new-bnacourseinstructor.component.html',
  styleUrls: ['./new-bnacourseinstructor.component.sass']
})
export class NewBnaCourseInstructorComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  buttonText: string;
  pageTitle: string;
  //traineeId: number;
  destination: string;
  CourseInstructorForm: FormGroup;
  validationErrors: string[] = [];
  coursesByBaseSchoolId: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectCourse:SelectedModel[]
  selectedSchool: SelectedModel[];
  selectedBatch: SelectedModel[];
  selectedRank: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selectedsubjectname: SelectedModel[];
  selectSubject:SelectedModel[]
  selectedcourseduration: SelectedModel[];
  selectedmarktype:SelectedModel[];
  selectMarkType:SelectedModel[];
  selectedModule: SelectedModel[];
  selectedSemester: SelectedModel[];
  selectSemester:SelectedModel[];
  selectedSubjectCurriculum: SelectedModel[];
  selectCurriculum:SelectedModel[];
  selectedDepartment: SelectedModel[];
  selectedCourseSection: SelectedModel[];
  selectSection:SelectedModel[]
  selectedCourseInstructor: CourseInstructor;
  selectedCourseModuleByBaseSchoolAndCourseNameId: SelectedModel[];
  GetInstructorByParameters: CourseInstructor[];
  isShown: boolean = false;
  courseDurationIdForList: number
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  department: any;
  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser', 'bnaSemester', 'bnaSubjectName', 'trainee', 'markentry', 'status', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar, private authService: AuthService,private ClassRoutineService: ClassRoutineService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private CourseInstructorService: CourseInstructorService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    const id = this.route.snapshot.paramMap.get('courseInstructorId');
    if (id) {
      this.pageTitle = 'Update Course Instructor Assign';
      this.destination = "Update";
      this.buttonText = "Update"

      this.subscription = this.CourseInstructorService.find(+id).subscribe(
       
        res => {
       
          this.CourseInstructorForm.patchValue({
            courseInstructorId: res.courseInstructorId,
            courseDurationId: res.courseDurationId,
            courseNameId: res.courseNameId,
            baseSchoolNameId: res.baseSchoolNameId,
            //courseModuleId: res.courseModuleId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            bnaSemesterId:res.bnaSemesterId,
            departmentId:res.departmentId,
            bnaSubjectCurriculumId:res.bnaSubjectCurriculumId,
            courseSectionId: res.courseSectionId,
            traineeId: res.traineeId,
            subjectMarkId:res.subjectMarkId,
            markTypeId:res.markTypeId,
            traineeName:res.trainee,
            status: res.status,
            menuPosition: res.menuPosition, 
            isActive: res.isActive,
            courseName: res.courseDurationId+'_'+res.courseNameId,
            examMarkEntry:res.examMarkEntry
           // courseName: res.courseDurationId+'_'+res.courseNameId
          //  traineeName:res.traineePno+'_'+res.
          }); 
          this.traineeId = res.traineeId;
          //this.courseNameId = res.courseNameId;
          //this.baseSchoolId=res.baseSchoolName;    
          this.getselectedcoursedurationbyschoolname();
          this.getselectedbnasubjectname();
          this.getCourseModuleOnEdit(res.baseSchoolNameId,res.courseNameId);
       
        }
      );
    } else {
      this.pageTitle = 'Course Instructor Assign';
      this.destination = "Assign";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.getselectedcoursedurationbyschoolname();
    }
    
    this.getselectedschools();
    //this.getselectedbnasubjectname();
    //this.getselectedcoursedurationbyschoolname();
    this.getSelectedModule();
    this.getSelectedBnaSemester();
    this.getSelectSection();
    this.getSelectedSubjectCurriculum();
    this.getSelectedDepartment();
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
      //courseModuleId: [''],
      bnaSubjectNameId: [''],
      bnaSemesterId:[],
      departmentId:[],
      bnaSubjectCurriculumId:[],
      courseSectionId: [''],
      traineeId: [''],
      subjectMarkId: [''],
      markTypeId: [''],
      courseName: [''],
      traineeName: [''], 
      courseNameId: [],
      status: [0],
      isActive: [true],
      examMarkEntry:[]
    })

    //autocomplete
    this.CourseInstructorForm.get('traineeName')?.valueChanges
      .subscribe(value => {

        this.getSelectedTraineeByPno(value);

      })

  }
  getselectedcoursedurationbyschoolname() {
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.CourseInstructorForm.get('baseSchoolNameId')?.setValue(this.branchId);
    }
    var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    this.subscription = this.CourseInstructorService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res => {
      this.selectedcoursedurationbyschoolname = res;
      this.selectCourse=res;
    });
  }
  filterByCourse(value:any){
    this.selectedcoursedurationbyschoolname=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  //autocomplete
  getSelectedTraineeByPno(pno) {
    this.subscription = this.CourseInstructorService.getSelectedTraineeByPno(pno).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  //Stop Course Instructor
  stopCourseInstructor(element) {
    this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
        this.subscription = this.CourseInstructorService.stopCourseInstructor(element.courseInstructorId).subscribe(() => {

          var baseSchoolNameId = element.baseSchoolNameId;
          var bnaSubjectNameId = element.bnaSubjectNameId;
          var bnaSemesterId = element.bnaSemesterId;
          var courseNameId = element.courseNameId;
          var courseDurationId = element.courseDurationId;
          var courseSectionId = element.courseSectionId;

          
          this.snackBar.open('Information Stop Successfully ', '', {
            
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
          if (baseSchoolNameId != null && bnaSubjectNameId != null && bnaSemesterId != null && courseNameId != null) {

            this.subscription = this.CourseInstructorService.getInstructorListForBnaByParameters(baseSchoolNameId,bnaSubjectNameId, bnaSemesterId, courseNameId,courseDurationId,courseSectionId).subscribe(res => {
              this.GetInstructorByParameters = res;
            });
          }
        })
      }
    })
  }

  //Running Course Instructor
  RunningCourseInstructor(element) {

    this.subscription = this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
        

        this.subscription = this.CourseInstructorService.RunningCourseInstructor(element.courseInstructorId).subscribe(() => {

          var baseSchoolNameId = element.baseSchoolNameId;
          var bnaSubjectNameId = element.bnaSubjectNameId;
          var bnaSemesterId = element.bnaSemesterId;
          var courseNameId = element.courseNameId;
          var courseDurationId = element.courseDurationId;
          var courseSectionId = element.courseSectionId;
          
          
          this.snackBar.open('Instructor Running Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });

          if (baseSchoolNameId != null && bnaSubjectNameId != null && bnaSemesterId != null && courseNameId != null) {

            this.subscription = this.CourseInstructorService.getInstructorListForBnaByParameters(baseSchoolNameId,bnaSubjectNameId, bnaSemesterId, courseNameId,courseDurationId,courseSectionId).subscribe(res => {
              this.GetInstructorByParameters = res;
            });
          }
        })

        
      }
    })
  }

  //autocomplete
  onTraineeSelectionChanged(item) {
    this.traineeId=item.value;
    this.CourseInstructorForm.get('traineeId')?.setValue(item.value);
    this.CourseInstructorForm.get('traineeName')?.setValue(item.text);
  }

  onBaseNameSelectionChangeGetModule(dropdown) {
    
    if (dropdown.isUserInput) {
      
      var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.source.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];

      this.CourseInstructorForm.get('courseName')?.setValue(dropdown.text);
      this.CourseInstructorForm.get('courseNameId')?.setValue(courseNameId);
      this.CourseInstructorForm.get('courseDurationId')?.setValue(courseDurationId);

      // if (baseSchoolNameId != null && courseNameId != null) {
      //   this.CourseInstructorService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {
      //     this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;
      //   });
      // }
    }
  }

  getCourseModuleOnEdit(baseSchoolNameId, courseNameId){
    this.subscription = this.CourseInstructorService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId, courseNameId).subscribe(res => {
      this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;
    });
  }

  getSelectedModule() {
    this.CourseInstructorService.getSelectedModule().subscribe(res => {
      this.selectedModule = res
    });
  }
  getSelectedBnaSemester(){
    this.subscription = this.CourseInstructorService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
      this.selectSemester=res
    });
  } 
  filterBySemester(value:any){
    this.selectedSemester=this.selectSemester.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  getSelectedSubjectCurriculum(){
    this.subscription = this.CourseInstructorService.getSelectedSubjectCurriculum().subscribe(res=>{
      this.selectedSubjectCurriculum=res
      this.selectCurriculum=res
    });
  } 
  filterByCurriculum(value:any){
    this.selectedSubjectCurriculum=this.selectCurriculum.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  onStatus(dropdown) {
    if (dropdown.isUserInput) {
      this.department = dropdown.source.value;
    }
  }
  getSelectedDepartment(){
    this.subscription = this.CourseInstructorService.getSelectedDepartment().subscribe(res=>{
      this.selectedDepartment=res;     
    })
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
    // var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    // var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    // var courseModuleId = this.CourseInstructorForm.value['courseModuleId'];
    var bnaSemesterId=this.CourseInstructorForm.value['bnaSemesterId'];  
    var bnaSubjectCurriculumId=this.CourseInstructorForm.value['bnaSubjectCurriculumId'];  
    this.subscription = this.CourseInstructorService.getselectedbnasubjectnamebybnaSemesterIdAndSubjectCurriculumId(bnaSemesterId,bnaSubjectCurriculumId).subscribe(res => {
      this.selectedsubjectname = res;
      this.selectSubject=res
    });
  }
  filterBySubject(value:any){
    this.selectedsubjectname=this.selectSubject.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getSelectSection(){
   // var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    //var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    
    this.subscription = this.CourseInstructorService.getselectedcoursedurationForBna().subscribe(res=>{
      this.selectedCourseSection=res;
      this.selectSection=res
    });
  }
  filterBySection(value:any){
    this.selectedCourseSection=this.selectSection.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }


  onSectionChangeGetInstructorList() {
    var baseSchoolNameId = this.CourseInstructorForm.value['baseSchoolNameId'];
    var bnaSubjectNameId = this.CourseInstructorForm.value['bnaSubjectNameId'];
    var bnaSemesterId = this.CourseInstructorForm.value['bnaSemesterId'];
    var courseNameId = this.CourseInstructorForm.value['courseNameId'];
    var courseDurationId = this.CourseInstructorForm.value['courseDurationId'];
    var courseSectionId = this.CourseInstructorForm.value['courseSectionId'];
    
    this.subscription = this.ClassRoutineService.getselectedmarktypeForBna(bnaSubjectNameId).subscribe(res=>{
      this.selectedmarktype=res;
      this.selectMarkType=res;
    });
 


    this.isShown = true;
    if (baseSchoolNameId != null && bnaSubjectNameId != null && bnaSemesterId != null && courseNameId != null && courseSectionId != null) {

      this.subscription = this.CourseInstructorService.getInstructorListForBnaByParameters(baseSchoolNameId,bnaSubjectNameId, bnaSemesterId, courseNameId,courseDurationId,courseSectionId).subscribe(res => {
        this.GetInstructorByParameters = res;
        
      });
    }
  }
  filterByMark(value:any){
    this.selectedmarktype=this.selectMarkType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  onSubjectMarkSelectionGetMarkType(){
    var subjectMarkId = this.CourseInstructorForm.value['subjectMarkId'];
    this.subscription = this.ClassRoutineService.findSubjectMark(subjectMarkId).subscribe(res=>{
      this.CourseInstructorForm.get('markTypeId')?.setValue(res.markTypeId);
    });

  }
  GetInstructorListAfterDelete(baseSchoolNameId, bnaSubjectNameId, bnaSemesterId, courseNameId, courseDurationId,courseSectionId) {
    this.isShown = true;
    if (baseSchoolNameId != null && bnaSubjectNameId != null && bnaSemesterId != null && courseNameId != null) {

      this.subscription = this.CourseInstructorService.getInstructorListForBnaByParameters(baseSchoolNameId,bnaSubjectNameId, bnaSemesterId, courseNameId,courseDurationId,courseSectionId).subscribe(res => {
        this.GetInstructorByParameters = res;
      });
    }
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  deleteItem(row) {
    const id = row.courseInstructorId;
    var baseSchoolNameId = row.baseSchoolNameId;
    var bnaSubjectNameId = row.bnaSubjectNameId;
    var courseModuleId = row.courseModuleId;
    var courseNameId = row.courseNameId;
    var courseDurationId = row.courseDurationId;
    var courseSectionId = row.courseSectionId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.CourseInstructorService.delete(id).subscribe(() => {
          this.GetInstructorListAfterDelete(baseSchoolNameId, bnaSubjectNameId, courseModuleId, courseNameId,courseDurationId,courseSectionId);
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

  // getselectedbnasubjectname(){
  //   this.CourseInstructorService.getselectedbnasubjectname().subscribe(res=>{
  //     this.selectedsubjectname=res;
  //   });
  // } 

  onSubmit() {
    this.loading = true;
    const id = this.CourseInstructorForm.get('courseInstructorId')?.value;
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.CourseInstructorService.update(+id, this.CourseInstructorForm.value).subscribe(response => {
            this.router.navigateByUrl('/subject-management/add-subjectinstructor');
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

    else {
      this.loading = true;
      this.subscription = this.CourseInstructorService.submit(this.CourseInstructorForm.value).subscribe(response => {
        //this.router.navigateByUrl('/subject-management/subjectinstructor-list');
        this.onSectionChangeGetInstructorList();
        this.reloadCurrentRoute();
        this.CourseInstructorForm.reset();
        this.CourseInstructorForm.get('courseInstructorId')?.setValue(0);
        this.CourseInstructorForm.get('isActive')?.setValue(true);
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

  }
}
