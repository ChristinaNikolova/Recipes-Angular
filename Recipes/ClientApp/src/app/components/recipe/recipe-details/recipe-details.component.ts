import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import IDetailsRecipe from '../../shared/models/recipes/IDetailsRecipe';

@Component({
  selector: 'app-recipe-details',
  templateUrl: './recipe-details.component.html',
  styleUrls: ['./recipe-details.component.css']
})
export class RecipeDetailsComponent implements OnInit {
  public recipe: IDetailsRecipe;

  constructor(
    private route: ActivatedRoute
  ) { }

  ngOnInit() {
    this.recipe = this.route.snapshot.data['singleRecipe'];
    console.log(this.recipe);
  }
}
