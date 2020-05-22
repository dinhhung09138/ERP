import { Injectable } from "@angular/core";
import { CanActivate, Router, RouterStateSnapshot, ActivatedRouteSnapshot } from '@angular/router';
import { SessionContext } from '../session.context';

@Injectable()
export class AuthenticationGuard implements CanActivate {

  constructor(private router: Router, private context: SessionContext) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    const user = this.context.getUser();

    return true;
    if (user) {
      return true;
    }

    this.router.navigate(['login'], { queryParams: { returnUrl: state.url } });
    return false;
  }
}
