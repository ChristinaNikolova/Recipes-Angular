import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import IUpdateIngredient from "../../components/shared/models/ingredients/IUpdateIngredient";
import { IngredientsService } from "../services/ingredients/ingredients.service";

@Injectable({
  providedIn: 'root'
})
export class IngredientUpdateResolver implements Resolve<IUpdateIngredient> {

  constructor(
    private ingredientsService: IngredientsService
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IUpdateIngredient> {
    const id: string = route.params['id'];

    return this.ingredientsService.getIngredientForUpdate(id);
  }
}
