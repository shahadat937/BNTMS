import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { EventService } from '../../service/event.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { ClassRoutineService } from '../../../../../src/app/routine-management/service/classroutine.service';
import { Event } from '../../models/event';
import { MatOption } from '@angular/material/core';
import { Role } from '../../../../../src/app/core/models/role';
import { unix } from 'moment';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-event',
  templateUrl: './new-event.component.html',
  styleUrls: ['./new-event.component.sass']
}) 
export class NewEventComponent implements OnInit {
  @ViewChild('allSelected') private allSelected: MatOption;
  @ViewChild('allSelectedCourse') private allSelectedCourse: MatOption;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;
  userRole = Role;
  isShowCourseName:boolean=false;
   masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  eventForm: FormGroup;
  validationErrors: string[] = [];
  selectedCourse:SelectedModel[];
  selectedbaseschools:SelectedModel[];
  filteredbaseschools: SelectedModel[];
  filteredCourse: SelectedModel[];
  selectedevent:Event[];
  isShown: boolean = false ;
  courseName:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['ser','eventHeading','eventDetails','courseName','startDate','endDate','status'];
  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private eventService: EventService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute, 
    private classRoutineService: ClassRoutineService,
    public sharedService: SharedServiceService
    ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('eventId'); 
    if (id) {
      this.pageTitle = 'Edit event'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.eventService.find(+id).subscribe(
        res => {
          this.eventForm.patchValue({             
            eventId: res.eventId,
            courseDurationId: res.courseDurationId,
            baseSchoolNameId: res.baseSchoolNameId,
            courseNameId: res.courseNameId,
            traineeNominationId: res.traineeNominationId,
            courseInstructorId: res.courseInstructorId,
            eventHeading:res.eventHeading,
            endDate:res.endDate,
            status: res.status,
            eventDetails: res.eventDetails,
            menuPosition: res.menuPosition,
            isActive: res.isActive
          });          
        }
      );
    } else {
      this.pageTitle = 'Create event';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    this.getselectedbaseschools();
    //this.getselectedcoursedurationbyschoolname();
   // this.geteventBySchool();
  }
  intitializeForm() {
    this.eventForm = this.fb.group({
      eventId: [0],
      courseDurationId: [''],
      baseSchoolNameId: [''],
      courseNameId: [''],
      
     // courseNameIds: [''],
      courseName:[''],
      eventHeading:[''],
      startDate:[],
      endDate:[],
      traineeNominationId: [''],
      courseInstructorId: [''],
      status: [0],
      eventDetails: [''],
      menuPosition: [''],
      isActive: [true]
    })
  }
  

  // onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId){
  //     this.classRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
  //     this.selectedCourse=res;
  //   });
  // var baseSchoolNameId=this.ClassRoutineForm.value['baseSchoolNameId'];
  // var courseNameArr = dropdown.value.split('_');
  // var courseDurationId = courseNameArr[0];
  // var courseNameId=courseNameArr[1];
  // this.courseName=dropdown.text;
  // this.ClassRoutineForm.get('courseName').setValue(dropdown.text);
  // this.ClassRoutineForm.get('courseNameId').setValue(courseNameId);
  // this.ClassRoutineForm.get('courseDurationId').setValue(courseDurationId);
  // }

  getSelectedCourseName(dropdown){
   var baseSchoolNameId=this.eventForm.value['baseSchoolNameId'];
  var courseNameArr = dropdown.value.split('_');
  var courseDurationId = courseNameArr[0];
  var courseNameId=courseNameArr[1];
  this.courseName=dropdown.text;

  //this.eventForm.get('courseName').setValue(dropdown.text);
  this.eventForm.get('courseNameId')?.setValue(courseNameId);
  this.eventForm.get('courseDurationId')?.setValue(courseDurationId);
  }

  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.eventForm.value['baseSchoolNameId'];
    this.isShown=true;
    this.classRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedCourse=res;   
      this.filteredCourse = res;
    });
    this.eventService.geteventBySchool(baseSchoolNameId).subscribe(res=>{
      this.selectedevent=res
    }); 
} 

inActiveItem(row){
  const id = row.eventId;    
  var baseSchoolNameId=this.eventForm.value['baseSchoolNameId'];
  if(row.status == 0){
    this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Stop This Event').subscribe(result => {
      if (result) {
        this.eventService.ChangeEventStatus(id,1).subscribe(() => {
          this.eventService.geteventBySchool(baseSchoolNameId).subscribe(res=>{
            this.selectedevent=res
          }); 
          this.snackBar.open('Event Stopped!', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-warning'
          });
        })
      }
    })
  }
  else{
    this.confirmService.confirm('Confirm Active message', 'Are You Sure Run This Event').subscribe(result => {
      if (result) {
        this.eventService.ChangeEventStatus(id,0).subscribe(() => {
          this.eventService.geteventBySchool(baseSchoolNameId).subscribe(res=>{
            this.selectedevent=res
          }); 
          this.snackBar.open('Event Running!', '', { 
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        })
      }
    })
  }
}

stopevents(element){
  if(element.status ===0){
    this.confirmService.confirm('Confirm Stop message', 'Are You Sure Stop This Item').subscribe(result => {
      if (result) {
     this.eventService.stopevents(element.eventId).subscribe(() => {
      var baseSchoolNameId=this.eventForm.value['baseSchoolNameId'];

      this.eventService.geteventBySchool(baseSchoolNameId).subscribe(res=>{
        this.selectedevent=res
      }); 

     // this.getCourseplanCreates();
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
//   else{
//     this.confirmService.confirm('Confirm Running message', 'Are You Sure Running This Item').subscribe(result => {
//       if (result) {
//      this.eventService.runningevents(element.eventId).subscribe(() => {
//       var baseSchoolNameId=this.eventForm.value['baseSchoolNameId'];

//       this.eventService.geteventBySchool(baseSchoolNameId).subscribe(res=>{
//         this.selectedevent=res
//       }); 

//      // this.getCourseplanCreates();
//       this.snackBar.open('Information Rnnning Successfully ', '', {
//         duration: 3000,
//         verticalPosition: 'bottom',
//         horizontalPosition: 'right',
//         panelClass: 'snackbar-success'
//       });
//     })
//   }
// })
//   }
}
// stopevents(id: number) {
//   this.eventService.st
// }


  // this.eventService.stopevents(id).subscribe(res=>{
  //   this.events=res
  // }); 


// inActiveItem(){

//   if(row.isActive == true){
//     this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Deactive This Item').subscribe(result => {
//       if (result) {
//     this.CourseplanCreateService.deactiveCoursePlan(id).subscribe(() => {
//       this.getCourseplanCreates();
//       this.snackBar.open('Information Deactive Successfully ', '', {
//         duration: 3000,
//         verticalPosition: 'bottom',
//         horizontalPosition: 'right',
//         panelClass: 'snackbar-warning'
//       });
//     })
//   }
// })
// }
//   this.eventService.stopevents(id).subscribe(() => {
//     //this.getCourseplanCreates();
//     this.snackBar.open('Information Deactive Successfully ', '', {
//       duration: 3000,
//       verticalPosition: 'bottom',
//       horizontalPosition: 'right',
//       panelClass: 'snackbar-warning'
//     });
//   })
// }

  getselectedbaseschools(){
    this.eventService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschools=res
      this.filteredbaseschools=res;
    }); 
  }
  
  filterBaseSchools(value:string) {
    this.filteredbaseschools = this.selectedbaseschools.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()));
  }

  filterCourse(value:string) {
    if(this.selectedCourse==undefined||this.selectedCourse.length<=0) {
      return;
    }
    this.filteredCourse = this.selectedCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase()));
  }

  onSubmit() {
    const id = this.eventForm.get('eventId')?.value; 
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
    
        if (result) {
          this.loading = true;
          this.eventService.update(+id,this.eventForm.value).subscribe(response => {
            // this.router.navigateByUrl('/event-bulletin/event-list');
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
    }
    else if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.loading = true;
      this.selectedCourse.forEach(element => {
        var courseNameArr = element.value.split('_');
        var courseDurationId = courseNameArr[0];
        var courseNameId=courseNameArr[1];
        this.eventForm.get('courseNameId')?.patchValue(courseNameId);
        this.eventForm.get('courseDurationId')?.patchValue(courseDurationId);
      });
      
      this.eventForm.value.courseName.forEach(element => {
        this.eventForm.value.courseName=element;
        this.eventService.submit(this.eventForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        // this.getBulletins(baseSchoolNameId);
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })

      });

      
     }
     else {
      this.loading = true;
      this.eventForm.value.baseSchoolNameId.forEach(element => {  
        debugger
        if(element!=0){
          this.eventForm.value.baseSchoolNameId=element;
          if(this.eventForm.value.courseName!=""){
            this.eventForm.value.courseName.forEach((courseElement,index) => {
            if (courseElement!=0){
              var courseNameArr = courseElement.split('_');    
              var courseDurationId = courseNameArr[0];
              var courseNameId=courseNameArr[1];
               this.eventForm.get('courseNameId')?.patchValue(courseNameId);
                this.eventForm.get('courseDurationId')?.patchValue(courseDurationId);
              this.eventForm.value.courseName="" 
              this.eventForm.value.baseSchoolNameId=element
            }
            if (courseElement!=0){
              this.eventService.submit(this.eventForm.value).subscribe(response => {
              }, error => {
                this.validationErrors = error;
              })
            }
              });
          
          }
          else{  
            this.eventService.submit(this.eventForm.value).subscribe(response => {
              // this.reloadCurrentRoute();
              // // this.getBulletins(baseSchoolNameId);
              // this.snackBar.open('Information Inserted Successfully ', '', {
              //   duration: 2000,
              //   verticalPosition: 'bottom',
              //   horizontalPosition: 'right',
              //   panelClass: 'snackbar-success'
              // });
            }, error => {
              this.validationErrors = error;
            })
      
          }
        }
        debugger
        
       
      });

      this.reloadCurrentRoute();
      // this.getBulletins(baseSchoolNameId);
      this.snackBar.open('Information Inserted Successfully ', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-success'
      }); 
     
    }
 
  }
  toggleAllSelection() {
    
    if (this.allSelected.selected) {
  this.isShowCourseName=true;
      this.eventForm.controls.baseSchoolNameId
        .patchValue([...this.selectedbaseschools.map(item => item.value), 0]);
    } else {
      //this.isShowCourseName=true;
      this.eventForm.controls.baseSchoolNameId.patchValue([]);
    }
    
  }
  toggleAllSelectionCourse() {
    if (this.allSelectedCourse.selected) {
      this.eventForm.controls.courseName
        .patchValue([...this.selectedCourse.map(item => item.value), 0]);
    } else {
      this.eventForm.controls.courseName.patchValue([]);
    }
  }
}
