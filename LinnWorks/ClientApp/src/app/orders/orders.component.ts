import { Component, Inject} from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-orders',
    templateUrl: './orders.component.html',
    styleUrls: ['./orders.component.scss']
})
/** orders component*/
export class OrdersComponent {
/** orders ctor */
  private countries: Country[] = [];
  private orders: Order[] = [];
  private HTTP: HttpClient;
  private baseURL: string;
  private selectedCountry: number;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.HTTP = http;
    this.baseURL = baseUrl;
    this.HTTP.get<Country[]>(this.baseURL + 'Country').subscribe(result => {
      this.countries = result;
      this.countries.unshift({ countryId: 0, name: "All" });
      this.onCountryChange(0);
      }, error => console.error(error));
  }
  onCountryChange(value) {
    this.selectedCountry = value;
    this.HTTP.get<Order[]>(this.baseURL + 'Orders?countryId=' + value).subscribe(result => {
      this.orders = result;
    }, error => console.error(error));
  }
  onDelete(id) {
    this.HTTP.delete(this.baseURL + 'Orders?id=' + id).subscribe(result => { this.onCountryChange(this.selectedCountry); }, error => { console.error(error) });
  }
}

interface Country{
  countryId: number;
  name: string;
}
interface Order {
  orderId: number;
  extId: number;
  country: string;
  region: string;
  orderDate: string;
  shipDate: string;
  unitsSold: number;
  unitPrice: number;
  unitCost: number;
}
