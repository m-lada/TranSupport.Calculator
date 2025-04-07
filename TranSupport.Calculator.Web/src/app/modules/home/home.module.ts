import { NgModule } from '@angular/core';
import { HomeComponent } from './pages';
import { HomeRoutingModule } from './home-routing.module';
import { CommonModule } from '@angular/common';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [HomeComponent],
  imports: [HomeRoutingModule, CommonModule, SharedModule],
  exports: [],
})
export class HomeModule {}
