import { Injectable } from '@angular/core';
import { HttpService } from './HttpService.service';
import { Observable } from 'rxjs';
import { Invoice } from '../Models/Invoice';


@Injectable()
export class InvoiceService {

  constructor(private httpService: HttpService) { }


  public getInvoice(invoiceId: number): Observable<Invoice> {
    return this.httpService.getInvoice(invoiceId);
  }

  public getAllInvoices(): Observable<Array<Invoice>> {
    return this.httpService.getAllInvoices();
  }

  public createInvoice(invoice: Invoice): Observable<number> {
    return this.httpService.createInvoice(invoice);
  }

  public updateInvoice(invoice: Invoice): Observable<boolean> {
    return this.httpService.updateInvoice(invoice);
  }

}
