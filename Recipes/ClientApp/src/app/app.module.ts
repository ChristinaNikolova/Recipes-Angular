import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtInterceptorService } from './core/interceptors/jwt-interceptor.service';
import { ResponseHandlerInterceptorService } from './core/interceptors/response-handler-interceptor.service';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthService } from './core/services/auth/auth.service';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    NotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    AuthService,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ResponseHandlerInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
