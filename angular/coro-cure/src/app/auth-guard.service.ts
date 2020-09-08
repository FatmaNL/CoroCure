import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { AuthenticationService } from './auth.service';
@Injectable()
export class AuthGuardService implements CanActivate {
  constructor(public router: Router, public httpClient: HttpClient, private authService: AuthenticationService) { }
  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    return new Observable<boolean>(o => {
      this.authService.Authorize().toPromise()
      .then(
        () => {o.next(true); this.authService.loggedIn.next(true); }
      )
      .catch(
        () => { console.log('unauthorized'); this.router.navigate(['/login']); o.next(false); this.authService.loggedIn.next(false); }
      );
    });


    /* return new Observable<boolean>(o => {
      this.authService.Authorize().subscribe({
        next: () => o.next(true),
        error: () => {
          this.router.navigate(['/login']);
          return o.next(false);
        },
      });
    }); */
  }
}
