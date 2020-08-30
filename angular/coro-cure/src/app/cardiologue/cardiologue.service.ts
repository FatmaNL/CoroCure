import { Injectable } from '@angular/core';
import { TabCardiologue } from './cardiologue';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable(
  { providedIn: 'root' }
)

export class CardiologueService{
    private cardiologueUrl='http://localhost:5000/api/Cardiologue';
    // private cardiologueUrl='assets/cardiologue.json';

  constructor(private http: HttpClient) { }

  getCardiologues(): Observable<TabCardiologue[]> {
    return this.http.get<TabCardiologue[]>(this.cardiologueUrl)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getCardiologue(cin: number): Observable<TabCardiologue | undefined> {
    return this.http.get<TabCardiologue>(`${this.cardiologueUrl}/${cin}`);
  }

  deleteCardiologue(id: number): Observable<void> {
    return this.http.delete<void>(`${this.cardiologueUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  addCardiologue(newCardiologue: TabCardiologue): Observable<TabCardiologue> {
    return this.http.post<TabCardiologue>(this.cardiologueUrl, newCardiologue)
      .pipe(
        catchError(this.handleError)
      );
  }

  updateCardiologue(updatedCardiologue: TabCardiologue) {
    return this.http.put<void>(`${this.cardiologueUrl}/${updatedCardiologue.cin}`, updatedCardiologue);
  }

      /*updateCardiologue(updatedCardiologue: TabCardiologue) {
        return this.http.put<void>(`${this.cardiologueUrl}/${this.cardiologueUrl.cin}`, updatedCardiologue);
      }*/

    private handleError(err: HttpErrorResponse) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        let errorMessage = '';
        if (err.error instanceof ErrorEvent) {
          // A client-side or network error occurred. Handle it accordingly.
          errorMessage = `An error occurred: ${err.error.message}`;
        } else {
          // The backend returned an unsuccessful response code.
          // The response body may contain clues as to what went wrong,
          errorMessage = `Server returned code: ${err.status}, error message is: ${err.message}`;
        }
        console.error(errorMessage);
        return throwError(errorMessage);
      }
}