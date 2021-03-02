import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { RecipesService } from '../../../core/services/recipes/recipes.service';
import IBaseRecipe from '../../shared/models/recipes/IBaseRecipe';

@Component({
  selector: 'app-recipe-search-results',
  templateUrl: './recipe-search-results.component.html',
  styleUrls: ['./recipe-search-results.component.css']
})
export class RecipeSearchResultsComponent implements OnInit {
  public searchedRecipes$: Observable<Array<IBaseRecipe>>;

  constructor(
    private route: ActivatedRoute,
    private recipesService: RecipesService
  ) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params: Params) => {
      const query: string = params['query'];
      this.searchedRecipes$ = this.recipesService.search(query);
    });
  }
}
