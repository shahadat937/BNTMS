import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { CourseNameService } from '../../../basic-setup/service/CourseName.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { ConnectedOverlayPositionChange } from '@angular/cdk/overlay';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNASubjectName } from '../../models/BNASubjectName';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { Role } from '../../../../../src/app/core/models/role';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-subjectnameforbna',
  templateUrl: './new-subjectnameforbna.component.html',
  styleUrls: ['./new-subjectnameforbna.component.sass']
})
export class NewSubjectnameforBnaComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  pageTitle: string; 
  destination:string;
  btnText:string;
  BNASubjectNameForm: FormGroup;
  buttonText:string;
  validationErrors: string[] = [];
  selectedSemester:SelectedModel[];
  selectSemester: SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectedCourseName:SelectedModel[];
  selectedSubjectCategory:SelectedModel[];
  selectSubjectCategory:SelectedModel[]
  selectedSubjectCurriculum:SelectedModel[];
  selectCurriculum:SelectedModel[];
  selectedSubjectType:SelectedModel[];
  selectSubjectType:SelectedModel[];
  selectedKindOfSubject:SelectedModel[];
  selectKindofSubject:SelectedModel[];
  selectedDepartment:SelectedModel[];
  selectedSubjectClassification:SelectedModel[];
  selectedResultStatus:SelectedModel[];
  selectResult:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  selectedCourseByParameterRequest:BNASubjectName[];
  subjectnamelist:BNASubjectName[];
  courseNameId:number;
  selected:number;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  department: any;
  status=2;
  isShown: boolean = false ;
  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  displayedColumns: string[] = ['ser','subjectName','subjectType','kindOfSubject','totalPeriod','totalMark','passMarkBna',/*'bnaSemesterId','courseNameId','isActive',*/ 'actions'];
  subscription: any;
  constructor(private snackBar: MatSnackBar,private authService:AuthService, private confirmService: ConfirmService,private CourseNameService: CourseNameService,private CodeValueService:CodeValueService,private BNASubjectNameService: BNASubjectNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('bnaSubjectNameId'); 
    if (id) {
      this.pageTitle = 'Edit Subject Name';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.subscription = this.BNASubjectNameService.find(+id).subscribe(
        res => {
          this.BNASubjectNameForm.patchValue({          

            bnaSubjectNameId: res.bnaSubjectNameId,
            bnaSemesterId:res.bnaSemesterId,
            departmentId:res.departmentId,
            courseModuleId:res.courseModuleId,
            courseNameId:res.courseNameId,
            resultStatusId:res.resultStatusId,
            subjectTypeId:res.subjectTypeId,
            kindOfSubjectId:res.kindOfSubjectId,
            baseSchoolNameId:res.baseSchoolNameId,
            subjectName:res.subjectName,
            subjectNameBangla:res.subjectNameBangla,
            subjectShortName:res.subjectShortName,
            subjectCode:res.subjectCode,
            totalMark:res.totalMark,
            passMarkBna:res.passMarkBna,
            passMarkBup:res.passMarkBup,
            classTestMark:res.classTestMark,
            assignmentMark:res.assignmentMark,
            caseStudyMark:res.caseStudyMark,
            totalPeriod:res.totalPeriod,
            subjectGreading:res.subjectGreading,
            course:res.courseName,
            isActive:res.isActive,
            menuPosition: res.menuPosition,
            subjectActiveStatus : res.subjectActiveStatus,
            contactHour:res.contactHour,
            creditHour:res.creditHour,
            subjectCategoryId : res.subjectCategoryId,
            bnaSubjectCurriculumId :res.bnaSubjectCurriculumId         
          });   
          this.onBaseNameSelectionChangeGetModule();
          this.courseNameId = res.courseNameId; 
          this.selected=res.subjectGreading;
          //this.onBaseNameSelectionChangeGetModule()
        }
      );
    } else {
      this.pageTitle = 'Create Subject Name';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    if(this.role === this.userRole.BNASchool){
      //this.onBaseNameSelectionChangeGetModule();
    }
    this.getSelectedBnaSemester();
    this.getSelectedSchoolName();
    this.getSelectedCourseName();
    this.getSelectedSubjectCategory();
    this.getSelectedSubjectCurriculum();
    this.getSelectedSubjectType();
    this.getSelectedKindOfSubject();
    this.getSelectedSubjectClassification();
    this.getSelectedResultStatus();
    this.getSelectedCourseModule();
    this.getSelectedDepartment();
    //this.getSelectedModule();

    this.intitializeForm();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.BNASubjectNameForm = this.fb.group({
      bnaSubjectNameId: [0],
      bnaSemesterId: [''],
      departmentId:[''],
      //courseModuleId:[''],
      subjectCategoryId:[''],
     // subjectCategoryId: ['1'],
      bnaSubjectCurriculumId: [''],
      courseNameId: [''],
      course:[''],
      resultStatusId: [''],
      subjectTypeId: [''],
      kindOfSubjectId: [''],
      baseSchoolNameId: [''],
   //   subjectClassificationId: ['1'],
      subjectName:[''],
      subjectNameBangla:[''],
      subjectShortName:[''],
      subjectCode:[''],
      totalMark:[''],
      passMarkBna:[''],
      passMarkBup:[''],
      classTestMark:[''],
      assignmentMark:[''],
      caseStudyMark:[''],
      totalPeriod:[''],
      subjectGreading:[],
      isActive: [true],
      status:[this.status],
      menuPosition:[],
      subjectActiveStatus:[1],
      contactHour:[],
      creditHour:[]

    })
    this.subscription = this.BNASubjectNameForm.get('course')?.valueChanges
    .subscribe(value => {
        this.getSelectedCourseAutocomplete(value);
    })
  }

  onBaseNameSelectionChangeGetModule(){
   var baseSchoolNameId=this.BNASubjectNameForm.value['baseSchoolNameId'];
   var courseNameId=this.BNASubjectNameForm.value['courseNameId'];
    
    if(baseSchoolNameId != null && courseNameId != null){
      this.subscription = this.BNASubjectNameService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseModuleByBaseSchoolAndCourseNameId=res;     
      });
    }  
  }
  // activeItem(row){
  //   const id = row.bnaSubjectNameId;    
  //   if(row.isActive == true){
  //     this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Deactive This Item').subscribe(result => {
  //       if (result) {
  //         this.BNASubjectNameService.deActiveSubjectName(id).subscribe(() => {
  //          // this.getCourseDurations();
  //           this.snackBar.open('Information Deactive Successfully ', '', {
  //             duration: 3000,
  //             verticalPosition: 'bottom',
  //             horizontalPosition: 'right',
  //             panelClass: 'snackbar-warning'
  //           });
  //         })
  //       }
  //     })
  //   }
  // }
  inActiveItem(row){
    const id = row.bnaSubjectNameId;    
    if(row.subjectActiveStatus == 0){
      this.subscription = this.confirmService.confirm('Confirm Active message', 'Are You Sure Active This Item').subscribe(result => {
        if (result) {
          this.subscription = this.BNASubjectNameService.activeSubject(id).subscribe(() => {
            this.onModuleSelectionChangeGetsubjectList();
           // this.getCourseDurations();
            this.snackBar.open('Information actived Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          })
        }
      })
    }else{
      this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Deactive This Item').subscribe(result => {
        if (result) {
          this.subscription = this.BNASubjectNameService.activeSubject(id).subscribe(() => {
            this.onModuleSelectionChangeGetsubjectList();
           // this.getCourseDurations();
            this.snackBar.open('Information Deactived Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-danger'
            });
          })
        }
      })
    }
  }

  onModuleSelectionChangeGetsubjectList(){
    var baseSchoolNameId=this.BNASubjectNameForm.value['baseSchoolNameId'];
    var courseNameId=this.BNASubjectNameForm.value['courseNameId'];
    var courseModuleId=this.BNASubjectNameForm.value['courseModuleId'];
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && courseModuleId !=null){
      this.subscription = this.BNASubjectNameService.getSelectedCourseByParameters(baseSchoolNameId,courseNameId,courseModuleId,this.status).subscribe(res=>{
        this.selectedCourseByParameterRequest=res;  
      }); 
    }
  }
  getSubjectListbyBnaSemesterId(){
    var bnaSemesterId=this.BNASubjectNameForm.value['bnaSemesterId'];
    this.isShown=true;
    this.subscription = this.BNASubjectNameService.getSubjectListbyBnaSemesterId(bnaSemesterId).subscribe(res=>{
      this.subjectnamelist=res;     
    })
  }
  onStatus(dropdown) {
    if (dropdown.isUserInput) {
      this.department = dropdown.source.value;
    }
  }

  //autocomplete
  onCourseSelectionChanged(item) {
    if(this.role === this.userRole.BNASchool){
      this.BNASubjectNameForm.get('baseSchoolNameId')?.setValue(this.branchId);
    } 
    this.courseNameId = item.value 
    this.BNASubjectNameForm.get('courseNameId')?.setValue(item.value);
    this.BNASubjectNameForm.get('course')?.setValue(item.text);
    this.onBaseNameSelectionChangeGetModule();
  }
  getSelectedCourseAutocomplete(cName){
    this.subscription = this.CourseNameService.getSelectedCourseByName(cName).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  getSelectedCourseModule(){
    this.subscription = this.BNASubjectNameService.getSelectedCourseModule().subscribe(res=>{
      this.selectedCourseModule=res;     
    })
  }
  getSelectedDepartment(){
    this.subscription = this.BNASubjectNameService.getSelectedDepartment().subscribe(res=>{
      this.selectedDepartment=res;     
    })
  }



  getSelectedResultStatus(){
    this.CodeValueService.getSelectedCodeValueByType(this.masterData.codevaluetype.ResultStatus).subscribe(res=>{
      this.selectedResultStatus=res;
      this.selectResult=res    
    })
  }
  filterByResult(value:any){
    this.selectedResultStatus=this.selectResult.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  
  getSelectedBnaSemester(){
    this.subscription = this.BNASubjectNameService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
      this.selectSemester=res
    });
  } 
  filterBySemester(value:any){
    this.selectedSemester=this.selectSemester.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  getSelectedSchoolName(){
    this.subscription = this.BNASubjectNameService.getSelectedSchoolName().subscribe(res=>{
      this.selectedSchoolName=res
    });
  }

  getSelectedCourseName(){
    this.subscription = this.BNASubjectNameService.getSelectedCourseName().subscribe(res=>{
      this.selectedCourseName=res
    });
  }
 
  getSelectedSubjectCategory(){
    this.subscription = this.BNASubjectNameService.getSelectedSubjectCategory().subscribe(res=>{
      this.selectedSubjectCategory=res
      this.selectSubjectCategory=res

    });
  }
  filterByCategory(value:any){
    this.selectedSubjectCategory=this.selectSubjectCategory.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
 
  getSelectedSubjectCurriculum(){
    this.subscription = this.BNASubjectNameService.getSelectedSubjectCurriculum().subscribe(res=>{
      this.selectedSubjectCurriculum=res
      this.selectCurriculum=res
    });
  } 

  filterBySubject(value:any){
    this.selectedSubjectCurriculum=this.selectCurriculum.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getSelectedSubjectType(){
    this.subscription = this.BNASubjectNameService.getSelectedSubjectType().subscribe(res=>{
      this.selectedSubjectType=res
      this.selectSubjectType=res
    });
  }
  filterByType(value:any){
    this.selectedSubjectType=this.selectSubjectType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
 
  getSelectedKindOfSubject(){
    this.subscription = this.BNASubjectNameService.getSelectedKindOfSubject().subscribe(res=>{
      this.selectedKindOfSubject=res
      this.selectKindofSubject=res
    });
  }
  filterByKindofSubject(value:any){
    this.selectedKindOfSubject=this.selectKindofSubject.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getSelectedSubjectClassification(){
    this.subscription = this.BNASubjectNameService.getSelectedSubjectClassification().subscribe(res=>{
      this.selectedSubjectClassification=res
    });
  }

  SubjectListonDelete(baseSchoolNameId,courseNameId,courseModuleId){
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && courseModuleId !=null){
      this.BNASubjectNameService.getSelectedCourseByParameters(baseSchoolNameId,courseNameId,courseModuleId,this.status).subscribe(res=>{
        this.selectedCourseByParameterRequest=res;  
      }); 
    }
  }

  deleteItem(row) {
    const id = row.bnaSubjectNameId; 
    var baseSchoolNameId=row.baseSchoolNameId;
    var courseNameId=row.courseNameId;
    var courseModuleId=row.courseModuleId;
    
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This BNASubjectName Item').subscribe(result => {
      if (result) {
        this.subscription = this.BNASubjectNameService.delete(id).subscribe(() => {
          this.SubjectListonDelete(baseSchoolNameId,courseNameId,courseModuleId);
          this.reloadCurrentRoute();   
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

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.BNASubjectNameForm.get('bnaSubjectNameId')?.value;
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.BNASubjectNameService.update(+id,this.BNASubjectNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/subject-management/add-subjectnameforbna');  
            //this.router.navigateByUrl('/routine-management/add-classperiod');
            //this.reloadCurrentRoute();          
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
    }else {
      this.loading = true;
      this.subscription = this.BNASubjectNameService.submit(this.BNASubjectNameForm.value).subscribe(response => {
        // this.router.navigateByUrl('/subject-management/subjectname-list');
        this.onModuleSelectionChangeGetsubjectList();
        this.BNASubjectNameForm.reset();
        this.BNASubjectNameForm.get('bnaSubjectNameId')?.setValue(0);
        this.BNASubjectNameForm.get('isActive')?.setValue(true);
        this.BNASubjectNameForm.get('status')?.setValue(this.status);   
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
 
  }

}
