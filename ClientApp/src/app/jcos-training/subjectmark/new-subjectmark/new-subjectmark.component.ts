import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,  } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from '../../../core/models/selectedModel';
import { SubjectMark } from '../../models/SubjectMark';
import {MasterData} from '../../../../../src/assets/data/master-data';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-subjectmark',
  templateUrl: './new-subjectmark.component.html',
  styleUrls: ['./new-subjectmark.component.sass']
})
export class NewSubjectMarkComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  pageTitle: string;
  destination:string;
  btnText:string;
  branchId:number;
  SubjectMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedmarktype:SelectedModel[];
  selectMarkType: SelectedModel[];
  selectedSchoolName:SelectedModel[];
  selectedSaylorBranch:SelectedModel[];
  selectSaylor: SelectedModel[]
  selectedSaylorSubBranch:SelectedModel[];
  selectSylorSub: SelectedModel[]
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectedSubjectValue:SelectedModel[];
  selectSubjectName: SelectedModel[]
  selectedBranch:SelectedModel[];
  courseNameId:number;
  isShown: boolean = false ;
  selectedSubjectMark:SubjectMark[];
  selectedCourseDurationByCourseTypeAndCourseName:SelectedModel[];
  courseTypeId:any;

  options = [];
  filteredOptions;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser', 'markType', 'mark', 'passMark', 'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private BNAExamMarkService: BNAExamMarkService,private confirmService: ConfirmService,private SubjectMarkService: SubjectMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('subjectMarkId'); 
    if (id) {
      this.pageTitle = 'Edit JCOs Training Subject Mark';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.subscription = this.SubjectMarkService.find(+id).subscribe(
        res => {
          this.SubjectMarkForm.patchValue({          

            subjectMarkId: res.subjectMarkId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId:  res.courseNameId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            branchId:res.branchId,
            saylorBranchId:res.saylorBranchId,
            saylorSubBranchId:res.saylorSubBranchId,
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
          this.courseNameId = res.courseNameId; 
          this.onSelectedSubjectNameBySubBranchId(res.branchId);
          this.onBranchSelectionChangegetSubBranch(res.saylorBranchId)    
        }
      );
    } else {
      this.pageTitle = 'Create JCOs Training Subject Mark';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    this.getSelectedBranch();
    //this.getSelectedSubjectNameByBranchId();
    this.getSelectedKindOfSubject();
    this.getSelectedSchoolName();
    this.getSelectedCourseDurationByCourseTypeIdAndCourseNameId();
    this.getSelectedSubjectNameByCourseNameId();
    this.getselectedSaylorBranch();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.SubjectMarkForm = this.fb.group({
      subjectMarkId: [0],
      baseSchoolNameId: [''],
      courseNameId:  [''],
      course:[''],
      courseNames:[''],
      bnaSubjectNameId:[],
      branchId:[17],
      saylorBranchId:[],
      saylorSubBranchId:[],
      courseModuleId: [],
      markTypeId: [],
      passMark: [],
      mark: [],
      remarks:[''],    
      status:[],
      menuPosition:[],
      isActive: [true],
    })
    this.subscription = this.SubjectMarkForm.get('course')?.valueChanges
    .subscribe(value => {
     
        this.getSelectedCourseAutocomplete(value);
    })
  }

  getSelectedCourseDurationByCourseTypeIdAndCourseNameId(){
    this.subscription = this.BNAExamMarkService.getSelectedCourseDurationByCourseTypeIdAndCourseNameId(MasterData.coursetype.CentralExam,MasterData.courseName.JCOsTraining).subscribe(res => {
      this.selectedCourseDurationByCourseTypeAndCourseName = res;
    });
  }
  getSelectedSubjectNameByCourseNameId(){
    this.subscription = this.SubjectMarkService.getSelectedSubjectNameByCourseNameId(MasterData.courseName.JCOsTraining).subscribe(res=>{
      this.selectedsubjectname=res;
    });
  }
  getselectedSaylorBranch(){
    this.subscription = this.SubjectMarkService.getselectedSaylorBranch().subscribe(res=>{
      this.selectedSaylorBranch=res
     this.selectSaylor = res
    });
  }
  onBranchSelectionChangegetSubBranch(saylorBranchId){
    var saylorBranchId
    this.subscription = this.SubjectMarkService.getselectedSaylorSubBranch(saylorBranchId).subscribe(res=>{
      this.selectedSaylorSubBranch=res
      this.selectSylorSub = res
    });
  }
  filterBySaylorSub(value:any){
    this.selectedSaylorSubBranch=this.selectSylorSub.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSelectedBranch() {
    this.subscription = this.SubjectMarkService.getSelectedBranch().subscribe(res => {
      this.selectedBranch = res
    });
  }
  filterBySaylor(value:any){
    this.selectedSaylorBranch=this.selectSaylor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onSelectedSubjectNameBySubBranchId(saylorSubBranchId) {
    this.subscription = this.SubjectMarkService.getSelectedSubjectNameByBranchId(saylorSubBranchId).subscribe(res => {
      this.selectedSubjectValue = res
    });
  }
  onCourseNameSelectionChangeGetSelectedSubjectNameList(dropdown){
    var item=dropdown.source.value.value;
    var courseNameArr = item.split('_');
    this.courseTypeId = courseNameArr[0];
    var courseNameId =courseNameArr[1];
  
    this.SubjectMarkForm.get('courseNameId')?.setValue(courseNameId);

    
  }
    

  onsubjectSelectionChangeGetsubjectMarkList(){
    var courseNameId=MasterData.courseName.JCOsTraining;
    this.SubjectMarkForm.get('courseNameId')?.setValue(courseNameId);
    // var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];
    var bnaSubjectNameId=this.SubjectMarkForm.value['bnaSubjectNameId'];
    this.isShown=true;
    if(courseNameId != null  && bnaSubjectNameId !=null){
      this.subscription = this.SubjectMarkService.getSelectedSubjectMarkByCourseNameIdAndBnaSubjectNameId(courseNameId,bnaSubjectNameId).subscribe(res=>{
        this.selectedSubjectMark=res;  
      }); 
    }
  }

  getselectedbnasubjectname(){
    var baseSchoolNameId=this.SubjectMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.SubjectMarkForm.value['courseNameId'];
    var courseModuleId=this.SubjectMarkForm.value['courseModuleId'];    
    this.subscription = this.SubjectMarkService.getselectedbnasubjectnamebyparameters(baseSchoolNameId,courseNameId,courseModuleId).subscribe(res=>{
      this.selectedsubjectname=res;
    });
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
      this.selectMarkType  = res
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
    this.courseNameId = item.value 
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
          this.loading=true;
          this.subscription = this.SubjectMarkService.update(+id,this.SubjectMarkForm.value).subscribe(response => {
            this.router.navigateByUrl('/jcos-training/add-jcostrainingubjectmark');
            
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
      this.loading=true;
      this.subscription = this.SubjectMarkService.submit(this.SubjectMarkForm.value).subscribe(response => {
        // this.router.navigateByUrl('/jcos-training/add-subjectmark');
        this.reloadCurrentRoute();
        this.onsubjectSelectionChangeGetsubjectMarkList();
        this.SubjectMarkForm.reset();
        this.SubjectMarkForm.get('subjectMarkId')?.setValue(0);
        this.SubjectMarkForm.get('isActive')?.setValue(true);
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
          this.reloadCurrentRoute();
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
