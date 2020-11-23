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
    http.get<Import[]>(baseUrl + 'HandleFile').subscribe(result => {
      this.imports = result;
    }, error => console.error(error));
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
      console.log(result);
    }, error => console.error(error));
  }
  private validateFile() {
    return true;
  }
  

}
interface Import {
  id: number;
  LastModifyDttm: string;
  LastModifyUserId: number;
}
