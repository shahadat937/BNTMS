import { Component, OnInit, ViewChild, ElementRef } from "@angular/core";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { MatTableDataSource } from "@angular/material/table";
import { SubjectMark } from "../../../subject-management/models/SubjectMark";
import { SubjectMarkService } from "../../../subject-management/service/SubjectMark.service";
import { SelectionModel } from "@angular/cdk/collections";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material/snack-bar";
import { MasterData } from "../../../../assets/data/master-data";
import { Role } from "../../../core/models/role";
import { AuthService } from "../../../core/service/auth.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-viewsubjectmarkbysubject",
  templateUrl: "./viewsubjectmarkbysubject-list.component.html",
  styleUrls: ["./viewsubjectmarkbysubject-list.component.sass"],
})
export class ViewSubjectMarkListBySubjectComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  masterData = MasterData;
  loading = false;
  userRole = Role;
  ELEMENT_DATA: SubjectMark[] = [];
  isLoading = false;
  baseSchoolNameId: any;
  courseNameId: any;
  bnaSubjectNameId: any;
  courseListStatus: any;
  traineeId: any;
  role: any;
  courseDurationId: any;
  courseName: string;
  traineeDb: any;
  status = 1;
  SelectedsubjectMarksBySubject: SubjectMark[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  searchText = "";

  displayedColumns: string[] = ["ser", "markType", "mark", "passMark"];

  selection = new SelectionModel<SubjectMark>(true, []);

  constructor(
    private snackBar: MatSnackBar,
    private authService: AuthService,
    private SubjectMarkService: SubjectMarkService,
    private router: Router,
    private confirmService: ConfirmService,
    private route: ActivatedRoute,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId = this.authService.currentUserValue.traineeId.trim();
    const branchId = this.authService.currentUserValue.branchId
      ? this.authService.currentUserValue.branchId.trim()
      : "";
    this.getSubjectMarks();
  }

  getSubjectMarks() {
    this.isLoading = true;
    this.traineeDb = 1;
    this.baseSchoolNameId =
      this.route.snapshot.paramMap.get("baseSchoolNameId");
    this.courseNameId = this.route.snapshot.paramMap.get("courseNameId");
    this.courseDurationId =
      this.route.snapshot.paramMap.get("courseDurationId");
    this.bnaSubjectNameId =
      this.route.snapshot.paramMap.get("bnaSubjectNameId");
    this.courseListStatus =
      this.route.snapshot.paramMap.get("courseListStatus");
    this.SubjectMarkService.getSelectedsubjectMarksBySubject(
      Number(this.baseSchoolNameId),
      Number(this.courseNameId),
      Number(this.bnaSubjectNameId)
    ).subscribe((res) => {
      this.SelectedsubjectMarksBySubject = res;
    });
  }
}
