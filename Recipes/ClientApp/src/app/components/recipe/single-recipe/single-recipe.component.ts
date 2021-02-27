import { Component, Input, OnInit } from '@angular/core';
import IBaseRecipe from '../../shared/models/IBaseRecipe';

@Component({
  selector: 'app-single-recipe',
  templateUrl: './single-recipe.component.html',
  styleUrls: ['./single-recipe.component.css']
})
export class SingleRecipeComponent implements OnInit {
  @Input() recipe: IBaseRecipe;

  constructor() { }

  ngOnInit() {
  }
}
