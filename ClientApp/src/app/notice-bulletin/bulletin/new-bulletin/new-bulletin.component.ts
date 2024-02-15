import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup,FormArray, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BulletinService } from '../../service/bulletin.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { MatTableDataSource } from '@angular/material/table';
import {Bulletin} from '../../models/bulletin';
import { AuthService } from 'src/app/core/service/auth.service';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { Role } from 'src/app/core/models/role';
import { MatOption } from '@angular/material/core';
import { IDropdownSettings } from 'ng-multiselect-dropdown';
import { ClassGetter } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-new-bulletin',
  templateUrl: './new-bulletin.component.html',
  styleUrls: ['./new-bulletin.component.sass']
}) 
export class NewBulletinComponent implements OnInit {
  @ViewChild('allSelected') private allSelected: MatOption;
  @ViewChild('allSelectedCourse') private allSelectedCourse: MatOption;
  isShowCourseName:boolean=false;
  masterData = MasterData;
  loading = false;
  runningload = false;
  userRole = Role;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BulletinForm: FormGroup;
  validationErrors: string[] = [];
  selectedcoursedurationbyschoolname:SelectedModel[];
  selectedbaseschools:SelectedModel[];
  isLoading = false;
  partyTypedropdownList = [];
  partyTypeselectedItems = [];
  partyTypedropdownSettings:IDropdownSettings;
  role:any;
  traineeId:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = ['ser','courseName','buletinDetails', 'status', 'actions'];
  dataSource: MatTableDataSource<Bulletin> = new MatTableDataSource();

  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private bulletinService: BulletinService,
    private fb: FormBuilder, 
    private router: Router,  
    private route: ActivatedRoute,
    private authService: AuthService 
    ) { }

  ngOnInit(): void {
   
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.partyTypedropdownSettings= {
      singleSelection: false,
      idField: 'value',
      textField: 'text',
      selectAllText: 'Select All',
      unSelectAllText: 'UnSelect All',
      itemsShowLimit: 3,
      allowSearchFilter: true
    };
    const id = this.route.snapshot.paramMap.get('bulletinId'); 
    if (id) {
      this.pageTitle = 'Edit Bulletin'; 
      this.destination = "Edit"; 
      this.buttonText= "Update" 
      this.bulletinService.find(+id).subscribe(
        res => {
          this.BulletinForm.patchValue({          
            bulletinId:res.bulletinId, 
            baseSchoolNameId: res.baseSchoolNameId, 
            courseNameId:res.courseNameId, 
            courseDurationId:res.courseDurationId, 
            courseName: res.courseDurationId+'_'+res.courseNameId,
            buletinDetails:res.buletinDetails,
            status:res.status,
            menuPosition: res.menuPosition,
            isActive: res.isActive,
          }); 
          //this.onBaseSchoolNameSelectionChangeGetCourse(res.baseSchoolNameId);
        }
      );
    } else {
      this.pageTitle = 'Create Buletin';
      this.destination = "Add"; 
      this.buttonText= "Save"
    } 
    this.intitializeForm();
    
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.BulletinForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getselectedcoursedurationbyschoolname();
     }
    this.getselectedbaseschools();
    
  }
  intitializeForm() {
    this.BulletinForm = this.fb.group({
      bulletinId: [0],
      baseSchoolNameId:[''],
      courseName:[''],
      courseNameId:[''],
      courseDurationId:[''],
      buletinDetails:[''],
      status:[0],
      menuPosition:[''], 
      isActive:[true]
    })
  }

  getselectedcoursedurationbyschoolname(){
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
 if (typeof(baseSchoolNameId)=='string'||baseSchoolNameId.length ==1){ 
         // Previus Code
         this.bulletinService.getselectedcoursedurationbyschoolname(typeof(baseSchoolNameId)=='string'?baseSchoolNameId:baseSchoolNameId[0].value).subscribe(res=>{
          this.selectedcoursedurationbyschoolname=res;
          
        }); 
 }
 else { 
 
  if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
    this.isShowCourseName=false;
   }
else{
  this.isShowCourseName=true;
  this.selectedcoursedurationbyschoolname=[];
}
  }

    this.getBulletins(typeof(baseSchoolNameId)=='string'?baseSchoolNameId:baseSchoolNameId[0].value);
  }
  getSelectionByBranch(){
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    console.log('base School ID',baseSchoolNameId[0].value)
   if (baseSchoolNameId.length ==1){ 
           // Previus Code
           this.bulletinService.getselectedcoursedurationbyschoolname(baseSchoolNameId[0].value).subscribe(res=>{
            this.selectedcoursedurationbyschoolname=res;
            console.log(this.selectedcoursedurationbyschoolname)
          }); 
   }
   else { 
   
    if(this.role === this.userRole.SuperAdmin || this.role === this.userRole.JSTISchool || this.role === this.userRole.BNASchool){
      this.isShowCourseName=false;
     }
  else{
    this.isShowCourseName=true;
    this.selectedcoursedurationbyschoolname=[];
  }
    }
  
      this.getBulletins(baseSchoolNameId[0].value);
  }

  getselectedbnasubjectname(dropdown){

      var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
      var courseNameArr = dropdown.value.split('_');
      var courseDurationId = courseNameArr[0];
      var courseNameId=courseNameArr[1];
      //this.courseName=dropdown.text;
      this.BulletinForm.get('courseName').patchValue(dropdown.text);
      this.BulletinForm.get('courseNameId').patchValue(courseNameId);
      this.BulletinForm.get('courseDurationId').patchValue(courseDurationId);
       
  }

  getselectedbaseschools(){
    this.bulletinService.getselectedbaseschools().subscribe(res=>{
      this.selectedbaseschools=res
    }); 
  } 

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    
    const id = this.BulletinForm.get('bulletinId').value;   
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item').subscribe(result => {
        if (result) {
          this.loading = true;
          this.bulletinService.update(+id,this.BulletinForm.value).subscribe(response => {
            this.reloadCurrentRoute();
            // this.getBulletins(baseSchoolNameId);
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
      this.selectedcoursedurationbyschoolname.forEach(element => {
        var courseNameArr = element.value.split('_');
        var courseDurationId = courseNameArr[0];
        var courseNameId=courseNameArr[1];
        this.BulletinForm.get('courseNameId').patchValue(courseNameId);
        this.BulletinForm.get('courseDurationId').patchValue(courseDurationId);
      });
      
      // var courseNameArr = this.BulletinForm.value.courseName.split('_');
      // var courseDurationId = courseNameArr[0];
      // var courseNameId=courseNameArr[1]; 
      // //this.courseName=dropdown.text;
      // //this.BulletinForm.get('courseName').patchValue(dropdown.text);
      // this.BulletinForm.get('courseNameId').patchValue(courseNameId);
      // this.BulletinForm.get('courseDurationId').patchValue(courseDurationId);

      this.BulletinForm.value.courseName.forEach(element => {
        this.BulletinForm.value.courseName=element;
 
        this.bulletinService.submit(this.BulletinForm.value).subscribe(response => {
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
      //
      this.loading = true;
      this.BulletinForm.value.baseSchoolNameId.forEach(element => {  
        if(element.value!=0){
          
          this.BulletinForm.value.baseSchoolNameId=element.value;
          if(this.BulletinForm.value.courseName!=""){
            this.BulletinForm.value.courseName.forEach((courseElement,index) => {
       
            if (courseElement!=0){
              var courseNameArr = courseElement.split('_');    
              var courseDurationId = courseNameArr[0];
              var courseNameId=courseNameArr[1];
               this.BulletinForm.get('courseNameId').patchValue(courseNameId);
                this.BulletinForm.get('courseDurationId').patchValue(courseDurationId);
              this.BulletinForm.value.courseName="" 
              this.BulletinForm.value.baseSchoolNameId=element.value
            }
            if (courseElement!=0){
              this.bulletinService.submit(this.BulletinForm.value).subscribe(response => {
             
              }, error => {
                this.validationErrors = error;
              })
            }
          
            
              });
          
          }
          else{
            
            this.bulletinService.submit(this.BulletinForm.value).subscribe(response => {
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


  // for view

  getBulletins(baseSchoolNameId) {
    this.isLoading = true;
    this.bulletinService.getBulletins(this.paging.pageIndex, this.paging.pageSize,this.searchText,baseSchoolNameId).subscribe(response => {
      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;

    })
  }

  pageChanged(event: PageEvent) {
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    baseSchoolNameId[0].value
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBulletins( baseSchoolNameId[0].value);
 
  }
  applyFilter(searchText: any){ 
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    this.searchText = searchText;
    this.getBulletins( baseSchoolNameId[0].value);
  } 

  deleteItem(row) {
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    const id = row.bulletinId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item').subscribe(result => {
      if (result) {
        this.bulletinService.delete(id).subscribe(() => {
          this.getBulletins( baseSchoolNameId[0].value);
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

  inActiveItem(row){
    const id = row.bulletinId;    
    var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
    if(row.status == 0){
      this.confirmService.confirm('Confirm Deactive message', 'Are You Sure Stop This Bulletin').subscribe(result => {
        if (result) {
          this.runningload = true;
          this.bulletinService.ChangeBulletinStatus(id,1).subscribe(() => {
            this.getBulletins( baseSchoolNameId[0].value);
            this.snackBar.open('Bulletin Stopped!', '', {
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
      
      this.confirmService.confirm('Confirm Active message', 'Are You Sure Run This Bulletin').subscribe(result => {
        if (result) {
          this.runningload = true;
          this.bulletinService.ChangeBulletinStatus(id,0).subscribe(() => {
            this.getBulletins( baseSchoolNameId[0].value);
            this.snackBar.open('Bulletin Running!', '', { 
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
  // getselectedcoursedurationbyschoolname(){
  //   var baseSchoolNameId=this.BulletinForm.value['baseSchoolNameId'];
  //   this.bulletinService.getselectedcoursedurationbyschoolname(baseSchoolNameId).subscribe(res=>{
  //     this.selectedcoursedurationbyschoolname=res;
  //   });
  //   this.getBulletins(baseSchoolNameId);
  // }
  
  toggleAllSelection() {
    //if (this.allSelected.selected) {
      this.isShowCourseName=true;
      this.BulletinForm.controls.baseSchoolNameId
        .patchValue([...this.selectedbaseschools.map(item => item.value), 0]);
   // } 
   
   
   //else {
      this.BulletinForm.controls.baseSchoolNameId.patchValue([]);
  //  }
  }
  toggleAllSelectionCourse() {
    if (this.allSelectedCourse.selected) {
      
      this.BulletinForm.controls.courseName
        .patchValue([...this.selectedcoursedurationbyschoolname.map(item => item.value), 0]);
    } else {
      this.BulletinForm.controls.courseName.patchValue([]);
    }
  }
  public onItemSelect(item: any) {
    console.log(item);
  }
  public onSelectAll(items: any) {
    console.log(items);
  }
  public onDeSelectAll(items: any) {
    console.log(items);
  }
  public onDeSelect(item: any) {
    console.log(item);
  }
}
