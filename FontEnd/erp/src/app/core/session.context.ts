import { RefreshTokenModel } from './models/refresh-token.model';
import { Injectable } from '@angular/core';
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

  isTokenExpired(needToLogout: boolean): boolean {
    const context = JSON.parse(sessionStorage.getItem('token'));
    if (context) {
      const time = Math.round((new Date()).getTime() / 1000);
      const expireDate = parseInt(context.expiration, null);
      if (needToLogout) {
        if (time >= expireDate) {
          return true;
        }
      } else {
        if (time + 300 >= expireDate) {
          return true;
        }
      }
    }
    return false;
  }

  getRefreshToken(): RefreshTokenModel {
    const context = JSON.parse(sessionStorage.getItem('token'));
    const user = this.getUser();
    if (context) {
      const token = new RefreshTokenModel();
      token.userId = user.id;
      token.token = context.refreshToken;
      return token;
    }
    return null;
  }

  clearToken() {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('userInfo');
  }

}
