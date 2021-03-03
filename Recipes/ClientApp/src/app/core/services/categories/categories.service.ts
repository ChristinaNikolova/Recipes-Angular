import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ICategory from '../../../components/shared/models/categories/ICategory';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private readonly baseUrl = 'https://localhost:44309/api/categories/';
  private readonly getNamesUrl = 'allNames';
  private readonly allUrl = 'all';

  constructor(
    private http: HttpClient) { }

  public getAll(): Observable<Array<ICategory>> {
    return this.http.get<Array<ICategory>>(this.baseUrl + this.allUrl);
  }

  public getAllNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.baseUrl + this.getNamesUrl);
  }
}
