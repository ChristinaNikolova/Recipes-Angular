import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { RecipesService } from '../../../core/services/recipes.service';
import IFavouriteRecipe from '../../shared/models/user/IFavouriteRecipe';

@Component({
  selector: '[app-user-favourite-single-recipe-row]',
  templateUrl: './user-favourite-single-recipe.component.html',
  styleUrls: ['./user-favourite-single-recipe.component.css']
})
export class UserFavouriteSingleRecipeComponent implements OnInit {
  @Input() recipe: IFavouriteRecipe;
  @Output() removeFavRecipe = new EventEmitter<void>();

  constructor(
    private recipesService: RecipesService
  ) { }

  ngOnInit() {
  }

  public remove(recipeId: string) {
    this.recipesService.dislike(recipeId).subscribe((_) => {
      this.removeFavRecipe.emit();
    });
  }
}
