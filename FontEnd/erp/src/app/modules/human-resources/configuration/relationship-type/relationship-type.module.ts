import { NgModule } from '@angular/core';
import { RelationshipTypeComponent } from './relationship-type.component';
import { Routes, RouterModule } from '@angular/router';
import { RelationshipTypeFormComponent } from './form/form.component';
import { RelationshipTypeService } from './relationship-type.service';
import { SharedModule } from 'src/app/shared/shared.module';
import { MatTableModule } from '@angular/material/table';
import { MatSortModule } from '@angular/material/sort';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';

const route: Routes = [
  {
    path: '',
    component: RelationshipTypeComponent,
    data: { title: 'SCREEN.HR.CONFIGURATION.RELATIONSHIP_TYPE.TITLE' }
  }
];

@NgModule({
  declarations: [
    RelationshipTypeComponent,
    RelationshipTypeFormComponent,
  ],
  imports: [
    SharedModule,
    RouterModule.forChild(route),
    MatTableModule,
    MatSortModule,
    MatCheckboxModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
  ],
  providers: [
    RelationshipTypeService,
  ]
})
export class RelationshipTypeModule { }
