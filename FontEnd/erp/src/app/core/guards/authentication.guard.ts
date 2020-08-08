import { Injectable } from '@angular/core';
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot, CanActivateChild } from '@angular/router';
import { SessionContext } from '../session.context';

@Injectable()
export class AuthenticationGuard implements CanActivate, CanActivateChild {

  constructor(private router: Router, private context: SessionContext) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log('check canActivate');
    return this.authentication(state);
  }

  canActivateChild(next: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    console.log('check canActivateChild');
    return this.authentication(state);
  }

  private authentication(state: RouterStateSnapshot): boolean {


    const user = this.context.getUser();

    if (user) {
      return true;
    }

    this.router.navigate(['login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
