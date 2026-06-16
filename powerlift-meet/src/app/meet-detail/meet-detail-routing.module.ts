import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MeetDetailPage } from './meet-detail.page';

const routes: Routes = [
  {
    path: '',
    component: MeetDetailPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MeetDetailPageRoutingModule {}
