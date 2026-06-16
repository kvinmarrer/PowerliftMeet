import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MeetDetailPageRoutingModule } from './meet-detail-routing.module';

import { MeetDetailPage } from './meet-detail.page';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MeetDetailPageRoutingModule,
    SharedModule
  ],
  declarations: [MeetDetailPage]
})
export class MeetDetailPageModule {}
