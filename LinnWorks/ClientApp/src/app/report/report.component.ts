import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';

@Component({
    selector: 'app-report',
    templateUrl: './report.component.html',
    styleUrls: ['./report.component.scss']
})
/** report component*/
export class ReportComponent {
/** report ctor */
  reports: Report[];
  HTTP: HttpClient;
  baseURL: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.HTTP = http;
    this.baseURL = baseUrl;
    this.HTTP.get<Report[]>(this.baseURL + 'Report').subscribe(result => {
    }, error => console.error(error));
  }
}
interface Report{
  country: string;
  year: number;
  nrOrders: number;
  profit: number;
}
