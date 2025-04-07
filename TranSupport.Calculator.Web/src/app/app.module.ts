import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { HomeModule } from './modules/home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { LoginModule } from './modules/login/login.module';
import { CoreModule } from './core/core.module';
import { environment } from 'src/environments/environment';
import { API_BASE_URL } from './core/nSwag/nSwag';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AdministrationModule } from './modules/administration/administration.module';
import { SharedModule } from './shared/shared.module';

export function getBaseUrl(): string {
  return environment.API_BASE_URL;
}

@NgModule({
  declarations: [AppComponent],
  imports: [
    CoreModule,
    BrowserModule,
    HomeModule,
    LoginModule,
    RouterModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AdministrationModule,
    SharedModule,
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useFactory: getBaseUrl,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
