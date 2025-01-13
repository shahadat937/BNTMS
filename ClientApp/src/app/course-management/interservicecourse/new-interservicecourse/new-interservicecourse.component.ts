import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseDurationService } from '../../service/courseduration.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-interservicecourse',
  templateUrl: './new-interservicecourse.component.html',
  styleUrls: ['./new-interservicecourse.component.sass']
})
export class NewInterservicecourseComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  CourseDurationForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse:SelectedModel[];
  selectedbaseschool:SelectedModel[];
  selectedcountry:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selectedcoursetype:SelectedModel[];
  courseTypeId:string;
  selectedSchool:SelectedModel[];
  selectSchoolName: SelectedModel[];
  selectedBaseName:SelectedModel[];
  selectBaseName: SelectedModel[]
  selectCourse: SelectedModel[];

  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private CourseDurationService: CourseDurationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('courseDurationId'); 
     this.courseTypeId= this.route.snapshot.paramMap.get('courseTypeId'); 

     if(!this.courseTypeId){
      this.courseTypeId = MasterData.coursetype.InterService.toString();
     }
     
    
    if (id) {
      this.pageTitle = 'Edit Interservice Course'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.CourseDurationService.find(+id).subscribe(
        res => {
                   
          this.CourseDurationForm.patchValue({          
            courseDurationId:res.courseDurationId, 
            courseNameId: res.courseNameId, 
            courseTitle:res.courseTitle, 
            baseSchoolNameId:res.baseSchoolNameId, 
            durationFrom:res.durationFrom, 
            durationTo:res.durationTo,
            professional:res.durationTo,
            nbcd:res.nbcd,
            remark:res.remark,
            courseTypeId:res.courseTypeId,
            countryId:res.countryId,
            baseNameId:res.baseNameId,
            // isCompletedStatus:res.isCompletedStatus,
            // isApproved:res.isApproved,
            // approvedBy:res.approvedBy,
            // approvedDate:res.approvedDate,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          });     
          this.onBaseNameSelectionChangeGetSchool(res.baseNameId)
        }
      );
    } else {
      this.pageTitle = 'Create Interservice Course'; 
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedcoursename();
    this.getselectedbaseschools();
    this.getselectedcountry();
    this.getselectedcoursetype();
    this.getselectedbasesName();
  }
  intitializeForm() {
    this.CourseDurationForm = this.fb.group({
      courseDurationId: [0],
      courseNameId:['',Validators.required],
      courseTitle:['',Validators.required],
      baseSchoolNameId:[''],
      baseNameId:[],
      durationFrom:[],
      durationTo:[],    
      professional:[''],
      nbcd:[''], 
      remark:[''],
      courseTypeId:[this.masterData.coursetype.InterService],
      countryId:[this.masterData.country.bangladesh],
      isCompletedStatus:[0],
      // isApproved:[],
      // approvedBy:[],
      // approvedDate:[],
      status:[1],
      isActive: [true],    
    })
  }
  
  getselectedbasesName(){
    const branchLevel : number = 3;
    this.CourseDurationService.getSelectedBaseName(branchLevel).subscribe(res=>{
      this.selectedBaseName=res
      this.selectBaseName=res
    });
  }
  onBaseNameSelectionChangeGetSchool(baseNameId){
    this.CourseDurationService.getSchoolByBaseId(baseNameId).subscribe(res=>{
      this.selectedSchool=res
      this.selectSchoolName=res
    });
   }
   filterBySchool(value:any){
    this.selectedSchool = this.selectSchoolName.filter(x => x.text.toLowerCase().includes(value.toLowerCase()))
   }
   filterByCourse(value: any) {
    this.selectedcourse = this.selectCourse.filter(x => x.text.toLowerCase().includes(value.toLowerCase()))
  }
  filterByBaseName(value:any){
    this.selectedBaseName = this.selectBaseName.filter(x => x.text.toLowerCase().includes(value.toLowerCase()))
  }

  getselectedcoursename(){
    
    this.CourseDurationService.getCourseByType(this.courseTypeId).subscribe(res=>{
      this.selectedcourse=res
      this.selectCourse=res
    });
  } 

  getselectedcoursetype(){
    this.CourseDurationService.getselectedcoursetype().subscribe(res=>{
      this.selectedcoursetype=res
    });
  } 

  getselectedbaseschools(){
    this.CourseDurationService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res
    });
  }

  getselectedcountry(){
    this.CourseDurationService.getselectedcountry().subscribe(res=>{
      this.selectedcountry=res
    });
  }

  onSubmit() {
    const id = this.CourseDurationForm.get('courseDurationId')?.value;   
    // const dateCreated = this.sharedService.formatDateTime(this.CourseDurationForm.get('dateCreated').value)

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.CourseDurationService.update(+id,this.CourseDurationForm.value).subscribe(response => {
            this.router.navigateByUrl('/course-management/interservicecourse-list');
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
      this.CourseDurationService.submit(this.CourseDurationForm.value).subscribe(response => {
        this.router.navigateByUrl('/course-management/interservicecourse-list');
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
