import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Invoice } from '../Models/Invoice';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private apiUrl = environment.apiUrl + '/api';

  constructor(private http: HttpClient) {
  }

  public getInvoice(invoiceId:number): Observable<Invoice> {
    return this.http.get(this.apiUrl + '/Invoice/GetInvoiceById/?id=' + invoiceId).pipe(map((value: any) => value));
  }

  public getAllInvoices(): Observable<Array<Invoice>> {
    return this.http.get(this.apiUrl + '/Invoice/GetInvoices').pipe(map((value: any) => value));
  }

  public createInvoice(invoice:Invoice): Observable<number> {
    return this.http.post(this.apiUrl + '/Invoice/CreateInvoice',invoice).pipe(map((value: any) => value));
  }

  public updateInvoice(invoice:Invoice): Observable<boolean> {
    return this.http.post(this.apiUrl + '/Invoice/UpdateInvoice',invoice).pipe(map((value: any) => value));
  }

}
