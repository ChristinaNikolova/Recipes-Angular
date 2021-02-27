import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { AllRecipesComponent } from './all-recipes/all-recipes.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { CategoriesService } from '../../core/services/categories.service';
import { SingleRecipeComponent } from './single-recipe/single-recipe.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { ToastrModule } from 'ngx-toastr';
import { RecipeDetailsResolver } from '../../core/resolvers/recipe-details.resolver';

@NgModule({
  declarations: [
    CreateRecipeComponent,
    AllRecipesComponent,
    SingleRecipeComponent,
    RecipeDetailsComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'all', component: AllRecipesComponent },
      { path: 'create', component: CreateRecipeComponent },
      { path: 'details/:id', component: RecipeDetailsComponent, resolve: { singleRecipe: RecipeDetailsResolver } }
    ]),
  ],
  providers: [
    CategoriesService
  ]
})
export class RecipeModule { }
