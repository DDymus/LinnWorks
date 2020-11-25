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
    constructor() {

    }
    ngOnChanges(changes: SimpleChanges): void {
        throw new Error('Method not implemented.');
    }
}
