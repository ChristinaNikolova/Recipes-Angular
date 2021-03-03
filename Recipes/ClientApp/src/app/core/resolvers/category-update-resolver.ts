import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";
import ICategoryUpdate from "../../components/shared/models/categories/ICategoryUpdate";
import { CategoriesService } from "../services/categories/categories.service";

@Injectable({
  providedIn: 'root'
})
export class CategoryUpdateResolver implements Resolve<ICategoryUpdate> {

  constructor(
    private categoriesService: CategoriesService
  ) { }

  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<ICategoryUpdate> {
    const id: string = route.params['id'];

    return this.categoriesService.getCategoryForUpdate(id);
  }
}
