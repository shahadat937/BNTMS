import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { RoutineSoftCopyUploadService } from '../../service/RoutineSoftCopyUpload.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { CodeValueService } from 'src/app/basic-setup/service/codevalue.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { CourseNameService } from 'src/app/basic-setup/service/CourseName.service';
import { RoutineSoftCopyUpload } from '../../models/RoutineSoftCopyUpload';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { HttpEvent, HttpEventType  } from '@angular/common/http';
import {FileDialogMessageComponent} from '../file-dialog-message/file-dialog-message.component';
import { MatDialog } from '@angular/material/dialog';
import { ClassRoutineService } from '../../service/classroutine.service';
import { SelectionModel } from '@angular/cdk/collections';
import { MatTableDataSource } from '@angular/material/table';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-routinesoftcopyupload',
  templateUrl: './new-routinesoftcopyupload.component.html',
  styleUrls: ['./new-routinesoftcopyupload.component.sass']
})
export class NewRoutineSoftcopyUploadComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  roleList = Role;
  buttonText: string;
  pageTitle: string;
  destination: string;
  RoutineSoftCopyUploadForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse: SelectedModel[];
  selectedschool: SelectedModel[];
  selecteddocs: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selecteddownload: SelectedModel[];
  selectedRoutineSoftCopyUploadTitle: SelectedModel[];
  isShown: boolean = false;
  options = [];
  courseNameId: number;
  traineeId: any;
  role:any;
  loggedTraineeId:any;
  branchId:any;
  schoolId: any;
  baseSchoolNameId: number;
  RoutineSoftCopyUploadTitleId: number;
  RoutineSoftCopyUploadList: RoutineSoftCopyUpload[];
  public files: any[];
  progress: number = 0;
  btnShow=true;
  showSpinner=false;
  documentTypeId:any;
  IsAuthorNameShow:boolean=false;
  IsPublisherNameShow:boolean=false;
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectedCourse:SelectedModel[];
  selectCourse:SelectedModel[];
  selectedbaseschool:SelectedModel[];
  selectSchool:SelectedModel[];
  displayedColumns: string[] = ['ser', 'documentName', 'documentLink', 'actions'];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  isLoading = false;
  
  searchText="";
  filteredOptions;

  dataSource: MatTableDataSource<RoutineSoftCopyUpload> = new MatTableDataSource();


   selection = new SelectionModel<RoutineSoftCopyUpload>(true, []);
  subscription: any;

  constructor(public dialog: MatDialog,private snackBar: MatSnackBar,private ClassRoutineService: ClassRoutineService, private authService: AuthService,private courseNameService: CourseNameService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private RoutineSoftCopyUploadService: RoutineSoftCopyUploadService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) {
    this.files = [];
  }

  ngOnInit(): void {
    this.traineeId = this.route.snapshot.paramMap.get('traineeId');
    this.schoolId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    const id = this.route.snapshot.paramMap.get('routineSoftCopyUploadId');

    this.role = this.authService.currentUserValue.role.trim();
    this.loggedTraineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();


    if (id) {
      this.pageTitle = 'Soft Copy Upload';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.subscription = this.RoutineSoftCopyUploadService.find(+id).subscribe(
        res => {
          this.RoutineSoftCopyUploadForm.patchValue({
           routineSoftCopyUploadId: res.routineSoftCopyUploadId,
           courseDurationId: res.courseDurationId,
           baseSchoolNameId:res.baseSchoolNameId,
           documentLink:res.documentLink,
           documentName:res.documentName,
           status:res.status,
           isApproved: res.isApproved,
           isActive: res.isActive
          });
        //  this.getselectedcoursedurationbyschoolname()
        this.getCourseForRoutine();
        }
        
      );
    } else {
      this.pageTitle = 'Create Soft Copy Upload';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.intitializeForm();
    if(this.role === this.roleList.SuperAdmin || this.role === this.roleList.BNASchool || this.role === this.roleList.JSTISchool){
      this.RoutineSoftCopyUploadForm.get('baseSchoolNameId').setValue(this.branchId);
     // this.getselectedcoursedurationbyschoolname();
     this.getCourseForRoutine();
    }

    else{
      this.getselectedbaseschools();
    }
    this.getselectedcoursename();
    this.getselectedschools();
    // this.getselectedDocumentType();
    // this.getselecteddownloadright();
  }
  intitializeForm() { 
    this.RoutineSoftCopyUploadForm = this.fb.group({
      routineSoftCopyUploadId: [0],
      courseDurationId: [''],
      courseName:[''],
      documentName:[''],
      courseNameId:[''],
      baseSchoolNameId: [''],
      doc: [''],
      documentLink: [''],
      status: [0],
      isApproved: [true],
      isActive: [true]
    })
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      if(file.size >2147483648){
        let tempDirection;
        if (localStorage.getItem('isRtl') === 'true') {
          tempDirection = 'rtl';
        } else {
          tempDirection = 'ltr';
        }
        const dialogRef = this.dialog.open(FileDialogMessageComponent, {
         // data: this.spareStockBySpRequest,
          direction: tempDirection,
        });
         this.btnShow=false;
      }

      else{
        this.btnShow=true;
      }
      this.RoutineSoftCopyUploadForm.patchValue({
        doc: file,
      });
    }
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }


  getselectedbnasubjectname(dropdown){
    this.isShown =true;
      //var courseNameArr = dropdown.value.split('_');
      var courseDurationId = dropdown.value;
      this.RoutineSoftCopyUploadForm.get('courseDurationId').setValue(courseDurationId);

      this.isLoading = true;
      this.subscription = this.RoutineSoftCopyUploadService.getSoftCopyUploadList(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.branchId,courseDurationId).subscribe(response => {
  
        this.dataSource.data = response.items;
      })
  } 

  getselectedbaseschools(){
    this.subscription = this.ClassRoutineService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschool=res;
      this.selectSchool=res
    });
  } 

  getselectedbaseschoolsByBase(baseNameId){
    this.subscription = this.ClassRoutineService.getselectedbaseschoolsByBase(baseNameId).subscribe(res=>{
      this.selectedbaseschool=res;
     
    });
  }  
  filterBySchool(value:any){
    this.selectedbaseschool=this.selectSchool.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }


  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.RoutineSoftCopyUploadForm.value['baseSchoolNameId'];
    this.subscription = this.ClassRoutineService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
      this.selectedcoursedurationbyschoolname=res;
    });
} 

getCourseForRoutine(){
  var baseSchoolNameId=this.RoutineSoftCopyUploadForm.value['baseSchoolNameId'];
  this.subscription = this.ClassRoutineService.getCourseForRoutine(baseSchoolNameId).subscribe(res=>{
    this.selectedCourse=res;
    this.selectCourse=res
  });
}
filterByCourse(value:any){
  this.selectedCourse=this.selectCourse.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
}

  getSelectedRoutineSoftCopyUpload() {
    this.subscription = this.RoutineSoftCopyUploadService.getSelectedRoutineSoftCopyUpload().subscribe(res => {
      this.selectedRoutineSoftCopyUploadTitle = res;
    });
  }
  getselectedcoursename() {
    this.subscription = this.RoutineSoftCopyUploadService.getselectedcoursename().subscribe(res => {
      this.selectedcourse = res;
    });
  }

  getselectedschools() {
    this.subscription = this.RoutineSoftCopyUploadService.getselectedschools().subscribe(res => {
      this.selectedschool = res;
    });
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  deleteItem(row) {
    const id = row.routineSoftCopyUploadId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.subscription = this.RoutineSoftCopyUploadService.delete(id).subscribe(() => {
          this.getCourseForRoutine();
         //this.getCourseDurationsByCourseType();
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

  onSubmit() {
    const id = this.RoutineSoftCopyUploadForm.get('routineSoftCopyUploadId').value;
   // this.RoutineSoftCopyUploadForm.get('approvedDate').setValue((new Date(this.RoutineSoftCopyUploadForm.get('approvedDate').value)).toUTCString());
    const formData = new FormData();
    for (const key of Object.keys(this.RoutineSoftCopyUploadForm.value)) {
      const value = this.RoutineSoftCopyUploadForm.value[key];
      formData.append(key, value);
    }

    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
        if (result) {
          this.loading = true;
          this.subscription = this.RoutineSoftCopyUploadService.update(+id, formData).subscribe(response => {
            // if(this.traineeId){              
            //   const url = '/admin/dashboard/RoutineSoftCopyUploadlistinstructor/'+this.traineeId+'/'+this.schoolId;          
            //   this.router.navigateByUrl(url);
            // }else{

              this.router.navigateByUrl('/routine-management/add-routinesoftcopyupload');
           // }
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
    } else {
      this.loading = true;
      this.subscription = this.RoutineSoftCopyUploadService.submit(formData).subscribe((event: HttpEvent<any>) => {

        switch (event.type) {
          case HttpEventType.Sent:
            break;
          case HttpEventType.ResponseHeader:
            break;
          case HttpEventType.UploadProgress:
            this.progress = Math.round(event.loaded / event.total * 100);
            this.showSpinner=true;
            break;
          case HttpEventType.Response:

            setTimeout(() => {
              this.progress = 0;
            }, 1500);
            this.snackBar.open('Information Inserted Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.showSpinner =false;
          //  this.router.navigateByUrl('/reading-materials/RoutineSoftCopyUpload-list');
          this.reloadCurrentRoute();
        }
      //  this.reloadCurrentRoute();
        
        // }, error => {
        //   this.validationErrors = error;
        // })

        // if(this.progress == 100){
        //   this.snackBar.open('Information Inserted Successfully ', '', {
        //     duration: 2000,
        //     verticalPosition: 'bottom',
        //     horizontalPosition: 'right',
        //     panelClass: 'snackbar-success'
        //   });
        // }
      }, error => {
        this.validationErrors = error;
      });

      // if(this.traineeId){  
      //     const url = '/admin/dashboard/RoutineSoftCopyUploadlistinstructor/'+this.traineeId+'/'+this.schoolId;            
      //     this.router.navigateByUrl(url);
      //   }else{    
      //     this.router.navigateByUrl('/reading-materials/RoutineSoftCopyUpload-list');
      //   }

          // }, error => {
          //   this.validationErrors = error;
          // })
    
    // else {
    //   this.RoutineSoftCopyUploadService.submit(formData).subscribe(response => {
    //     if(this.traineeId){  
    //       const url = '/admin/dashboard/RoutineSoftCopyUploadlistinstructor/'+this.traineeId+'/'+this.schoolId;            
    //       this.router.navigateByUrl(url);
    //     }else{

    //       this.router.navigateByUrl('/reading-materials/RoutineSoftCopyUpload-list');
    //     }
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

  // }
    }
  }
}
