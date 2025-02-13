import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { SelectedModel } from "../../../core/models/selectedModel";
import { ForeignCourseOtherDoc } from "../../models/ForeignCourseOtherDoc";
import { ForeignCourseOtherDocService } from "../../service/ForeignCourseOtherDoc.service";
import { TraineeListForForeignCourseOtherDoc } from "../../../air-ticket/models/traineeListforforeigncourseotherdoc";
import { ConfirmService } from "../../../core/service/confirm.service";
import { TraineeNominationService } from "../../../course-management/service/traineenomination.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-new-foreigncourseotherdoc",
  templateUrl: "./new-foreigncourseotherdoc.component.html",
  styleUrls: ["./new-foreigncourseotherdoc.component.sass"],
})
export class NewForeignCourseOtherDocComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  buttonText: string;
  loading = false;
  pageTitle: string;
  destination: string;
  courseDurationId: number;
  selectedCourseDuration: number;
  ForeignCourseOtherDocForm: FormGroup;
  validationErrors: string[] = [];
  selectedCountryGroup: SelectedModel[];
  selectedCourseName: SelectedModel[];
  selectedCountry: SelectedModel[];
  selectedAllowancePercentages: SelectedModel[];
  selectedRanks: SelectedModel[];
  selectedFinancialSanctions: SelectedModel[];
  selectedCountryValue: SelectedModel[];
  selectedCurrencyValue: SelectedModel[];
  traineeList: TraineeListForForeignCourseOtherDoc[];
  isShown: boolean = false;
  courseNameId: any;
  foreignCourseOtherDocId: any;
  fileAttr = "Choose File";
  imageUrl: string = "/assets/img/icon.png";
  public files: any[];

  //displayedColumns: string[] = ['countryGroup', 'country', 'currencyName', 'allowancePercentage', 'dailyPayment',   'actions'];
  constructor(
    private snackBar: MatSnackBar,
    private traineeNominationService: TraineeNominationService,
    private ForeignCourseOtherDocService: ForeignCourseOtherDocService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("foreignCourseOtherDocId");
    if (id) {
      this.pageTitle = "Update Related Work Status";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.ForeignCourseOtherDocService.find(+id).subscribe((res) => {
        this.ForeignCourseOtherDocForm.patchValue({
          foreignCourseOtherDocId: res.foreignCourseOtherDocId,
          financialSanctionId: res.financialSanctionId,
          courseDurationId: res.courseDurationId,
          courseNameId: res.courseNameId,
          traineeNominationId: res.traineeNominationId,
          traineeId: res.traineeId,
          ticket: res.ticket,
          visa: res.visa,
          passport: res.passport,
          covidTest: res.covidTest,
          medicalTest: res.medicalTest,
        });
        //this.onCountryGroupSelectionChangeGetCountry(res.countryGroupId),
        //this.onCountrySelectionChangeGetCurrency(res.countryId)
      });
    } else {
      this.pageTitle = "Update Related Work Status";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    this.getselectedCourseName();
    this.getselectedFinancialSanctions();
    //this.getselectedCurrencyName();
    //this.getselectedCountry();
    //this.getselectedAllowancePercentages();
    //this.getselectedRank();
  }
  intitializeForm() {
    this.ForeignCourseOtherDocForm = this.fb.group({
      foreignCourseOtherDocId: [0],
      financialSanctionId: [],
      courseDurationId: [],
      courseNameId: [],
      traineeNominationId: [],
      traineeId: [],
      ticket: [],
      visa: [],
      passport: [],
      covidTest: [],
      medicalTest: [],
      // dniBreafing:[],
      // embassiBreafing:[],
      // financialSanction:[],
      //exBdLeave:[],
      //remark:[],
      traineeListForm: this.fb.array([this.createTraineeData()]),
      isActive: [true],
    });
  }
  getControlLabel(index: number, type: string) {
    return (this.ForeignCourseOtherDocForm.get("traineeListForm") as FormArray)
      ?.at(index)
      ?.get(type)?.value;
  }
  private createTraineeData() {
    return this.fb.group({
      courseNameId: [],
      courseDurationId: [],
      financialSanctionId: [],
      traineeNominationId: [],
      foreignCourseOtherDocId: [0],
      visa: [""],

      dgfiBreafing: [],
      dniBreafing: [],
      embassiBreafing: [],
      financialSanction: [],
      exBdLeave: [],
      remark: [],
      image: [""],
      familyGo: [""],
      medicalDocument: [],
      traineePNo: [""],
      traineeId: [""],
      traineeName: [""],
      rankPosition: [],
      ticket: [],
      passport: [],
      covidTest: [],
    });
  }

  getTraineeListonClick() {
    const control = <FormArray>(
      this.ForeignCourseOtherDocForm.controls["traineeListForm"]
    );
    for (let i = 0; i < this.traineeList.length; i++) {
      control.push(this.createTraineeData());
    }
    this.ForeignCourseOtherDocForm.patchValue({
      traineeListForm: this.traineeList,
    });
  }

  clearList() {
    const control = <FormArray>(
      this.ForeignCourseOtherDocForm.controls["traineeListForm"]
    );
    while (control.length) {
      control.removeAt(control.length - 1);
    }
    control.clearValidators();
  }

  onCourseSelectionChangeGetCourseModule(dropdown) {
    this.isShown = true;
    if (dropdown.isUserInput) {
      this.courseNameId = dropdown.source.value;

      this.getselectedCourseName();
      // if(this.foreignCourseOtherDocId ===null){
      //   this.buttonText="Save";
      //  }
      //  else{
      //    this.buttonText="Update"
      //  }
    }
  }
  getselectedFinancialSanctions() {
    this.ForeignCourseOtherDocService.getselectedFinancialSanctions().subscribe(
      (res) => {
        this.selectedFinancialSanctions = res;
      }
    );
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      // this.labelImport.nativeElement.value = file.name;
      // this.BIODataGeneralInfoForm.controls["picture"].setValue(event.target.files[0]);
      this.ForeignCourseOtherDocForm.patchValue({
        image: file,
      });
    }
  }
  getselectedCourseName() {
    //this.isShown=true

    this.ForeignCourseOtherDocService.getselectedCourseName().subscribe(
      (res) => {
        this.selectedCourseName = res;
        this.traineeNominationService
          .getForeignTrainingOtherDocTraineeNominationByCourseDurationId(
            this.courseNameId
          )
          .subscribe((res) => {
            this.traineeList = res;
            this.foreignCourseOtherDocId = res[0].foreignCourseOtherDocId;
            this.clearList();
            this.getTraineeListonClick();
          });
      }
    );
  }
  // onCourseNameChangeGetCourseDuration(){
  //   this.selectedCourseName=selectedCourseNam
  //   this.ForeignCourseOtherDocService.getNewTraineeNominationByCourseDurationId(this.courseDurationId).subscribe(res=>{
  //     this.traineeList=res;
  //     this. clearList();
  //     this.getTraineeListonClick();

  //    });
  // }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.foreignCourseOtherDocId;
    // var foreignCourseOtherDocId=0;
    // const id = this.ForeignCourseOtherDocForm.get('traineeListForm').value.find(x=>x.foreignCourseOtherDocId).foreignCourseOtherDocId;
    // if (id) {
    //   this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This  Item?').subscribe(result => {
    //     if (result) {

    //         this.ForeignCourseOtherDocService.update(+id,this.ForeignCourseOtherDocForm.value).subscribe(response => {
    //           // this.router.navigateByUrl('/air-ticket/foreigncourseotherdoc-list');
    //           this.reloadCurrentRoute();
    //           this.snackBar.open('Information Updated Successfully ', '', {
    //           duration: 2000,
    //           verticalPosition: 'bottom',
    //           horizontalPosition: 'right',
    //           panelClass: 'snackbar-success'
    //         });
    //       }, error => {
    //         this.validationErrors = error;
    //       })
    //     }
    //   })
    // } else {
    this.loading = true;
    this.ForeignCourseOtherDocService.submit(
      this.ForeignCourseOtherDocForm.value
    ).subscribe(
      (response) => {
        // this.router.navigateByUrl('/air-ticket/foreigncourseotherdoc-list');
        this.reloadCurrentRoute();
        this.snackBar.open("Information Inserted Successfully ", "", {
          duration: 2000,
          verticalPosition: "bottom",
          horizontalPosition: "right",
          panelClass: "snackbar-success",
        });
      },
      (error) => {
        this.validationErrors = error;
      }
    );
  }
}
// }
