import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import IDetailsRecipe from "../../components/shared/models/recipes/IDetailsRecipe";
import { RecipesService } from "../services/recipes.service";

@Injectable({
  providedIn: 'root'
})
export class RecipeDetailsResolver implements Resolve<IDetailsRecipe> {

  constructor(private recipesService: RecipesService) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IDetailsRecipe> {
    const id: string = route.params['id'];

    return this.recipesService.getDetails(id);
  }
}
