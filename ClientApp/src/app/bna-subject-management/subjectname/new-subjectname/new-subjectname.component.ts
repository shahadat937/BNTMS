import { Component, OnInit } from '@angular/core';
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
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-subjectname',
  templateUrl: './new-subjectname.component.html',
  styleUrls: ['./new-subjectname.component.sass']
})
export class NewSubjectnameComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  pageTitle: string; 
  destination:string;
  btnText:string;
  BNASubjectNameForm: FormGroup;
  buttonText:string;
  validationErrors: string[] = [];
  selectedSemester:SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectedCourseName:SelectedModel[];
  selectedSubjectCategory:SelectedModel[];
  selectedSubjectCurriculum:SelectedModel[];
  selectedSubjectType:SelectedModel[];
  selectedKindOfSubject:SelectedModel[];
  selectedSubjectClassification:SelectedModel[];
  selectedResultStatus:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  selectedCourseByParameterRequest:BNASubjectName[];
  courseNameId:number;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;

  status=2;
  isShown: boolean = false ;
  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  displayedColumns: string[] = ['ser','subjectName','subjectCode','subjectType','kindOfSubject','totalMark','passMarkBna',/*'bnaSemesterId','courseNameId','isActive',*/ 'actions'];
  constructor(private snackBar: MatSnackBar,private authService:AuthService, private confirmService: ConfirmService,private CourseNameService: CourseNameService,private CodeValueService:CodeValueService,private BNASubjectNameService: BNASubjectNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) {
    super();
  }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('bnaSubjectNameId'); 
    if (id) {
      this.pageTitle = 'Edit Subject Name';
      this.destination = "Edit";
      this.buttonText= "Update"
      this.BNASubjectNameService.find(+id).subscribe(
        res => {
          this.BNASubjectNameForm.patchValue({          

            bnaSubjectNameId: res.bnaSubjectNameId,
           //bnaSemesterId: res.bnaSemesterId,
            courseModuleId:res.courseModuleId,
           // subjectCategoryId:res.subjectCategoryId,
            //bnaSubjectCurriculumId:res.bnaSubjectCurriculumId,
            courseNameId:res.courseNameId,
            resultStatusId:res.resultStatusId,
            subjectTypeId:res.subjectTypeId,
            kindOfSubjectId:res.kindOfSubjectId,
            baseSchoolNameId:res.baseSchoolNameId,
          //  subjectClassificationId:res.subjectClassificationId,
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
            course:res.courseName,
            isActive:res.isActive,
            subjectActiveStatus:res.subjectActiveStatus
            //menuPosition: res.menuPosition,
          
          });   
          this.courseNameId = res.courseNameId;  
        }
      );
    } else {
      this.pageTitle = 'Create Subject Name';
      this.destination = "Add";
      this.buttonText= "Save"
    }
    if(this.role === 'Super Admin'){
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
    //this.getSelectedModule();

    this.intitializeForm();
  }
  intitializeForm() {
    this.BNASubjectNameForm = this.fb.group({
      bnaSubjectNameId: [0],
      //bnaSemesterId: [''],
      courseModuleId:[''],
     // subjectCategoryId: ['1'],
     // bnaSubjectCurriculumId: ['2'],
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
      subjectActiveStatus:[0],
      subjectCode:[''],
      totalMark:[''],
      passMarkBna:[''],
      passMarkBup:[''],
      classTestMark:[''],
      assignmentMark:[''],
      caseStudyMark:[''],
      totalPeriod:[''],
      isActive: [true],
      status:[this.status]
    })
    this.BNASubjectNameForm.get('course')?.valueChanges
    .subscribe(value => {
        this.getSelectedCourseAutocomplete(value);
    })
  }

  onBaseNameSelectionChangeGetModule(){
   var baseSchoolNameId=this.BNASubjectNameForm.value['baseSchoolNameId'];
   var courseNameId=this.BNASubjectNameForm.value['courseNameId'];
    
    if(baseSchoolNameId != null && courseNameId != null){
      this.BNASubjectNameService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseModuleByBaseSchoolAndCourseNameId=res;     
      });
    }  
  }


  onModuleSelectionChangeGetsubjectList(){
    var baseSchoolNameId=this.BNASubjectNameForm.value['baseSchoolNameId'];
    var courseNameId=this.BNASubjectNameForm.value['courseNameId'];
    var courseModuleId=this.BNASubjectNameForm.value['courseModuleId'];
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && courseModuleId !=null){
      this.BNASubjectNameService.getSelectedCourseByParameters(baseSchoolNameId,courseNameId,courseModuleId,this.status).subscribe(res=>{
        this.selectedCourseByParameterRequest=res;  
      }); 
    }
  }

  //autocomplete
  onCourseSelectionChanged(item) {
    if(this.role === 'Super Admin'){
      this.BNASubjectNameForm.get('baseSchoolNameId')?.setValue(this.branchId);
    } 
    this.courseNameId = item.value 
    this.BNASubjectNameForm.get('courseNameId')?.setValue(item.value);
    this.BNASubjectNameForm.get('course')?.setValue(item.text);
    this.onBaseNameSelectionChangeGetModule();
  }
  getSelectedCourseAutocomplete(cName){
    this.CourseNameService.getSelectedCourseByName(cName).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  getSelectedCourseModule(){
    this.BNASubjectNameService.getSelectedCourseModule().subscribe(res=>{
      this.selectedCourseModule=res;     
    })
  }

  getSelectedResultStatus(){
    this.CodeValueService.getSelectedCodeValueByType(this.masterData.codevaluetype.ResultStatus).subscribe(res=>{
      this.selectedResultStatus=res;     
    })
  }
  
  getSelectedBnaSemester(){
    this.BNASubjectNameService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
    });
  } 
  getSelectedSchoolName(){
    this.BNASubjectNameService.getSelectedSchoolName().subscribe(res=>{
      this.selectedSchoolName=res
    });
  }

  getSelectedCourseName(){
    this.BNASubjectNameService.getSelectedCourseName().subscribe(res=>{
      this.selectedCourseName=res
    });
  }
 
  getSelectedSubjectCategory(){
    this.BNASubjectNameService.getSelectedSubjectCategory().subscribe(res=>{
      this.selectedSubjectCategory=res
    });
  }
 
  getSelectedSubjectCurriculum(){
    this.BNASubjectNameService.getSelectedSubjectCurriculum().subscribe(res=>{
      this.selectedSubjectCurriculum=res
    });
  } 

  getSelectedSubjectType(){
    this.BNASubjectNameService.getSelectedSubjectType().subscribe(res=>{
      this.selectedSubjectType=res
    });
  }
 
  getSelectedKindOfSubject(){
    this.BNASubjectNameService.getSelectedKindOfSubject().subscribe(res=>{
      this.selectedKindOfSubject=res
    });
  }

  getSelectedSubjectClassification(){
    this.BNASubjectNameService.getSelectedSubjectClassification().subscribe(res=>{
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
        this.BNASubjectNameService.delete(id).subscribe(() => {
          this.SubjectListonDelete(baseSchoolNameId,courseNameId,courseModuleId);
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
    const id = this.BNASubjectNameForm.get('bnaSubjectNameId')?.value;
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.BNASubjectNameService.update(+id,this.BNASubjectNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/bna-subject-management/add-subjectname');            
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
      this.loading=true;
      this.BNASubjectNameService.submit(this.BNASubjectNameForm.value).subscribe(response => {
        // this.router.navigateByUrl('/bna-subject-management/subjectname-list');
        this.onModuleSelectionChangeGetsubjectList();
        this.BNASubjectNameForm.reset();
        this.BNASubjectNameForm.get('bnaSubjectNameId')?.setValue(0);
        this.BNASubjectNameForm.get('isActive')?.setValue(true);
        this.BNASubjectNameForm.get('status')?.setValue(this.status);        
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
