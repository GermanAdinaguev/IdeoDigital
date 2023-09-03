export class InvoiceItem {
    id: number;
    itemName: string;
    quantity: number;
    pricePerUnit: number;
    totalPrice: number;

    constructor() {
        this.id = 0;
        this.itemName = '';
        this.quantity = 0;
        this.pricePerUnit = 0;
        this.totalPrice = 0;
    }
}

