import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MeetAthletesPage } from './meet-athletes.page';

const routes: Routes = [
  {
    path: '',
    component: MeetAthletesPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MeetAthletesPageRoutingModule {}
