import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ResponseHandlerInterceptorService implements HttpInterceptor {

  constructor(
    private toastr: ToastrService
  ) {
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(tap((success) => {
      if (success instanceof HttpResponse) {
        if (success.url.includes('create') ||
          success.url.includes('update') ||
          success.url.includes('delete') ||
          success.url.includes('login') ||
          success.url.includes('register') ||
          success.url.includes('like') ||
          success.url.includes('unlike') ||
          success.url.includes('order')) {
          this.toastr.success(success.body.message, 'Success');
        }
      }
    }), catchError((err) => {
      this.toastr.error(err.error.message, 'Error');
      throw err
    }));
  }
}
