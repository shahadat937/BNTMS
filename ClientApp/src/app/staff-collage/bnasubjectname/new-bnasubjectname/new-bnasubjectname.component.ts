import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BNASubjectNameService } from '../../service/BNASubjectName.service';
import { SelectedModel } from '../../../../../src/app/core/models/selectedModel';
import { CodeValueService } from '../../../../../src/app/basic-setup/service/codevalue.service';
import { CourseNameService } from '../../../basic-setup/service/CourseName.service';
import { MasterData } from '../../../../../src/assets/data/master-data';
import { ConnectedOverlayPositionChange } from '@angular/cdk/overlay';
import { ConfirmService } from '../../../../../src/app/core/service/confirm.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { BNASubjectName } from '../../models/BNASubjectName';
import { SharedServiceService } from '../../../../../src/app/shared/shared-service.service';


@Component({
  selector: 'app-edit-bnasubjectname',
  templateUrl: './new-bnasubjectname.component.html',
  styleUrls: ['./new-bnasubjectname.component.sass']
})
export class NewBNASubjectNameComponent implements OnInit, OnDestroy {
   masterData = MasterData;
  loading = false;
  pageTitle: string;
  destination: string;
  btnText: string;
  courseNameId: number;
  //courseTypeId:number;
  course: string;
  branchId: number;
  BNASubjectNameForm: FormGroup;
  buttonText: string;
  validationErrors: string[] = [];
  selectedSemester: SelectedModel[];
  selectedBranch: SelectedModel[];
  selectedCourseName: SelectedModel[];
  selectedSubjectType: SelectedModel[];
  selectedKindOfSubject: SelectedModel[];
  selectedResultStatus: SelectedModel[];
  subjectNameList: BNASubjectName[];
  status = 1;
  isShown: boolean = false;
  courseTypeId: 1021;

  options = [];
  filteredOptions;


  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }

  displayedColumns: string[] = ['paperNo', 'subjectName', 'totalMark', 'passMarkBna', 'menuPosition', 'actions'];
  subscription: any;
  constructor(private snackBar: MatSnackBar, private CourseNameService: CourseNameService, private confirmService: ConfirmService, private CodeValueService: CodeValueService, private BNASubjectNameService: BNASubjectNameService, private fb: FormBuilder, private router: Router, private route: ActivatedRoute, public sharedService: SharedServiceService) { }

  ngOnInit(): void {

    const id = this.route.snapshot.paramMap.get('bnaSubjectNameId');
    if (id) {
      this.pageTitle = 'Edit Subject Name';
      this.destination = "Edit";
      this.buttonText = "Update"
      this.subscription = this.BNASubjectNameService.find(+id).subscribe(
        res => {
          this.BNASubjectNameForm.patchValue({

            bnaSubjectNameId: res.bnaSubjectNameId,
            //bnaSemesterId: res.bnaSemesterId,
            courseModuleId: res.courseModuleId,
            subjectCategoryId: res.subjectCategoryId,
            bnaSubjectCurriculumId: res.bnaSubjectCurriculumId,
            courseNameId: res.courseNameId,
            courseTypeId: res.courseTypeId,
            branchId: res.branchId,
            resultStatusId: res.resultStatusId,
            subjectTypeId: res.subjectTypeId,
            kindOfSubjectId: res.kindOfSubjectId,
            baseSchoolNameId: res.baseSchoolNameId,
            subjectClassificationId: res.subjectClassificationId,
            subjectName: res.subjectName,
            subjectNameBangla: res.subjectNameBangla,
            subjectShortName: res.subjectShortName,
            subjectCode: res.subjectCode,
            totalMark: res.totalMark,
            passMarkBna: res.passMarkBna,
            passMarkBup: res.passMarkBup,
            classTestMark: res.classTestMark,
            assignmentMark: res.assignmentMark,
            caseStudyMark: res.caseStudyMark,
            totalPeriod: res.totalPeriod,
            qExamTime: res.qExamTime,
            paperNo: res.paperNo,
            isActive: res.isActive,
            remarks: res.remarks,
            menuPosition: res.menuPosition,
            course: res.courseName,
          });
          //this.courseNameId = res.courseNameId;
        }
      );
    } else {
      this.pageTitle = 'Create Subject Name';
      this.destination = "Add";
      this.buttonText = "Save"
    }
    this.getSelectedBranch();
    this.getSelectedCourseName();
    //this.getSelectedSubjectType();
    //this.getSelectedResultStatus();
    //this.getSelectedRank();
    //this.getSelectedModule();

    this.intitializeForm();
    this.onBranchSelectionChange()
  }
  ngOnDestroy() {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  intitializeForm() {
    this.BNASubjectNameForm = this.fb.group({
      bnaSubjectNameId: [0],
      //bnaSemesterId: [''],
      courseModuleId: [''],
      subjectCategoryId: [''],
      bnaSubjectCurriculumId: [''],
      courseNameId: [1251],
      course: [''],
      courseTypeId: [],
      branchId: [],
      resultStatusId: [''],
      subjectTypeId: [''],
      kindOfSubjectId: [''],
      baseSchoolNameId: [''],
      subjectClassificationId: [''],
      subjectName: [''],
      subjectNameBangla: [''],
      subjectShortName: [''],
      subjectCode: [''],
      totalMark: [''],
      passMarkBna: [''],
      passMarkBup: [''],
      classTestMark: [''],
      assignmentMark: [''],
      caseStudyMark: [''],
      totalPeriod: [''],
      qExamTime: [''],
      status: [this.status],
      remarks: [''],
      paperNo: [''],
      menuPosition: [],
      isActive: [true],

    })
  }


  getSelectedBranch() {
    this.subscription = this.BNASubjectNameService.getSelectedBranch().subscribe(res => {
      this.selectedBranch = res
    });
  }
  getSelectedCourseName() {
    this.subscription = this.BNASubjectNameService.getSelectedCourseName().subscribe(res => {
      this.selectedCourseName = res
    });
  }
  onBranchSelectionChange() {
    this.isShown = true;
    this.subscription = this.BNASubjectNameService.getselectedSubjectNameByBranchId().subscribe(res => {
      this.subjectNameList = res
    });
  }



  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', { skipLocationChange: true }).then(() => {
      this.router.navigate([currentUrl]);
    });
  }

  onSubmit() {
    const id = this.BNASubjectNameForm.get('bnaSubjectNameId')?.value;
    if (id) {
      this.subscription = this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        if (result) {
          this.loading=true;
          this.subscription = this.BNASubjectNameService.update(+id, this.BNASubjectNameForm.value).subscribe(response => {
            this.router.navigateByUrl('/staff-collage/add-bnasubjectname');
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
      this.loading=true;
      this.subscription = this.BNASubjectNameService.submit(this.BNASubjectNameForm.value).subscribe(response => {
        //this.router.navigateByUrl('/staff-collage/add-bnasubjectname');
        this.reloadCurrentRoute();
        this.snackBar.open('Information Inserted Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }, error => {
        this.validationErrors = error;
      })
    }

  }

  deleteItem(row) {
    const id = row.bnaSubjectNameId;
    this.subscription = this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This Item?').subscribe(result => {
      if (result) {
        this.subscription = this.BNASubjectNameService.delete(id).subscribe(() => {
          //this.onModuleSelectionChangeGetsubjectList();
          this.onBranchSelectionChange();
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

}
