import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoutineNoteService } from '../../service/routinenote.service';
import { ClassRoutineService } from '../../service/classroutine.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { RoutineNote } from '../../models/routinenote';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { PageEvent } from '@angular/material/paginator';
import { Role } from 'src/app/core/models/role';
import { Subject, Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-routinenote',
  templateUrl: './new-routinenote.component.html',
  styleUrls: ['./new-routinenote.component.sass']
}) 
export class NewRoutineNoteComponent implements OnInit, OnDestroy {
   masterData = MasterData;
   userRole = Role;
  loading = false;
  isLoading = false;
  ELEMENT_DATA: RoutineNote[] = [];
  buttonText:string;
  pageTitle: string;
  destination:string;
  RoutineNoteForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschool:SelectedModel[];
  selectSchool:SelectedModel[];
  selectedclasstype:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selectedclassperiod:SelectedModel[];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectCourseTitle:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectedRoutineList:SelectedModel[];
  selectRoutine:SelectedModel[];
  selectedSchool:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedModule:SelectedModel[];
  selectedcoursename:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  routineCount:number;
  courseName:any;
  weekName:any;
  courseDurationId:any;
  
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;

  schoolId:any;
  durationId:any;
  courseId:any;
  weekId:any;

  totalPeriod:string;
  routineNoteList:any[];
  selectedRoutineByParametersAndDate:any[];
  traineeListByBaseSchoolAndCourse
  dataForClassRoutine:any;
  periodListByBaseSchoolAndCourse:any[];
  selectedRoutineByParameter:any;
  subjectlistBySchoolAndCourse:any;
  schoolName:any;
  courseNameTitle:any;
  weekFromDate:any;
  weekFromTo:any;
  selectedWeek:any;
  selectWeek:SelectedModel[];
  isShown: boolean = false ;
  groupArrays:{ date: string; games: any; }[];
  displayedRoutineNoteColumns: string[] = ['ser','courseName','routineName','routineNotes','actions'];
  displayedColumns: string[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  showHideDiv = false;

  searchText="";
  private searchSubject: Subject<string> = new Subject<string>();
  private searchSubscription: Subscription;
  subscription: any;

  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe,private classRoutineService:ClassRoutineService,private authService: AuthService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private routineNoteService: RoutineNoteService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('routineNoteId'); 
    this.searchSubscription = this.searchSubject.pipe(
      debounceTime(300), 
      distinctUntilChanged() 
    ).subscribe(searchText => {
      this.applyFilter(searchText);
    });

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    if (id) {
      this.pageTitle = 'Edit Routine Note'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.subscription = this.routineNoteService.find(+id).subscribe(
        res => {
          this.RoutineNoteForm.patchValue({                      
            routineNoteId: res.routineNoteId,
            baseSchoolNameId: res.baseSchoolNameId,
            classRoutineId: res.classRoutineId,
            courseNameId: res.courseNameId,
            courseDurationId: res.courseDurationId,
            courseWeekId: res.courseWeekId,
            bnaSubjectNameId: res.bnaSubjectNameId,
            routineNotes: res.routineNotes,
            status:res.status,
            isActive: res.isActive,            
          });  
          
          var editArr = [res.courseDurationId, res.courseNameId, res.baseSchoolNameId];
          this.getselectedcoursedurationbyschoolname()
          this.getselectedclassroutine(editArr)
        }
      );
    } else {
      this.pageTitle = 'Create Routine Note';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.RoutineNoteForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
    }else if(this.role === this.userRole.TrainingOffice || this.role === this.userRole.CO){
      this.getselectedbaseschoolsByBase(this.branchId);
    }else{
      this.getselectedbaseschools();
      this.getRoutineNoteList();
    }
    // this.getselectedbaseschools();
    // this.getselectedclasstype();
    // this.getselectedCourseModules();
    
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
    if (this.searchSubscription) {
      this.searchSubscription.unsubscribe();
    }
  }
  onSearchChange(searchValue: string): void {
    this.searchSubject.next(searchValue);
  }

  intitializeForm() {
    this.RoutineNoteForm = this.fb.group({
      routineNoteId: [0],
      baseSchoolNameId: [],
      classRoutineId: [],
      courseNameId: [],
      courseName:[''],
      courseDurationId: [],
      courseWeekId: [],
      bnaSubjectNameId: [],
      routineNotes: [],
      status:[1],
      isActive: [true],
    })
  }
  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.RoutineNoteForm.value['baseSchoolNameId'];
    this.subscription = this.routineNoteService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedcoursedurationbyschoolname=res;
      this.selectCourseTitle=res
    });

    this.getRoutineNoteList();
  } 
  filterByCourse(value:any){
    this.selectedcoursedurationbyschoolname=this.selectCourseTitle.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedWeeks(dropdown){
    const id = this.route.snapshot.paramMap.get('routineNoteId'); 
    if(id){
      var courseDurationId = dropdown[0];
      var courseNameId=dropdown[1];
      var baseSchoolNameId=dropdown[2];
    }else{
      var baseSchoolNameId=this.RoutineNoteForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];
      this.courseName=dropdown.text;
      this.RoutineNoteForm.get('courseName').setValue(dropdown.text);
      this.RoutineNoteForm.get('courseNameId').setValue(courseNameId);
      this.RoutineNoteForm.get('courseDurationId').setValue(courseDurationId);
    } 

    this.routineNoteService.getSelectedCourseWeeks(baseSchoolNameId,courseDurationId,courseNameId).subscribe(res=>{
      this.selectedWeek=res;
      this.selectWeek=res;
    }); 

  }
  filterByWeek(value:any){
    this.selectedWeek=this.selectWeek.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getselectedclassroutine(dropdown){
    const id = this.route.snapshot.paramMap.get('routineNoteId'); 
    if(id){
      var courseDurationId = dropdown[0];
      var courseNameId=dropdown[1];
      var baseSchoolNameId=dropdown[2];
    }else{
      var baseSchoolNameId=this.RoutineNoteForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];
      this.courseName=dropdown.text;
      this.RoutineNoteForm.get('courseName').setValue(dropdown.text);
      this.RoutineNoteForm.get('courseNameId').setValue(courseNameId);
      this.RoutineNoteForm.get('courseDurationId').setValue(courseDurationId);
    } 
    
        
  } 
  onWeekSelectionChangeGet(dropdown){
    this.schoolId=this.RoutineNoteForm.value['baseSchoolNameId'];
    this.durationId=this.RoutineNoteForm.value['courseDurationId'];
    this.courseId=this.RoutineNoteForm.value['courseNameId'];
    this.RoutineNoteForm.get('courseWeekId').setValue(dropdown.value);
    var courseWeekId=this.RoutineNoteForm.value['courseWeekId'];
    this.subscription = this.routineNoteService.getRoutineListForRoutineNote(this.schoolId,this.courseId,this.durationId,courseWeekId).subscribe(res=>{
      this.selectedRoutineList=res;
      this.selectRoutine=res;
    });
  }
  filterByRoutine(value:any){
    this.selectedRoutineList=this.selectRoutine.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
    
    onRoutineSelectionChangeGet(){
    this.schoolId=this.RoutineNoteForm.value['baseSchoolNameId'];
    this.durationId=this.RoutineNoteForm.value['courseDurationId'];
    this.courseId=this.RoutineNoteForm.value['courseNameId'];
    var classroutineid=this.RoutineNoteForm.value['classRoutineId'];
    // this.weekName=dropdown.text;
    // this.weekId=dropdown.value;
    this.subscription = this.classRoutineService.getSubjectNameIdFromclassRoutine(classroutineid).subscribe(res=>{
      
      this.RoutineNoteForm.get('bnaSubjectNameId').setValue(res);
      // this.RoutineNoteForm.get('courseWeekId').setValue(res.courseWeekId);
      
    });
  }
  getRoutineNoteList(){
    var baseSchoolNameId=this.RoutineNoteForm.value['baseSchoolNameId'];
    this.subscription = this.routineNoteService.getRoutineNotesByBaseSchoolNameId(this.paging.pageIndex, this.paging.pageSize,this.searchText,baseSchoolNameId).subscribe(response => {    
      this.routineNoteList = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }


  pageChanged(event: PageEvent) {
    
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getRoutineNoteList();

  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    
    this.getRoutineNoteList();
  } 

  getselectedbaseschools(){
    this.subscription = this.routineNoteService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
    });
  }  
  getselectedbaseschoolsByBase(baseNameId){
    this.subscription = this.routineNoteService.getselectedbaseschoolsByBase(baseNameId).subscribe(res=>{
      this.selectedbaseschool=res;
      this.selectSchool=res
    });
  }
  filterBySchool(value:any){
    this.selectedbaseschool=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()))
  }

  

  // getselectedCourseModules(){
  //   this.routineNoteService.getselectedCourseModules().subscribe(res=>{
  //     this.selectedCourseModule=res;
  //   });
  // } 

  

  // getselectedcoursename(){
  //   this.routineNoteService.getselectedcoursename().subscribe(res=>{
  //     this.selectedcoursename=res;
  //   });
  // } 

  // getselectedclasstype(){
  //   this.routineNoteService.getselectedclasstype().subscribe(res=>{
  //     this.selectedclasstype=res;
  //   });
  // }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  

  onSubmit() {
    const id = this.RoutineNoteForm.get('routineNoteId').value;   
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.routineNoteService.update(+id,this.RoutineNoteForm.value).subscribe(response => {
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
      this.loading = true;
      this.subscription = this.routineNoteService.submit(this.RoutineNoteForm.value).subscribe(response => {
        
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
    const id = row.routineNoteId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.routineNoteService.delete(id).subscribe(() => {
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
