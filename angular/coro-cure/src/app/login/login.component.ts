import {Component, OnInit} from '@angular/core';
import { AuthenticationService } from '../auth.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component ({
    selector :'pm-login',
    templateUrl : './login.component.html'
    // styleUrls: ['login.style.css']
})
export class LoginComponent implements OnInit{

  public username: string;
  public password: string;

  /**
   *
   */
  constructor(private auth: AuthenticationService, private router: Router, private toastr: ToastrService  ) {
  }
  ngOnInit(): void {
    this.auth.loggedIn.next(false);
  }

  public Login(): void {
    this.auth.SignIn(this.username, this.password).subscribe({
      next: (data) => {
        this.auth.loggedIn.next(true);
        this.auth.compte.next(data.body);
        this.router.navigate(['/patients']);
      },
      error: () => { this.username = ''; this.password = ''; this.toastr.error('Authentification Echoué'); }
    });
  }

  public Logout(): void {
    this.auth.SignOut().subscribe({
      next : () => { this.auth.loggedIn.next(false); },
      error: () => { console.log('déconnection échouée'); }
    });
  }

}
