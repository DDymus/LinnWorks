import { Component,Inject, OnChanges, Input, SimpleChanges } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'app-imports-table',
    templateUrl: './imports-table.component.html',
    styleUrls: ['./imports-table.component.scss']
})
/** imports-table component*/
export class ImportsTableComponent implements OnChanges {
/** imports-table ctor */
  baseURL = "";
  @Input() imports: any;
  constructor() {
   
    }
  ngOnChanges(): void {
    
    }
}
 
