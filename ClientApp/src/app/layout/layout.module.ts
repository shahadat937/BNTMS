import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MatTabsModule } from '@angular/material/tabs';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { AuthLayoutComponent } from './app-layout/auth-layout/auth-layout.component';
import { MainLayoutComponent } from './app-layout/main-layout/main-layout.component';
@NgModule({
  imports: [CommonModule, NgbModule, MatTabsModule, MatButtonModule,MatIconModule],
  declarations: [AuthLayoutComponent, MainLayoutComponent],
})
export class LayoutModule {}
