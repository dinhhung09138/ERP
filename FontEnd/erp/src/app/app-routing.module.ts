import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthenticationGuard } from './core/guards/authentication.guard';
import { PageNotFoundComponent } from './shared/components/page-not-found/page-not-found.component';


const routes: Routes = [
  {
    path: 'login',
    loadChildren: () => import('../app/modules/login/login.module').then(m => m.LoginModule)
  },
  {
    path: 'dashboard',
    canActivate: [AuthenticationGuard],
    loadChildren: () => import('../app/modules/dashboard/dashboard.module').then(m => m.DashboardModule),
  },
  {
    path: 'hr',
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
    loadChildren: () => import('../app/modules/human-resources/human-resources.module').then(m => m.HumanResourcesModule),
  },
  {
    path: 'training',
    canActivate: [AuthenticationGuard],
    canActivateChild: [AuthenticationGuard],
    loadChildren: () => import('../app/modules/training/training.module').then(m => m.TrainingModule),
  },
  {
    path: '**',
    component: PageNotFoundComponent,
    canActivate: [AuthenticationGuard],
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
