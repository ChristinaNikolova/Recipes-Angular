import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import IRegister from '../../components/shared/models/IRegister';
import ILogin from '../../components/shared/models/ILogin';

@Injectable()
export class AuthService {
  private readonly loginUrl = 'https://localhost:44309/api/account/login';
  private readonly registerUrl = 'https://localhost:44309/api/account/register';

  constructor(
    private http: HttpClient
  ) { }

  register(body: IRegister) {
    return this.http.post(this.registerUrl, body);
  }

  login(body: ILogin) {
    return this.http.post(this.loginUrl, body);
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
