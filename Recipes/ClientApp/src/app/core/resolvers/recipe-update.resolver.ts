import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import IUpdateRecipe from "../../components/shared/models/recipes/IUpdateRecipe";
import { RecipesService } from "../services/recipes/recipes.service";


@Injectable({
  providedIn: 'root'
})
export class RecipeUpdateResolver implements Resolve<IUpdateRecipe> {

  constructor(
    private recipesService: RecipesService
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IUpdateRecipe> {
    const id: string = route.params['id'];

    return this.recipesService.getRecipeForUpdate(id);
  }
}
