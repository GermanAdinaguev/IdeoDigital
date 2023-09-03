import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InvoiceComponent } from './components/invoice/invoice.component';
import { InvoiceGridComponent } from './components/invoiceGrid/invoiceGrid.component';
import { HttpService } from './Services/HttpService.service';
import { InvoiceService } from "./Services/InvoiceService.service";
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { InvoiceItemComponent } from './components/InvoiceItem/InvoiceItem.component';

@NgModule({
  declarations: [
    AppComponent,
    InvoiceComponent,
    InvoiceGridComponent,
    InvoiceItemComponent
  ],
  imports: [
    BrowserModule,
    NgbModule, 
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    FormsModule
  ],
  providers: [HttpService,InvoiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
