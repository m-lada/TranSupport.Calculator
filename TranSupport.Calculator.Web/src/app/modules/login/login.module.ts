import { NgModule } from '@angular/core';
import { LoginComponent } from './pages/login/login.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [LoginComponent],
  imports: [SharedModule, FormsModule],
})
export class LoginModule {}
