import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { RecipesService } from '../../../core/services/recipes/recipes.service';
import IBaseRecipe from '../../shared/models/recipes/IBaseRecipe';

@Component({
  selector: 'app-recipe-current-category',
  templateUrl: './recipe-current-category.component.html',
  styleUrls: ['./recipe-current-category.component.css']
})
export class RecipeCurrentCategoryComponent implements OnInit {
  public categoryId: string;
  public recipes$: Observable<Array<IBaseRecipe>>;

  constructor(
    private route: ActivatedRoute,
    private recipesService: RecipesService
  ) { }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.categoryId = params['id'];
      this.recipes$ = this.recipesService.getByCategory(this.categoryId);
    });
  }
}
