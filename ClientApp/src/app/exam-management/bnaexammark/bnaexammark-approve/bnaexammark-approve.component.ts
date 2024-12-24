import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BNASubjectName } from 'src/app/subject-management/models/BNASubjectName';
import { SubjectMark } from '../../../subject-management/models/SubjectMark';
import {TraineeNominationService} from '../../../course-management/service/traineenomination.service'
import { TraineeList } from '../../../attendance-management/models/traineeList';
import { TraineeListForExamMark } from '../../models/traineeListforexammark';
import { AuthService } from 'src/app/core/service/auth.service';
import { SubjectMarkService } from 'src/app/subject-management/service/SubjectMark.service';
import { MarkTypeService } from 'src/app/basic-setup/service/MarkType.service';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-bnaexammark-approve',
  templateUrl: './bnaexammark-approve.component.html',
  styleUrls: ['./bnaexammark-approve.component.css']
})  
export class BNAExamMarkApproveComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BNAExamMarkForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools:SelectedModel[];
 
   selectedcoursename:SelectedModel[];
    selectedcoursedurationbyschoolname:SelectedModel[];
    selectedClassTypeByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
    selectedSubjectNameByBaseSchoolNameIdAndCourseNameId:SelectedModel[];
    selectedmarktype:SelectedModel[];
    selectedmarkremarks:SelectedModel[];
    getTotalMarkAndPassMark:BNASubjectName;
    totalMark: string;
    baseSchoolNameId:number;
    classRoutineId:number;
    bnaSubjectNameId:number;
    passMarkBna:string;
    subjectMarkList:SubjectMark[]
    isShown: boolean = false ;
    selectedCourseDuration:number;
    traineeList:TraineeListForExamMark[];
    examTypeCount:number;
    markTypeName:any;
    subjectPassMark:any;
    ApproveMsgScreen: boolean = false ;
    ApproveMsg:string;
    mark:any;
    isBigger:boolean =false;
    markType:any;
    role:any;
    traineeId:any;
    branchId:any;
    baseSchoolId:any;

    paging = {
      pageIndex: this.masterData.paging.pageIndex,
      pageSize: this.masterData.paging.pageSize,
      length: 1
    }
  
    displayedColumns: string[] = ['sl','markType','passMark', 'mark'];
    displayedColumnsForTraineeList: string[] = ['sl','traineePNo','traineeName', 'obtaintMark','examMarkRemarksId'];

  constructor(private snackBar: MatSnackBar,private authService: AuthService,private markTypeService: MarkTypeService,private subjectMarkService: SubjectMarkService,private traineeNominationService:TraineeNominationService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private BNAExamMarkService: BNAExamMarkService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bnaExamMarkId'); 
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    if (id) {
      this.pageTitle = 'Edit  Exam Mark'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.BNAExamMarkService.find(+id).subscribe(
        res => {
          this.BNAExamMarkForm.patchValue({          
            bnaExamMarkId:res.bnaExamMarkId, 
            bnaExamScheduleId:res.bnaExamScheduleId, 
            bnaSemesterId:res.bnaSemesterId, 
            bnaBatchId:res.bnaBatchId, 
            baseSchoolNameId:res.baseSchoolNameId,
            courseNameId:res.courseNameId,
            examTypeId:res.examTypeId,
            bnaCurriculamTypeId:res.bnaCurriculamTypeId,
            bnaSubjectNameId:res.bnaSubjectNameId,
            totalMark:res.totalMark,
            passMark:res.passMark,
            isApproved:res.isApproved,
            isApprovedBy:res.isApprovedBy,
            isApprovedDate:res.isApprovedDate,
            remarks:res.remarks,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });          
        }
      );
    } else {
      this.pageTitle = 'Approve  Exam Mark';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
     this.intitializeForm();   
     if(this.role === 'Super Admin'){
      this.BNAExamMarkForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
     }
     this.setParamDataToForm();
     this.getselectedbaseschools(); 
     this.getselectedcoursename();
     this.getselectedexammarkremark();
     
  }
  intitializeForm() {
    this.BNAExamMarkForm = this.fb.group({
      bnaExamScheduleId:[],
      bnaSemesterId:[],
      courseName:[''],
      bnaBatchId:[],
      baseSchoolNameId:[],    
      courseNameId:[],
      courseModuleId:[],
      courseTypeId:[],
      SubjectMarkId:[], 
      bnaCurriculamTypeId:[],
      bnaSubjectNameId:[],
      bnaSubjectName:[''],
      courseDurationId:[],
      classRoutineId:[],
      courseSectionId:[],
      totalMark:[''],
      passMark:[''],
      obtaintMark:[],
      examTypeCount:[],
      isApproved:[true],
      isApprovedBy:[],
      isApprovedDate:[],
    //  courseSectionId:[],
      remarks:[],
      approveTraineeListForm: this.fb.array([
        this.createTraineeData()
      ]),
      status:[],
      isActive: [true],    
      
    })
  }
  setParamDataToForm(){
    var courseDurationId = this.route.snapshot.paramMap.get('courseDurationId');
    var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    var courseModuleId = this.route.snapshot.paramMap.get('courseModuleId');
    var classRoutineId = this.route.snapshot.paramMap.get('classRoutineId');
    var courseSectionId = this.route.snapshot.paramMap.get('courseSectionId');
    var branchId = this.route.snapshot.paramMap.get('branchId');
    var bnaSubjectNameId = this.route.snapshot.paramMap.get('bnaSubjectNameId');
    var subjectMarkId = this.route.snapshot.paramMap.get('subjectMarkId');
    var markTypeId = this.route.snapshot.paramMap.get('markTypeId');
    var courseSectionId = this.route.snapshot.paramMap.get('courseSectionId');

    this.markType=markTypeId;
    this.BNAExamMarkForm.get('baseSchoolNameId').setValue(baseSchoolNameId);
    this.BNAExamMarkForm.get('courseDurationId').setValue(courseDurationId);
    this.BNAExamMarkForm.get('courseNameId').setValue(courseNameId);
    this.BNAExamMarkForm.get('classRoutineId').setValue(classRoutineId);
    this.BNAExamMarkForm.get('courseSectionId').setValue(courseSectionId);
    this.BNAExamMarkForm.get('courseModuleId').setValue(courseModuleId);
    this.BNAExamMarkForm.get('bnaSubjectNameId').setValue(bnaSubjectNameId);
    this.BNAExamMarkForm.get('SubjectMarkId').setValue(subjectMarkId);
    this.BNAExamMarkForm.get('courseSectionId').setValue(courseSectionId);
    this.BNAExamMarkForm.get('examTypeCount').setValue(1);

    this.markTypeService.find(Number(markTypeId)).subscribe(res => {       
      this.markTypeName = res.typeName;
      this.onSubjectMarkSelectionGetPassMark();
      this.getselectedtraineebytype();
    });

    // this.BNAExamMarkService.GetSubjectMarkByCourseNameIdSubjectNameId(courseNameId, bnaSubjectNameId).subscribe(res => {       
    //   this.subjectMarkList = res;
    //  });
    this.BNAExamMarkService.GetSubjectMarkByBaseSchoolNameIdCourseNameAndSubjectNameId(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
      this.subjectMarkList=res;
    });


    
    // this.BNAExamMarkService.getapprovededmarktypes(baseSchoolNameId,courseNameId,courseDurationId,bnaSubjectNameId,courseModuleId,true).subscribe(res=>{
    //   this.selectedmarktype=res
    //   this.examTypeCount = res.length;
    //   this.BNAExamMarkForm.get('examTypeCount').setValue(this.examTypeCount);
    // });

    //  this.BNAExamMarkService.getapprovedMarkTypeByParametersForCentralExam(courseNameId, courseDurationId, bnaSubjectNameId,true).subscribe(res => {
    //   this.selectedmarktype = res
    //   this.examTypeCount = res.length;
    //   this.BNAExamMarkForm.get('examTypeCount').setValue(this.examTypeCount);
    // });


    // this.BNAExamMarkService.GetTotalMarkAndPassMarkByCourseNameIdAndSubjectId(courseNameId, bnaSubjectNameId).subscribe(res => {

    //   this.getTotalMarkAndPassMark = res;
    //   this.totalMark = res[0].totalMark;
    //   this.passMarkBna = res[0].passMarkBNA
    //   this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
    //   this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
    // });

    // this.BNAExamMarkService.GetTotalMarkAndPassMarkByBaseSchoolIdCourseIdAndSubjectId(baseSchoolNameId,courseNameId,bnaSubjectNameId).subscribe(res=>{
          
    //   this.getTotalMarkAndPassMark=res; 
    //   this.totalMark=res[0].totalMark;
    //   this.passMarkBna=res[0].passMarkBNA
    //   this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
    //   this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
    // });

    
    
  }

  onValueChange(value,i){
    var baseSchoolNameId = this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId = this.BNAExamMarkForm.value['courseNameId'];
    var courseDurationId = this.BNAExamMarkForm.value['courseDurationId'];
    var courseSectionId = this.BNAExamMarkForm.value['courseSectionId'];
    var bnaSubjectNameId = this.BNAExamMarkForm.value['bnaSubjectNameId'];
    var classRoutineId = this.BNAExamMarkForm.value['classRoutineId'];
    

   // this.BNAExamMarkService.getExamMarkForValidation(baseSchoolNameId,courseDurationId,courseSectionId,bnaSubjectNameId,this.markType).subscribe(res=>{
      //this.mark=res;
      if( value >this.mark){
          this.isBigger=true;
          (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(i).get('obtaintMark').setValue("");

      }
      else{
        this.isBigger=false;
    }
   // });

  }

  onSubjectMarkSelectionGetPassMark(){
    var subjectMarkId=this.BNAExamMarkForm.value['SubjectMarkId'];
    this.subjectMarkService.find(subjectMarkId).subscribe(res => {
      this.subjectPassMark = res.passMark;
      var mark = res.mark;
      this.mark=mark;
      this.BNAExamMarkForm.get('totalMark').setValue(mark);
      this.BNAExamMarkForm.get('passMark').setValue(this.subjectPassMark);
    });
    
  }

  OnTextCheck(value,index ){

    if(value >= this.subjectPassMark){
      (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(index).get('resultStatusShow').setValue('Pass');
      (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(index).get('resultStatus').setValue(1);
    }else{
      (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(index).get('resultStatusShow').setValue('Fail');
      (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(index).get('resultStatus').setValue(0);
    }
  }

  getControlLabel(index: number,type: string){
    return  (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(index).get(type).value;
   }
  private createTraineeData() {
 
    return this.fb.group({
      bnaExamMarkId: [],
      traineePNo:[],
      traineeId: [],
      traineeName:[],
      rankPosition:[],
      saylorRank:[],
      obtaintMark: [],
      resultStatusShow:[''],
      resultStatus:[],
      checkStatus:[],
      examMarkRemarksId:[],
      submissionStatus:[],
      createdBy:[],
      dateCreated:[],
      reExamStatus:[]
    });
  }

  

  getselectedbaseschools(){
    this.BNAExamMarkService.getselectedbaseschools().subscribe(res=>{

      this.selectedbaseschools=res
    });
  }

  getselectedexammarkremark(){
    this.BNAExamMarkService.getselectedexammarkremark().subscribe(res=>{

      this.selectedmarkremarks=res
    });
  }
  onCourseNameSelectionChangeGetSubjectAndTraineeList(dropdown){
    if(dropdown.isUserInput) {
    var courseNameArr = dropdown.source.value.value.split('_');
    var courseNameTextArr = dropdown.source.value.text.split('_');
    var courseName = courseNameTextArr[0];
    var coursetitle = courseNameTextArr[1];
    var courseDurationId=courseNameArr[0];
    var courseNameId=courseNameArr[1];
    this.BNAExamMarkForm.get('courseName').setValue(dropdown.text);
    this.BNAExamMarkForm.get('courseNameId').setValue(courseNameId);
    this.BNAExamMarkForm.get('courseDurationId').setValue(courseDurationId);
    this.isShown=false;

    var baseSchoolNameId=this.BNAExamMarkForm.value['baseSchoolNameId'];
    this.baseSchoolNameId=baseSchoolNameId;
    var courseNameId=this.BNAExamMarkForm.value['courseNameId'];
    
     if(baseSchoolNameId != null && courseNameId != null){
       this.BNAExamMarkService.getApprovedSubjectNameByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId,courseDurationId).subscribe(res=>{
     
        this.selectedSubjectNameByBaseSchoolNameIdAndCourseNameId=res;      
       });
     }
     
     this.BNAExamMarkService.getCourseDurationByBaseSchoolNameIdAndCourseNameId(baseSchoolNameId,courseNameId).subscribe(res=>{
      this.selectedCourseDuration=res;   
     });
     
  }
}

  getselectedtraineebytype(){
    var baseSchoolNameId=this.BNAExamMarkForm.value['baseSchoolNameId'];
    var courseNameId=this.BNAExamMarkForm.value['courseNameId'];
    var courseDurationId=this.BNAExamMarkForm.value['courseDurationId'];
    var bnaSubjectNameId=this.BNAExamMarkForm.value['bnaSubjectNameId'];
    var classRoutineId=this.BNAExamMarkForm.value['classRoutineId'];
    var SubjectMarkId=this.BNAExamMarkForm.value['SubjectMarkId'];
    var courseSectionId=this.BNAExamMarkForm.value['courseSectionId'];

    
    this.BNAExamMarkService.getexamMarkFilterListByParameters(baseSchoolNameId,courseNameId,bnaSubjectNameId,courseDurationId,SubjectMarkId,false,courseSectionId,classRoutineId).subscribe(res=>{
      var unapprovedlistItemCount = res.length;
      if(unapprovedlistItemCount > 0){
        this.traineeList=res;  
        this.ApproveMsgScreen=false;
        this.isShown=true;   
        this.clearList();
        this.getTraineeListonClick(); 
      }else{
        this.isShown=false;  
        this.ApproveMsgScreen=true;

        this.BNAExamMarkService.getexamMarkFilterListByParameters(baseSchoolNameId,courseNameId,bnaSubjectNameId,courseDurationId,SubjectMarkId,true,courseSectionId,classRoutineId).subscribe(response=>{


          var approvedlistItemCount = response.length;
          if(approvedlistItemCount > 0){
            this.ApproveMsg = "Records are already Approved!";
          }else{
            this.ApproveMsg = "Marks are not isnerted Yet!";
          }
        });
        
      }
      
    });   
    
  }

  onSubjectNameSelectionChangeGetTotalMarkAndPassMark(dropdown){

    if(dropdown.isUserInput) {
        
      this.isShown=false;
      var subjectArr = dropdown.source.value.value.split('_');
      
      var baseSchoolNameId=this.BNAExamMarkForm.value['baseSchoolNameId'];  
      var courseNameId=this.BNAExamMarkForm.value['courseNameId'];

      this.bnaSubjectNameId = subjectArr[0];
      var courseModuleId = subjectArr[1];
      this.BNAExamMarkForm.get('bnaSubjectName').setValue(dropdown.text);
      this.BNAExamMarkForm.get('bnaSubjectNameId').setValue(this.bnaSubjectNameId);
      this.BNAExamMarkService.GetSubjectMarkByBaseSchoolNameIdCourseNameAndSubjectNameId(baseSchoolNameId,courseNameId,this.bnaSubjectNameId).subscribe(res=>{
        this.subjectMarkList=res;
      });

      this.BNAExamMarkService.GetRoutineIdWithSchoolCourseSubject(baseSchoolNameId,courseNameId,this.bnaSubjectNameId).subscribe(res=>{
        this.classRoutineId=res;
        this.BNAExamMarkForm.get('classRoutineId').setValue(this.classRoutineId);
        
      });

      // this.BNAExamMarkService.getapprovededmarktypes(baseSchoolNameId,courseNameId,this.bnaSubjectNameId,courseModuleId).subscribe(res=>{
      //   this.selectedmarktype=res
      // });

    


      this.BNAExamMarkService.GetTotalMarkAndPassMarkByBaseSchoolIdCourseIdAndSubjectId(baseSchoolNameId,courseNameId,this.bnaSubjectNameId).subscribe(res=>{
        this.getTotalMarkAndPassMark=res; 
        this.totalMark=res[0].totalMark;
        this.passMarkBna=res[0].passMarkBNA
        this.BNAExamMarkForm.get('totalMark').setValue(this.totalMark);
        this.BNAExamMarkForm.get('passMark').setValue(this.passMarkBna);
      });
      
    }
  }


  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.BNAExamMarkForm.value['baseSchoolNameId'];
    this.isShown=false;
    
    this.BNAExamMarkService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedcoursedurationbyschoolname=res;
    }); 
  }
  
  getselectedcoursename(){
    this.BNAExamMarkService.getselectedcoursename().subscribe(res=>{
      this.selectedcoursename=res
    });
  }

  getTraineeListonClick(){ 
    const control = <FormArray>this.BNAExamMarkForm.controls["approveTraineeListForm"];
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData()); 
      if(this.traineeList[i].resultStatus == 1){
        (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(i).get('resultStatusShow').setValue('Pass');
      }else{
        (this.BNAExamMarkForm.get('approveTraineeListForm') as FormArray).at(i).get('resultStatusShow').setValue('Fail');
      }
    }
    this.BNAExamMarkForm.patchValue({ approveTraineeListForm: this.traineeList });
  }

  clearList() {
    const control = <FormArray>this.BNAExamMarkForm.controls["approveTraineeListForm"];
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  onSubmit() {     
    
    this.confirmService.confirm('Confirm Save message', 'Are You Sure Save This Records?').subscribe(result => {
      if (result) {
        this.loading = true;
        this.BNAExamMarkService.approve(JSON.stringify(this.BNAExamMarkForm.value)).subscribe(response => {            
          this.BNAExamMarkForm.reset();
          // if(this.branchId){
          //   this.router.navigateByUrl(`/admin/dashboard/pendingexamevaluation-list/${this.branchId}`);
          // }
          //   // else if(this.courseNameId == this.masterData.courseName.QExam){
          //   //   this.router.navigateByUrl(`/central-exam/qexamapprove-list`);
          //   //}
          // else {
          //   this.router.navigateByUrl(`/exam-management/exammarkapprove-list`);
          // }
          this.sharedService.goBack(); // redirect to privious Page;
          this.isShown = false;         
          this.BNAExamMarkForm.get('isActive').setValue(true);
          this.BNAExamMarkForm.get('isApproved').setValue(false); 
          this.snackBar.open('Information Inserted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warn'
          });
        }, error => {
          this.validationErrors = error;
        })
      }
    })      
  }
}
