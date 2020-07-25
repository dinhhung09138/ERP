import { NetworkInterceptor } from './../core/interceptor/network.interceptor';
import { ErrorInterceptor } from './../core/interceptor/error.interceptor';
import { HeaderInterceptor } from './../core/interceptor/header.interceptor';
import { HTTP_INTERCEPTORS } from '@angular/common/http';

export const appInterceptors = [
  { provide: HTTP_INTERCEPTORS, useClass: NetworkInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: HeaderInterceptor, multi: true },
  { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
];
