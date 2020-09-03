import {Component} from '@angular/core';
import { AuthenticationService } from '../auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component ({
    selector :'pm-login',
    templateUrl : './login.component.html'
    // styleUrls: ['login.style.css']
})
export class LoginComponent {

  public username: string;
  public password: string;

  /**
   *
   */
  constructor(private auth: AuthenticationService, private router: Router, private toastr: ToastrService  ) {

  }

  public Login(): void {
    this.auth.SignIn(this.username, this.password).subscribe({
      next: () => this.router.navigate(['/patients']),
      error: () => { this.username = ''; this.password = ''; this.toastr.error('Authentification Echoué'); }
    });
  }

}
