import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';
import IIngredientAdmin from '../../shared/models/ingredients/IIngredientAdmin';

@Component({
  selector: '[app-ingredient-single]',
  templateUrl: './ingredient-single.component.html',
  styleUrls: ['./ingredient-single.component.css']
})
export class IngredientSingleComponent implements OnInit {
  @Input() ingredient: IIngredientAdmin;
  @Output() reloadEventEmitter = new EventEmitter<void>();

  constructor(
    private ingredientsService: IngredientsService
  ) { }

  ngOnInit() {
  }

  public remove(id: string) {
    this.ingredientsService.deleteFromAdmin(id).subscribe((_) => {
      this.reloadEventEmitter.emit();
    });
  }
}
