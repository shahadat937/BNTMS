import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { SubjectMark } from '../../models/SubjectMark';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { Role } from '../../../../../src/app/core/models/role';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-subjectmark',
  templateUrl: './new-subjectmark.component.html',
  styleUrls: ['./new-subjectmark.component.sass']
})
export class NewSubjectMarkComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  pageTitle: string;
  destination:string;
  btnText:string;
  SubjectMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedmarktype:SelectedModel[];
  selectMarkType:SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  selectModule:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectSubject:SelectedModel[];
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

  displayedColumns: string[] = [ 'ser', 'markType', 'mark', 'passMark', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private bnaSubjectNameService:BNASubjectNameService,private confirmService: ConfirmService,private SubjectMarkService: SubjectMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    const id = this.route.snapshot.paramMap.get('subjectMarkId'); 
    if (id) {
      this.pageTitle = 'Edit Subject Mark';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.subscription = this.SubjectMarkService.find(+id).subscribe(
        res => {
          this.SubjectMarkForm.patchValue({          

            subjectMarkId: res.subjectMarkId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId:  res.courseNameId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            courseModuleId: res.courseModuleId,
            markTypeId: res.markTypeId,
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
      this.pageTitle = 'Create Subject Mark';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getSelectedKindOfSubject();
    this.getSelectedSchoolName();
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
      course:[''],
      bnaSubjectNameId:[],
      courseModuleId: [],
      markTypeId: [],
      passMark: [],
      mark: [],
      remarks:[''],    
      status:[],
      menuPosition:[],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    })
    this.subscription = this.SubjectMarkForm.get('course')?.valueChanges
    .subscribe(value => {
     
        this.getSelectedCourseAutocomplete(value);
    })
  }

  onsubjectSelectionChangeGetsubjectMarkList(){
    var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.SubjectMarkForm.value['courseNameId'];
    var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];
    var bnaSubjectNameId=this.SubjectMarkForm.value['bnaSubjectNameId'];
    this.isShown=true;
    if(baseSchoolNameId != null && courseNameId != null && courseModuleId !=null && bnaSubjectNameId !=null){
      this.SubjectMarkService.getselectedsubjectmarkbyparameters(baseSchoolNameId,courseNameId,courseModuleId,bnaSubjectNameId).subscribe(res=>{
        this.selectedSubjectMark=res;  
      }); 
      this.subscription = this.bnaSubjectNameService.find(bnaSubjectNameId).subscribe(res=>{
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

  getSelectedKindOfSubject(){
    this.subscription = this.SubjectMarkService.getselectedmarktypes().subscribe(res=>{
      this.selectedmarktype=res
      this.selectMarkType=res
    });
  }
  filterByMarkType(value:any){
    this.selectedmarktype=this.selectMarkType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSelectedSchoolName(){
    this.subscription = this.SubjectMarkService.getSelectedSchoolName().subscribe(res=>{
      this.selectedSchoolName=res
    });
  }

  

  //autocomplete
  onCourseSelectionChanged(item) {
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.SubjectMarkForm.get('baseSchoolNameId')?.setValue(this.branchId);
    }
    this.courseNameId = item.value 
    this.SubjectMarkForm.get('courseNameId')?.setValue(item.value);
    this.SubjectMarkForm.get('course')?.setValue(item.text);
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
        this.selectModule=res;
      });
    }  
  }
  filterByModule(value:any){
    this.selectedCourseModuleByBaseSchoolAndCourseNameId=this.selectModule.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  
  getselectedbnasubjectname(){
    var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.SubjectMarkForm.value['courseNameId'];
    var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];    
    this.subscription = this.SubjectMarkService.getselectedbnasubjectnamebyparameters(baseSchoolNameId,courseNameId,courseModuleId).subscribe(res=>{
      this.selectedsubjectname=res;
      this.selectSubject=res;
    });
  } 
  filterBySubject(value:any){
    this.selectedsubjectname=this.selectSubject.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.SubjectMarkForm.get('subjectMarkId')?.value;  
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        
        if (result) {
          this.loading = true;
          this.subscription = this.SubjectMarkService.update(+id,this.SubjectMarkForm.value).subscribe(response => {
            this.router.navigateByUrl('/subject-management/add-subjectmark');
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
    }  else {
      this.loading = true;
      this.subscription = this.SubjectMarkService.submit(this.SubjectMarkForm.value).subscribe(response => {
        // this.router.navigateByUrl('/subject-management/add-subjectmark');
        this.onsubjectSelectionChangeGetsubjectMarkList();
        this.SubjectMarkForm.reset();
        this.SubjectMarkForm.get('subjectMarkId')?.setValue(0);
        this.SubjectMarkForm.get('isActive')?.setValue(true);
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
        this.SubjectMarkService.delete(id).subscribe(() => {
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
