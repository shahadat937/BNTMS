import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";

import { ForeignCourseOtherDocumentService } from "../../service/ForeignCourseOtherDocument.service";
import { SelectedModel } from "../../../core/models/selectedModel";
import { ForeignCourseOtherDoc } from "../../models/ForeignCourseOtherDoc";
//import { TraineeNominationService } from 'src/app/course-management/service/traineenomination.service';
import { ForeignCourseOtherDocService } from "../../service/ForeignCourseOtherDoc.service";
import { TraineeListForForeignCourseOtherDoc } from "../../models/traineeListforforeigncourseotherdoc";
import { CourseBudgetAllocationService } from "../../../budget-management/service/courseBudgetAllocation.service";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { ForeignCourseOtherDocument } from "../../models/ForeignCourseOtherDocument";
import { SelectionModel } from "@angular/cdk/collections";
import { MasterData } from "../../../../assets/data/master-data";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-new-foreigncourseotherdocument",
  templateUrl: "./new-foreigncourseotherdocument.component.html",
  styleUrls: ["./new-foreigncourseotherdocument.component.sass"],
})
export class NewForeignCourseOtherDocumentComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  buttonText: string;
  pageTitle: string;
  destination: string;
  courseDurationId: number;
  selectedCourseDuration: number;
  ForeignCourseOtherDocumentForm: FormGroup;
  validationErrors: string[] = [];
  selectedCountryGroup: SelectedModel[];
  selectedCourseName: SelectedModel[];
  selectedCountry: SelectedModel[];
  selectedAllowancePercentages: SelectedModel[];
  selectedRanks: SelectedModel[];
  selectedCountryValue: SelectedModel[];
  selectedCurrencyValue: SelectedModel[];
  selectedTrainee: SelectedModel[];
  selectedDocType: SelectedModel[];
  traineeId: any;

  isShown: boolean = false;
  courseNameId: any;
  ForeignCourseOtherDocumentId: any;
  fileAttr = "Choose File";
  imageUrl: string = "/assets/img/icon.png";
  public files: any[];

  masterData = MasterData;
  loading = false;
  ELEMENT_DATA: ForeignCourseOtherDocument[] = [];
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "sl",
    "foreignCourseDocType",
    "fileUpload",
    "actions",
  ];
  dataSource: MatTableDataSource<ForeignCourseOtherDocument> =
    new MatTableDataSource();

  selection = new SelectionModel<ForeignCourseOtherDocument>(true, []);

  //displayedColumns: string[] = ['countryGroup', 'country', 'currencyName', 'allowancePercentage', 'dailyPayment',   'actions'];
  constructor(
    private snackBar: MatSnackBar,
    private CourseBudgetAllocationService: CourseBudgetAllocationService,
    private ForeignCourseOtherDocumentService: ForeignCourseOtherDocumentService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get(
      "foreignCourseOthersDocumentId"
    );
    if (id) {
      this.pageTitle = "Edit Foreign Course Other Doc";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.ForeignCourseOtherDocumentService.find(+id).subscribe((res) => {
        this.ForeignCourseOtherDocumentForm.patchValue({
          foreignCourseOthersDocumentId: res.foreignCourseOthersDocumentId,
          courseDurationId: res.courseDurationId,
          courseNameId: res.courseNameId,
          foreignCourseDocTypeId: res.foreignCourseDocTypeId,
          status: res.status,
          fileUpload: res.fileUpload,
          remarks: res.remarks,
          menuPosition: res.menuPosition,
          isActive: res.isActive,
        });
        //this.onCountryGroupSelectionChangeGetCountry(res.countryGroupId),
        //this.onCountrySelectionChangeGetCurrency(res.countryId)
      });
    } else {
      this.pageTitle = "Create Foreign Course Other Doc";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    // this.getselectedCourseName();
    this.getselectedDocType();
    this.getSelectedCourseDurationByCourseTypeId();
    //this.getselectedCurrencyName();
    //this.getselectedCountry();
    //this.getselectedAllowancePercentages();
    //this.getselectedRank();
  }
  intitializeForm() {
    this.ForeignCourseOtherDocumentForm = this.fb.group({
      foreignCourseOthersDocumentId: [0],
      courseDurationId: [],
      courseDurationIds: [""],
      courseNameId: [""],
      traineeId: [],
      foreignCourseDocTypeId: [],
      status: [""],
      fileUpload: [""],
      doc: [""],
      remarks: [""],
      menuPosition: [""],
      isActive: [true],
    });
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ForeignCourseOtherDocumentForm.patchValue({
        doc: file,
      });
    }
  }
  getForeignCourseOtherDocuments() {
    this.isLoading = true;
    this.ForeignCourseOtherDocumentService.getForeignCourseOtherDocuments(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText,
      this.courseDurationId,
      this.traineeId
    ).subscribe((response) => {
      this.dataSource.data = response.items;
      this.paging.length = response.totalItemsCount;
      this.isLoading = false;
    });
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex;
    this.paging.pageSize = event.pageSize;
    this.paging.pageIndex = this.paging.pageIndex + 1;
    this.getForeignCourseOtherDocuments();
  }

  applyFilter(searchText: any) {
    this.searchText = searchText;
    this.getForeignCourseOtherDocuments();
  }

  onCourseSelectionChangeGetCourseModule(dropdown) {
    this.isShown = true;
    if (dropdown.isUserInput) {
      this.courseNameId = dropdown.source.value;

      var courseNameArr = dropdown.source.value.split("_");
      this.courseDurationId = courseNameArr[0];
      this.courseNameId = courseNameArr[1];
      this.ForeignCourseOtherDocumentForm.get("courseNameId")!.setValue(
        this.courseNameId
      );
      this.ForeignCourseOtherDocumentForm.get("courseDurationId")!.setValue(
        this.courseDurationId
      );
      this.CourseBudgetAllocationService.getSelectedTraineeByCourseDurationId(
        this.courseDurationId
      ).subscribe((res) => {
        this.selectedTrainee = res;
      });
    }
  }

  getSelectedCourseDurationByCourseTypeId() {
    this.CourseBudgetAllocationService.getSelectedCourseDurationByCourseTypeId(
      MasterData.coursetype.ForeignCourse
    ).subscribe((res) => {
      this.selectedCourseName = res;
    });
  }

  getselectedDocType() {
    this.ForeignCourseOtherDocumentService.getselectedDocType().subscribe(
      (res) => {
        this.selectedDocType = res;
      }
    );
  }

  onTraineeSelectionChangeGetList(dropdown) {
    this.isShown = true;
    if (dropdown.isUserInput) {
      var courseNameId =
        this.ForeignCourseOtherDocumentForm.get("courseNameId")!.value;
      var courseDurationId =
        this.ForeignCourseOtherDocumentForm.get("courseDurationId")!.value;

      this.traineeId = dropdown.source.value;
      this.getForeignCourseOtherDocuments();
    }
  }

  getselectedCourseName() {
    this.ForeignCourseOtherDocumentService.getselectedCourseName().subscribe(
      (res) => {
        this.selectedCourseName = res;
      }
    );
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
    const id = this.ForeignCourseOtherDocumentForm.get(
      "foreignCourseOthersDocumentId"
    )!.value;
    const formData = new FormData();
    for (const key of Object.keys(this.ForeignCourseOtherDocumentForm.value)) {
      const value = this.ForeignCourseOtherDocumentForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item")
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.ForeignCourseOtherDocumentService.update(
              +id,
              formData
            ).subscribe(
              (response) => {
                // this.router.navigateByUrl('/air-ticket/foreigncourseotherdocument-list');
                this.reloadCurrentRoute();
                this.snackBar.open("Information Updated Successfully ", "", {
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
        });
    } else {
      this.loading = true;
      this.ForeignCourseOtherDocumentService.submit(formData).subscribe(
        (response) => {
          // this.router.navigateByUrl('/air-ticket/foreigncourseotherdocument-list');
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
  deleteItem(row) {
    const id = row.foreignCourseOthersDocumentId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This Item?")
      .subscribe((result) => {
        if (result) {
          this.ForeignCourseOtherDocumentService.delete(id).subscribe(() => {
            // this.getForeignCourseOtherDocuments();
            this.reloadCurrentRoute();
            this.snackBar.open("Information Deleted Successfully ", "", {
              duration: 3000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }
}
