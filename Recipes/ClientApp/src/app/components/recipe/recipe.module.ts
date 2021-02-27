import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { AllRecipesComponent } from './all-recipes/all-recipes.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoriesService } from '../../core/services/categories.service';



@NgModule({
  declarations: [CreateRecipeComponent, AllRecipesComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'all', component: AllRecipesComponent },
      { path: 'create', component: CreateRecipeComponent }
    ]),
  ],
  providers: [
    CategoriesService
  ]
})
export class RecipeModule { }
