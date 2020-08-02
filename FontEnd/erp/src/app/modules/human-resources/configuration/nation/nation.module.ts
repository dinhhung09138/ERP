import { NationService } from './nation.service';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { SharedModule } from 'src/app/shared/shared.module';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NationComponent } from './nation.component';
import { NationFormComponent } from './form/form.component';


const routes: Routes = [
  {
    path: '',
    component: NationComponent,
    data: { title: 'Dân tộc' }
  }
];


@NgModule({
  declarations: [
    NationComponent,
    NationFormComponent
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(routes),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    NationService,
  ]
})
export class NationModule { }
