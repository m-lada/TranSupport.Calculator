import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticateRequest, UserService } from 'src/app/core/nSwag/nSwag';
import { AuthenticationUserService } from 'src/app/core/services/authentication-user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  public loginForm: AuthenticateRequest = { email: '', password: '' };

  constructor(
    private _auth: AuthenticationUserService,
    private router: Router,
  ) {}

  public ngOnInit() {}

  public loginUser(): void {
    this._auth.login(this.loginForm).subscribe();
  }
}
