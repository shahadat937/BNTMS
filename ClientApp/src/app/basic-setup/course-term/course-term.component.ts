<<<<<<< HEAD
import { Component, OnInit } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { CourseTermService } from "../service/course-term.service";
import { CourseLevelService } from "../service/course-level.service";
import { BaseSchoolNameService } from "../../basic-setup/service/BaseSchoolName.service";
import { CourseTerm } from "../models/course-term";
import { stringify } from "@angular/compiler/src/util";
import { MasterData } from "../../../assets/data/master-data";
import { SelectedModel } from "../../core/models/selectedModel";
import { ConfirmService } from "../../core/service/confirm.service";
import { SharedServiceService } from "../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../shared/UnsubscribeOnDestroyAdapter";
=======
import { Component, OnInit } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { CourseTermService } from '../service/course-term.service';
import { ConfirmService } from '../../../../src/app/core/service/confirm.service';
import { SelectedModel } from '../../../../src/app/core/models/selectedModel';
import { CourseLevelService } from '../service/course-level.service';
import { BaseSchoolNameService } from '../../basic-setup/service/BaseSchoolName.service';
import{MasterData} from '../../../../src/assets/data/master-data';
import { CourseTerm } from '../models/course-term';
import { stringify } from '@angular/compiler/src/util';
import { UnsubscribeOnDestroyAdapter } from '../../../../src/app/shared/UnsubscribeOnDestroyAdapter';
import { SharedServiceService } from '../../../../src/app/shared/shared-service.service';

>>>>>>> 88d368759e0e15a558ceda810473fca6d7a871ed
@Component({
  selector: "app-course-term",
  templateUrl: "./course-term.component.html",
  styleUrls: ["./course-term.component.sass"],
})
export class CourseTermComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  pageTitle: string;
  loading = false;
  destination: string;
  btnText: string;
  CourseTermForm: FormGroup;
  validationErrors: string[] = [];

  selectedSchool: SelectedModel[];
  SelectedCourseLevel: SelectedModel[];
  selectCourse: SelectedModel[];
  selectSchool: SelectedModel[];

  masterData = MasterData;
  isLoading = false;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = [
    "ser",
    "courseTermTitle",
    "isActive",
    "actions",
  ];
  dataSource: MatTableDataSource<CourseTerm> = new MatTableDataSource();

  constructor(
    private baseSchoolNameService: BaseSchoolNameService,
    private CourseLevelService: CourseLevelService,
    private snackBar: MatSnackBar,
    private confirmService: ConfirmService,
    private CourseTermService: CourseTermService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("courseTermId");
    if (id) {
      this.pageTitle = "Edit Course Term ";
      this.destination = "Edit";
      this.btnText = "Update";
      this.CourseTermService.find(+id).subscribe((res) => {
        this.CourseTermForm.patchValue({
          courseTermId: res.courseTermId,

          courseLevelId: res.courseLevelId,
          courseTermTitle: res.courseTermTitle,
          baseSchoolNameId: res.baseSchoolNameId,
          isActive: res.isActive,
          //menuPosition: res.menuPosition,
        });
      });
    } else {
      this.pageTitle = "Create Course Term ";
      this.destination = "Add";
      this.btnText = "Save";
    }
    this.intitializeForm();

    this.getSelectedbaseSchoolName();
    this.getSelectedCourseLevel();
    this.getCourseTerms();
  }
  intitializeForm() {
    this.CourseTermForm = this.fb.group({
      courseTermId: [0],
      courseTermTitle: ["", Validators.required],
      courseLevelId: ["", Validators.required],
      baseSchoolNameId: ["", Validators.required],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    });
  }

  getCourseTerms() {
    this.isLoading = true;
    this.CourseTermService.getCourseTerms(
      this.paging.pageIndex,
      this.paging.pageSize,
      this.searchText
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
    this.getCourseTerms();
  }

  applyFilter(searchText: any) {
    this.paging.pageSize = 10;
    this.paging.pageIndex = 1;
    this.searchText = searchText;
    this.getCourseTerms();
  }

  deleteItem(row) {
    const id = row.courseTermId;
    this.confirmService
      .confirm("Confirm delete message", "Are You Sure Delete This  Item")
      .subscribe((result) => {
        if (result) {
          this.CourseTermService.delete(id).subscribe(() => {
            this.getCourseTerms();
            this.snackBar.open("Information Deleted Successfully ", "", {
              duration: 2000,
              verticalPosition: "bottom",
              horizontalPosition: "right",
              panelClass: "snackbar-danger",
            });
          });
        }
      });
  }

  getSelectedbaseSchoolName() {
    this.baseSchoolNameService.getselectedSchools().subscribe((res) => {
      this.selectedSchool = res;
      this.selectSchool = res;
    });
  }

  getSelectedCourseLevel() {
    this.CourseLevelService.getselectedCourseLevel().subscribe((res) => {
      this.SelectedCourseLevel = res;
      this.selectCourse = res;
    });
  }
  filterByCourseLevel(value: any) {
    this.SelectedCourseLevel = this.selectCourse.filter((x) =>
      x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, ""))
    );
  }
  filterBySchoolName(value: any) {
    this.selectedSchool = this.selectSchool.filter((x) =>
      x.text.toLowerCase().includes(value.toLowerCase().replace(/\s/g, ""))
    );
  }

  onSubmit() {
<<<<<<< HEAD
    const id = this.CourseTermForm.get("courseTermId")?.value;
=======
    const id = this.CourseTermForm.get('courseTermId')?.value;   
>>>>>>> 88d368759e0e15a558ceda810473fca6d7a871ed

    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This Item")
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.CourseTermService.update(
              +id,
              this.CourseTermForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl("/basic-setup/add-courseTerm");
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
      this.CourseTermService.submit(this.CourseTermForm.value).subscribe(
        (response) => {
          this.router.navigateByUrl("/basic-setup/add-courseTerm");
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
