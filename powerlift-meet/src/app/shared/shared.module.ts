import { IonicModule } from '@ionic/angular';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from '../header/header.component';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  imports: [CommonModule, TranslateModule, IonicModule, HeaderComponent],
  exports: [HeaderComponent, TranslateModule, IonicModule],
})
export class SharedModule {}
