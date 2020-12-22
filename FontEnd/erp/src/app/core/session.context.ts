import { Injectable } from '@angular/core';

import { RefreshTokenModel } from './models/refresh-token.model';
import { TokenModel } from './models/token.model';
import { UserInfoModel } from './models/user-info.model';
import { ModuleViewModel } from './models/module.model';
import { FunctionViewModel } from './models/function.model';
import { PermissionViewModel } from './models/permission.model';

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
    sessionStorage.removeItem('modules');
  }

  saveModules(modules: ModuleViewModel[]) {
    sessionStorage.setItem('modules', JSON.stringify(modules));
  }

  getListModule(): ModuleViewModel[] {
    const listModule = JSON.parse(sessionStorage.getItem('modules')) as ModuleViewModel[];
    return listModule;
  }

  getSidebarByModule(moduleName: string): FunctionViewModel[] {
    const listModule = JSON.parse(sessionStorage.getItem('modules')) as ModuleViewModel[];
    const md = listModule.find(m => m.name === moduleName);
    return md.functions.filter(m => m.code.startsWith('HR_EMPLOYEE_') === false);
  }

  getPermissionByForm(moduleName: string, functionCode: string): PermissionViewModel {

    const permission = new PermissionViewModel();

    const listModule = JSON.parse(sessionStorage.getItem('modules')) as ModuleViewModel[];
    const listCommands = listModule.find(m => m.name === moduleName).functions.find(t => t.code === functionCode).commands;

    if (listCommands.length > 0) {
      if (listCommands.some(m => m.isView)) {
        permission.allowView = true;
      }
      if (listCommands.some(m => m.name === 'INSERT')) {
        permission.allowInsert = true;
      }
      if (listCommands.some(m => m.name === 'UPDATE')) {
        permission.allowUpdate = true;
      }
      if (listCommands.some(m => m.name === 'DELETE')) {
        permission.allowDelete = true;
      }
    }

    return permission ?? new PermissionViewModel();

  }

}
