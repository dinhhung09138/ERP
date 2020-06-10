import { Routes, RouterModule } from '@angular/router';
import { ContractTypeComponent } from './contract-type.component';
import { NgModule } from '@angular/core';
import { ContractTypeFormComponent } from './contract-type-form/contract-type-form.component';
import { ContractTypeListComponent } from './contract-type-list/contract-type-list.component';
import { CommonModule } from '@angular/common';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';

const route: Routes = [
    {
      path: '',
      component: ContractTypeComponent,
      data: { title: 'ContractType' }
    }
  ]
  
  @NgModule({
    declarations: [
      ContractTypeComponent,
      ContractTypeFormComponent,
      ContractTypeListComponent,
    ],
    imports: [
      CommonModule,
      MatCheckboxModule,
      MatSortModule,
      MatPaginatorModule,
      MatTableModule,
      RouterModule.forChild(route),
    ]
  })
  export class ContractTypeModule { }