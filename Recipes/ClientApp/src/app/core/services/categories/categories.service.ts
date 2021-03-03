import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ICategory from '../../../components/shared/models/categories/ICategory';
import ICategoryAdmin from '../../../components/shared/models/categories/ICategoryAdmin';
import ICategoryUpdate from '../../../components/shared/models/categories/ICategoryUpdate';
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
  private readonly updateUrl = 'update';
  private readonly deleteUrl = 'delete/';
  private readonly categoryForUpdateUrl = 'categoryForUpdate/';

  constructor(
    private http: HttpClient) { }

  public getAll(): Observable<Array<ICategory>> {
    return this.http.get<Array<ICategory>>(this.baseUrl + this.allUrl);
  }

  public getAllNames(): Observable<Array<string>> {
    return this.http.get<Array<string>>(this.baseUrl + this.getNamesUrl);
  }

  public getAllForAdmin(): Observable<Array<ICategoryAdmin>> {
    return this.http.get<Array<ICategoryAdmin>>(this.baseUrlAdmin + this.allUrl);
  }

  public create(data: ICreateCategory) {
    return this.http.post(this.baseUrlAdmin + this.createUrl, data);
  }

  public delete(id: string) {
    return this.http.delete(this.baseUrlAdmin + this.deleteUrl + `${id}`);
  }

  public update(data: ICategoryUpdate, id: string) {
    data.id = id;
    return this.http.put(this.baseUrlAdmin + this.updateUrl, data);
  }

  public getCategoryForUpdate(id: string): Observable<ICategoryUpdate> {
    return this.http.get<ICategoryUpdate>(this.baseUrlAdmin + this.categoryForUpdateUrl + `${id}`);
  }
}
