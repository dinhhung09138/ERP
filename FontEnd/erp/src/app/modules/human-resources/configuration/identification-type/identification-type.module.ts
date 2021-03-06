import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { IdentificationTypeComponent } from './identification-type.component';
import { IdentificationTypeFormComponent } from './form/form.component';
import { IdentificationTypeService } from './identification-type.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: IdentificationTypeComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.IDENTIFICATION.TITLE' }
  }
];

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
    MatCheckboxModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    IdentificationTypeService,
  ]
})
export class IdentificationTypeModule { }
