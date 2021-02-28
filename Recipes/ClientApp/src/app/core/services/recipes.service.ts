import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import IBaseRecipe from '../../components/shared/models/recipes/IBaseRecipe';
import IDetailsRecipe from '../../components/shared/models/recipes/IDetailsRecipe';
import IRecipe from '../../components/shared/models/recipes/IRecipe';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
  private readonly baseUrl = 'https://localhost:44309/api/recipes/';
  private readonly createUrl = 'create';
  private readonly allUrl = 'all';
  private readonly getDetailsUrl = 'details/';
  private readonly likeUrl = 'like/';
  private readonly dislikeUrl = 'dislike/';
  private readonly searchUrl = 'search/';

  constructor(
    private http: HttpClient
  ) { }

  public create(data: IRecipe) {
    return this.http.post(this.baseUrl + this.createUrl, data);
  }

  public getAll(): Observable<Array<IBaseRecipe>> {
    return this.http.get<Array<IBaseRecipe>>(this.baseUrl + this.allUrl);
  }

  public getDetails(id: string): Observable<IDetailsRecipe> {
    return this.http.get<IDetailsRecipe>(this.baseUrl + this.getDetailsUrl + `${id}`);
  }

  public like(id: string) {
    return this.http.post(this.baseUrl + this.likeUrl + `${id}`, {});
  }

  public dislike(id: string) {
    return this.http.post(this.baseUrl + this.dislikeUrl + `${id}`, {});
  }

  public search(query: string): Observable<Array<IBaseRecipe>> {
    return this.http.get<Array<IBaseRecipe>>(this.baseUrl + this.searchUrl + `${query}`)
  }
}
