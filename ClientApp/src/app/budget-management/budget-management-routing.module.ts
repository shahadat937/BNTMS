import { AddBudgetListComponent } from './budgetallocation/budgetadd/add-budget.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {NewBudgetAllocationComponent} from './budgetallocation/new-budgetallocation/new-budgetallocation.component';
import {BudgetAllocationListComponent} from './budgetallocation/budgetallocation-list/budgetallocation-list.component';
import {NewCourseBudgetAllocationComponent} from './coursebudgetallocation/new-coursebudgetallocation/new-coursebudgetallocation.component';
import {CourseBudgetAllocationListComponent} from './coursebudgetallocation/coursebudgetallocation-list/coursebudgetallocation-list.component';
import {ScheduleInstallmentListComponent} from './scheduleinstallment/scheduleinstallment-list/scheduleinstallment-list.component';
import { BudgetTransaction } from './budgetallocation/budget-transaction/transaction.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },

  { 
    path: 'scheduleinstallment-list', 
    component: ScheduleInstallmentListComponent,
  },

  {
    path: 'coursebudgetallocation-list', 
    component: CourseBudgetAllocationListComponent,
  },
  { path: 'update-coursebudgetallocation/:courseBudgetAllocationId',  
  component: NewCourseBudgetAllocationComponent, 
  },
  {
    path: 'add-coursebudgetallocation',
    component: NewCourseBudgetAllocationComponent,
  },


  {
    path: 'budgetallocation-list', 
    component: BudgetAllocationListComponent,
  },
  // { path: 'update-budgetallocation/:budgetAllocationId',  
  // component: NewBudgetAllocationComponent, 
  // },
  {
    path: 'add-budgetallocation',
    component: NewBudgetAllocationComponent,
  }, 
  {
    path: 'add-budget',
    component: AddBudgetListComponent,
  },
  {
    path: 'transaction-type',
    component: BudgetTransaction,
  },
  { path: 'update-budgettransaction/:budgetTransactionId',  
    component: BudgetTransaction, 
    },
    { path: 'update-budgetallocation/:budgetAllocationId',  
      component: AddBudgetListComponent, 
      },

];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BudgetManagementRoutingModule { }
