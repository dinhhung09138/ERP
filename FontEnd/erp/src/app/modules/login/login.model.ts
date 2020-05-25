export class LoginModel {
  userName: string;
  password: string;
  rememberMe: boolean;

  constructor() {
    this.userName = '';
    this.password = '';
    this.rememberMe = false;
  }
}
