import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';

import { HeaderComponent } from './components';

const components = [HeaderComponent];

@NgModule({
  declarations: [...components],
  imports: [MaterialModule, CommonModule],
  exports: [MaterialModule, CommonModule, ...components],
})
export class SharedModule {}
