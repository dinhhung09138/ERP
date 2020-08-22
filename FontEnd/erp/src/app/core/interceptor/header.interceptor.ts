import { SessionContext } from './../session.context';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHeaders, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { EMPTY, Observable } from 'rxjs';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {

  constructor(private context: SessionContext) { }

  setHeaders(request, token) {
    let headers = new HttpHeaders();

    headers = headers.append('Authorization', token);
    if (request.url.includes('/authentication') || request.url.includes('.json')) {
    } else {
      headers = headers.append('Cache-Control', 'no-cache');
      headers = headers.append('Pragma', 'no-cache');
      if (this.routeWithFormData(request) === false) {
        headers = headers.append('Content-Type', 'application/json');
      }
    }

    return request.clone( {headers });
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    if (req.url.includes('/authentication') || req.url.includes('.json')) {
      return next.handle(req);
    }

    const token = this.context.getAccessToken();

    const modified = this.setHeaders(req, this.jwtToken(token));
    return next.handle(modified);
  }

  private jwtToken(token): string {
    return 'bearer ' + token;
  }

  private routeWithFormData(request: any): boolean {
    if (request.url.includes('/employee/insert')) {
      return true;
    }
    if (request.url.includes('/employee/update')) {
      return true;
    }
    return false;
  }

}
