import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SessionContext } from 'src/app/core/session.context';
import { LoginService } from './login.service';
import { ResponseModel } from 'src/app/core/models/response.model';
import { ResponseStatus } from 'src/app/core/enums/response-status.enum';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  returnUrl: string;
  submitted = false;
  loginForm: FormGroup;
  warningMessage = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private activeRoute: ActivatedRoute,
    private context: SessionContext,
    private loginService: LoginService) { }

  ngOnInit(): void {
    this.returnUrl = this.activeRoute.snapshot.queryParams.returnUrl;
    this.loginForm = this.fb.group({
      userName: [localStorage.getItem('username'), [Validators.required, Validators.maxLength(50)]],
      password: [localStorage.getItem('password'), [Validators.required, Validators.maxLength(50)]],
      rememberMe: [localStorage.getItem('rememberMe') ? localStorage.getItem('rememberMe') : false],
    });

    if (this.context.isAuthenticated()) {
      this.router.navigate(['/'], {});
      return;
    }
  }

  get f() { return this.loginForm.controls; }

  onSubmitForm() {
    this.warningMessage = [];
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }

    this.isLoading = true;

    this.loginService.login(this.loginForm.value).subscribe((res: ResponseModel) => {
      if (res) {
        if (res.responseStatus === ResponseStatus.success) {
          console.log(res.result);
          this.context.saveToken(res.result);
          this.router.navigate([this.returnUrl ? this.returnUrl : '/'], {});
        } else {
          this.warningMessage.push('User name or password incorrect');
          this.isLoading = false;
          this.submitted = false;
        }
      }
    });
  }

}
