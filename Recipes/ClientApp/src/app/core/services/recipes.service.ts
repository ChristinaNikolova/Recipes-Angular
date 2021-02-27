import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IRecipe from '../../components/shared/models/IRecipe';

@Injectable({
  providedIn: 'root'
})
export class RecipesService {
 private readonly baseUrl = 'https://localhost:44309/api/recipes/';
 private readonly createUrl = 'create';

  constructor(
    private http: HttpClient
  ) { }

  public create(data: IRecipe) {
    return this.http.post(this.baseUrl + this.createUrl, data);
  }
}
