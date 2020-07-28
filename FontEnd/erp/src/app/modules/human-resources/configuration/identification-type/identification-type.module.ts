import { NgModule } from '@angular/core';
import { IdentificationTypeComponent } from './identification-type.component';
import { Routes, RouterModule } from '@angular/router';
import { IdentificationTypeFormComponent } from './form/form.component';
import { IdentificationTypeService } from './identification-type.service';
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
    component: IdentificationTypeComponent,
    data: { title: 'Identification Type' }
  }
]

@NgModule({
  declarations: [
    IdentificationTypeComponent,
    IdentificationTypeFormComponent,
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
    IdentificationTypeService,
  ]
})
export class IdentificationTypeModule { }