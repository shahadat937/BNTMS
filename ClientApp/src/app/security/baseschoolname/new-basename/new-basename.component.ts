import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseSchoolNameService } from '../../service/BaseSchoolName.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BaseSchoolName } from '../../models/BaseSchoolName';
import { MasterData } from 'src/assets/data/master-data';
import { SharedServiceService } from 'src/app/shared/shared-service.service';

@Component({
  selector: 'app-new-basename',
  templateUrl: './new-basename.component.html',
  styleUrls: ['./new-basename.component.sass']
})
export class NewBaseNameComponent implements OnInit, OnDestroy {
  pageTitle: string;
  destination:string;
  btnText:string;
   masterData = MasterData;
  loading = false;
  BaseNameForm: FormGroup;
  baseNameList: BaseSchoolName[];
  validationErrors: string[] = [];
  selectedOrganization:SelectedModel[];
  selectedCommendingArea:SelectedModel[];
  selectCommendingArea:SelectedModel[];
  organizationId:any;
  commendingAreaId:any;
  isShown:boolean=false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = [ 'ser','schoolLogo', 'schoolName', 'shortName',  'actions'];
  subscription: any;

  constructor(private snackBar: MatSnackBar,private BaseSchoolNameService: BaseSchoolNameService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute,private confirmService:ConfirmService, public sharedService: SharedServiceService) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('baseSchoolNameId'); 
    if (id) {
      this.pageTitle = 'Edit Base Name';
      this.destination = "Edit";
      this.btnText = 'Update';
      this.subscription = this.BaseSchoolNameService.find(+id).subscribe(
        res => {
          this.BaseNameForm.patchValue({          
            
            baseSchoolNameId: res.baseSchoolNameId,
            schoolName: res.schoolName,
            shortName: res.shortName,
            schoolLogo: res.schoolLogo,
            //status: res.status,
            //menuPosition:res.menuPosition,
            isActive: res.isActive,
            contactPerson: res.contactPerson,
            address: res.address,
            telephone: res.telephone,
            cellphone: res.cellphone,
            email: res.email,
            fax: res.fax,
            branchLevel: res.branchLevel,
            firstLevel: res.firstLevel,
            secondLevel: res.secondLevel,
            thirdLevel: res.thirdLevel,
            //fourthLevel: res.fourthLevel,
            //fifthLevel: res.fifthLevel,
            serverName: res.serverName,
            schoolHistory: res.schoolHistory,
          
          }); 
          this.onOrganizationSelectionChangeGetCommendingArea();         
        }
      );
    } else {
      this.pageTitle = 'Create Base Name';
      this.destination = "Add";
      this.btnText = 'Save';
    }
    this.intitializeForm();
    //this.getOrganizationList();
    this.onOrganizationSelectionChangeGetCommendingArea();
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  

  // getSelectedOrganization(){
  //   this.BaseSchoolNameService.getSelectedOrganization().subscribe(res=>{
  //     this.selectedOrganization=res
  //   });
  // }

  filterByCommendingArea(value:any){
    this.selectedCommendingArea=this.selectCommendingArea.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }
  onOrganizationSelectionChangeGetCommendingArea(){
    this.organizationId=this.BaseNameForm.value['firstLevel'];
    this.subscription = this.BaseSchoolNameService.getSelectedCommendingArea(this.organizationId).subscribe(res=>{
      console.log(res);
      this.selectedCommendingArea=res
      this.selectCommendingArea=res
    });        
  }
  
  onCommendingAreaSelectionChangeGetBaseList(){
    this.commendingAreaId=this.BaseNameForm.value['secondLevel'];
    this.getBaseNameList(this.commendingAreaId);
            
  }

  getBaseNameList(commendingAreaId){
    this.isShown=true;
    this.subscription = this.BaseSchoolNameService.getBaseNameList(commendingAreaId).subscribe(res=>{
      this.baseNameList=res
    });
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.BaseNameForm.patchValue({
        image: file,
      });
    }
  }
  intitializeForm() {
    this.BaseNameForm = this.fb.group({
      
      baseSchoolNameId: [0],
      schoolName: [''],
      shortName: [''],
      schoolLogo: [''],
      image:[''],
      status: [''],
      menuPosition: [''],
      isActive: [true],
      contactPerson: [],
      address: [],
      telephone: [],
      cellphone: [],
      email: ['', [Validators.email]],
      fax: [],
      branchLevel: [3],
      firstLevel: [this.masterData.UserLevel.navy],
      secondLevel: [""],
      thirdLevel: [""],
      fourthLevel: [""],
      fifthLevel: [""],
      serverName: [],
      schoolHistory: [''],
    
    })
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.BaseNameForm.get('baseSchoolNameId').value;
    const formData = new FormData();
    for (const key of Object.keys(this.BaseNameForm.value)) {
      const value = this.BaseNameForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.BaseSchoolNameService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/security/new-basename');
            this.getBaseNameList(this.commendingAreaId);
            this.BaseNameForm.reset();
              this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.loading = false;
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    } else {  
      this.loading=true;    
      this.subscription = this.BaseSchoolNameService.submit(formData).subscribe(response => {
        //this.router.navigateByUrl('/basic-setup/baseschoolname-list');
        this.getBaseNameList(this.commendingAreaId);
        this.BaseNameForm.reset();
          this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.loading = false;
        this.reloadCurrentRoute();
      }, error => {
        this.validationErrors = error;
      })
    }
    
  }

  deleteItem(row) {
    const id = row.baseSchoolNameId; 
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.subscription = this.BaseSchoolNameService.delete(id).subscribe(() => {
          this.getBaseNameList(this.commendingAreaId);
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
        })
      }
    })    
  }

}
