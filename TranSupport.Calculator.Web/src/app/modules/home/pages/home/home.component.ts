import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/core/nSwag/nSwag';

export class PageFilter {
  public data: Person[] = [];
  public Total: number | undefined;
  public Page: number | undefined;
  public Limit: number | undefined;
}

export class Person {
  id: string | undefined;
  Title: string | undefined;
  FirstName: string | undefined;
  LastName: string | undefined;
  Picture: string | undefined;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private authService: AuthenticationService) {}

  public pageFilter?: PageFilter;

  public ngOnInit(): void {
    this.authService.getFilterPage().subscribe((x) => {
      this.pageFilter = x;
      console.log(this.pageFilter);
    });
  }

  // public testAnyUser(): void {
  //   this.authService
  //     .auth()
  //     .subscribe(() => console.log('Test polaczenia z API - ok'));
  // }

  // public testAdmin(): void {
  //   this.authService
  //     .authA()
  //     .subscribe(() => console.log('Test polaczenia Admina z API - ok'));
  // }

  // public testFreeUser(): void {
  //   this.authService
  //     .authU()
  //     .subscribe(() => console.log('Test polaczenia FreeUser z API - ok'));
  // }
}
