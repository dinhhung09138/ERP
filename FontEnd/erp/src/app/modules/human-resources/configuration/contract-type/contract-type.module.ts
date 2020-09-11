import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

import { ContractTypeFormComponent } from './form/form.component';
import { ContractTypeService } from './contract-type.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { ContractTypeComponent } from './contract-type.component';

const route: Routes = [
  {
    path: '',
    component: ContractTypeComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.CONTRACT_TYPE.TITLE' }
  }
];

@NgModule({
  declarations: [
    ContractTypeComponent,
    ContractTypeFormComponent,
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
    ContractTypeService,
  ]
})
export class ContractTypeModule { }
