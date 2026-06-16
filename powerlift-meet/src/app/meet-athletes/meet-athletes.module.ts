import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { MeetAthletesPageRoutingModule } from './meet-athletes-routing.module';

import { MeetAthletesPage } from './meet-athletes.page';

import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    MeetAthletesPageRoutingModule,
    SharedModule
  ],
  declarations: [MeetAthletesPage]
})
export class MeetAthletesPageModule {}
