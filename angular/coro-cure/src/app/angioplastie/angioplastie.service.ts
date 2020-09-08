import { Injectable } from '@angular/core';
import { CoronarographieDTO } from '../models/coronarographie.dto';
import { HttpClient } from '@angular/common/http';
import { NgxSpinner } from 'ngx-spinner/lib/ngx-spinner.enum';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { CardiologueDTO } from '../models/cardiologue.dto';
import { tap, catchError } from 'rxjs/operators';
import { AngioplastieDTO } from '../models/angioplastie.dto';

@Injectable({
  providedIn: 'root'
})
export class AngioplastieService {

  private endpoint: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.endpoint = `${environment.endpoint}/angioplastie`;
  }

  public add(angioplastie: AngioplastieDTO): Observable<any> {
    return this.httpClient.post(this.endpoint, angioplastie);
  }

  public get(): Observable<AngioplastieDTO[]> {
    const data = this.httpClient.get<AngioplastieDTO[]>(this.endpoint)
    .pipe(
      tap(data => console.log('All: ' + JSON.stringify(data)))
    );

    return data;
  }

}
