import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTabsModule } from '@angular/material/tabs';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { AuthLayoutComponent } from './app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './app-layout/main-layout/main-layout.component';
import {MatDialog, MatDialogModule} from '@angular/material/dialog';
import {GlobalSearchModalComponent} from '../admin/dashboard/global-search-modal/global-search-modal.component'
@NgModule({
  imports: [CommonModule, NgbModule, MatTabsModule, MatButtonModule,MatIconModule, MatDialog, MatDialogModule],
  declarations: [AuthLayoutComponent, MainLayoutComponent],
  entryComponents: [GlobalSearchModalComponent]
})
export class LayoutModule {}
