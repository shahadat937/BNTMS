import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {ClassRoutineService} from '../../../routine-management/service/classroutine.service'
import { SelectedModel } from '../../../core/models/selectedModel';
import {CodeValueService} from '../../../basic-setup/service/codevalue.service';
import {MasterData} from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import{ConfirmService} from '../../../../../src/app/core/service/confirm.service';
import { ClassRoutine } from '../../../routine-management/models/classroutine';
import {ClassPeriodService} from '../../../routine-management/service/classperiod.service'
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { BNASubjectNameService } from '../../service/BNASubjectName.service'
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SubjectMarkService } from '../../service/SubjectMark.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-classroutine',
  templateUrl: './new-classroutine.component.html',
  styleUrls: ['./new-classroutine.component.sass']
}) 
export class NewClassRoutineComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  ClassRoutineForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschool:SelectedModel[];
  selectedclasstype:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selectedclassperiod:SelectedModel[];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectedWeek:SelectedModel[];
  selectedSchool:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedModule:SelectedModel[];
  selectedcoursename:SelectedModel[];
  selectedSubjectNameByCourseNameId:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  routineCount:number;
  selectedSubjectValue:SelectedModel[];
  selectedBranch:SelectedModel[];
  courseName:any;
  qexamRoutineList:any;
  weekName:any;
  courseDurationId:any;
  durationId:any;
  courseId:any;
  selectedCourseDurationByCourseTypeAndCourseName:SelectedModel[];
  isLoading = false;
  selectMarkType : any;
  subscription : any;
  showEditBtn = false;
    
  displayedColumnsList: string[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  searchText="";

  displayedColumns: string[];

  dataSource: MatTableDataSource<ClassRoutine> = new MatTableDataSource();
  schoolId:any;
  
  
  weekId:any;

  totalPeriod:string;
  selectedRoutineByParameters:ClassRoutine[];
  selectedRoutineByParametersAndDate:ClassRoutine[];
  traineeListByBaseSchoolAndCourse:any[];
  periodListByBaseSchoolAndCourse:any[];
  selectedRoutineByParameter:any;
  subjectlistBySchoolAndCourse:any;
  isShown: boolean = false ;
  groupArrays:{ date: string; games: any; }[];
  // displayedRoutineCountColumns: string[] = ['ser','name','shortCode'];
  // displayedSubjectListColumns: string[] = ['ser','subjectName','subjectShortName'];
  // displayedPeriodListColumns: string[] = ['ser','periodName','duration'];

  constructor(private snackBar: MatSnackBar,private SubjectMarkService: SubjectMarkService,private subjectNameService: BNASubjectNameService, private BNAExamMarkService: BNAExamMarkService, private ClassPeriodService: ClassPeriodService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private ClassRoutineService: ClassRoutineService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('classRoutineId'); 
    if (id) {
      this.pageTitle = 'Edit Class Routine'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.ClassRoutineService.find(+id).subscribe(
        res => {
          this.ClassRoutineForm.patchValue({          
            classRoutineId:res.classRoutineId, 
            courseModuleId:res.courseModuleId,
            courseNameId:res.courseNameId,
            classPeriodId: res.classPeriodId, 
            baseSchoolNameId:res.baseSchoolNameId, 
            courseDurationId:res.courseDurationId, 
            bnaSubjectNameId:res.bnaSubjectNameId,
            branchId:res.branchId,
            courseWeekId:res.courseWeekId,
            classTypeId:res.classTypeId,
            date:res.date,
            classLocation:res.classLocation,
            remarks:res.remarks,
            isApproved:res.isApproved,
            approvedDate:res.approvedDate,
            approvedBy:res.approvedBy,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
            
          });  
          
          var editArr = [res.courseDurationId, res.courseNameId, res.baseSchoolNameId];
          this.getselectedcoursedurationbyschoolname()
          this.getselectedbnasubjectname(editArr)
        }
      );
    } else {
      this.pageTitle = 'Create Class Routine';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getSelectedBranch();
    this.getselectedbaseschools();
    this.getselectedclasstype();
    this.getselectedCourseModules();
    this.getselectedcoursename();


    this.getSelectedCourseDurationByCourseTypeIdAndCourseNameId();
  }
  intitializeForm() {
    this.ClassRoutineForm = this.fb.group({
      classRoutineId: [0],
      courseModuleId:[],
      courseName:[''],
      courseNameId:[],
      classPeriodId:[''],
      baseSchoolNameId:[''],
      courseDurationId:[],
      subjectName:[''],
      timeDuration:[''],
      subjectMarkId: [''],
      markTypeId : [''],
      bnaSubjectNameId:[],
      courseWeekId:[],
      branchId:[],
      examMarkComplete:[0],
      classTypeId:[this.masterData.classType.Exam],
      classCountPeriod:[],
      subjectCountPeriod:[],
      date:[], 
      classLocation:[''],
      remarks:[''],
      isApproved:[true],
      approvedDate:[],
      approvedBy:[],
      status:[1],
      isActive: [true],    
    })
  }


  getSelectedBranch() {
    this.SubjectMarkService.getSelectedBranch().subscribe(res => {
      this.selectedBranch = res
    });
  }
  getSelectedCourseDurationByCourseTypeIdAndCourseNameId(){
    this.BNAExamMarkService.getSelectedCourseDurationByCourseTypeIdAndCourseNameId(MasterData.coursetype.CentralExam,MasterData.courseName.QExam).subscribe(res => {
      this.selectedCourseDurationByCourseTypeAndCourseName = res;
    });
  }

  onSelectedSubjectNameByBranchId(branchId) {
    this.SubjectMarkService.getSelectedSubjectNameByBranchId(branchId).subscribe(res => {
      this.selectedSubjectValue = res
    });
  }

  onCourseNameSelectionChangeGetSubjectList(dropdown){
    if (dropdown.isUserInput) {
      var courseNameArr = dropdown.source.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId = courseNameArr[1];

      this.durationId = courseDurationId;
      this.courseId = courseNameId;

      this.ClassRoutineForm.get('courseNameId')?.setValue(courseNameId);
      this.ClassRoutineForm.get('courseDurationId')?.setValue(courseDurationId);

      this.subjectNameService.getSelectedSubjectNameByCourseNameId(courseNameId).subscribe(res => {
        this.selectedSubjectNameByCourseNameId = res;
      });

      this.isLoading = true;
      this.ClassRoutineService.getClassRoutinesByCourseDurationId(this.paging.pageIndex, this.paging.pageSize,this.searchText,courseDurationId).subscribe(response => {  

        this.dataSource.data = response.items; 
        this.paging.length = response.totalItemsCount    
        this.isLoading = false;
     
          this.showEditBtn = this.dataSource.data.length ? true : false;
        
      })
      this.ClassRoutineService.getQexamRoutine(courseDurationId).subscribe(response => {     
        this.qexamRoutineList=response;

        for(let i=0;i<=this.qexamRoutineList.length;i++){

         }
 
         this.displayedColumns =[...Object.keys(this.qexamRoutineList[0]).filter(column => column !== 'menuPosition')];
         
 
      })
    }
  }

  onSubjectMarkSelectionGetMarkType(event){

    let subjectMarkId = event.source.value;
   
      this.ClassRoutineService.findSubjectMark(subjectMarkId).subscribe(res=>{
      this.ClassRoutineForm.get('markTypeId')?.setValue(res.markTypeId);
      });
   
    }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
   // this.getClassRoutines();
 
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    //this.getClassRoutines();
  } 

  onSubjectNameSelectionChangeGet(dropdown){
    var bnaSubjectNameId = dropdown.source.value.value;
    this.ClassRoutineForm.get('subjectName')?.setValue(bnaSubjectNameId);
    this.ClassRoutineForm.get('bnaSubjectNameId')?.setValue(bnaSubjectNameId);

    this.subscription = this.ClassRoutineService.getselectedmarktype(bnaSubjectNameId).subscribe(res=>{
      // this.selectedmarktype[bnaSubjectNameId]=res;
      this.selectMarkType=res
    });
}


  getselectedbaseschools(){
    this.ClassRoutineService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
    });
  }  

  getselectedcoursedurationbyschoolname(){
      var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
      this.ClassRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
        this.selectedcoursedurationbyschoolname=res;
      });
  } 

  getselectedbnasubjectname(dropdown){
    const id = this.route.snapshot.paramMap.get('classRoutineId'); 
    if(id){
      var courseDurationId = dropdown[0];
      var courseNameId=dropdown[1];
      var baseSchoolNameId=dropdown[2];
    }else{
      var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];
      this.courseName=dropdown.text;
      this.ClassRoutineForm.get('courseName')?.setValue(dropdown.text);
      this.ClassRoutineForm.get('courseNameId')?.setValue(courseNameId);
      this.ClassRoutineForm.get('courseDurationId')?.setValue(courseDurationId);
    } 
    
    this.ClassRoutineService.getSelectedCourseWeeks(baseSchoolNameId,courseDurationId,courseNameId).subscribe(res=>{
      this.selectedWeek=res;
    });    
  } 

  getselectedCourseModules(){
    this.ClassRoutineService.getselectedCourseModules().subscribe(res=>{
      this.selectedCourseModule=res;
    });
  } 

  

  getselectedcoursename(){
    this.ClassRoutineService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res;
    });
  } 

  getselectedclasstype(){
    this.ClassRoutineService.getselectedclasstype().subscribe(res=>{
      this.selectedclasstype=res;
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  

  onSubmit() {
    const id = this.ClassRoutineForm.get('classRoutineId')?.value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.ClassRoutineService.update(+id,this.ClassRoutineForm.value).subscribe(response => {
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
    }else {
      this.loading=true;
      this.ClassRoutineService.submitCentralExamRoutine(this.ClassRoutineForm.value).subscribe(response => {
        
        this.reloadCurrentRoute();
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

  deleteItem(row) {
    const id = row.classRoutineId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.ClassRoutineService.delete(id).subscribe(() => {
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
}
