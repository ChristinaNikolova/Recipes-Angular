import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import IRecipeIngredientUpdate from '../../../components/shared/models/ingredients/IRecipeIngredientUpdate';

@Injectable({
  providedIn: 'root'
})
export class IngredientsService {
  private readonly baseUrl = 'https://localhost:44309/api/ingredients/';
  private readonly getByRecipeUrl = 'getByRecipe/';
  private readonly deleteUrl = 'delete'

  constructor(
    private http: HttpClient
  ) { }

  public getByRecipe(recipeId: string): Observable<Array<IRecipeIngredientUpdate>> {
    return this.http.get<Array<IRecipeIngredientUpdate>>(this.baseUrl + this.getByRecipeUrl + `${recipeId}`);
  }

  public delete(ingredientId: string, recipeId: string) {
    return this.http.delete(this.baseUrl + this.deleteUrl + `?ingredientId=${ingredientId}&recipeId=${recipeId}`);
  }
}
