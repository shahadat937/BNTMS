import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassRoutineService } from '../../service/classroutine.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { ClassRoutine } from '../../models/classroutine';
import { ClassPeriodService } from '../../service/classperiod.service'
import { CourseSectionService } from '../../../basic-setup/service/CourseSection.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { CourseWeekService } from 'src/app/course-management/service/CourseWeek.service';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { SharedServiceService } from 'src/app/shared/shared-service.service';


@Component({
  selector: 'app-new-bnaclassroutinesecondpart',
  templateUrl: './new-bnaclassroutinesecondpart.component.html',
  styleUrls: ['./new-bnaclassroutinesecondpart.component.sass']
})
export class NewBnaclassroutinesecondpartComponent implements OnInit, OnDestroy {
   masterData = MasterData;
   userRole = Role;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  ClassRoutineForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschool:SelectedModel[];
  selectedclasstype:SelectedModel[];
  selectedSemester:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selectedclassperiod:SelectedModel[];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectedWeek:SelectedModel[];
  selectedSchool:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedModule:SelectedModel[];
  selectedcoursename:SelectedModel[];
  routinManagementdropdownSettings:IDropdownSettings;
  routinManagementdropdownSettingsSingle:IDropdownSettings;
  //selectedmarktype:SelectedModel[];
  //selectedInstructor:{};
  selectedCourseSection:SelectedModel[];
  selectedInstructorInfo:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  routineCount:number;
  instructorRoutineCount:number;
  instructorRoutineOverLapList:any[];
  courseName:any;
  weekName:any;
  courseDurationId:any;
  
  bnaSelectedSubjectCurriculumId : any;
  selectedDepartmentId : any;
  selectedCourseNameId : any;
  selectedCourseDurationId : any;
  selectedBnaSemesterId : any;
  selectedBnaSemesterName : any;
  selectedBnaSubjectCurriculumName : any;
  selectedCourseWeekId : any;
  selectedCourseWeekName : any;
  selectedCourseSectionId : any;
  selectedClassPeriod : string;
  clasPeriodCount : number;
  selectedClassPeriodArray: any;

  routineStatus = 0 ;

  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;

  schoolId:any;
  durationId:any;
  courseId:any;
  weekId:any;
  sectionId:any;
  selectedClassTypeId:any;
  selectedSubjectId:number;


  popup = false;

  totalPeriod:string;
  selectedRoutineByParameters:ClassRoutine[];
  selectedRoutineByParametersAndDate:ClassRoutine[];
 
  selectedRoutineByParametersAndDateexam:ClassRoutine[]; 
  traineeListByBaseSchoolAndCourse
  dataForClassRoutine:any;
  periodListByBaseSchoolAndCourse:any[];
  routineNotesList:any;
  selectedRoutineByParameter:any;
  subjectlistBySchoolAndCourse:any;
  getSubjectsByRoutineList:any;
  schoolName:any;
  courseNameTitle:any;
  runningWeek:any;
  totalWeek:any;
  durationFrom:any;
  durationTo:any;
  weekFromDate:any;
  courseSection:any;
  weekStartDate:any;
  weekFromTo:any;
  isShown: boolean = false ;
  bnaSemesterId :number;
  groupArrays:{ date: string; games: any; }[];
  displayedRoutineCountColumns: string[] = ['ser','name','shortCode'];
  displayedSubjectListColumns: string[] = ['ser','instructorName','instructorShortCode'];
  displayedPeriodListColumns: string[] = ['ser','periodName','duration'];
  displayedRoutineNoteColumns: string[] = ['ser','routineName','routineNote'];
  displayedColumns: string[];
 
  selectedSubjectCurriculum:SelectedModel[];
  selectedDepartment:SelectedModel[];
  department: number = 0;

  displayedColumnsexam: string[]; 
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  showHideDiv = false;
  showSpinner = false;
  selectedWeekAll: SelectedModel[];
  bnaClassRoutineAll: any[];
  bnaInstructorInfo: any[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe, private courseWeekService: CourseWeekService,private authService: AuthService,private courseSectionService: CourseSectionService, private ClassPeriodService: ClassPeriodService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private ClassRoutineService: ClassRoutineService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    this.getSelectedSubjectCurriculum()
    this.getSelectedDepartment()
    this.getCourseWeeksAll()
    this.getDropdownCourseSection()
    this.getDropdownSubjectName()
    this.getSelectedClassPeriod();

    const id = this.route.snapshot.paramMap.get('classRoutineId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
 
    this.routinManagementdropdownSettings= {
      singleSelection: false,
      idField: 'value',
      textField: 'text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    
    this.routinManagementdropdownSettingsSingle= {
      singleSelection: true,
      idField: 'value',
      textField: 'text',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    if (id) {
      this.pageTitle = 'Edit Weekly Program'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.subscription = this.ClassRoutineService.find(+id).subscribe(
        res => {
          this.ClassRoutineForm.patchValue({          
            classRoutineId:res.classRoutineId, 
            courseModuleId:res.courseModuleId,
            courseNameId:res.courseNameId,
           // classPeriodId: res.classPeriodId, 
            baseSchoolNameId:res.baseSchoolNameId, 
            courseDurationId:res.courseDurationId, 
           // bnaSubjectNameId:res.bnaSubjectNameId,
           // subjectMarkId:res.subjectMarkId, 
            markTypeId:res.markTypeId, 
            courseWeekId:res.courseWeekId,
           // classTypeId:res.classTypeId,
            date:res.date,
            classLocation:res.classLocation,
            isApproved:res.isApproved,
            approvedDate:res.approvedDate,
            approvedBy:res.approvedBy,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          //  classRoomName:res.classRoomName,
          });  
          
          var editArr = [res.courseDurationId, res.courseNameId, res.baseSchoolNameId];
          this.getselectedcoursedurationbyschoolname()
          this.getselectedbnasubjectname(editArr)
        }
      );
    } else {
      this.pageTitle = 'Create Weekly Program';
      this.destination =  "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.ClassRoutineForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
    }else if(this.role === this.userRole.TrainingOffice || this.role === this.userRole.CO){
      this.getselectedbaseschoolsByBase(this.branchId);
    }else{
      this.getselectedbaseschools();
    }
    this.getselectedclasstype();
    this.getselectedCourseModules();
    this.getselectedcoursename();
    this.getSelectedBnaSemester();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.ClassRoutineForm = this.fb.group({
      classRoutineId: [0],
      bnaSubjectCurriculumId: [],
      departmentId:[],
      courseModuleId:[],
      bnaSemesterId:[],
      courseName:[''],
      courseNameId:[],
      classPeriodId:['',Validators.required],
      periodFrom:[],
      periodTo:[],
      baseSchoolNameId:['',Validators.required],
      courseDurationId:[],
      subjectName:[''],
      subjectId:[''],
      bnaSubjectNameId:[],
      traineeId:[],
      courseSectionId:[],
      subjectMarkId:[],
      markTypeId:[],
      courseWeekId:[],
      examMarkComplete:[0],
      classTypeId:[],
      classCountPeriod:[],
      subjectCountPeriod:[],
      date:[], 
      classLocation:[''],
      isApproved:[true],
      approvedDate:[],
      approvedBy:[],
      status:[1],
      isActive: [true],
      classRoomName:[],   
      classTopic:[],  
      perodListForm: this.fb.array([
        this.createPeriodData()
      ]),  
    })
  }

  private createPeriodData() {

    return this.fb.group({
      subjectId:[''],
      bnaSubjectNameId:[],
      traineeId:[''],
      subjectMarkId:[''],
      classPeriodId:['',Validators.required],
      classTypeId:[''],
      classRoomName:[],  
      classTopic:[], 
      markTypeId:[''],
      classCountPeriod:[],
      subjectCountPeriod:[],
      periodFrom:[],
      periodTo:[],
      //isApproved:[true],
    });
  }

  addSinglePeriod(){
    this.getDropdownSubjectName()
    this.getSelectedClassPeriod();
    this.getselectedclasstype();
    const control = <FormArray>this.ClassRoutineForm.controls["perodListForm"];
    control.push(this.createPeriodData());
   // this.ClassRoutineForm.patchValue({ perodListForm: this.traineeList });
  }

  deletePeriod(index: number) {
    //const control = this.ClassRoutineForm.get('selling_points') as FormArray;
     const control = <FormArray>this.ClassRoutineForm.controls["perodListForm"];
     control.removeAt(index);
   // control.splice(index, 1);
  }

  toggle(){
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle(){
    this.showHideDiv= false;
    this.print();
  }
  print(){ 
     
    let printContents, popupWin;
    printContents = document.getElementById('print-routine').innerHTML;
    popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    .dynamic-tbl-forroutine tr th span {
                      writing-mode: vertical-rl;
                      transform: rotate(180deg);
                      padding: 2px;
                      text-transform: capitalize;
                      height:170px;
                  }
 
                   
                    table th,table td {
                  font-size: 10px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
              .first-col-hide .mat-header-row.cdk-header-row.ng-star-inserted .mat-header-cell:first-child, .first-col-hide .mat-row.cdk-row.ng-star-inserted .mat-cell:first-child {
                      display: none;
                  }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
                .header-warning{
                  font-size:12px;
                }
                .header-warning.bottom{
                  position:absolute;
                  bottom:0;
                  left:44%;
                }
                .header-commencement{
                  font-size:12px;
                  text-align:left;
                  margin:0;
                }
                .row{
                  width:100%;
                }
                .col-md-4{
                  width:33%;
                  float:left;
                }
                .col-md-5{
                  width:42%;
                  float:left;
                }
                .col-md-3{
                  width:25%;
                  float:left;
                }
                .space{
                  text-align: center;
                  background:#ffffff;
                  color:#ffffff;
                  font-size:12px;
                  margin:0;
                }
                .header-top-name{
                  font-size:16px;
                  margin:0;
                }
                .sub-short-list{
                  margin:0;
                  font-size:12px;
                }
                .no-border-table ,.no-border-table th,.no-border-table td{
                  border:none;
                  margin:0;
                  padding:0;
                  text-align:left;
                }
                .no-border-table th.legend-cell{
                  text-align:center;
                }
                .no-border-table th {
                  text-decoration: underline;
                }
                .cell-routine-note{
                  width:70%;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
            <span class="header-warning top">RESTRICTED</span>
            <h3 class="header-top-name"> ${this.schoolName}</h3>
            <h3 class="header-top-name"> ${this.courseNameTitle}</h3>
            <h3 class="header-top-name">Section :- ${this.courseSection }</h3>                        
          </div>
          <div class="row">
            <div class="col-md-4">
              <h3 class="header-commencement">Wef :- ${this.weekStartDate}</h3>
              <h3 class="header-commencement">Date of Commencement :- ${this.durationFrom}</h3>
            </div>
            <div class="col-md-5">
              <h3 class="space"> - </h3>
            </div>
            <div class="col-md-3">
              <h3 class="header-commencement">Week:- ${this.runningWeek } / ${this.totalWeek }</h3>            
              <h3 class="header-commencement">Date of Completion :- ${this.durationTo }</h3>
            </div>
          </div>
          <br>
          <hr>
          ${printContents}
          <span class="header-warning bottom">RESTRICTED</span>
        </body>
      </html>`
    );
    popupWin.document.close();
  }


  onWeekSelectionChangeGet(dropdown){
    this.schoolId=this.ClassRoutineForm.value['baseSchoolNameId'];
    this.durationId=this.ClassRoutineForm.value['courseDurationId'];
    this.courseId=this.ClassRoutineForm.value['courseNameId'];
    this.weekName=dropdown.text;
    this.weekId=dropdown.value;
    
    this.subscription = this.ClassRoutineService.getRoutineNotesForWeeklyRoutine(this.schoolId,this.courseId,this.durationId,this.weekId).subscribe(res=>{
      this.routineNotesList=res;
    });

    // this.ClassRoutineService.getselectedCourseSection(this.schoolId,this.courseId).subscribe(res=>{
    //   this.selectedCourseSection=res;
    // });
    
    this.subscription = this.ClassRoutineService.getdataForPrintWeeklyRoutine(this.weekId).subscribe(res=>{
      this.dataForClassRoutine=res;
      // this.schoolName = res[0].schoolName;
      // this.courseNameTitle = res[0].courseName;
      let weekFrom = res[0].dateFrom;
      this.weekFromDate = this.datepipe.transform(weekFrom, 'dd/MM/yyyy');
      let weekTo = res[0].dateTo;
      this.weekFromTo = this.datepipe.transform(weekTo, 'dd/MM/yyyy');
      
    });
    if(this.schoolId != null && this.courseId != null){            

      this.subscription = this.ClassRoutineService.getCourseInstructorByBaseSchoolNameAndCourseName(this.schoolId,this.courseId,this.durationId).subscribe(res=>{
          this.traineeListByBaseSchoolAndCourse=res;
        })

        this.subscription = this.ClassPeriodService.getSelectedPeriodBySchoolAndCourse(this.schoolId,this.courseId).subscribe(res=>{
          this.periodListByBaseSchoolAndCourse=res;
        })

      // this.ClassRoutineService.getselectedClassPeriodbyschoolandcourse(this.schoolId,this.courseId).subscribe(res=>{
      //   this.selectedclassperiod=res;
      // });
      
      this.isShown=true;
    } 
  }

  onDateSelectionChange(event){
    var date=this.datepipe.transform((event.value), 'MM/dd/yyyy');
    var traineeId=this.ClassRoutineForm.value['traineeId'];
    var classPeriodId=this.ClassRoutineForm.value['classPeriodId'];


    this.subscription = this.ClassRoutineService.getInstructorAvailabilityByDateAndPeriod(traineeId, classPeriodId, date).subscribe(res=>{
       //this.selectedclassperiod=res;
      this.instructorRoutineOverLapList = res;
      this.instructorRoutineCount=res.length;
    });

   }

   selectedInstructor = {};
   selectedmarktype={};

  onSubjectNameSelectionChangeGet(dropdown,index: number){
    var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    var courseName=this.ClassRoutineForm.value['courseName'];
    var courseSectionId = this.ClassRoutineForm.value['courseSectionId'];
    var courseDurationId = this.ClassRoutineForm.value['courseDurationId'];
    var courseNameId = this.ClassRoutineForm.value['courseNameId'];

    // var courseNameArr = courseName.value.split('_');
    // this.courseDurationId = courseNameArr[0];
    // var courseNameId =courseNameArr[1];

    var bnaSubjectNameId = dropdown.value;
    this.ClassRoutineForm.get('subjectName').setValue(dropdown.text);
    this.ClassRoutineForm.get('bnaSubjectNameId').setValue(bnaSubjectNameId);
   this.onSubjectNameSelectionChange(baseSchoolNameId,courseNameId,courseSectionId,bnaSubjectNameId,courseDurationId,index);  

   this.subscription = this.ClassRoutineService.getselectedInstructor(baseSchoolNameId,courseNameId,courseDurationId,courseSectionId,bnaSubjectNameId).subscribe(res=>{
      this.selectedInstructor[bnaSubjectNameId]=res;
      
    });

    
    
    
    this.subscription = this.ClassRoutineService.getselectedmarktype(bnaSubjectNameId).subscribe(res=>{
      this.selectedmarktype[bnaSubjectNameId]=res;
    });
  }

  onSubjectMarkSelectionGetMarkType(index: number){

   let markId = (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('subjectMarkId').value;
    // var subjectMarkId = this.ClassRoutineForm.value['subjectMarkId'];
    this.subscription = this.ClassRoutineService.findSubjectMark(markId).subscribe(res=>{
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('markTypeId').setValue(res.markTypeId);
     // this.ClassRoutineForm.get('markTypeId').setValue(res.markTypeId);
    });

  }

  onSubjectNameSelectionChange(baseSchoolNameId,courseNameId,courseSectionId,bnaSubjectNameId,courseDurationId,index){
    // var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    // var courseNameId=this.ClassRoutineForm.value['courseNameId'];
    // var bnaSubjectNameId=this.ClassRoutineForm.value['bnaSubjectNameId'];
    // var courseDurationId=this.ClassRoutineForm.value['courseDurationId'];


    this.subscription = this.ClassRoutineService.getClassRoutineCountByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId,courseDurationId,courseSectionId).subscribe(res=>{
      this.routineCount=res;
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('classCountPeriod').setValue(this.routineCount);
    //  this.ClassRoutineForm.get('classCountPeriod').setValue(this.routineCount);
    });

    
  
    this.subscription = this.ClassRoutineService.getTotalPeriodByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      this.totalPeriod=res;
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('subjectCountPeriod').setValue(this.totalPeriod);
      // this.ClassRoutineForm.get('subjectCountPeriod').setValue(this.totalPeriod);
    });


    if(baseSchoolNameId !=null && courseNameId !=null  && bnaSubjectNameId !=null){

      // this.ClassRoutineService.getCourseModuleIdForRoutine(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      //   var courseModuleId=res;
      //   this.ClassRoutineForm.get('courseModuleId').setValue(courseModuleId);
      // });

      // this.ClassRoutineService.getselectedClassPeriodbyschoolandcourse(baseSchoolNameId,courseNameId).subscribe(res=>{
      //   this.selectedclassperiod=res;
      // });
    
    }  
  }

  getControlLevel(index: number, type: string) {
    return (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get(type).value;
  }

  onSectionSelectionGet(){    
    var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    var courseNameId=this.ClassRoutineForm.value['courseNameId'];
    var courseWeekId=this.ClassRoutineForm.value['courseWeekId'];
    var courseDurationId=this.ClassRoutineForm.value['courseDurationId'];
    this.sectionId = this.ClassRoutineForm.value['courseSectionId'];
    this.bnaSemesterId = this.ClassRoutineForm.value['bnaSemesterId'];


    // this.ClassRoutineService.getselectedSubjectNamesBySchoolAndCourse_sem(baseSchoolNameId,courseNameId,this.bnaSemesterId).subscribe(res=>{
    //   this.selectedsubjectname=res;
    // });

    this.subscription = this.ClassRoutineService.getSubjectlistBySchoolAndCourse(baseSchoolNameId,courseNameId,courseDurationId,courseWeekId,this.sectionId).subscribe(res=>{
      this.subjectlistBySchoolAndCourse=res;
    });

    this.subscription = this.ClassRoutineService.getSubjectsByRoutineList(baseSchoolNameId,courseNameId,courseDurationId,courseWeekId,this.sectionId).subscribe(res=>{
      this.getSubjectsByRoutineList=res;
    });

    // this.courseSectionService.find(this.sectionId).subscribe(res=>{
    //   this.courseSection = res.sectionName;
    // });

    this.subscription = this.ClassRoutineService.getClassRoutineHeaderByParams(baseSchoolNameId,courseNameId,courseDurationId,this.sectionId).subscribe(res=>{
      this.courseSection = res[0].sectionName;
      this.schoolName = res[0].schoolName;
      this.courseNameTitle = res[0].courseNameTitle;
      this.runningWeek = res[0].runningWeek + 1;
      this.totalWeek = res[0].totalWeek;
      var durationFrom = res[0].durationFrom;
      this.durationFrom =this.datepipe.transform(durationFrom, 'dd/MM/yyyy');
      var durationTo = res[0].durationTo;
      this.durationTo =this.datepipe.transform(durationTo, 'dd/MM/yyyy');
    });

    this.subscription = this.courseWeekService.find(courseWeekId).subscribe(res=>{
      var weekStartDate = res.dateFrom;
      this.weekStartDate =this.datepipe.transform(weekStartDate, 'dd/MM/yyyy');
    });

 

 
    this.subscription = this.ClassRoutineService.getClassRoutineByCourseNameBaseSchoolNameBNAClassSpRequest(baseSchoolNameId,courseNameId,courseWeekId,this.sectionId).subscribe(res=>{
      this.selectedRoutineByParametersAndDate=res;
      //debugger;
      // for(let i=0;i<=this.selectedRoutineByParametersAndDate.length;i++){

      // }

      this.displayedColumns =[...Object.keys(this.selectedRoutineByParametersAndDate[0])];
      


      
    }); 
    this.subscription = this.ClassRoutineService.getClassRoutineByCourseNameBaseSchoolNameBNAExamSpRequest(baseSchoolNameId,courseNameId,courseWeekId,this.sectionId).subscribe(res=>{
      this.selectedRoutineByParametersAndDateexam=res;
      this.displayedColumnsexam =[...Object.keys(this.selectedRoutineByParametersAndDateexam[0])];      
    });
 
  }

  getSelectedBnaSemester(){
    this.subscription = this.ClassRoutineService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
    });
  } 

  getselectedbaseschools(){
    this.subscription = this.ClassRoutineService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
    });
  } 

  getselectedbaseschoolsByBase(baseNameId){
    this.subscription = this.ClassRoutineService.getselectedbaseschoolsByBase(baseNameId).subscribe(res=>{
      this.selectedbaseschool=res;
    });
  }  

  getselectedcoursedurationbyschoolname(){
      var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
      this.subscription = this.ClassRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
        this.selectedcoursedurationbyschoolname=res;
      });
  } 

  getSelectedSubjectCurriculum(){
    this.subscription = this.ClassRoutineService.getSelectedSubjectCurriculum().subscribe(res=>{
      this.selectedSubjectCurriculum=res
    });
  }
  getCourseWeeksAll(){
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();
    this.subscription = this.ClassRoutineService.getDropdownSelectedCourseWeeksAll(this.baseSchoolId).subscribe(res=>{
      this.selectedWeekAll = res
    });
  }
  
  getDropdownSubjectName(){
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();
    this.subscription = this.ClassRoutineService.getDropdownSubjectName(this.baseSchoolId).subscribe(res=>{
      this.selectedsubjectname = res
    });
  }

  getDropdownCourseSection(){
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();
    this.subscription = this.ClassRoutineService.getDropdownCourseSection(this.baseSchoolId).subscribe(res=>{
      this.selectedCourseSection = res
    });
  }

  getDropdownInstructorInfo(){
    this.subscription = this.ClassRoutineService.getDropdownInstructorInfo(this.selectedSubjectId).subscribe(res=>{
      this.selectedInstructorInfo = res
    });
  }

  getSelectedMarkType(){
    this.subscription = this.ClassRoutineService.getDropdownMarkType(this.selectedSubjectId).subscribe(res=>{
      this.selectedmarktype=res;
    });
  }
  // getBnaCourseTitle(){
  //   var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
  //   this.ClassRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
  //     this.selectedcoursedurationbyschoolname=res;
  //   });
  // } 
  
  getSelectedClassPeriod(){
    this.baseSchoolId = this.authService.currentUserValue.branchId.trim();
    this.subscription = this.ClassRoutineService.getDropdownClassPeriod(this.baseSchoolId).subscribe(res=>{
      this.selectedclassperiod=res;
    });
  }
  
  
  // getBnaClassRoutineAll(){
  //   this.baseSchoolId = this.authService.currentUserValue.branchId.trim();
  //   this.ClassRoutineService.getBnaClassRoutineAll(this.baseSchoolId).subscribe(res=>{
  //     this.bnaClassRoutineAll=res.items;
  //   });
  // }

  getSelectedDepartment(){
    this.subscription = this.ClassRoutineService.getSelectedDepartment().subscribe(res=>{
      this.selectedDepartment=res;     
    })
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
      this.ClassRoutineForm.get('courseName').setValue(dropdown.text);
      this.ClassRoutineForm.get('courseNameId').setValue(courseNameId);
      this.ClassRoutineForm.get('courseDurationId').setValue(courseDurationId);
    } 
    
  //  this.ClassRoutineService.getSelectedCourseWeeks(baseSchoolNameId,courseDurationId,courseNameId).subscribe(res=>{
  //     this.selectedWeek=res;
  //   });    

   
  
 
    
  this.subscription = this.ClassRoutineService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId).subscribe(res=>{
      this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;    
    });
  } 

  // onWeekSelectionChangesemisterGet(dropdown){
  //   var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
  //   var bnaSemesterId=dropdown.value;

  //   var courseNameId=this.ClassRoutineForm.value['courseNameId'];
  //   //var courseWeekId=this.ClassRoutineForm.value['courseWeekId'];
  //   var courseDurationId=this.ClassRoutineForm.value['courseDurationId'];
  //   this.ClassRoutineService.getSelectedCourseWeeks_sem(baseSchoolNameId,courseDurationId,courseNameId,bnaSemesterId).subscribe(res=>{
  //     this.selectedWeek=res;
  //   });    
 
  // //  (onSelectionChange)="onSubjectNameSelectionChangeGet(dropdown,i)"
  // }

  getselectedCourseModules(){
    this.subscription = this.ClassRoutineService.getselectedCourseModules().subscribe(res=>{
      this.selectedCourseModule=res;
    });
  } 


  onsemSelectionChangeGet(dropdown){
   // const id = this.route.snapshot.paramMap.get('classRoutineId'); 

    var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    var courseNameArr = this.ClassRoutineForm.value['courseNameId'].split('_');
    var courseDurationId = courseNameArr[0];//dropdown.value;
   var courseNameId=courseNameArr[1];
  //  this.courseName=dropdown.text;
   // this.ClassRoutineForm.get('courseName').setValue(dropdown.text);
    //this.ClassRoutineForm.get('courseNameId').setValue(courseNameId);
   //this.ClassRoutineForm.get('courseDurationId').setValue(dropdown.value);

    
    /*
   this.ClassRoutineService.getSelectedBnaCourseWeeks(baseSchoolNameId,courseDurationId,courseNameId).subscribe(res=>{
      this.selectedWeek=res;
    }); 

 */
  }

  

  getselectedcoursename(){
    this.subscription = this.ClassRoutineService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res;
    });
  } 


  getselectedclasstype(){
    this.subscription = this.ClassRoutineService.getselectedclasstype().subscribe(res=>{
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
    const id = this.ClassRoutineForm.get('classRoutineId').value; 

    this.ClassRoutineForm.value.bnaSubjectCurriculumId = this.bnaSelectedSubjectCurriculumId;
    this.ClassRoutineForm.value.departmentId = this.selectedDepartmentId;
    this.ClassRoutineForm.value.courseDurationId = this.selectedCourseDurationId;
    this.ClassRoutineForm.value.courseNameId = this.selectedCourseNameId;
    this.ClassRoutineForm.value.bnaSemesterId = this.selectedBnaSemesterId;
    this.ClassRoutineForm.value.courseSectionId = this.selectedCourseSectionId;
    this.ClassRoutineForm.value.courseWeekId = this.selectedCourseWeekId;
    

    
    
    if(this.ClassRoutineForm.get('perodListForm').value != undefined){
      this.ClassRoutineForm.get('perodListForm').value.forEach(element => {


        if(element.subjectId.length != 0){
          element.subjectId.forEach(x => {
            element.subjectId = x.value
          });
        }
        if(element.traineeId.length != 0){
          element.traineeId.forEach(x => {
            element.traineeId = x.value
          });
        }
        if(element.subjectMarkId.length != 0){
          element.subjectMarkId.forEach(x => {
            element.subjectMarkId = x.value
          });
        }
        
        if(element.classPeriodId != undefined){
          this.clasPeriodCount = element.classPeriodId.length;
          element.classPeriodId.forEach(x => {
            if(this.clasPeriodCount == 1){
              this.selectedClassPeriodArray = x.value;
            }
            else {
              if(this.selectedClassPeriodArray == null) {
                this.selectedClassPeriodArray = x.value;
              }
              else{
                this.selectedClassPeriodArray = this.selectedClassPeriodArray + ", "+ x.value;
              }
            }
          });
          element.classPeriodId = this.selectedClassPeriodArray;
        }


        if(element.classTypeId.length != 0){
          element.classTypeId.forEach(x => {
            element.classTypeId = x.value
          });
        }
        
      });
    }
    
    this.loading = true;

    this.subscription = this.ClassRoutineService.bnasubmit(this.ClassRoutineForm.value).subscribe(response => {
      
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


    // if (id) {
    //   this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
    //     if (result) {
    //       this.loading = true;
    //       this.ClassRoutineService.update(+id,this.ClassRoutineForm.value).subscribe(response => {
    //         // this.loadSpinner();
    //         this.reloadCurrentRoute();
    //         this.snackBar.open('Information Updated Successfully ', '', {
    //           duration: 2000,
    //           verticalPosition: 'bottom',
    //           horizontalPosition: 'right',
    //           panelClass: 'snackbar-success'
    //         });
    //       }, error => {
    //         this.validationErrors = error;
    //       })
    //     }
    //   })
    // }else {
    //   this.loading = true;
    //   this.ClassRoutineService.submit(this.ClassRoutineForm.value).subscribe(response => {
        
    //     this.reloadCurrentRoute();
    //     this.snackBar.open('Information Inserted Successfully ', '', {
    //       duration: 2000,
    //       verticalPosition: 'bottom',
    //       horizontalPosition: 'right',
    //       panelClass: 'snackbar-success'
    //     });
    //   }, error => {
    //     this.validationErrors = error;
    //   })
    // }
  }

  getPopup(){
    this.popup = true;
  }

  deleteItem(row) {
    const id = row.classRoutineId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.ClassRoutineService.delete(id).subscribe(() => {
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


  onStatusbnaSubjectCurriculum(dropdown) {
    if(dropdown.value == 1019){
      this.department = dropdown.value
    }
    if(this.bnaSelectedSubjectCurriculumId == null){
      this.bnaSelectedSubjectCurriculumId = dropdown.value.toString();
      this.selectedBnaSubjectCurriculumName = dropdown.text;
    }
    else {
      this.bnaSelectedSubjectCurriculumId = this.bnaSelectedSubjectCurriculumId + ", "+ dropdown.value;
      this.selectedBnaSubjectCurriculumName = this.selectedBnaSubjectCurriculumName + ", "+ dropdown.text;
    }
    this.showBnaClassRoutine();
  }
  onDeSelectbnaSubjectCurriculum(dropdown) {
    if(dropdown.value == 1019){
      this.department = 0;
    }
    let bnaSelectedSubjectCurriculumIdsArray: string[] = this.bnaSelectedSubjectCurriculumId.split(',');
    let bnaSelectedSubjectCurriculumIdsNumberArray : number[] = bnaSelectedSubjectCurriculumIdsArray.map(Number);
    let indexToRemove : number = bnaSelectedSubjectCurriculumIdsNumberArray.indexOf(dropdown.value);
    if(indexToRemove !== -1){
      bnaSelectedSubjectCurriculumIdsNumberArray.splice(indexToRemove, 1);
    }
    this.bnaSelectedSubjectCurriculumId = bnaSelectedSubjectCurriculumIdsNumberArray.join(', ');

    let selectedBnaSubjectCurriculumNamesArray: string[] = this.selectedBnaSubjectCurriculumName.split(',').map(item => item.trim());
    let indexNameToRemove: number = selectedBnaSubjectCurriculumNamesArray.indexOf(dropdown.text.trim());
    if (indexNameToRemove !== -1) {
      selectedBnaSubjectCurriculumNamesArray.splice(indexNameToRemove, 1);
    }
    this.selectedBnaSubjectCurriculumName = selectedBnaSubjectCurriculumNamesArray.join(', ');
    this.showBnaClassRoutine();
  }
  onSelectAllbnaSubjectCurriculum() {
    this.department = 1019;
    this.bnaSelectedSubjectCurriculumId = null;
    this.selectedBnaSubjectCurriculumName = null;
    this.selectedSubjectCurriculum.forEach(element => {
      if(this.bnaSelectedSubjectCurriculumId == null){
        this.bnaSelectedSubjectCurriculumId = element.value;
        this.selectedBnaSubjectCurriculumName = element.text;
      }
      else {
        this.bnaSelectedSubjectCurriculumId = this.bnaSelectedSubjectCurriculumId + ", "+ element.value;
        this.selectedBnaSubjectCurriculumName = this.selectedBnaSubjectCurriculumName + ", "+ element.text;
      }
    });
    this.showBnaClassRoutine();
  }
  onDeSelectAllbnaSubjectCurriculum() {
    this.department = 0;
    this.bnaSelectedSubjectCurriculumId = null;
    this.selectedBnaSubjectCurriculumName = null;
    this.showBnaClassRoutine();
  }

  onStatusDepartment(dropdown) {
    if(this.selectedDepartmentId == null){
      this.selectedDepartmentId = dropdown.value.toString();
    }
    else {
      this.selectedDepartmentId = this.selectedDepartmentId + ", "+ dropdown.value;
    }
  }
  onDeSelectDepartment(dropdown) {
    let selectedDepartmentIdsArray: string[] = this.selectedDepartmentId.split(',');
    let selectedDepartmentIdsNumberArray : number[] = selectedDepartmentIdsArray.map(Number);
    let indexToRemove : number = selectedDepartmentIdsNumberArray.indexOf(dropdown.value);
    if(indexToRemove !== -1){
      selectedDepartmentIdsNumberArray.splice(indexToRemove, 1);
    }
    this.selectedDepartmentId = selectedDepartmentIdsNumberArray.join(', ');
  }
  onSelectAllDepartment() {
    this.selectedDepartmentId = null;
    this.selectedDepartment.forEach(element => {
      if(this.selectedDepartmentId == null){
        this.selectedDepartmentId = element.value;
      }
      else {
        this.selectedDepartmentId = this.selectedDepartmentId + ", "+ element.value;
      }
    });
  }
  onDeSelectAllDepartment() {
    this.selectedDepartmentId = null;
  }


  onStatusCourseTitle(dropdown) {
    var courseNameArr = dropdown.value.split('_');
    if(this.selectedCourseNameId == null && this.selectedCourseDurationId == null){
      this.selectedCourseDurationId = courseNameArr[0].toString();
      this.selectedCourseNameId = courseNameArr[1].toString();
    }
    else {
      this.selectedCourseDurationId = this.selectedCourseDurationId + ", "+ courseNameArr[0];
      this.selectedCourseNameId = this.selectedCourseNameId + ", "+ courseNameArr[1];
    }
    this.showBnaClassRoutine();
  }
  onDeSelectCourseTitle(dropdown) {
    var courseNameArr = dropdown.value.split('_');
    let selectedCourseNameIdsArray: string[] = this.selectedCourseNameId.split(', ');
    let selectedCourseDurationIdsArray: string[] = this.selectedCourseDurationId.split(', ');

    // Find and remove the deselected course name
    let indexCourseNameToRemove: number = selectedCourseNameIdsArray.indexOf(courseNameArr[1]);
    if (indexCourseNameToRemove !== -1) {
      selectedCourseNameIdsArray.splice(indexCourseNameToRemove, 1);
    }
    this.selectedCourseNameId = selectedCourseNameIdsArray.join(', ');

    // Find and remove the deselected course duration
    let indexCourseDurationToRemove: number = selectedCourseDurationIdsArray.indexOf(courseNameArr[0]);
    if (indexCourseDurationToRemove !== -1) {
      selectedCourseDurationIdsArray.splice(indexCourseDurationToRemove, 1);
    }
    this.selectedCourseDurationId = selectedCourseDurationIdsArray.join(', ');
    this.showBnaClassRoutine();
}
  onSelectAllCourseTitle() {
    this.selectedCourseNameId = null;
    this.selectedCourseDurationId = null;
    this.selectedcoursedurationbyschoolname.forEach(element => {
      var courseNameArr = element.value.split('_');
      if(this.selectedCourseNameId == null && this.selectedCourseDurationId == null){
        this.selectedCourseDurationId = courseNameArr[0].toString();
        this.selectedCourseNameId = courseNameArr[1].toString();
      }
      else {
        this.selectedCourseDurationId = this.selectedCourseDurationId + ", "+ courseNameArr[0];
        this.selectedCourseNameId = this.selectedCourseNameId + ", "+ courseNameArr[1];
      }
    });
    this.showBnaClassRoutine();
  }
  onDeSelectAllCourseTitle() {
    this.selectedCourseNameId = null;
    this.selectedCourseDurationId = null;
    this.showBnaClassRoutine();
  }

  
  onStatusSemester(dropdown) {
    if(this.selectedBnaSemesterId == null){
      this.selectedBnaSemesterId = dropdown.value.toString();
      this.selectedBnaSemesterName = dropdown.text;
    }
    else {
      this.selectedBnaSemesterId = this.selectedBnaSemesterId + ", "+ dropdown.value;
      this.selectedBnaSemesterName = this.selectedBnaSemesterName + ", "+ dropdown.text;
    }
    this.showBnaClassRoutine();
  }
  onDeSelectSemester(dropdown) {
    let selectedBnaSemesterIdsArray: string[] = this.selectedBnaSemesterId.split(',');
    let selectedBnaSemesterIdsNumberArray : number[] = selectedBnaSemesterIdsArray.map(Number);
    let indexToRemove : number = selectedBnaSemesterIdsNumberArray.indexOf(dropdown.value);
    if(indexToRemove !== -1){
      selectedBnaSemesterIdsNumberArray.splice(indexToRemove, 1);
    }
    this.selectedBnaSemesterId = selectedBnaSemesterIdsNumberArray.join(', ');

    let selectedBnaSemesterNamesArray: string[] = this.selectedBnaSemesterName.split(',').map(item => item.trim());
    let indexNameToRemove: number = selectedBnaSemesterNamesArray.indexOf(dropdown.text.trim());
    if (indexNameToRemove !== -1) {
      selectedBnaSemesterNamesArray.splice(indexNameToRemove, 1);
    }
    this.selectedBnaSemesterName = selectedBnaSemesterNamesArray.join(', ');

    this.showBnaClassRoutine();
  }
  onSelectAllSemester() {
    this.selectedBnaSemesterId = null;
    this.selectedBnaSemesterName = null;
    this.selectedSemester.forEach(element => {
      if(this.selectedBnaSemesterId == null){
        this.selectedBnaSemesterId = element.value;
        this.selectedBnaSemesterName = element.text;
      }
      else {
        this.selectedBnaSemesterId = this.selectedBnaSemesterId + ", "+ element.value;
        this.selectedBnaSemesterName = this.selectedBnaSemesterName + ", " + element.text;
      }
    });
    this.showBnaClassRoutine();
  }
  onDeSelectAllSemester() {
    this.selectedBnaSemesterId = null;
    this.selectedBnaSemesterName = null;
    this.showBnaClassRoutine();
  }

  
  onStatusCourseSection(dropdown) {
    if(this.selectedCourseSectionId == null){
      this.selectedCourseSectionId = dropdown.value.toString();
    }
    else {
      this.selectedCourseSectionId = this.selectedCourseSectionId + ", "+ dropdown.value;
    }
    this.showBnaClassRoutine();
  }
  onDeSelectCourseSection(dropdown) {
    let selectedCourseSectionIdsArray: string[] = this.selectedCourseSectionId.split(',');
    let selectedCourseSectionIdsNumberArray : number[] = selectedCourseSectionIdsArray.map(Number);
    let indexToRemove : number = selectedCourseSectionIdsNumberArray.indexOf(dropdown.value);
    if(indexToRemove !== -1){
      selectedCourseSectionIdsNumberArray.splice(indexToRemove, 1);
    }
    this.selectedCourseSectionId = selectedCourseSectionIdsNumberArray.join(', ');
    this.showBnaClassRoutine();
  }
  onSelectAllCourseSection() {
    this.selectedCourseSectionId = null;
    this.selectedCourseSection.forEach(element => {
      if(this.selectedCourseSectionId == null){
        this.selectedCourseSectionId = element.value;
      }
      else {
        this.selectedCourseSectionId = this.selectedCourseSectionId + ", "+ element.value;
      }
    });
    this.showBnaClassRoutine();
  }
  onDeSelectAllCourseSection() {
    this.selectedCourseSectionId = null;
    this.showBnaClassRoutine();
  }


  onSubjectStatus(dropdown){
    this.selectedSubjectId = dropdown.value
    this.getDropdownInstructorInfo();
    this.getSelectedMarkType()
  }
  onSubjectDeSelect(dropdown){
    this.selectedSubjectId = null;
    this.getDropdownInstructorInfo();
    this.getSelectedMarkType()
  }


  onStatusCourseWeek(dropdown){
    this.selectedCourseWeekId = dropdown.value;
    this.selectedCourseWeekName = dropdown.text;
    this.showBnaClassRoutine();
  }

  onDeSelectCourseWeek(dropdown){
    this.selectedCourseWeekId = null;
    this.selectedCourseWeekName = null;
    this.showBnaClassRoutine();
  }




  showBnaClassRoutine(){
    if((this.bnaSelectedSubjectCurriculumId != null && this.selectedCourseNameId != null && this.selectedCourseDurationId != null && this.selectedBnaSemesterId != null && this.selectedCourseSectionId != null && this.selectedCourseWeekId != null)){
      this.routineStatus = 1;
      this.viewFilteredBnaClassRoutine();
      this.viewFilteredInstructorInfo();
    }
    else{
      this.routineStatus = 0;
    }
  }
  viewFilteredBnaClassRoutine(){
    this.subscription = this.ClassRoutineService.viewFilteredBnaClassRoutine(this.bnaSelectedSubjectCurriculumId, this.selectedCourseNameId, this.selectedCourseDurationId, this.selectedBnaSemesterId, this.selectedCourseSectionId, this.selectedCourseWeekId).subscribe(res=>{
      this.bnaClassRoutineAll = res;
    });
  }
  
  viewFilteredInstructorInfo(){
    this.subscription = this.ClassRoutineService.viewFilteredInstructorInfo(this.bnaSelectedSubjectCurriculumId, this.selectedCourseNameId, this.selectedCourseDurationId, this.selectedBnaSemesterId, this.selectedCourseSectionId, this.selectedCourseWeekId).subscribe(res=>{
      this.bnaInstructorInfo = res;
    });
  }
}
