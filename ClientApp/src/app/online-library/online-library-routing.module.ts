import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OnlineLibraryMeterialListComponent } from './online-library-meterial-list/online-library-meterial-list.component';
import { NewOnlineLibraryMetarialComponent } from './new-online-library-metarial/new-online-library-metarial.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  {
    path: 'online-library-materials',
    component: OnlineLibraryMeterialListComponent,
  },
  {
    path: 'new-online-library-materials',
    component: NewOnlineLibraryMetarialComponent,
  },
  {
    path: 'update-online-library-materials/:onlineLibraryId',
    component: NewOnlineLibraryMetarialComponent,
  },
 
]

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class OnlineLibraryRoutingModule { }
