import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { Observable } from 'rxjs';
import { RecipesService } from '../../../core/services/recipes.service';
import IBaseRecipe from '../../shared/models/recipes/IBaseRecipe';

@Component({
  selector: 'app-recipe-order-result',
  templateUrl: './recipe-order-result.component.html',
  styleUrls: ['./recipe-order-result.component.css']
})
export class RecipeOrderResultComponent implements OnInit {
  public orderedRecipes$: Observable<Array<IBaseRecipe>>;
  public orderCriteria: string;

  constructor(
    private route: ActivatedRoute,
    private recipesService: RecipesService
  ) { }

  ngOnInit() {
    this.route.queryParams.subscribe((params: Params) => {
      const criteria: string = params['criteria'];
      this.orderedRecipes$ = this.recipesService.order(criteria);
      this.orderCriteria = criteria;
    });
  }
}
