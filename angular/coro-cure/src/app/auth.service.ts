import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable()
export class AuthenticationService {
  private endpoint: string;

  constructor(
    private httpClient: HttpClient
  ) {
    this.endpoint = `${environment.endpoint}/authentication`;
  }
  public SignIn(username: string, password: string): Observable<HttpResponse<any>> {
    const payload = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient.post<HttpResponse<any>>(`${this.endpoint}/signin`, payload, {withCredentials: true});
  }

  public SignOut(): Observable<HttpResponse<any>> {
    return this.httpClient.post<HttpResponse<any>>(`${this.endpoint}/signout`, null, {withCredentials: true});
  }

  public Authorize(): Observable<HttpResponse<any>> {
    return this.httpClient.get<HttpResponse<any>>(`${this.endpoint}/authorize`, {withCredentials: true});
  }

}
