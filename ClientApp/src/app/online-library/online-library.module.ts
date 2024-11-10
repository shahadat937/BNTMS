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
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatDialogModule } from '@angular/material/dialog';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

import { OnlineLibraryRoutingModule } from './online-library-routing.module';
import { OnlineLibraryMeterialListComponent } from './online-library-meterial-list/online-library-meterial-list.component';
import { NewOnlineLibraryMetarialComponent } from './new-online-library-metarial/new-online-library-metarial.component';


@NgModule({
  declarations: [
    OnlineLibraryMeterialListComponent,
    NewOnlineLibraryMetarialComponent
  ],
  imports: [
    CommonModule,
    OnlineLibraryRoutingModule,   
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
    MatProgressSpinnerModule,
    MatDialogModule,
  ]
})
export class OnlineLibraryModule { }
