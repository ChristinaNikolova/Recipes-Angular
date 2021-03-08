import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import IRegister from '../../../components/shared/models/authentication/IRegister';
import ILogin from '../../../components/shared/models/authentication/ILogin';

@Injectable()
export class AuthService {
  private readonly baseUrl = 'https://localhost:44324/api/account/';
  private readonly loginUrl = 'login';
  private readonly registerUrl = 'register';
  private readonly isUserAdmin: boolean;

  constructor(
    private http: HttpClient
  ) {
    this.isUserAdmin = false;
  }

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

  isAdmin(): boolean {
    return localStorage.getItem('isAdmin') === 'true' ? !this.isUserAdmin : this.isUserAdmin;
  }
}
