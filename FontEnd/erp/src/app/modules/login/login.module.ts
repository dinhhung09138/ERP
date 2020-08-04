import { MatInputModule } from '@angular/material/input';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatFormFieldModule } from '@angular/material/form-field';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import { LoginService } from './login.service';
import { WarningMessageComponent } from 'src/app/shared/components/warning-message/warning-message.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' }
];

@NgModule({
  declarations: [
    WarningMessageComponent,
    LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule,
    MatCheckboxModule,
    RouterModule.forChild(routes)
  ],
  providers: [
    LoginService,
  ]
})
export class LoginModule { }
