import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, catchError, of, tap } from 'rxjs';
import {
  AuthenticateRequest,
  AuthenticateResponse,
  AuthenticationService,
} from '../nSwag/nSwag';
import { SnackbarService } from './snackbar.service';
import * as jwtDecode from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class AuthenticationUserService {
  private userNameClaim =
    'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier';
  private readonly authAPIUrl = 'authentication/login';

  constructor(
    private snackbarService: SnackbarService,
    private authenticationService: AuthenticationService,
    private router: Router,
  ) {}

  public getUserName(): string | null {
    const userDetails = this.getDecodedToken();
    return userDetails ? userDetails[this.userNameClaim.valueOf()] : null;
  }

  public getToken(): string | null {
    return this.getUserFromLocalStorage();
  }

  public isLoggedIn(): boolean {
    return this.getUserFromLocalStorage() ? true : false;
  }

  public login(request: AuthenticateRequest): Observable<AuthenticateResponse> {
    return this.authenticationService.login(request).pipe(
      //TODO
      //wyłapać error po nieudanej próbie logowania
      catchError((error) =>
        of(error, this.snackbarService.openErrorSnackBar(error.error, 'Close')),
      ),
      tap((response) => {
        this.saveUserToLocalStorage(response);
        this.navigateToHomePage();
        this.snackbarService.openSuccessSnackBar(
          'Successful Authentication',
          'Close',
        );
      }),
    );
  }

  public logout(): void {
    localStorage.removeItem('token');
    this.navigateToHomePage();
  }

  private saveUserToLocalStorage(
    authenticateResponse: AuthenticateResponse,
  ): void {
    if (authenticateResponse) {
      localStorage.setItem('token', authenticateResponse.token);
    }
  }

  private getUserFromLocalStorage(): string | null {
    return localStorage.getItem('token');
  }

  private navigateToHomePage(): void {
    this.router.navigate(['']);
  }

  private getDecodedToken(): any {
    const token = this.getToken();

    if (token) {
      return jwtDecode.jwtDecode(token);
    }

    return null;
  }
}
