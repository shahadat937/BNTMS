import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { SubjectMark } from '../../models/SubjectMark';
import { MasterData } from 'src/assets/data/master-data';
import { AuthService } from 'src/app/core/service/auth.service';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-bnasubjectmark',
  templateUrl: './new-bnasubjectmark.component.html',
  styleUrls: ['./new-bnasubjectmark.component.sass']
})
export class NewBnaSubjectMarkComponent implements OnInit , OnDestroy {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  pageTitle: string;
  destination:string;
  btnText:string;
  SubjectMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedmarktype:SelectedModel[];
  selectMark:SelectedModel[];
  selectedmarkCategory:SelectedModel[];
  selectCategory:SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectSubjectName:SelectedModel[];
  selectedSemester:SelectedModel[];
  selectSemester:SelectedModel[]
  selectedSubjectCurriculum:SelectedModel[];
  selectCurriculum:SelectedModel[];
  courseNameId:number;
  isShown: boolean = false ;
  numberShown: boolean = false ;
  subTotalMark:any;
  selectedSubjectMark:SubjectMark[];
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  courseModuleId:number;

  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'subjectCurriculumName','markCategory','markType', 'mark', 'passMark', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private bnaSubjectNameService:BNASubjectNameService,private confirmService: ConfirmService,private SubjectMarkService: SubjectMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('subjectMarkId'); 
    if (id) {
      this.pageTitle = 'Edit BNA Subject Mark';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.subscription = this.SubjectMarkService.find(+id).subscribe(
        res => {
          this.SubjectMarkForm.patchValue({          

            subjectMarkId: res.subjectMarkId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId:  res.courseNameId,
            bnaSemesterId:res.bnaSemesterId,
            bnaSubjectCurriculumId:res.bnaSubjectCurriculumId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            courseModuleId: res.courseModuleId,
            markTypeId: res.markTypeId,
            markCategoryId:res.markCategoryId,
            passMark: res.passMark,
            mark: res.mark,
            remarks:res.remarks,    
            status:res.status,
            menuPosition:res.menuPosition,
            course:res.courseName,
            isActive: res.isActive
            //menuPosition: res.menuPosition,         
          }); 
          this.onBaseNameSelectionChangeGetModule();
          this.getselectedbnasubjectname();
          this.courseNameId = res.courseNameId;      
        }
      );
    } else {
      this.pageTitle = 'Create BNA Subject Mark';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getSelectedKindOfSubject();
    this.getSelectedSchoolName();
    this.getSelectedBnaSemester();
    this.getselectedmarkCategory();
    this.getSelectedSubjectCurriculum();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.SubjectMarkForm = this.fb.group({
      subjectMarkId: [0],
      baseSchoolNameId: ['', Validators.required],
      courseNameId:  [],
      bnaSemesterId:[],
      bnaSubjectCurriculumId:[],
      course:[''],
      bnaSubjectNameId:[],
      courseModuleId: [],
      markTypeId: [],
      markCategoryId:[],
      passMark: [],
      mark: [],
      remarks:[''],    
      status:[],
      menuPosition:[],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    })
    this.SubjectMarkForm.get('course').valueChanges
    .subscribe(value => {
     
        this.getSelectedCourseAutocomplete(value);
    })
  }

  onsubjectSelectionChangeGetsubjectMarkList(){
    var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.SubjectMarkForm.value['courseNameId'];
    //var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];
    var bnaSemesterId=this.SubjectMarkForm.value['bnaSemesterId'];
    var bnaSubjectNameId=this.SubjectMarkForm.value['bnaSubjectNameId'];
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && bnaSemesterId !=null && bnaSubjectNameId !=null){
      this.SubjectMarkService.getselectedsubjectmarkbyBnaSemester(baseSchoolNameId,courseNameId,bnaSemesterId,bnaSubjectNameId).subscribe(res=>{
        this.selectedSubjectMark=res;  
      }); 
      this.bnaSubjectNameService.find(bnaSubjectNameId).subscribe(res=>{
        this.numberShown = true;
        this.subTotalMark = res.totalMark;
        // this.selectedSubjectMark=res;  
      }); 
    }
  }
  SubjectMarkListAfterDelete(baseSchoolNameId,courseNameId,courseModuleId,bnaSubjectNameId){
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && courseModuleId !=null && bnaSubjectNameId !=null){
      this.subscription = this.SubjectMarkService.getselectedsubjectmarkbyparameters(baseSchoolNameId,courseNameId,courseModuleId,bnaSubjectNameId).subscribe(res=>{
        this.selectedSubjectMark=res;  
      }); 
    }
  }
  getSelectedBnaSemester(){
    this.subscription = this.SubjectMarkService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
      this.selectSemester=res
    });
  } 
  filterBySemester(value:any){
    this.selectedSemester=this.selectSemester.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  getSelectedSubjectCurriculum(){
    this.subscription = this.SubjectMarkService.getSelectedSubjectCurriculum().subscribe(res=>{
      this.selectedSubjectCurriculum=res
      this.selectCurriculum=res
    });
  } 
  filterByCurriculum(value:any){
    this.selectedSubjectCurriculum=this.selectCurriculum.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  getSelectedKindOfSubject(){
    this.subscription = this.SubjectMarkService.getselectedmarktypes().subscribe(res=>{
      this.selectedmarktype=res
      this.selectMark=res
    });
  }
  filterByMark(value:any){
    this.selectedmarktype=this.selectMark.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getselectedmarkCategory(){
    this.subscription = this.SubjectMarkService.getselectedmarkCategory().subscribe(res=>{
      this.selectedmarkCategory=res
      this.selectCategory=res
    });
  }
  filterByCategory(value:any){
    this.selectedmarkCategory=this.selectCategory.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getSelectedSchoolName(){
    this.subscription = this.SubjectMarkService.getSelectedSchoolName().subscribe(res=>{
      this.selectedSchoolName=res
    });
  }

  

  //autocomplete
  onCourseSelectionChanged(item) {
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.SubjectMarkForm.get('baseSchoolNameId').setValue(this.branchId);
    }
    this.courseNameId = item.value 
    this.SubjectMarkForm.get('courseNameId').setValue(item.value);
    this.SubjectMarkForm.get('course').setValue(item.text);
    this.onBaseNameSelectionChangeGetModule();
  }
  getSelectedCourseAutocomplete(cName){
    this.subscription = this.SubjectMarkService.getSelectedCourseByName(cName).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }

  onBaseNameSelectionChangeGetModule(){
    var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.SubjectMarkForm.value['courseNameId'];
     
    if(baseSchoolNameId != null && courseNameId != null){
      this.subscription = this.SubjectMarkService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedCourseModuleByBaseSchoolAndCourseNameId=res;  
      });
    }  
  }

  
  getselectedbnasubjectname(){
    // var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    // var courseNameId=this.SubjectMarkForm.value['courseNameId'];
    // var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];    
    var bnaSemesterId=this.SubjectMarkForm.value['bnaSemesterId'];  
    var bnaSubjectCurriculumId=this.SubjectMarkForm.value['bnaSubjectCurriculumId'];  
    this.subscription = this.SubjectMarkService.getselectedbnasubjectnamebybnaSemesterId(bnaSemesterId,bnaSubjectCurriculumId).subscribe(res=>{
      this.selectedsubjectname=res;
      this.selectSemester=res
    });
  } 
  filterBySubject(value:any){
    this.selectedsubjectname=this.selectSubjectName.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.SubjectMarkForm.get('subjectMarkId').value;  
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.loading = true;
          this.subscription = this.SubjectMarkService.update(+id,this.SubjectMarkForm.value).subscribe(response => {
            this.router.navigateByUrl('/subject-management/add-bnasubjectmark');
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
    }  else {
      this.loading = true;
      this.subscription = this.SubjectMarkService.submit(this.SubjectMarkForm.value).subscribe(response => {
        // this.router.navigateByUrl('/subject-management/add-bnasubjectmark');
        this.onsubjectSelectionChangeGetsubjectMarkList();
        this.SubjectMarkForm.reset();
        this.SubjectMarkForm.get('subjectMarkId').setValue(0);
        this.SubjectMarkForm.get('isActive').setValue(true);
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

  deleteItem(row) {
    const id = row.subjectMarkId; 
    var baseSchoolNameId=row.baseSchoolNameId;
    var courseNameId=row.courseNameId;
    var courseModuleId=row.courseModuleId;
    var bnaSubjectNameId=row.bnaSubjectNameId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      if (result) {
        this.subscription = this.SubjectMarkService.delete(id).subscribe(() => {
          this.SubjectMarkListAfterDelete(baseSchoolNameId,courseNameId,courseModuleId,bnaSubjectNameId);
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })    
  }

}
