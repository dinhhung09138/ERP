import { Injectable } from "@angular/core";
import { HttpInterceptor, HttpHeaders, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SessionContext } from '../sessioncontext';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {

  constructor(private context: SessionContext) { }

  setHeaders(request, token) {
    let headers = new HttpHeaders();

    headers = headers.append('Authentication', token);
    if (request.url.includes('/authentication') || request.url.includes('.json')) {
    } else {
      headers = headers.append('Content-Type', 'application/json');
      headers = headers.append('Cache-Control', 'no-cache');
      headers = headers.append('Pragma', 'no-cache');
    }

    return request.clone( {headers });
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (req.url.includes('/authentication') || req.url.includes('.json')) {
      return next.handle(req);
    }

    const token = this.context.getContext();

    const modified = this.setHeaders(req, this.jwtToken(token));
    return next.handle(modified);
  }

  jwtToken(token): string {
    return 'bearer ' + token;
  }

}
