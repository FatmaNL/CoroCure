import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, BehaviorSubject } from 'rxjs';
import { CompteDTO } from './models/compte.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private endpoint: string;

  public compte = new BehaviorSubject<CompteDTO>(null);

  public loggedIn = new BehaviorSubject<boolean>(false);

  constructor(private httpClient: HttpClient) {
    this.endpoint = `${environment.endpoint}/authentication`;
  }

  public SignIn(username: string, password: string): Observable<HttpResponse<CompteDTO>> {
    const payload = new HttpParams()
      .set('username', username)
      .set('password', password);

    return this.httpClient.post<CompteDTO>(`${this.endpoint}/signin`, payload, {withCredentials: true, observe: 'response'});
  }

  public SignOut(): Observable<HttpResponse<any>> {
    return this.httpClient.post<HttpResponse<any>>(`${this.endpoint}/signout`, null, {withCredentials: true, observe: 'response'});
  }

  public Authorize(): Observable<HttpResponse<CompteDTO>> {
    return this.httpClient.get<CompteDTO>(`${this.endpoint}/authorize`, {withCredentials: true, observe: 'response'});
  }

}
