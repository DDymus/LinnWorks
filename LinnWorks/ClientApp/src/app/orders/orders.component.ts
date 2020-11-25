import { Component, OnChanges, SimpleChanges, Input } from '@angular/core';

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss']
})
/** orders component*/
export class OrdersComponent implements OnChanges {
/** orders ctor */
  @Input() orders: any;
  @Input() countries: any;
    constructor() {

    }
  ngOnChanges(): void {
    console.log(this.orders);
    console.log(this.countries);
    }
}
