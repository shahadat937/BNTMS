import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';

import { AttendanceManagementRoutingModule } from './attendance-management-routing.module';
import { BNAExamAttendanceListComponent } from './bnaexamattendance/bnaexamattendance-list/bnaexamattendance-list.component';
import { NewBNAExamAttendanceComponent } from './bnaexamattendance/new-bnaexamattendance/new-bnaexamattendance.component';
import { AttendanceListComponent } from './attendance/attendance-list/attendance-list.component';
import { NewAttendanceComponent } from './attendance/new-attendance/new-attendance.component';
import {AttendanceApprovedComponent} from './attendance/attendance-approved/attendance-approved.component';
import {AttendanceInstructorComponent} from './attendance/attendance-instructor/attendance-instructor.component';
import { AddBnaClassattendanceComponent } from './bna-classattendance/add-bna-classattendance/add-bna-classattendance.component';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { MatTooltipModule } from '@angular/material/tooltip';

@NgModule({
  declarations: [
    BNAExamAttendanceListComponent,
    NewBNAExamAttendanceComponent,
    AttendanceListComponent,
    NewAttendanceComponent,
    AttendanceApprovedComponent,
    AttendanceInstructorComponent,
    AddBnaClassattendanceComponent
  ],
  imports: [
    CommonModule,
    AttendanceManagementRoutingModule,
    CommonModule,
    FormsModule,  
    ReactiveFormsModule,
    NgxDatatableModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    MatSnackBarModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatDatepickerModule,
    MaterialFileInputModule,
    MatTooltipModule,
    MatCheckboxModule,
    NgMultiSelectDropDownModule.forRoot(),
  ]
})
export class AttendanceManagementModule { }
