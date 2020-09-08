import { Injectable } from '@angular/core';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { HttpClient } from '@angular/common/http';
import { NgxSpinner } from 'ngx-spinner/lib/ngx-spinner.enum';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { ExportationDTO } from '../models/exportation.dto';

@Injectable({
  providedIn: 'root'
})
export class ExportationService {

  private endpoint: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.endpoint = `${environment.endpoint}/exportation`;
  }

  public get(): Observable<ExportationDTO[]> {
    return this.httpClient.get<ExportationDTO[]>(this.endpoint);
  }

  public exportPdf(patientId: number, interventionId: number): Observable<any> {
    const httpOptions = {
      responseType: 'blob' as 'json'
    };

    return this.httpClient.get(this.endpoint + '/pdf/' + patientId + '/' + interventionId, httpOptions);
  }

  public exportXls(): Observable<any> {
    const httpOptions = {
      responseType: 'blob' as 'json'
    };

    return this.httpClient.get(this.endpoint + '/excel', httpOptions);
  }

}
