import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { WeighInPageRoutingModule } from './weigh-in-routing.module';

import { WeighInPage } from './weigh-in.page';

import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    WeighInPageRoutingModule,
    SharedModule
  ],
  declarations: [WeighInPage]
})
export class WeighInPageModule {}
