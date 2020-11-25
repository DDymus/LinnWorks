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
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
 
    http.get<Country[]>(baseUrl + 'Country').subscribe(result => {
      this.countries = result;
      this.countries.unshift({ id: 0, name: "All" });
      }, error => console.error(error));
  }
  onCountryChange() {
    this.selec
  }
}
interface Country{
  id: number;
  name: string;
}
interface Order {
  id: number;
  extId: number;
  country: string;
  region: string;
}
