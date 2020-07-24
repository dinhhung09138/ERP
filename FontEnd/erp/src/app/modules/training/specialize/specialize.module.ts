import { NgModule } from '@angular/core';
import { SpecializeComponent } from './specialize.component';
import { Routes, RouterModule } from '@angular/router';
import { SpecializeFormComponent } from './form/form.component';
import { SpecializeService } from './specialize.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: SpecializeComponent,
    data: { title: 'Training Type' }
  }
]

@NgModule({
  declarations: [
    SpecializeComponent,
    SpecializeFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatPaginatorModule,
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    SpecializeService,
  ]
})
export class SpecializeModule { }
