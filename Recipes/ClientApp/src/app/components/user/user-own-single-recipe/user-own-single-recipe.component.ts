import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import IOwnRecipe from '../../shared/models/user/IOwnRecipe';

@Component({
  selector: '[app-user-own-single-recipe]',
  templateUrl: './user-own-single-recipe.component.html',
  styleUrls: ['./user-own-single-recipe.component.css']
})
export class UserOwnSingleRecipeComponent implements OnInit {
  @Input() recipe: IOwnRecipe;
  @Output() reloadEventEmitter = new EventEmitter<void>();

  constructor(
    private recipesService: RecipesService
  ) { }

  ngOnInit() {
  }

  public remove(recipeId: string) {
    this.recipesService.delete(recipeId).subscribe((_) => {
      this.reloadEventEmitter.emit();
    });
  }
}
