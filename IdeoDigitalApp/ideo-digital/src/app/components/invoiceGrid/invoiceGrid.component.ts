import { Component, OnInit } from '@angular/core';
import { Invoice } from 'src/app/Models/Invoice';
import { InvoiceService } from 'src/app/Services/InvoiceService.service';

@Component({
  selector: 'app-invoiceGrid',
  templateUrl: './invoiceGrid.component.html',
  styleUrls: ['./invoiceGrid.component.scss']
})
export class InvoiceGridComponent implements OnInit {

  public invoices: Array<Invoice> = new Array<Invoice>();
  
  constructor(private invoiceService: InvoiceService) { }

  ngOnInit() {
    this.getInvoices();
  }

  getInvoices() {
    this.invoiceService.getAllInvoices().pipe().subscribe({
      next: (data) => {
        this.invoices = data;
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });
  }

}
