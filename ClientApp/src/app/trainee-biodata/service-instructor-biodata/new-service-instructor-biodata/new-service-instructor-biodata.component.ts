import { Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { delay, of, Subscription } from 'rxjs';
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


@Component({
  selector: 'app-new-service-instructor-biodata',
  templateUrl: './new-service-instructor-biodata.component.html',
  styleUrls: ['./new-service-instructor-biodata.component.sass']
})
export class NewServiceInstructorBiodataComponent extends UnsubscribeOnDestroyAdapter implements OnInit {

  subscription: Subscription = new Subscription();
  masterData = MasterData;
  loading = false;
  buttonText:string;
  pageTitle: string;
  destination:string;
  ServiceInstructorForm: FormGroup;
  validationErrors: string[] = [];
  selectedcourse:SelectedModel[];
  selectedcoursestatus:SelectedModel[];
  selectedLocationType:SelectedModel[];
  selecteddoc:SelectedModel[];
  selectedTrainee:SelectedModel[];
  traineeId:number;
  traineeInfoById:any;
  courseDurationId:string;
  courseNameId:any;
  isLoading = false;
  nominatedPercentageList:any[];
  showHideDiv= false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  schoolName:any;
  courseName:any;
  courseTitle:any;
  runningWeek:any;
  totalWeek:any;
  selectedItems: any[] = [];
  //formGroup : FormGroup;

  options = [];
  @ViewChild('fileInput') fileInput!: ElementRef;

  filteredOptions;
  displayedColumns: string[] = ['ser','traineeName','courseName', 'actions'];
  dataSource: MatTableDataSource<TraineeNomination> = new MatTableDataSource();
   selection = new SelectionModel<TraineeNomination>(true, []);
  constructor(private snackBar: MatSnackBar,private bioDataGeneralInfoService: BIODataGeneralInfoService,private courseDurationService: CourseDurationService,private confirmService: ConfirmService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute, public sharedService: SharedServiceService ) {
    super();
  }
 
  ngOnInit(): void {
    this.buttonText = "Save"
    this.intitializeForm()
  }
  
  intitializeForm() {

    this.ServiceInstructorForm = this.fb.group({    
      traineeId:[''],
      traineeName:[''],         
    })

    this.ServiceInstructorForm.get('traineeName')?.valueChanges
    .subscribe(value => {
        this.getSelectedTraineeByPno(value);
    })
  }

  getSelectedTraineeByPno(pno){
    const source$ = of (pno);
    const delay$ = source$.pipe (
      delay(700)
    );
  
    if(this.subscription) {
      this.subscription.unsubscribe();
    }

    if(typeof pno !== "object"){

      if( pno.trim()=="") {
        this.options = [];
        this.filteredOptions = [];
        return;
      }
    
      this.subscription = delay$.subscribe(data => {
        this.bioDataGeneralInfoService.getSelectedTraineeByparameterRequest(data.trim()).subscribe(response => {
          console.log(response);
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

  getTraineeInfoByTraineeId(traineeId){
    this.bioDataGeneralInfoService.find(traineeId).subscribe(res=>{
      this.traineeInfoById=res;      
      console.log(this.traineeInfoById)
    });
  }



}
