import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import IRegister from '../../../components/shared/models/authentication/IRegister';
import ILogin from '../../../components/shared/models/authentication/ILogin';

@Injectable()
export class AuthService {
  private readonly baseUrl = 'https://localhost:44309/api/account/';
  private readonly loginUrl = 'login';
  private readonly registerUrl = 'register';

  constructor(
    private http: HttpClient
  ) { }

  register(body: IRegister) {
    return this.http.post(this.baseUrl + this.registerUrl, body);
  }

  login(body: ILogin) {
    return this.http.post(this.baseUrl + this.loginUrl, body);
  }

  logout() {
    return localStorage.clear();
  }

  isAuthenticated() {
    return localStorage.getItem('token') !== null;
  }

  getToken() {
    return localStorage.getItem('token');
  }
}
