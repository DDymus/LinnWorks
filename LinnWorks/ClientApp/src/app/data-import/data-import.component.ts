import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-data-import',
  templateUrl: './data-import.component.html'
})

export class ImportDataComponent {
  baseURL = "";
  imports: Import[];
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURL = baseUrl;
    this.loadImports();
    this.loadOrders();
  }
  public fileChange(event) {
    const fileList: FileList = event.target.files;
    if (fileList.length === 0) {
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
    if (!this.validateFile()) {
      console.log("Validation Failed");
      return;
    }
    const url = this.baseURL + "HandleFile";
    const formData: FormData = new FormData();

    formData.append('File', file, file.name);
    return this.http.post(url, formData).subscribe(result => {
      this.loadImports();
      this.loadOrders();
    }, error => {
        this.loadImports();
        this.loadOrders();
    });
  }
  private validateFile() {
    return true;
  }
  private loadImports() {
    this.http.get<Import[]>(this.baseURL + 'Import').subscribe(result => {
      this.imports = result;
    }, error => console.error(error));
  }
  private loadOrders() {
    this.http.get<Import[]>(this.baseURL + 'Orders').subscribe(result => {
      this.imports = result;
    }, error => console.error(error));}
}
interface Import {
  id: number;
  lastModifyDttm: string;
  lastModifyUserId: number;
  originalFileName: string;
}
