import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipesService } from '../../../core/services/recipes/recipes.service';
import IDetailsRecipe from '../../shared/models/recipes/IDetailsRecipe';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  public recipe: IDetailsRecipe;

  constructor(
    private recipesService: RecipesService,
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.recipe = this.route.snapshot.data['singleRecipe'];
  }

  public like(id: string) {
    this.recipesService.like(id).subscribe((_) => {
      this.recipesService.getDetails(id).subscribe((data) => {
        this.recipe = data;
      });
    });
  }

  public dislike(id: string) {
    this.recipesService.dislike(id).subscribe((_) => {
      this.recipesService.getDetails(id).subscribe((data) => {
        this.recipe = data;
      });
    });
  }
}
