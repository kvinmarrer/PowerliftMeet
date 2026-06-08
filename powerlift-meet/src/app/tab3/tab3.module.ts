import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IonicModule } from '@ionic/angular';
import { TranslateModule } from '@ngx-translate/core'; 

import { Tab3PageRoutingModule } from './tab3-routing.module';
import { Tab3Page } from './tab3.page';

import { SharedModule } from '../shared/shared.module'; 

@NgModule({
  imports: [
    CommonModule,
    IonicModule,
    TranslateModule, 
    Tab3PageRoutingModule,
    SharedModule
  ],
  declarations: [Tab3Page]
})
export class Tab3PageModule {}