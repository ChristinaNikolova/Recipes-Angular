import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';
import IIngredientAdmin from '../../shared/models/ingredients/IIngredientAdmin';

@Component({
  selector: 'app-ingredient-all',
  templateUrl: './ingredient-all.component.html',
  styleUrls: ['./ingredient-all.component.css']
})
export class IngredientAllComponent implements OnInit {
  public ingredients$: Observable<Array<IIngredientAdmin>>;

  constructor(
    private ingredientsService: IngredientsService
  ) { }

  ngOnInit() {
    this.reload();
  }

  public reload(): void {
    this.ingredients$ = this.ingredientsService.getAll();
  }
}
