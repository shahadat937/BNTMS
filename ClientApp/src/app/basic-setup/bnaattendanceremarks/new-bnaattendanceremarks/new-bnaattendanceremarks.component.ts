import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material/snack-bar";
import { ActivatedRoute, Router } from "@angular/router";
import { BNAAttendanceRemarksService } from "../../service/BNAAttendanceRemarks.service";
import { ConfirmService } from "../../../core/service/confirm.service";
import { SharedServiceService } from "../../../shared/shared-service.service";
import { UnsubscribeOnDestroyAdapter } from "../../../shared/UnsubscribeOnDestroyAdapter";

@Component({
  selector: "app-new-bnaattendanceremarks",
  templateUrl: "./new-bnaattendanceremarks.component.html",
  styleUrls: ["./new-bnaattendanceremarks.component.sass"],
})
export class NewBNAAttendanceRemarksComponent
  extends UnsubscribeOnDestroyAdapter
  implements OnInit
{
  buttonText: string;
  loading = false;
  pageTitle: string;
  destination: string;
  BNAAttendanceRemarksForm: FormGroup;
  validationErrors: string[] = [];

  constructor(
    private snackBar: MatSnackBar,
    private BNAAttendanceRemarksService: BNAAttendanceRemarksService,
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private confirmService: ConfirmService,
    public sharedService: SharedServiceService
  ) {
    super();
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get("bnaAttendanceRemarksId");
    if (id) {
      this.pageTitle = "Edit BNA Attendance Remarks";
      this.destination = "Edit";
      this.buttonText = "Update";
      this.BNAAttendanceRemarksService.find(+id).subscribe((res) => {
        this.BNAAttendanceRemarksForm.patchValue({
          bnaAttendanceRemarksId: res.bnaAttendanceRemarksId,
          attendanceRemarksCause: res.attendanceRemarksCause,
          //menuPosition: res.menuPosition,
        });
      });
    } else {
      this.pageTitle = "Create BNA Attendance Remarks";
      this.destination = "Add";
      this.buttonText = "Save";
    }
    this.intitializeForm();
  }
  intitializeForm() {
    this.BNAAttendanceRemarksForm = this.fb.group({
      bnaAttendanceRemarksId: [0],
      attendanceRemarksCause: ["", Validators.required],
      //menuPosition: ['', Validators.required],
      isActive: [true],
    });
  }

  onSubmit() {
    const id = this.BNAAttendanceRemarksForm.get(
      "bnaAttendanceRemarksId"
    )?.value;
    if (id) {
      this.confirmService
        .confirm("Confirm Update message", "Are You Sure Update This  Item?")
        .subscribe((result) => {
          if (result) {
            this.loading = true;
            this.BNAAttendanceRemarksService.update(
              +id,
              this.BNAAttendanceRemarksForm.value
            ).subscribe(
              (response) => {
                this.router.navigateByUrl(
                  "/basic-setup/bnaattendanceremarks-list"
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
      this.BNAAttendanceRemarksService.submit(
        this.BNAAttendanceRemarksForm.value
      ).subscribe(
        (response) => {
          this.router.navigateByUrl("/basic-setup/bnaattendanceremarks-list");
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
