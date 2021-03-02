import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';
import IRecipeIngredientUpdate from '../../shared/models/ingredients/IRecipeIngredientUpdate';

@Component({
  selector: 'app-update-recipe-ingredient',
  templateUrl: './update-recipe-ingredient.component.html',
  styleUrls: ['./update-recipe-ingredient.component.css']
})
export class UpdateRecipeIngredientComponent implements OnInit {
  public id: string;
  public ingredients$: Observable<Array<IRecipeIngredientUpdate>>;

  constructor(
    private route: ActivatedRoute,
    private ingredientsService: IngredientsService
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.reload();
  }

  public reload(): void {
    this.ingredients$ = this.ingredientsService.getByRecipe(this.id);
  }
}
