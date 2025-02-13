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

import { JCOsTrainingRoutingModule } from './jcos-training-routing.module';
import { JCOsTrainingListComponent } from './jcostraining/jcostraining-list/jcostraining-list.component';
import { NewJCOsTrainingComponent } from './jcostraining/new-jcostraining/new-jcostraining.component';
import { TraineeNominationListComponent } from './traineenomination/traineenomination-list/traineenomination-list.component';
import { NewTraineeNominationComponent } from './traineenomination/new-traineenomination/new-traineenomination.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { BNASubjectNameListComponent } from './bnasubjectname/bnasubjectname-list/bnasubjectname-list.component';
import { NewBNASubjectNameComponent } from './bnasubjectname/new-bnasubjectname/new-bnasubjectname.component';
import { ViewSubjectListByJCOsComponent } from './jcostraining/viewsubjectbyjcos-list/viewsubjectbyjcos-list.component';
import { NewJCOsTrainingMarkComponent } from './jcostrainingmark/new-jcostrainingmark/new-jcostrainingmark.component';
import { NewSubjectMarkComponent } from './subjectmark/new-subjectmark/new-subjectmark.component';
import { NewClassRoutineComponent } from './classroutine/new-classroutine/new-classroutine.component';
import { NewAttendanceComponent } from './attendance/new-attendance/new-attendance.component';
import {NewAttendanceTraineeListComponent } from './attendance/new-attendancetraineelist/new-attendancetraineelist.component';
import { NewCourseInstructorComponent } from './courseinstructor/new-courseinstructor/new-courseinstructor.component';
import { NewIndexNoComponent } from './indexno/new-indexno/new-indexno.component';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { ExamApproveListComponent } from './jcoexammark/examapprove-list/examapprove-list.component';
import { ViewSubjectResultJcosComponent } from './jcostraining/viewsubjectresultjcos-list/viewsubjectresultjcos-list.component';
import { JsoExamMarkApproveListComponent } from './jso-exam-mark-approve-list/jso-exam-mark-approve-list.component';
import { ApproveJcoexamemarkComponent } from './approve-jcoexamemark/approve-jcoexamemark.component';

@NgModule({
  declarations: [
    
     JCOsTrainingListComponent,
     NewJCOsTrainingComponent,
     ViewSubjectListByJCOsComponent,
     TraineeNominationListComponent,
     NewTraineeNominationComponent,
     BNASubjectNameListComponent,
     NewBNASubjectNameComponent,
     NewJCOsTrainingMarkComponent,
     NewSubjectMarkComponent,
     NewClassRoutineComponent,
     NewAttendanceComponent,
     NewAttendanceTraineeListComponent,
     NewCourseInstructorComponent,
     NewIndexNoComponent,
     ExamApproveListComponent,
     ViewSubjectResultJcosComponent,
     JsoExamMarkApproveListComponent,
     ApproveJcoexamemarkComponent
  ],
  imports: [
    CommonModule,
    JCOsTrainingRoutingModule,
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
    MatAutocompleteModule,
    MatCheckboxModule  
  ]
})
export class JCOsTrainingModule { }
