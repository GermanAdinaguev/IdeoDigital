import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Invoice } from 'src/app/Models/Invoice';
import { InvoiceItem } from 'src/app/Models/InvoiceItem';
import { InvoiceService } from "src/app/Services/InvoiceService.service";
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { InvoiceItemComponent } from '../InvoiceItem/InvoiceItem.component';

@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.scss']
})
export class InvoiceComponent implements OnInit {

  
  public invoice: Invoice = new Invoice();
  closeResult: string = '';

  constructor(private invoiceService: InvoiceService, private route: ActivatedRoute,private modalService: NgbModal,private router: Router) { }

  ngOnInit() {
    

    this.route.queryParams
      .subscribe(params => {
        if(Object.keys(params).length > 0){
          this.getInvoice(params.id);
        }
      }
    );
  }

  public createOrUpdateInvoice() {
    if(this.invoice.id > 0 ) {
      this.updateInvoice();
    }else {
      this.createInvoice();
    }
  }
 
  public addNewInvocice () {
      this.invoice.invoiceItems.push(new InvoiceItem());
  }


  getInvoice(id: number) {
    this.invoiceService.getInvoice(id).pipe().subscribe({
      next: (data) => {
        this.invoice = data;
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });
  }


  createInvoice() {
    this.invoiceService.createInvoice(this.invoice).pipe().subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigate(['/']);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });
  }

  updateInvoice() {
    this.invoiceService.updateInvoice(this.invoice).pipe().subscribe({
      next: (data) => {
        console.log(data);
        this.router.navigate(['/']);
      },
      error: (e) => console.error(e),
      complete: () => console.info('complete')
    });
  }

  open(item:InvoiceItem) {
    const modalRef = this.modalService.open(InvoiceItemComponent,
      {
        scrollable: true,
        windowClass: 'myCustomModalClass',
      });

    modalRef.componentInstance.invoiceItem = item;
    modalRef.result.then((result) => {
        if(result && result.itemName != ''){
          if(result.id <1) {
            this.invoice.invoiceItems.push(result);
          }         

          var sum: number = 0;
          this.invoice.invoiceItems.forEach( item => {
            sum += item.totalPrice;
          });

          this.invoice.subtotal = sum;
          this.invoice.total = sum + (sum * 18/100);
        }      
      }, (reason) => {
    });
  }

  editItem(item:InvoiceItem){
    this.open(item);
  }

  createItem(){
    const item = new InvoiceItem();
    this.open(item);
  }

}
