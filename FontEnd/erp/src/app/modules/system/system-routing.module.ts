import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { SystemComponent } from './system.component';
import { PageNotFoundComponent } from '../../shared/components/page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '',
    component: SystemComponent,
    children: [
      {
        path: 'account',
        loadChildren: () => import('../system/account/account.module').then(m => m.AccountModule),
        pathMatch: 'full',
      },
      {
        path: 'role',
        loadChildren: () => import('../system/role/role.module').then(m => m.RoleModule),
        pathMatch: 'full',
      },
      {
        path: '**',
        component: PageNotFoundComponent,
      }
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})

export class SystemRouterModule { }
