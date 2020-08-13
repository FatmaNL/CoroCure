import { Component } from '@angular/core';
import { Router, RouterEvent, NavigationStart, NavigationEnd, NavigationCancel, NavigationError } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'pm-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'coro-cure';

  constructor(private router: Router, private spinner: NgxSpinnerService) {
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
}
