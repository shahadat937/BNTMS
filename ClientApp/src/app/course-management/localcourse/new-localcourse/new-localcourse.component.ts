import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseDurationService } from '../../service/courseduration.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { CourseNameService } from '../../../basic-setup/service/CourseName.service';
import { delay, of, Subscription } from 'rxjs';
import { UnsubscribeOnDestroyAdapter } from 'src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-localcourse',
  templateUrl: './new-localcourse.component.html',
  styleUrls: ['./new-localcourse.component.sass']
})
export class NewLocalcourseComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
  subscription: Subscription = new Subscription();
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
  filteredSelectedSchool: SelectedModel[];
  selectedBaseName:SelectedModel[];
  filteredSelectedBaseName: SelectedModel[];
  selectedbaseschoolfornbcd:SelectedModel[];
  courseNameId:number;

  options = [];
  filteredOptions;
  filteredbaseSchoolFornbcd: SelectedModel[];

  constructor(private snackBar: MatSnackBar,private CourseNameService: CourseNameService,private confirmService: ConfirmService,private CodeValueService: CodeValueService,private CourseDurationService: CourseDurationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('courseDurationId'); 
     this.courseTypeId= this.route.snapshot.paramMap.get('courseTypeId');  
    if (id) {
      this.pageTitle = 'Edit Local Course'; 
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
            professional:res.professional,
            nbcd:res.nbcd,
            remark:res.remark,
            courseTypeId:res.courseTypeId,
            countryId:res.countryId,
            baseNameId:res.baseNameId,
            isCompletedStatus:res.isCompletedStatus,
            // isApproved:res.isApproved,
            // approvedBy:res.approvedBy,
            noOfCandidates:res.noOfCandidates,
            status:res.status,
            menuPosition: res.menuPosition, 
            isActive: res.isActive,
            course:res.courseName,
            nbcdSchoolId:res.nbcdSchoolId
            
          });     
          this.courseNameId = res.courseNameId;  
          this.getselectedbasesName();
          this.onBaseNameSelectionChangeGetSchool(res.baseNameId);
          
        }
      );
    } else {
      this.pageTitle = 'Create Local Course';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedcoursename();
    this.getselectedbaseschools();
    this.getselectedcountry();
    this.getselectedcoursetype();
    this.getselectedbasesName();
    this.getselectedbaseschoolsfornbcd();
  }
  intitializeForm() {
    this.CourseDurationForm = this.fb.group({
      courseDurationId: [0],
      courseNameId:['',Validators.required],
      course:[''],
      courseTitle:['',Validators.required],
      baseSchoolNameId:['',Validators.required],
      baseNameId:[],
      durationFrom:[],
      durationTo:[],    
      professional:[''],
      nbcd:[''], 
      remark:[''],
      courseTypeId:[this.courseTypeId],
      countryId:[1],
      isCompletedStatus:[0],
      nbcdSchoolId:[''],
      // isApproved:[],
      // approvedBy:[],
      noOfCandidates:[''],
      status:[1],
      isActive: [true],    
    })
    this.CourseDurationForm.get('course').valueChanges
    .subscribe(value => {
     
        this.getSelectedCourseAutocomplete(value);
    })
  }

  filterBaseName(value:any) {
    
    this.filteredSelectedBaseName = this.selectedBaseName.filter(x=> x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }

  filterSchoolName(value:any) {
    this.filteredSelectedSchool = this.selectedSchool.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }

  filterNbcd(value: any) {
    this.filteredbaseSchoolFornbcd = this.selectedbaseschoolfornbcd.filter(x => x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')));
  }
  //autocomplete
  onCourseSelectionChanged(item) {
    this.courseNameId = item.value 
    this.CourseDurationForm.get('courseNameId').setValue(item.value);
    this.CourseDurationForm.get('course').setValue(item.text);
  }
  getSelectedCourseAutocomplete(cName){
    if(cName.trim()=="") {
      this.options = [];
      this.filteredOptions = [];
      return;
    }

    const $source = (of (cName)).pipe(
      delay(700)
    );

    if(this.subscription) {
      this.subscription.unsubscribe();
    }

    this.subscription = $source.subscribe(data=> {
      this.CourseNameService.getSelectedCourseByNameAndType(this.courseTypeId,cName).subscribe(response => {
        this.options = response;
        this.filteredOptions = response;
      })

    })

  }
    
  getselectedbaseschoolsfornbcd(){
    this.CourseDurationService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschoolfornbcd=res
      this.filteredbaseSchoolFornbcd = res;
    });
  }

  getselectedbasesName(){
    let branchLevel = 3;
    this.CourseDurationService.getselectedBaseNamesForCourse(branchLevel).subscribe(res=>{
      this.selectedBaseName=res
      this.filteredSelectedBaseName = this.selectedBaseName;
    });
  }
  onBaseNameSelectionChangeGetSchool(baseNameId){
    this.CourseDurationService.getSelectedSchoolsForCourse(baseNameId).subscribe(res=>{
      this.selectedSchool=res
      this.filteredSelectedSchool = this.selectedSchool;
    });
   }

  getselectedcoursename(){
    this.CourseDurationService.getCourseByType(this.courseTypeId).subscribe(res=>{
      this.selectedcourse=res
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
    const id = this.CourseDurationForm.get('courseDurationId').value;   
    const durationFrom = this.sharedService.formatDateTime(this.CourseDurationForm.get('durationFrom').value)
    console.log(durationFrom)
    this.CourseDurationForm.get('durationFrom')?.setValue(durationFrom);
    const durationTo = this.sharedService.formatDateTime(this.CourseDurationForm.get('durationTo').value)
    this.CourseDurationForm.get('durationTo')?.setValue(durationTo);
    console.log(durationTo)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          console.log('Test',this.CourseDurationForm.value);
          this.CourseDurationService.update(+id,this.CourseDurationForm.value).subscribe(response => {
            this.router.navigateByUrl('/course-management/localcourse-list');
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
        this.router.navigateByUrl('/course-management/localcourse-list');
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
 
  }}
