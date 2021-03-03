import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ICategory from '../../../components/shared/models/categories/ICategory';
import ICreateCategory from '../../../components/shared/models/categories/ICreateCategory';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  private readonly baseUrl = 'https://localhost:44309/api/categories/';
  private readonly baseUrlAdmin = 'https://localhost:44309/api/admin/categories/';
  private readonly getNamesUrl = 'allNames';
  private readonly allUrl = 'all';
  private readonly createUrl = 'create';

  constructor(
    private http: HttpClient) { }

  public getAll(): Observable<Array<ICategory>> {
    return this.http.get<Array<ICategory>>(this.baseUrl + this.allUrl);
  }

  public getAllNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.baseUrl + this.getNamesUrl);
  }

  public create(data: ICreateCategory) {
    console.log(this.baseUrlAdmin + this.createUrl);
    return this.http.post(this.baseUrlAdmin + this.createUrl, data);
  }
}
