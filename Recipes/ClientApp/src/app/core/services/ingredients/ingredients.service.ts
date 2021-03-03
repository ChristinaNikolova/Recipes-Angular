import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import ICreateIngredient from '../../../components/shared/models/ingredients/ICreateIngredient';
import IIngredientAdmin from '../../../components/shared/models/ingredients/IIngredientAdmin';
import IRecipeIngredientUpdate from '../../../components/shared/models/ingredients/IRecipeIngredientUpdate';
import IUpdateIngredient from '../../../components/shared/models/ingredients/IUpdateIngredient';

@Injectable({
  providedIn: 'root'
})
export class IngredientsService {
  private readonly baseUrl = 'https://localhost:44309/api/ingredients/';
  private readonly baseUrlAdmin = 'https://localhost:44309/api/admin/ingredients/';
  private readonly getByRecipeUrl = 'getByRecipe/';
  private readonly getAllUrl = 'all';
  private readonly createUrl = 'create';
  private readonly updateUrl = 'update/';
  private readonly deleteUrl = 'delete'
  private readonly deleteFromAdminUrl = 'delete/'
  private readonly getIngredientForUpdateURL = 'ingredientForUpdate/'

  constructor(
    private http: HttpClient
  ) { }

  public getByRecipe(recipeId: string): Observable<Array<IRecipeIngredientUpdate>> {
    return this.http.get<Array<IRecipeIngredientUpdate>>(this.baseUrl + this.getByRecipeUrl + `${recipeId}`);
  }

  public getAll(): Observable<Array<IIngredientAdmin>> {
    return this.http.get<Array<IIngredientAdmin>>(this.baseUrlAdmin + this.getAllUrl);
  }

  public getIngredientForUpdate(id: string): Observable<IUpdateIngredient> {
    return this.http.get<IUpdateIngredient>(this.baseUrlAdmin + this.getIngredientForUpdateURL + `${id}`);
  }

  public create(data: ICreateIngredient) {
    return this.http.post(this.baseUrlAdmin + this.createUrl, data);
  }

  public delete(ingredientId: string, recipeId: string) {
    return this.http.delete(this.baseUrl + this.deleteUrl + `?ingredientId=${ingredientId}&recipeId=${recipeId}`);
  }

  public deleteFromAdmin(id: string) {
    return this.http.delete(this.baseUrlAdmin + this.deleteFromAdminUrl + `${id}`);
  }

  public update(data: IUpdateIngredient, id: string) {
    data.id = id;
    return this.http.put(this.baseUrlAdmin + this.updateUrl, data);
  }
}
