import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private readonly baseUrl = 'https://localhost:44309/api/categories/';
  private readonly getNames = 'getAllNames';

  constructor(
    private http: HttpClient) { }

  public getAllNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.baseUrl + this.getNames);
  }
}
