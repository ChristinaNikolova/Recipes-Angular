import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable, ViewContainerRef } from '@angular/core';
//import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ResponseHandlerInterceptorService implements HttpInterceptor {

  //constructor(
  //  private toastr: ToastrService,
  //  private viewContainerRef: ViewContainerRef
  //) {
  //  this.toastr.viewContainerRef = this.viewContainerRef;
  //}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(tap((success) => {
      if (success instanceof HttpResponse) {
        if (success.url.endsWith('login') || success.url.endsWith('register')) {
          //this.toastr.success('Success', 'Success');
        }
      }
    }), catchError((err) => {
      if (err instanceof HttpErrorResponse) {
        if (!err.url.endsWith('register')) {
          //this.toastr.error(err.error.message, 'Error');
        }
      }
      throw err
    }));
  }
}
