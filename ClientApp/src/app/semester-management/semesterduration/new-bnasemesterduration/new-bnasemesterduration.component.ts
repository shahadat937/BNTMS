import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNASemesterDurationService } from '../../service/BNASemesterDuration.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';

@Component({
  selector: 'app-new-bnasemesterduration',
  templateUrl: './new-bnasemesterduration.component.html',
  styleUrls: ['./new-bnasemesterduration.component.sass']
}) 
export class NewBnasemesterdurationComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BNASemesterDurationForm: FormGroup;
  validationErrors: string[] = [];
  bnaSubjectCurriculam:SelectedModel[];
  selectCurriculam:SelectedModel[];
  department:SelectedModel[];
  selectedSemester:SelectedModel[];
  selectedCourseDuration:SelectedModel[];
  selectSemester:SelectedModel[];
  selectCourse:SelectedModel[];
  selectedBatch:SelectedModel[];
  selectBatch:SelectedModel[];
  selectedRank:SelectedModel[];
  selectPromotion:SelectedModel[];
  selectedLocationType:SelectedModel[];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private BNASemesterDurationService: BNASemesterDurationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bnaSemesterDurationId'); 
    if (id) {
      this.pageTitle = 'Edit BNASemesterDuration'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.subscription = this.BNASemesterDurationService.find(+id).subscribe(
        res => {
          this.BNASemesterDurationForm.patchValue({  
                    
            bnaSemesterDurationId:res.bnaSemesterDurationId, 
            courseDurationId:res.courseDurationId,
            bnaSemesterId: res.bnaSemesterId, 
            bnaSubjectCurriculamId: res.bnaSubjectCurriculamId,
            // departmentId: res.departmentId,
            bnaBatchId:res.bnaBatchId, 
            startDate:res.startDate, 
            endDate:res.endDate, 
            semesterLocationType:res.semesterLocationType,
          // codeValueId:res.codeValueId, 
            rankId:res.rankId, 
            location:res.location, 
           // isSemesterComplete:res.isSemesterComplete,
            //nextSemesterId:res.nextSemesterId,
           // isApproved:res.isApproved,
            approvedBy:res.approvedBy, 
            approvedDate:res.approvedDate,
            status:res.status,
           // menuPosition:res.menuPosition,
           // isActive: res.isActive
         //   menuPosition: res.menuPosition,
          });          
        }
      );
    } else {
      this.pageTitle = 'Create BNASemesterDuration';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getSelectedBnaSubjectCurriculam();
    this.getSelectedDepartment();
    this.getSelectedBnaSemester();
    this.getSelectedBnaBatch();
    this.getSelectedRank();
    this.getSelectedLocationType();
    this.getSelectedCourseDuration();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.BNASemesterDurationForm = this.fb.group({
      bnaSemesterDurationId: [0],
      courseDurationId:[],
      bnaSemesterId:[''],
      bnaBatchId:[''],
      bnaSubjectCurriculamId:[''],
      // departmentId:[''],
      //codeValueId:[''],
     // nextSemesterId:[''],
      semesterLocationType:[''],
    //  isSemesterComplete:[true],
      rankId:[''],
      startDate:[],
      endDate:[],
      location:[''],
      //isApproved:[true],
      approvedBy:[''],
      approvedDate:[],
      status:[0],
      isActive: [true],    
    })
  }
  
  getSelectedLocationType(){
    this.subscription = this.CodeValueService.getSelectedCodeValueByType(this.masterData.codevaluetype.LocationType).subscribe(res=>{
      this.selectedLocationType=res;      
    })
  }

  filterSubjectCurriculam(value:any){
    this.bnaSubjectCurriculam=this.selectCurriculam.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().reeplac(/\s/g,'')))
  }
  getSelectedBnaSubjectCurriculam(){
    this.subscription = this.BNASemesterDurationService.getSelectedBnaSubjectCurriculam().subscribe(res=>{
      this.bnaSubjectCurriculam=res
      this.selectCurriculam=res
    });
  } 
  
  getSelectedDepartment(){
    this.subscription = this.BNASemesterDurationService.getSelectedDepartment().subscribe(res=>{
      this.department=res
    });
  } 

  filterBySemester(value:any){
    this.selectedSemester=this.selectSemester.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getSelectedBnaSemester(){
    this.subscription = this.BNASemesterDurationService.getSelectedBnaSemester().subscribe(res=>{
      this.selectedSemester=res
      this.selectSemester=res
    });
  } 
filterByCourse(value:any){
  this.selectedCourseDuration=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  getSelectedCourseDuration(){
    this.subscription = this.BNASemesterDurationService.getSelectedCourseDuration().subscribe(res=>{
      this.selectedCourseDuration=res
      this.selectCourse=res
    });
  } 

  filterByBatch(value:any){
    this.selectedBatch= this.selectBatch.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  getSelectedBnaBatch(){
    this.subscription = this.BNASemesterDurationService.getSelectedBnaBatch().subscribe(res=>{
      this.selectedBatch=res
      this.selectBatch=res
    });
  }
  filterPromotion(value:any){
    this.selectedRank=this.selectPromotion.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}
  getSelectedRank(){
    this.subscription =  this.BNASemesterDurationService.getSelectedRank().subscribe(res=>{
      this.selectedRank=res
      this.selectPromotion=res
    });
  }

  onSubmit() {
    const id = this.BNASemesterDurationForm.get('bnaSemesterDurationId').value;   
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.BNASemesterDurationService.update(+id,this.BNASemesterDurationForm.value).subscribe(response => {
            this.router.navigateByUrl('/semester-management/bnasemesterduration-list');
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
      this.subscription = this.BNASemesterDurationService.submit(this.BNASemesterDurationForm.value).subscribe(response => {
        this.router.navigateByUrl('/semester-management/bnasemesterduration-list');
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
