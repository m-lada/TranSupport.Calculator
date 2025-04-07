import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject, Observable } from 'rxjs';
import { AuthenticationUserService } from 'src/app/core/services/authentication-user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent implements OnInit {
  protected userName: string | null;

  constructor(
    private authService: AuthenticationUserService,
    private router: Router,
  ) {
    this.userName = this.authService.getUserName();
  }

  ngOnInit() {}

  public logout() {
    this.authService.logout();
  }

  public navigateAccountSettings() {
    //TODO: nawigacja do strony użytkownika
  }
}
