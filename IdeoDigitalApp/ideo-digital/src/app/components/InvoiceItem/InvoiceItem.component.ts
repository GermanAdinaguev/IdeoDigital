import { Component, Input, OnInit } from '@angular/core';
import { InvoiceItem } from 'src/app/Models/InvoiceItem';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-InvoiceItem',
  templateUrl: './InvoiceItem.component.html',
  styleUrls: ['./InvoiceItem.component.scss']
})
export class InvoiceItemComponent implements OnInit {

  @Input()  invoiceItem: InvoiceItem = new InvoiceItem();

  constructor(public activeModal: NgbActiveModal) {

   }

  ngOnInit() {
    console.log(this.invoiceItem);
  }

  closeModal() {
    this.activeModal.close();
  }

  saveItem() {
    this.invoiceItem.totalPrice = this.invoiceItem.pricePerUnit * this.invoiceItem.quantity;
    this.activeModal.close(this.invoiceItem);
  }

}
