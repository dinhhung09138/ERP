import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { RoleComponent } from './role.component';
import { RoleFormComponent } from './form/form.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleService } from './role.service';
import { FunctionService } from '../function/function.service';
import { PermissionComponent } from './form/permission/permission.component';

const routes: Routes = [
  {
    path: '',
    component: RoleComponent,
    data: { title: 'SCREEN.SYSTEM.ROLE.TITLE' }
  }
];

@NgModule({
  declarations: [
    RoleComponent,
    RoleFormComponent,
    PermissionComponent],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    RoleService,
    FunctionService,
  ]
})
export class RoleModule { }
