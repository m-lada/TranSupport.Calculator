import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  constructor(private snackBar: MatSnackBar) {}

  public openErrorSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action, {
      duration: 10000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: ['red-bg'],
    });
  }

  public openSuccessSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action, {
      duration: 10000,
      horizontalPosition: 'right',
      verticalPosition: 'top',
      panelClass: ['green-bg'],
    });
  }
}
