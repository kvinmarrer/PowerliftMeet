import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { authGuard } from './guards/auth-guard';


const routes: Routes = [
  {
    path: '',
    redirectTo: '/tabs/home',
    pathMatch: 'full'
  },
  {
    path: 'login',
    loadChildren: () => import('./login/login.module').then( m => m.LoginPageModule)
  },
  {
    path: 'tabs',
    canActivate: [authGuard],
    children: [
      {
        path: 'home',
        loadChildren: () => import('./home/home.module').then(m => m.HomePageModule)
      },
      {
        path: 'athletes',
        loadChildren: () => import('./athletes/athletes.module').then(m => m.AthletesPageModule)
      },
      {
        path: 'meet/:id',
        loadChildren: () => import('./meet-detail/meet-detail.module').then(m => m.MeetDetailPageModule)
      },
      {
        path: 'meet-athletes/:meetId',
        loadChildren: () => import('./meet-athletes/meet-athletes.module').then( m => m.MeetAthletesPageModule)
      },
      {
        path: 'flight/:meetId',
        loadChildren: () => import('./flight/flight.module').then( m => m.FlightPageModule)
      },
      {
        path: 'weigh-in/:meetId',
        loadChildren: () => import('./weigh-in/weigh-in.module').then( m => m.WeighInPageModule)
      },
      {
        path: '',
        redirectTo: '/tabs/home',
        pathMatch: 'full'
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes, { preloadingStrategy: PreloadAllModules })
  ],
  exports: [RouterModule]
})
export class AppRoutingModule {}