import { Injectable } from '@angular/core';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { HttpClient } from '@angular/common/http';
import { NgxSpinner } from 'ngx-spinner/lib/ngx-spinner.enum';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CoronarographieService {

  private endpoint: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.endpoint = `${environment.endpoint}/coronarographie`;
  }

  public add(coronarographie: CoronarographieDTO): Observable<any> {
    return this.httpClient.post(this.endpoint, coronarographie);
  }

}
