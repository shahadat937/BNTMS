import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { delay, last, of, Subscription } from 'rxjs';
import { MasterData } from '../../../../assets/data/master-data';
import { FormBuilder, FormGroup } from '@angular/forms';
import { SelectedModel } from '../../../core/models/selectedModel';
import { TraineeNomination } from '../../../course-management/models/traineenomination';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BIODataGeneralInfoService } from '../../service/BIODataGeneralInfo.service';
import { ConfirmService } from '../../../core/service/confirm.service';
import { CourseDurationService } from '../../../course-management/service/courseduration.service';
import { ActivatedRoute, Router } from '@angular/router';
import { SharedServiceService } from '../../../shared/shared-service.service';
import { UnsubscribeOnDestroyAdapter } from '../../../shared/UnsubscribeOnDestroyAdapter';
import { UserService } from '../../../security/service/User.service';
import { AuthService } from '../../../core/service/auth.service';
import { Role } from '../../../core/models/role';


@Component({
  selector: 'app-new-service-instructor-biodata',
  templateUrl: './new-service-instructor-biodata.component.html',
  styleUrls: ['./new-service-instructor-biodata.component.sass']
})
export class NewServiceInstructorBiodataComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  subscription: Subscription = new Subscription();
  masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  ServiceInstructorForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse: SelectedModel[];
  selectedcoursestatus: SelectedModel[];
  selectedLocationType: SelectedModel[];
  selecteddoc: SelectedModel[];
  selectedTrainee: SelectedModel[];
  traineeId: number;
  traineeInfoById: any;
  userInfo: any
  courseDurationId: string;
  courseNameId: any;
  isLoading = false;
  nominatedPercentageList: any[];
  showHideDiv = false;
  isInstractorNotAvailable = true;
  branchId: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText = "";
  userRoles = Role
  role : string;

  schoolName: any;
  courseName: any;
  courseTitle: any;
  runningWeek: any;
  totalWeek: any;
  selectedItems: any[] = [];
  warningMessage : string = ""
  selectedBaseSchoolList : any;
  schoolList : any;
  instructorSchoolId : any;
  isSchoolSelected : boolean

  options = [];
  @ViewChild('fileInput') fileInput!: ElementRef;

  filteredOptions;
  displayedColumns: string[] = ['ser', 'traineeName', 'courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();
  selection = new SelectionModel<TraineeNomination>(true, []);
  constructor(private snackBar: MatSnackBar, private bioDataGeneralInfoService: BIODataGeneralInfoService,  private fb: FormBuilder,  private route: ActivatedRoute, public sharedService: SharedServiceService, private userService: UserService, private authService: AuthService) {
    super();
  }

  ngOnInit(): void {
    this.buttonText = "Save";
    this.branchId = this.authService.currentUserValue.branchId;
    this.role = this.authService.currentUserValue.role;
    this.intitializeForm();
    this.getselectedbaseschools();
    this.isSchoolSelected = this.role === this.userRoles.MasterAdmin? true : false;
  }

  intitializeForm() {
    this.ServiceInstructorForm = this.fb.group({
      traineeId: [''],
      traineeName: [''],
      id: [0],
      userName: ['',],
      roleName: [''],
      password: ['Admin@123'],
      confirmPassword: ['Admin@123'],
      firstName: ['na'],
      lastName: ['na'],
      phoneNumber: [''],
      email: [''],
    })

    this.ServiceInstructorForm.get('traineeName')?.valueChanges
      .subscribe(value => {
        this.getSelectedTraineeByPno(value);
      })
  }

  getSelectedTraineeByPno(pno) {
    const source$ = of(pno);
    const delay$ = source$.pipe(
      delay(700)
    );

    if (this.subscription) {
      this.subscription.unsubscribe();
    }

    if (typeof pno !== "object") {

      if (pno.trim().length < 3) {
        this.options = [];
        this.filteredOptions = [];
        this.isInstractorNotAvailable = true;
        return;
      }

      this.subscription = delay$.subscribe(data => {
        this.bioDataGeneralInfoService.getSelectedTraineeByparameterRequest(data.trim()).subscribe(response => {
          this.options = response;
          this.filteredOptions = response;
        })
      })
    }
  }

  onTraineeSelectionChanged(item) {

    this.traineeId = item.value
    this.ServiceInstructorForm.get('traineeId')?.setValue(item.value);
    this.ServiceInstructorForm.get('traineeName')?.setValue(item.text);
    this.getTraineeInfoByTraineeId(this.traineeId);
  }

  getTraineeInfoByTraineeId(traineeId) {
    this.bioDataGeneralInfoService.find(traineeId).subscribe(res => {
      this.traineeInfoById = res;
      this.getUserInfo(res.traineeId);

    });
  }

  getselectedbaseschools(){
    this.bioDataGeneralInfoService.getselectedbaseschools().subscribe(res =>{
     this.selectedBaseSchoolList = res;
     this.schoolList = res;
    })
  }
  filterBySchool(value:any){
    this.selectedBaseSchoolList = this.schoolList.filter(x=>x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g,'')))
  }

  getUserInfo(traineeId) {
    this.userService.findUserByTraineeId(traineeId).subscribe(res => {
      this.userInfo = res;
      this.ServiceInstructorForm.patchValue({
        id: res.id,
        userName: res.userName,
        phoneNumber: res.phoneNumber,
        email: res.email,
        traineeId: res.traineeId
      });
      this.isInstractorNotAvailable = res.fourthLevel? true : false;
      if(this.isInstractorNotAvailable){
        this.bioDataGeneralInfoService.findSchoolById(res.fourthLevel).subscribe(res=>{
          this.warningMessage = `The instructor is currently assigned to ${res.schoolName}. Please contact either ${res.schoolName} or the administrator to facilitate the instructor's release from the school.`
        })
      }
      else{
        this.warningMessage = ""
      }
     
    }
    );
  }

  setInstractorBranch(value){
    this.instructorSchoolId= value;
    this.isSchoolSelected = false
  }

  
  onSubmit() {
    var userId = this.ServiceInstructorForm.get('id')?.value;
    this.ServiceInstructorForm.get('roleName')?.setValue('Instructor');
    if(this.role === this.userRoles.SuperAdmin){
      this.instructorSchoolId = this.branchId;
    }
    this.subscription = this.userService.updateUserAsServiceInstructor(userId, this.ServiceInstructorForm.value, this.instructorSchoolId).subscribe(response => {

      this.sharedService.goBack();

      this.snackBar.open('Information Updated Successfully ', '', {
        duration: 2000,
        verticalPosition: 'bottom',
        horizontalPosition: 'right',
        panelClass: 'snackbar-success'
      });
    })
  }

}


