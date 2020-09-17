import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';

import { AccountComponent } from './account.component';
import { AccountService } from './account.service';
import { SharedModule } from '../../../shared/shared.module';
import { AccountFormComponent } from './form/form.component';
import { PasswordComponent } from './password/password.component';

const routes: Routes = [
  {
    path: '',
    component: AccountComponent,
    data: { title: 'SCREEN.SYSTEM.ACCOUNT.TITLE' }
  }
];

@NgModule({
  declarations: [
    AccountComponent,
    AccountFormComponent,
    PasswordComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
    MatSelectModule,
  ],
  providers: [
    AccountService,
  ]
})
export class AccountModule { }
