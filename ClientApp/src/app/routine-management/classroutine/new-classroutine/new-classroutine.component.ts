import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ClassRoutineService } from '../../service/classroutine.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ClassRoutine } from '../../models/classroutine';
import { ClassPeriodService } from '../../service/classperiod.service'
import { CourseSectionService } from '../../../basic-setup/service/CourseSection.service';
import { AuthService } from '../../../../../src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from '../../../../../src/app/core/models/role';
import { CourseWeekService } from '../../../../../src/app/course-management/service/CourseWeek.service';
import { Subject } from 'rxjs';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';



@Component({
  selector: 'app-new-classroutine',
  templateUrl: './new-classroutine.component.html',
  styleUrls: ['./new-classroutine.component.sass']
}) 

export class NewClassRoutineComponent implements OnInit, OnDestroy {
  copy: boolean = true;
   masterData = MasterData;
   userRole = Role;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  ClassRoutineForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschool:SelectedModel[];
  selectSchool:SelectedModel[];
  selectedclasstype:SelectedModel[];
  selectClassType:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selectedclassperiod:SelectedModel[];
  selectClassPeriod:SelectedModel[];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectCourseTitle:SelectedModel[];
  selectedsubjectname:SelectedModel[];
  selectSubjectName:SelectedModel[];
  selectedWeek:SelectedModel[];
  selectWeek:SelectedModel[];
  selectedSchool:SelectedModel[];
  selectedCourseModule:SelectedModel[];
  selectedModule:SelectedModel[];
  selectedcoursename:SelectedModel[];
  //selectedmarktype:SelectedModel[];
  //selectedInstructor:{};
  selectMarkType:SelectedModel[];
  selectedCourseSection:SelectedModel[];
  selectInstructor:SelectedModel[];
  selectSection:SelectedModel[];
  selectedCourseModuleByBaseSchoolAndCourseNameId:SelectedModel[];
  routineCount:number;
  instructorRoutineCount:number;
  instructorRoutineOverLapList:any[];
  courseName:any;
  weekName:any;
  courseDurationId:any;
  
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  tooltipText: string;
  schoolId:any;
  durationId:any;
  courseId:any;
  weekId:any;
  sectionId:any;

  popup = false;

  totalPeriod:string;
  selectedRoutineByParameters:ClassRoutine[];
  selectedRoutineByParametersAndDate:ClassRoutine[];
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
  groupArrays:{ date: string; games: any; }[];
  displayedRoutineCountColumns: string[] = ['ser','name','shortCode'];
  displayedSubjectListColumns: string[] = ['ser','instructorName','instructorShortCode'];
  displayedPeriodListColumns: string[] = ['ser','periodName','duration'];
  displayedRoutineNoteColumns: string[] = ['ser','routineName','routineNote'];
  displayedColumns: string[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  showHideDiv = false;
  showSpinner = false;


  inputGroups: { value: string }[] = [{ value: '' }];
  subscription: any;

  


  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe, private courseWeekService: CourseWeekService,private authService: AuthService,private courseSectionService: CourseSectionService, private ClassPeriodService: ClassPeriodService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private ClassRoutineService: ClassRoutineService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) { }
 
  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('classRoutineId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
 
 

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
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.BNASchool || this.role === this.userRole.JSTISchool){
      this.ClassRoutineForm.get('baseSchoolNameId')?.setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
    }else if(this.role === this.userRole.TrainingOffice || this.role === this.userRole.CO){
      this.getselectedbaseschoolsByBase(this.branchId);
    }else{
      this.getselectedbaseschools();
    }
    this.getselectedclasstype();
    this.getselectedCourseModules();
    this.getselectedcoursename();
    
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

  addInputGroup() {
    this.inputGroups.push({ value: '' });
  }

  intitializeForm() {
    this.ClassRoutineForm = this.fb.group({
      classRoutineId: [0],
      courseModuleId:[],
      courseName:[''],
      courseNameId:[],
      classPeriodId:['',Validators.required],
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


    if(this.copy&&this.ClassRoutineForm!=undefined) {
      const control = <FormArray>this.ClassRoutineForm.controls["perodListForm"];
      const val = control.controls[control.length-1].value;

      return this.fb.group(val);
    }

    return this.fb.group({
      subjectId:[''],
      bnaSubjectNameId:[],
      traineeId:[],
      subjectMarkId:[],
      classPeriodId:['',Validators.required],
      classTypeId:[],
      classRoomName:[],  
      classTopic:[], 
      markTypeId:[],
      classCountPeriod:[],
      subjectCountPeriod:[],
      //isApproved:[true],
    });
  }
  

  addSinglePeriod(){
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
    printContents = document.getElementById('print-routine')?.innerHTML;
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
    
    this.ClassRoutineService.getRoutineNotesForWeeklyRoutine(this.schoolId,this.courseId,this.durationId,this.weekId).subscribe(res=>{
      this.routineNotesList=res;
    });

    this.subscription = this.ClassRoutineService.getselectedCourseSection(this.schoolId,this.courseId).subscribe(res=>{
      this.selectedCourseSection=res;
    });
  
    
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

        this.subscription = this.ClassRoutineService.getSelectedCourseModuleByBaseSchoolNameIdAndCourseNameId(this.schoolId,this.courseId).subscribe(res=>{
        this.selectedCourseModuleByBaseSchoolAndCourseNameId = res;    
      });
      this.subscription = this.ClassRoutineService.getselectedClassPeriodbyschoolandcourse(this.schoolId,this.courseId).subscribe(res=>{
        this.selectedclassperiod=res;
      });
      
      this.isShown=true;
    } 
  }
  
  filterBySection(value:any){
      this.selectedCourseSection=this.selectSection.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
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
    this.ClassRoutineForm.get('subjectName')?.setValue(dropdown.text);
    this.ClassRoutineForm.get('bnaSubjectNameId')?.setValue(bnaSubjectNameId);
   this.onSubjectNameSelectionChange(baseSchoolNameId,courseNameId,courseSectionId,bnaSubjectNameId,courseDurationId,index);  

   this.subscription = this.ClassRoutineService.getselectedInstructor(baseSchoolNameId,courseNameId,courseDurationId,courseSectionId,bnaSubjectNameId).subscribe(res=>{
      this.selectedInstructor[bnaSubjectNameId]=res;
      this.selectInstructor=res
    });

    
    
    
    this.subscription = this.ClassRoutineService.getselectedmarktype(bnaSubjectNameId).subscribe(res=>{
      this.selectedmarktype[bnaSubjectNameId]=res;
      this.selectMarkType=res
    });
  }
  // addInputGroup() {
  //   this.inputGroups.push({ value: '' });
  // }
  valueCopy(index: number, value: string){
    if (value) {
      this.inputGroups.push({ value });
    }
  }

  onSubjectMarkSelectionGetMarkType(index: number){

   let markId = (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('subjectMarkId')?.value;
    // var subjectMarkId = this.ClassRoutineForm.value['subjectMarkId'];
    this.ClassRoutineService.findSubjectMark(markId).subscribe(res=>{
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('markTypeId')?.setValue(res.markTypeId);
     // this.ClassRoutineForm.get('markTypeId').setValue(res.markTypeId);
    });

  }

  onSubjectNameSelectionChange(baseSchoolNameId,courseNameId,courseSectionId,bnaSubjectNameId,courseDurationId,index){
    // var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    // var courseNameId=this.ClassRoutineForm.value['courseNameId'];
    // var bnaSubjectNameId=this.ClassRoutineForm.value['bnaSubjectNameId'];
    // var courseDurationId=this.ClassRoutineForm.value['courseDurationId'];
    //let routineCounttt;

    this.subscription = this.ClassRoutineService.getClassRoutineCountByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId,courseDurationId,courseSectionId).subscribe(res=>{
      this.routineCount=res;
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('classCountPeriod')?.setValue(this.routineCount);
    //  this.ClassRoutineForm.get('classCountPeriod').setValue(this.routineCount);
    
   // if ( bnaSubjectNameId)
   //this.routineCount=this.routineCount+1;

    });

 
  
    this.subscription = this.ClassRoutineService.getTotalPeriodByParameterRequest(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      this.totalPeriod=res;
      (this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get('subjectCountPeriod')?.setValue(this.totalPeriod);
      // this.ClassRoutineForm.get('subjectCountPeriod').setValue(this.totalPeriod);
    });


    if(baseSchoolNameId !=null && courseNameId !=null  && bnaSubjectNameId !=null){

      this.subscription = this.ClassRoutineService.getCourseModuleIdForRoutine(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
        var courseModuleId=res;
        this.ClassRoutineForm.get('courseModuleId')?.setValue(courseModuleId);
      });

      this.subscription = this.ClassRoutineService.getselectedClassPeriodbyschoolandcourse(baseSchoolNameId,courseNameId).subscribe(res=>{
        this.selectedclassperiod=res;
        this.selectClassPeriod=res;
      });
    
    }  
  }
  filterByClassPeriod(value:any){
    this.selectedclassperiod=this.selectClassPeriod.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

filterByInstructor(value:any){
  this.selectedInstructor=this.selectInstructor.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
filterBymarkType(value:any){
  this.selectedmarktype=this.selectMarkType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
   
  getControlLevel(index: number, type: string) {
  
    let y =1;
    let period_count=0;
    period_count =(this.ClassRoutineForm.get('perodListForm') as FormArray).at(index).get(type)?.value;
    return  period_count;
  }
 

  onSectionSelectionGet(){
    var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
    var courseNameId=this.ClassRoutineForm.value['courseNameId'];
    var courseWeekId=this.ClassRoutineForm.value['courseWeekId'];
    var courseDurationId=this.ClassRoutineForm.value['courseDurationId'];
    this.sectionId = this.ClassRoutineForm.value['courseSectionId'];


    this.subscription = this.ClassRoutineService.getselectedSubjectNamesBySchoolAndCourse(baseSchoolNameId,courseNameId).subscribe(res=>{
      this.selectedsubjectname=res;
      this.selectSubjectName=res
    });
    
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

    this.subscription = this.ClassRoutineService.getClassRoutineByCourseNameBaseSchoolNameSpRequest(baseSchoolNameId,courseNameId,courseWeekId,this.sectionId).subscribe(res=>{
      this.selectedRoutineByParametersAndDate=res;
      //debugger;
      // for(let i=0;i<=this.selectedRoutineByParametersAndDate.length;i++){

      // }

      this.displayedColumns =[...Object.keys(this.selectedRoutineByParametersAndDate[0])];
      


      
    });
  }
  filterBySubject(value:any){
      this.selectedsubjectname=this.selectSubjectName.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }


  getselectedbaseschools(){
    this.subscription = this.ClassRoutineService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
      
    });
  } 
  filterBySchool(value:any){
    this.selectedbaseschool=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedbaseschoolsByBase(baseNameId){
    this.subscription = this.ClassRoutineService.getselectedbaseschoolsByBase(baseNameId).subscribe(res=>{
      this.selectedbaseschool=res;
      this.selectSchool=res
    });
  }  

  getselectedcoursedurationbyschoolname(){
      var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
      this.subscription = this.ClassRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
        this.selectedcoursedurationbyschoolname=res;
        this.selectCourseTitle=res;
      });
  } 
  filterByCourseTitle(value:any){
    this.selectedcoursedurationbyschoolname=this.selectCourseTitle.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
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
    
    this.subscription = this.ClassRoutineService.getSelectedCourseWeeks(baseSchoolNameId,courseDurationId,courseNameId).subscribe(res=>{
      this.selectedWeek=res;
      this.selectWeek=res;
    });    
  } 
  filterByWeek(value:any){
    this.selectedWeek=this.selectWeek.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getselectedCourseModules(){
    this.subscription = this.ClassRoutineService.getselectedCourseModules().subscribe(res=>{
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
      this.selectClassType=res
    });
  }
  filterByClassType(value:any){
    this.selectedclasstype=this.selectClassType.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  

  onSubmit() {
    const id = this.ClassRoutineForm.get('classRoutineId')?.value;   
    
    //his.loadSpinner();
    this.loading = true;
    this.ClassRoutineService.submit(this.ClassRoutineForm.value).subscribe(response => {
      
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
