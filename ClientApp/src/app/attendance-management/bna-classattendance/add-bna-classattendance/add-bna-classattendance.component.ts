import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { MasterData } from 'src/assets/data/master-data';

@Component({
  selector: 'app-add-bna-classattendance',
  templateUrl: './add-bna-classattendance.component.html',
  styleUrls: ['./add-bna-classattendance.component.sass']
})
export class AddBnaClassattendanceComponent implements OnInit {
  masterData = MasterData;
  loading = false;
  myModel = true;
  userRole = Role;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BnaAttendanceForm: FormGroup;
  role:any;
  traineeId:any;
  branchId:any;
  baseSchoolId:any;


  constructor(private authService: AuthService) { }

  ngOnInit(): void {
      this.pageTitle = 'Create Attendance';
      this.destination = "Add"; 
      this.buttonText= "Save";

      this.role = this.authService.currentUserValue.role.trim();
      this.baseSchoolId =  this.authService.currentUserValue.branchId.trim();

  }

}
