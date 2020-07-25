import { Injectable } from '@angular/core';
import { TabPatient } from './patient';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, map } from 'rxjs/operators'

@Injectable(
  { providedIn: 'root' }
)

export class PatientService {
  private patientUrl = 'http://localhost:5000/api/Patient';
  //private patientUrl = 'assets/patients.json';

  constructor(private http: HttpClient) { }

  getPatients(): Observable<TabPatient[]> {
    return this.http.get<TabPatient[]>(this.patientUrl)
      .pipe(
        tap(data => console.log('All: ' + JSON.stringify(data))),
        catchError(this.handleError)
      );
  }

  getPatient(id: number): Observable<TabPatient | undefined> {
    return this.http.get<TabPatient>(`${this.patientUrl}/${id}`);
  }

  deletePatient(id: number): Observable<void> {
    return this.http.delete<void>(`${this.patientUrl}/${id}`)
      .pipe(
        catchError(this.handleError)
      );
  }

  addPatient(newPatient: TabPatient): Observable<TabPatient> {
    return this.http.post<TabPatient>(this.patientUrl, newPatient)
      .pipe(
        catchError(this.handleError)
      );
  }

  updatePatient(updatedPatient: TabPatient) {
    return this.http.put<void>(`${this.patientUrl}/${updatedPatient.id}`, updatedPatient);
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