import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { WeighInPage } from './weigh-in.page';

const routes: Routes = [
  {
    path: '',
    component: WeighInPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class WeighInPageRoutingModule {}
