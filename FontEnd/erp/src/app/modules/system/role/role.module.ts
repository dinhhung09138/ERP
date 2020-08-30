import { NgModule } from '@angular/core';
import { RoleComponent } from './role.component';
import { RoleFormComponent } from './form/form.component';
import { RouterModule, Routes } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import { SharedModule } from 'src/app/shared/shared.module';
import { RoleService } from './role.service';

const routes: Routes = [
  {
    path: '',
    component: RoleComponent,
    data: { title: 'SCREEN.SYSTEM.ROLE.TITLE' }
  }
];

@NgModule({
  declarations: [RoleComponent, RoleFormComponent],
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
  ]
})
export class RoleModule { }
