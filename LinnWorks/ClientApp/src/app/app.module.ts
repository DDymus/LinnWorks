import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { ImportDataComponent } from './data-import/data-import.component';
import { ImportsTableComponent } from './imports-table/imports-table.component'
import { OrdersComponent } from './orders/orders.component';
import {ReportComponent} from './report/report.component'


@NgModule({
  declarations: [
    AppComponent,
    ImportDataComponent,
    ImportsTableComponent,
    OrdersComponent,
    ReportComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: ImportDataComponent, pathMatch: 'full' }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
