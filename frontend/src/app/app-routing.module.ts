import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CompanyOrdersComponent } from './company-orders/company-orders.component';
import { ChangesComponent } from './changes/changes.component';


const routes: Routes = [
  { path: '', redirectTo: 'companies/1/orders', pathMatch: 'full' },
  { path: 'changes', component: ChangesComponent },
  { path: 'companies/:id/orders', component: CompanyOrdersComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
