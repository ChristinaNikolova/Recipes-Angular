import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';
import IRecipeIngredientUpdate from '../../shared/models/ingredients/IRecipeIngredientUpdate';

@Component({
  selector: '[app-single-recipe-ingredient]',
  templateUrl: './single-recipe-ingredient.component.html',
  styleUrls: ['./single-recipe-ingredient.component.css']
})
export class SingleRecipeIngredientComponent implements OnInit {
  @Input() ingredient: IRecipeIngredientUpdate;
  @Output() reloadEventEmitter = new EventEmitter<void>();

  constructor(
    private ingredientsService: IngredientsService
  ) { }

  ngOnInit() {
  }

  public remove(ingredientId: string, recipeId: string) {
    this.ingredientsService.delete(ingredientId, recipeId).subscribe((_) => {
      this.reloadEventEmitter.emit();
    })
  }
}
