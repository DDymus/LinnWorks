/// <reference path="../../../../node_modules/@types/jasmine/index.d.ts" />
import { TestBed, async, ComponentFixture, ComponentFixtureAutoDetect } from '@angular/core/testing';
import { BrowserModule, By } from "@angular/platform-browser";
import { ImportsTableComponent } from './imports-table.component';

let component: ImportsTableComponent;
let fixture: ComponentFixture<ImportsTableComponent>;

describe('imports-table component', () => {
    beforeEach(async(() => {
        TestBed.configureTestingModule({
            declarations: [ ImportsTableComponent ],
            imports: [ BrowserModule ],
            providers: [
                { provide: ComponentFixtureAutoDetect, useValue: true }
            ]
        });
        fixture = TestBed.createComponent(ImportsTableComponent);
        component = fixture.componentInstance;
    }));

    it('should do something', async(() => {
        expect(true).toEqual(true);
    }));
});