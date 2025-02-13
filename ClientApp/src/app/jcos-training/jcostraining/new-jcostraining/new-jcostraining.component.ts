import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseDurationService } from '../../service/courseduration.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { CourseNameService } from '../../../../../src/app/basic-setup/service/CourseName.service';
import { MatTableDataSource } from '@angular/material/table';
import {CourseDuration} from '../../models/courseduration'
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-jcostraining',
  templateUrl: './new-jcostraining.component.html',
  styleUrls: ['./new-jcostraining.component.sass']
})
export class NewJCOsTrainingComponent extends UnsubscribeOnDestroyAdapter implements OnInit {
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  CourseDurationForm: FormGroup;
  validationErrors: string[] = [];
  selectedfiscalyear:SelectedModel[];
  courseTypeId:1021;
  courseNameId:number;
  selectedCourseByType:SelectedModel[];
  isLoading = false;
  options = [];
  filteredOptions;
  //courseNameIdQExam:1252;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','courseName','durationFrom','durationTo', 'status', 'actions'];
  dataSource: MatTableDataSource<CourseDuration> = new MatTableDataSource();


  constructor(private snackBar: MatSnackBar,private confirmService: ConfirmService,private CourseNameService: CourseNameService,private CodeValueService: CodeValueService,private CourseDurationService: CourseDurationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) { 
    super()
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('courseDurationId'); 
    if (id) {
      this.pageTitle = 'Edit JCOs Exam'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.CourseDurationService.find(+id).subscribe(
        res => {
          this.CourseDurationForm.patchValue({ 
            courseDurationId: res.courseDurationId,
            courseNameId:res.courseNameId,
            courseTypeId:res.courseTypeId,
            courseTitle:res.courseTitle,
            fiscalYearId:res.fiscalYearId,
            baseSchoolNameId:res.baseSchoolNameId,
            durationFrom:res.durationFrom,
            durationTo:res.durationTo,          
            remark:res.remark,
            course:res.courseName,
            status:res.status,
            isActive:  res.isActive 
                  
          });     
          this.courseNameId = res.courseNameId;
        }
      );
    } else {
      this.pageTitle = 'Create JCOs Exam';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedfiscalyear();
    this.getSelectedCourseByType();
    this.getCourseDurationsByCourseType();
  }

  getCourseDurationsByCourseType(){
    this.isLoading = true;
    this.CourseDurationService.getCourseDurationsByCourseType(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.masterData.examtypefromcoursetype.centralExam).subscribe(response => {
      this.dataSource.data = response.items.filter(x=>x.isCompletedStatus===0); 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }

  pageChanged(event: PageEvent) {
  
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getCourseDurationsByCourseType();
  }
  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getCourseDurationsByCourseType();
  } 

  intitializeForm() {
    this.CourseDurationForm = this.fb.group({
      courseDurationId: [0],
      courseNameId:[MasterData.courseName.JCOsTraining],
      course:[''],
      courseTypeId:[MasterData.coursetype.CentralExam],
      courseTitle:[''],
      fiscalYearId:[],
      baseSchoolNameId:[],
      durationFrom:[],
      durationTo:[],          
      remark:[''],
      isCompletedStatus:[0],
      isActive: [true],    
    })
    //AutoComplete for courseName
    this.CourseDurationForm.get('course')?.valueChanges
          .subscribe(value => {
           
              this.getSelectedCourseAutocomplete(value);
          })
  }
  //AutoComplete for courseName
  onCourseSelectionChanged(item) {
    this.courseNameId = item.value 
    this.CourseDurationForm.get('courseNameId')?.setValue(item.value);
    this.CourseDurationForm.get('course')?.setValue(item.text);
  }
  //AutoComplete for courseName
  getSelectedCourseAutocomplete(cName){
    this.CourseNameService.getSelectedCourseByNameAndType(this.masterData.coursetype.CentralExam,cName).subscribe(response => {
      this.options = response;
      this.filteredOptions = response;
    })
  }
  getSelectedCourseByType(){
    this.CourseNameService.getSelectedCourseByType(1021).subscribe(res=>{
      this.selectedCourseByType=res
    });
  }

  deleteItem(row) {
    const id = row.courseDurationId; 
  
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.CourseDurationService.delete(id).subscribe(() => {
         this.getCourseDurationsByCourseType();
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

  stopCentralExam(element){
    if(element.isCompletedStatus ===0){
      this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Course?').subscribe(result => {
        if (result) {
       this.CourseDurationService.stopCentralExam(element.courseDurationId).subscribe(() => {
        this.getCourseDurationsByCourseType();
        
        this.snackBar.open('Information Stop Successfully ', '', {
          duration: 3000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-warning'
        });
      })
    }
  })
    }
  }

  getselectedfiscalyear(){
    this.CourseDurationService.getselectedFiscalYear().subscribe(res=>{
      this.selectedfiscalyear=res
    });
  }
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {

    const durationTo = this.sharedService.formatDateTime(this.CourseDurationForm.get('durationTo')?.value)
      this.CourseDurationForm.get('durationTo')?.setValue(durationTo);
    const durationFrom = this.sharedService.formatDateTime(this.CourseDurationForm.get('durationFrom')?.value)
      this.CourseDurationForm.get('durationFrom')?.setValue(durationFrom);

    const id = this.CourseDurationForm.get('courseDurationId')?.value;  
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.CourseDurationService.update(+id,this.CourseDurationForm.value).subscribe(response => {
            // this.router.navigateByUrl('/central-exam/centralexam-list');
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
      this.CourseDurationService.submit(this.CourseDurationForm.value).subscribe(response => {
        // this.router.navigateByUrl('/central-exam/centralexam-list');
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
}
