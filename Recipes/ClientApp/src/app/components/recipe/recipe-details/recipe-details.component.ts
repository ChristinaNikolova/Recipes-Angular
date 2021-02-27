import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipesService } from '../../../core/services/recipes.service';

import IRecipe from '../../shared/models/IRecipe';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  public recipe: IRecipe;

  constructor(
    private recipesService: RecipesService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.params.subscribe((data) => {
      const id: string = data['id'];
      console.log(id);
      this.recipesService.getDetails(id).subscribe((data) => {
        this.recipe = data;
      })
    });
  }
}
