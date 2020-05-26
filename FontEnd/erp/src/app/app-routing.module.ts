import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from './core/guards/authentication.guard';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('../app/modules/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'dashboard',
    canActivate: [AuthenticationGuard],
    loadChildren: () => import('../app/modules/dashboard/dashboard.module').then(m => m.DashboardModule),
    data: { title: 'Dashboard' }
  },
  {
    path: 'hr',
    loadChildren: () => import('../app/modules/human-resources/human-resources.module').then(m => m.HumanResourcesModule),
    data: { title: 'Human Resources' }
  },
  {
    path: '**',
    loadChildren: () => import('../app/modules/login/login.module').then(m => m.LoginModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
