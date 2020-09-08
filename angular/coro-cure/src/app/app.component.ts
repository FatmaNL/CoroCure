import { Component, OnInit } from '@angular/core';
import { Router, RouterEvent, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { AuthGuardService } from './auth-guard.service';
import { AuthenticationService } from './auth.service';
import { Observable, of } from 'rxjs';
import { CompteDTO } from './models/compte.dto';

@Component({
  selector: 'pm-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {
  title = 'coro-cure';
  public userFullName: Observable<string>;

  public role: Observable<string>;

  public isLoggedIn$: Observable<boolean>;

  constructor(private router: Router, private spinner: NgxSpinnerService, private authService: AuthenticationService) {
    this.router.events.subscribe((event: RouterEvent) => {
      switch (true) {
        case event instanceof NavigationStart: {
          this.spinner.show();
          break;
        }

        case event instanceof NavigationEnd:
        case event instanceof NavigationCancel:
        case event instanceof NavigationError: {
          this.spinner.hide();
          break;
        }
        default: {
          this.spinner.hide();
          break;
        }
      }
    });
  }

  ngOnInit(): void {
    this.isLoggedIn$ = this.authService.loggedIn;

    this.authService.compte.subscribe({
      next: (data) => {
        if (data !== null) {
          this.userFullName = of(data.fullName);
          this.role = of(data.roles);
        }
        else {
          this.userFullName = of('Test test');
        }
      }
    });
  }

  public logOut(): void {
    this.authService.SignOut().subscribe({
      next: () => { this.router.navigate(['/login']); },
      error: () => { } });
  }
}
