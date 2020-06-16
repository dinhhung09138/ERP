import { NgModule } from '@angular/core';
import { ContractTypeComponent } from './contract-type.component';
import { Routes, RouterModule } from '@angular/router';
import { ContractTypeFormComponent } from './form/form.component';
import { ContractTypeService } from './contract-type.service';
import { SharedModule } from 'src/app/shared/shared.module';

const route: Routes = [
  {
    path: '',
    component: ContractTypeComponent,
    data: { title: 'Contract Type' }
  }
]

@NgModule({
  declarations: [
    ContractTypeComponent,
    ContractTypeFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
  ],
  providers: [
    ContractTypeService,
  ]
})
export class ContractTypeModule { }
