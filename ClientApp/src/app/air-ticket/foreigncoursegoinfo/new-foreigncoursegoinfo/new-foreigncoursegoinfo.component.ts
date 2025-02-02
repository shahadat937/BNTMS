import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { ForeignCourseGOInfoService } from "../../service/ForeignCourseGOInfo.service";
import { CodeValueService } from "../../../basic-setup/service/codevalue.service";

import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { SelectedModel } from "../../../core/models/selectedModel";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-new-foreigncoursegoinfo",
  templateUrl: "./new-foreigncoursegoinfo.component.html",
  styleUrls: ["./new-foreigncoursegoinfo.component.sass"],
})
export class NewForeignCourseGOInfoComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  buttonText: string;
  pageTitle: string;
  destination: string;
  ForeignCourseGOInfoForm: FormGroup;
  validationErrors: string[] = [];
  selectedbaseschools: SelectedModel[];
  selectedCourseName: SelectedModel[];
  selectedcoursedurationbyschoolname: SelectedModel[];
  selectedBudgetCode: SelectedModel[];
  selectedBudgetType: SelectedModel[];
  selectedFiscalYear: SelectedModel[];

  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private CodeValueService: CodeValueService,
    private ForeignCourseGOInfoService: ForeignCourseGOInfoService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("foreignCourseGOInfoId");

    if (id) {
      this.pageTitle = "Edit Foreign Course GO Info";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.ForeignCourseGOInfoService.find(+id).subscribe((res) => {
        this.ForeignCourseGOInfoForm.patchValue({
          foreignCourseGOInfoId: res.foreignCourseGOInfoId,
          courseDurationId: res.courseDurationId,
          courseNameId: res.courseNameId,
          documentName: res.documentName,
          fileUpload: res.fileUpload,
          remarks: res.remarks,
          status: res.status,
          menuPosition: res.menuPosition,
          isActive: res.isActive,
        });
      });
    } else {
      this.pageTitle = "Create Foreign Course GO Info";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    this.getselectedCourseName();
    //this.getselectedBudgetType();
    //this.getselectedFiscalYear();
  }
  intitializeForm() {
    this.ForeignCourseGOInfoForm = this.fb.group({
      foreignCourseGOInfoId: [0],
      courseDurationId: [],
      //courseNameId:[],
      documentName: [""],
      fileUpload: [""],
      doc: [""],
      remarks: [""],
      status: [""],
      //menuPosition:[],
      isActive: [true],
    });
  }

  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.ForeignCourseGOInfoForm.patchValue({
        doc: file,
      });
    }
  }
  getselectedCourseName() {
    this.ForeignCourseGOInfoService.getselectedCourseName().subscribe((res) => {
      this.selectedCourseName = res;
    });
  }

  // getselectedBudgetType(){
  //   this.BudgetAllocationService.getselectedBudgetType().subscribe(res=>{
  //     this.selectedBudgetType=res
  //   });
  // }
  // getselectedFiscalYear(){
  //   this.BudgetAllocationService.getselectedFiscalYear().subscribe(res=>{
  //     this.selectedFiscalYear=res
  //   });
  // }

  onSubmit() {
    const id = this.ForeignCourseGOInfoForm.get("foreignCourseGOInfoId")?.value;
    const formData = new FormData();
    for (const key of Object.keys(this.ForeignCourseGOInfoForm.value)) {
      const value = this.ForeignCourseGOInfoForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.ForeignCourseGOInfoService.update(+id, formData).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/air-ticket/foreigncoursegoinfo-list"
                );
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
      this.ForeignCourseGOInfoService.submit(formData).subscribe(
        (response) => {
          this.router.navigateByUrl("/air-ticket/foreigncoursegoinfo-list");
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
}
