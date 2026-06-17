import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { FlightPage } from './flight.page';

const routes: Routes = [
  {
    path: '',
    component: FlightPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class FlightPageRoutingModule {}
