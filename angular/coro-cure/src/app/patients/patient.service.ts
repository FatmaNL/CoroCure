import { Injectable } from '@angular/core';
import { TabPatient } from './patient';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap} from 'rxjs/operators'

@Injectable(
    {providedIn: 'root'}
)

export class PatientService {
    private patientUrl = 'https://localhost:5001/api/Patient';

    constructor(private http: HttpClient){}

    getPatients(): Observable<TabPatient[]> { 
        return this.http.get<TabPatient[]>(this.patientUrl)
        .pipe(
            tap(data => console.log('All: ' + JSON.stringify(data))),
            catchError(this.handleError)
          );
    }

    deletePatient(id: number): Observable<void> {
    return this.http.delete<void>(`${this.patientUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
    }


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