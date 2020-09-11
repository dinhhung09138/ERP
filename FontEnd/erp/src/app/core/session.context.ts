import { Injectable } from '@angular/core';

import { RefreshTokenModel } from './models/refresh-token.model';
import { TokenModel } from './models/token.model';
import { UserInfoModel } from './models/user-info.model';

/**
 * Processing user data into the local storage.
 * User info such as: user info, token, session
 */
@Injectable()
export class SessionContext {

  constructor() { }

  saveToken(data: TokenModel): void {
    sessionStorage.removeItem('token');
    sessionStorage.setItem('token', JSON.stringify({
      accessToken: data.accessToken,
      refreshToken: data.refreshToken,
      expiration: data.expiration
    }));

    this.saveUser(data.userInfo);
  }

  saveUser(user: UserInfoModel): void {
    sessionStorage.removeItem('userInfo');
    sessionStorage.setItem('userInfo', JSON.stringify(user));
  }

  isAuthenticated(): boolean {

    if (sessionStorage.getItem('token')) {
      return true;
    }
    return false;
  }

  getAccessToken(): string {

    const context = JSON.parse(sessionStorage.getItem('token'));
    if (context != null) {
      return context.accessToken;
    }

    return '';
  }

  getUser(): UserInfoModel {
    const user = JSON.parse(sessionStorage.getItem('userInfo'));
    return user;
  }

  getRefreshToken(): RefreshTokenModel {
    if (this.isAuthenticated() === true) {
      const context = JSON.parse(sessionStorage.getItem('token'));
      const user = this.getUser();
      if (context) {
        const token = new RefreshTokenModel();
        token.userId = user.id;
        token.token = context.refreshToken;
        return token;
      }
    }
    return null;
  }

  clearToken() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userInfo');
  }

}
