import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/core/service/auth.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BNAExamMarkService } from '../../service/bnaexammark.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Component({
  selector: 'app-add-bnaexammarkentry',
  templateUrl: './add-bnaexammarkentry.component.html',
  styleUrls: ['./add-bnaexammarkentry.component.sass']
})
export class AddBnaexammarkentryComponent implements OnInit {

  BNAExamMarkForm: FormGroup;
  pageTitle : string;
  role:any;
  traineeId:any;
  branchId:any;
  selectedcoursedurationbyschoolname:SelectedModel[];
  constructor(private snackBar: MatSnackBar, private authService: AuthService, private confirmService: ConfirmService,  private fb: FormBuilder, private router: Router, private route: ActivatedRoute, private BNAExamMarkService: BNAExamMarkService,) { }

  ngOnInit(): void {
    this.pageTitle = 'Create BNA Exam Mark';
    
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.intitializeForm();
    this.getSelectedCourseDurationByschoolname();
  }

  intitializeForm() {
    this.BNAExamMarkForm = this.fb.group({
      bnaExamMarkId: [0],
      traineeId: [],
      bnaExamScheduleId: [],
      bnaSemesterId: [],
      courseName: [''],
    })
  }

  getSelectedCourseDurationByschoolname() {

    this.BNAExamMarkService.getSelectedCourseDurationByschoolname(this.branchId).subscribe(res => {
      this.selectedcoursedurationbyschoolname = res;
      console.log("val : ", res)
    });
  }

  onSubmit(){

  }
}
