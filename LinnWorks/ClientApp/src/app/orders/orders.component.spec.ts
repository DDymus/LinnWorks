/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { OrdersComponent } from './orders.component';

let component: OrdersComponent;
let fixture: ComponentFixture<OrdersComponent>;

describe('orders component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ OrdersComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(OrdersComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});