import { InvoiceItem } from "./InvoiceItem";

export class Invoice {

    id: number;
    invoiceDate: Date;
    businessName: string;
    businessAddress: string;
    businessPhone: string;
    customerName: string;
    customerAddress: string;
    subtotal: number;
    tax: number;
    total: number;
    invoiceItems: InvoiceItem[];

    constructor() {
        this.id = 0;
        this.invoiceDate = new Date();
        this.businessName = '';
        this.businessAddress = '';
        this.businessPhone = '';
        this.customerName = '';
        this.customerAddress = '';
        this.subtotal = 0;
        this.tax = 18;
        this.total = 0;
        this.invoiceItems = [];
    }
}
