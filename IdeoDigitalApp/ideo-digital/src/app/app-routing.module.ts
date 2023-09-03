import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceComponent } from './components/invoice/invoice.component';
import { InvoiceGridComponent } from './components/invoiceGrid/invoiceGrid.component';

const routes: Routes = [
  {
    path: '',
    component: InvoiceGridComponent,
  },
  {
    path: 'invoice',
    component: InvoiceComponent,
  }
];

@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
