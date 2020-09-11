import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';

import { TranslateService } from '@ngx-translate/core';

import { ApplicationConstant } from 'src/app/core/constants/app.constant';
import { AuthenticationService } from './../../core/services/authentication.service';
import { SessionContext } from 'src/app/core/session.context';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  returnUrl: string;
  submitted = false;
  loginForm: FormGroup;
  warningMessage = [];

  constructor(
    public translate: TranslateService,
    private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private context: SessionContext,
    private authenticationService: AuthenticationService) {
      if (ApplicationConstant.defaultLanguage) {
        translate.use(ApplicationConstant.defaultLanguage);
      }
    }

  ngOnInit(): void {
    this.returnUrl = this.activeRoute.snapshot.queryParams.returnUrl;
    this.loginForm = this.fb.group({
      userName: [localStorage.getItem('userName'), [Validators.required, Validators.maxLength(50)]],
      password: [localStorage.getItem('password'), [Validators.required, Validators.maxLength(50)]],
      rememberMe: [localStorage.getItem('rememberMe') ? localStorage.getItem('rememberMe') : false],
    });

    if (this.context.isAuthenticated()) {
      this.router.navigate(['/dashboard'], {});
      return;
    }
  }

  onSubmitForm() {
    this.warningMessage = [];
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    this.isLoading = true;

    if (this.loginForm.get('rememberMe').value === true) {
      localStorage.setItem('userName', this.loginForm.get('userName').value);
      localStorage.setItem('password', this.loginForm.get('password').value);
      localStorage.setItem('rememberMe', this.loginForm.get('rememberMe').value);
    }

    this.authenticationService.login(this.loginForm.value).subscribe((response: ResponseModel) => {
      if (response) {
        if (response.responseStatus === ResponseStatus.success) {
          console.log(response.result);
          this.context.saveToken(response.result);
          this.router.navigate([this.returnUrl ? this.returnUrl : '/dashboard'], {});
        } else {
          this.warningMessage.push('Tên đăng nhập hoặc mật khẩu không đúng');
          this.isLoading = false;
          this.submitted = false;
        }
      }
    });
  }

}
