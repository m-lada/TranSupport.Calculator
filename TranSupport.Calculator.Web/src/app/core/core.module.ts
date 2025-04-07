import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule, Optional, SkipSelf } from '@angular/core';
import { TokenInterceptor } from './interceptors/token.service';
import { AuthenticationUserService } from './services/authentication-user.service';
import { AuthenticationGuard } from './guards/authentication.guard';

@NgModule({
  imports: [HttpClientModule],
  providers: [
    AuthenticationUserService,
    AuthenticationGuard,
    { provide: HTTP_INTERCEPTORS, useClass: TokenInterceptor, multi: true },
  ],
})
export class CoreModule {
  constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
    if (parentModule) {
      throw new Error(
        '$CoreModule has already been loaded. Import Core modules in AppModule only',
      );
    }
  }
}
