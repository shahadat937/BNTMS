<<<<<<< HEAD
import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { CourseGradingEntryService } from "../../service/CourseGradingEntry.service";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SelectedModel } from "../../../core/models/selectedModel";
import { CourseGradingEntry } from "../../models/CourseGradingEntry";
import { MasterData } from "../../../../assets/data/master-data";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";
=======
import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseGradingEntryService } from '../../service/CourseGradingEntry.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { SelectedModel } from '../../../core/models/selectedModel';
import { CourseGradingEntry } from '../../models/CourseGradingEntry';
import { UnsubscribeOnDestroyAdapter } from '../../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';
>>>>>>> 88d368759e0e15a558ceda810473fca6d7a871ed

@Component({
  selector: "app-new-coursegradingentry",
  templateUrl: "./new-coursegradingentry.component.html",
  styleUrls: ["./new-coursegradingentry.component.sass"],
})
export class NewCourseGradingEntryComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  pageTitle: string;
  destination: string;
  CourseGradingEntryForm: FormGroup;
  buttonText: string;
  validationErrors: string[] = [];
  selectedSchool: SelectedModel[];
  selectedCourseNames: SelectedModel[];
  selectCourse: SelectedModel[];
  selectedAssessment: SelectedModel[];
  selectAssesment: SelectedModel[];
  selectSchool: SelectedModel[];
  baseSchoolNameId: number;
  courseNameId: number;
  courseGradingEntryList: CourseGradingEntry[];
  masterData = MasterData;
  loading = false;

  isShown: boolean = false;
  options = [];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

  displayedColumns: string[] = [
    "sl",
    "markFrom",
    "grade",
    "assessment",
    "actions",
  ];
  constructor(
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private CourseGradingEntryService: CourseGradingEntryService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("courseGradingEntryId");
    if (id) {
      this.pageTitle = "Edit Class Type";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.CourseGradingEntryService.find(+id).subscribe((res) => {
        this.CourseGradingEntryForm.patchValue({
          courseGradingEntryId: res.courseGradingEntryId,
          baseSchoolNameId: res.baseSchoolNameId,
          courseNameId: res.courseNameId,
          assessmentId: res.assessmentId,
          markObtained: res.markObtained,
          grade: res.grade,
          markFrom: res.markFrom,
          markTo: res.markTo,
        });
      });
    } else {
      this.pageTitle = "Create Class Type";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
    this.getselectedSchools();
    this.getselectedCourseNames();
    this.getselectedAssessment();
  }
  intitializeForm() {
    this.CourseGradingEntryForm = this.fb.group({
      courseGradingEntryId: [0],
      baseSchoolNameId: [],
      courseNameId: [],
      assessmentId: [],
      markObtained: [""],
      grade: [""],
      markFrom: [""],
      markTo: [""],
      isActive: [true],
    });
  }
  getselectedSchools() {
    this.CourseGradingEntryService.getselectedSchools().subscribe((res) => {
      this.selectedSchool = res;
      this.selectSchool = res;
    });
  }
  // onBaseSchoolNameSelectionChangeGetCourse(baseSchoolNameId){
  //   this.CourseGradingEntryService.getCourseByBaseSchoolNameId(baseSchoolNameId).subscribe(res=>{
  //     this.selectedCourse=res
  //   });
  //  }
  getselectedCourseNames() {
    this.CourseGradingEntryService.getselectedCourseNames().subscribe((res) => {
      this.selectedCourseNames = res;
      this.selectCourse = res;
    });
  }
  filterByCourse(value: any) {
    this.selectedCourseNames = this.selectCourse.filter((x) =>
      x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, ""))
    );
  }
  getselectedAssessment() {
    this.CourseGradingEntryService.getselectedAssessment().subscribe((res) => {
      this.selectedAssessment = res;
      this.selectAssesment = res;
    });
  }
  filterByAssesment(value: any) {
    this.selectedAssessment = this.selectAssesment.filter((x) =>
      x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, ""))
    );
  }

  filterBySchoolName(value: any) {
    this.selectedSchool = this.selectSchool.filter((x) =>
      x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, ""))
    );
  }
  onCourseNameSelectionChanged(item) {
<<<<<<< HEAD
    this.courseNameId = item.value;
    this.baseSchoolNameId =
      this.CourseGradingEntryForm.get("baseSchoolNameId")?.value;
    this.isShown = true;
    this.CourseGradingEntryService.getCourseGradingEntryListBySchoolNameIdAndCourseNameId(
      this.baseSchoolNameId,
      this.courseNameId
    ).subscribe((response) => {
      this.courseGradingEntryList = response;
    });
  }
=======
      this.courseNameId = item.value 
      this.baseSchoolNameId = this.CourseGradingEntryForm.get('baseSchoolNameId')?.value;
      this.isShown=true;
      this.CourseGradingEntryService.getCourseGradingEntryListBySchoolNameIdAndCourseNameId(this.baseSchoolNameId,this.courseNameId).subscribe(response => {
        this.courseGradingEntryList = response;
      })
     }
>>>>>>> 88d368759e0e15a558ceda810473fca6d7a871ed
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl("/", { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }
  onSubmit() {
<<<<<<< HEAD
    const id = this.CourseGradingEntryForm.get("courseGradingEntryId")?.value;
=======
    const id = this.CourseGradingEntryForm.get('courseGradingEntryId')?.value;   
>>>>>>> 88d368759e0e15a558ceda810473fca6d7a871ed

    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This Item?")
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.CourseGradingEntryService.update(
              +id,
              this.CourseGradingEntryForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/basic-setup/add-coursegradingentry"
                );
                this.snackBar.open(" Information Updated Successfully ", "", {
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
      this.CourseGradingEntryService.submit(
        this.CourseGradingEntryForm.value
      ).subscribe(
        (response) => {
          //this.router.navigateByUrl('/basic-setup/add-coursegradingentry');
          this.reloadCurrentRoute();
          this.snackBar.open(" Information Save Successfully ", "", {
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
