import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
@Component({
  selector: 'app-data-import',
  templateUrl: './data-import.component.html'
})

export class ImportDataComponent {
  baseURL: string = "http://localhost:3000/";

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
  }
  public fileChange1(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length == 0) {
      //TODO: empty selection handling
    } else {
      let i;
      for (i = 0; i < fileList.length; i++) {
        const file: File = fileList[i];
        this.proceedFile(file);
      }
    }
  }
  private proceedFile(file: File) {
    if (!this.validateFile(file)) {
      console.log("Validation Failed");
      return;
    }
    const url = this.baseURL + "HandleFile";
    const formData: FormData = new FormData();

    formData.append('File', file, file.name);
    return this.http.post(url, formData).subscribe(result => {
      console.log(result);
    }, error => console.error(error));
  }
  private validateFile(file: File) {
    return true;
  }
  public fileChange(event) {
    let fileList: FileList = event.target.files;
    if (fileList.length == 0) {
      //TODO: empty selection handling
    } else {
        let file: File = fileList[0];
        this.readFile(file);
      
    }
  }

  private readFile(file: File) {
    const reader = new FileReader();
    reader.onload = () => {
      console.log(file.name + ":Start");
      const resultString = reader.result as string;
      const lines = resultString.split(/[\r\n]+/);
      if (lines.length === 0) {
        //TODO: empty file handling.
      } else {
        const columnNames = lines[0].split(',');
        const mapping = {
          region: 0,
          country: 1,
          itemType: 2,
          salesChannel: 3,
          orderPriority: 4,
          orderDate: 5,
          orderId: 6,
          shipDate: 7,
          unitsSold: 8,
          unitCost: 9,
          totalRevenue: 10,
          totalCost: 11,
          totalProfit: 12
        };
        const itemsPerRequest = 100;
        let itemsToSend = [];
        let i = 1;
        for (i = 1; i < lines.length; i++) {
          if (itemsToSend.length === itemsPerRequest) {
            const headers = { 'content-type': 'application/json' }
            const body = itemsToSend;
            this.http.post(this.baseURL + 'insertItems', body, { 'headers': headers });
          } 
            const values = lines[i].split(',');
            const salesItem = {
              region: values[mapping.region],
              country: values[mapping.country],
              item_type: values[mapping.itemType],
              sales_channel: values[mapping.salesChannel],
              order_priority: values[mapping.orderDate],
              order_date: values[mapping.orderDate],
              order_id: values[mapping.orderId],
              ship_date: values[mapping.shipDate],
              units_sold: values[mapping.unitsSold],
              unit_cost: values[mapping.unitCost],
              total_revenue: values[mapping.totalRevenue],
              total_cost: values[mapping.totalCost],
              total_profit: values[mapping.totalProfit]

            };
            itemsToSend.push(salesItem);
        }
      }
      console.log(file.name + ":End")
    };
    reader.readAsText(file);
  }
}
interface Sales {
  region: string;
  country: string;
  item_type: string;
  sales_channel: string;
  order_priority: string;
  order_date: string;
  order_id: number;
  ship_date: string;
  units_sold: number;
  unit_cost: number;
  total_revenue: number;
  total_cost: number;
  total_profit: number;
}
