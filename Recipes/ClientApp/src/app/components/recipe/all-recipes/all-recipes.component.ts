import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RecipesService } from '../../../core/services/recipes.service';
import IBaseRecipe from '../../shared/models/IBaseRecipe';

@Component({
  selector: 'app-all-recipes',
  templateUrl: './all-recipes.component.html',
  styleUrls: ['./all-recipes.component.css']
})
export class AllRecipesComponent implements OnInit {
  public recipes$: Observable<Array<IBaseRecipe>>;

  constructor(
    private recipesService: RecipesService) { }

  ngOnInit() {
    this.recipes$ = this.recipesService.getAll();
  }
}
