import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { AllRecipesComponent } from './all-recipes/all-recipes.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SingleRecipeComponent } from './single-recipe/single-recipe.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { ToastrModule } from 'ngx-toastr';
import { RecipeDetailsResolver } from '../../core/resolvers/recipe-details.resolver';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { RecipeSearchResultsComponent } from './recipe-search-results/recipe-search-results.component';
import { RecipeOrderComponent } from './recipe-order/recipe-order.component';
import { RecipeOrderResultComponent } from './recipe-order-result/recipe-order-result.component';
import { SharedModule } from '../shared/shared.module';
import { UpdateRecipeComponent } from './update-recipe/update-recipe.component';
import { RecipeUpdateResolver } from '../../core/resolvers/recipe-update.resolver';
import { CategoriesService } from '../../core/services/categories/categories.service';
import { UpdateRecipeIngredientComponent } from './update-recipe-ingredient/update-recipe-ingredient.component';
import { SingleRecipeIngredientComponent } from './single-recipe-ingredient/single-recipe-ingredient.component';

@NgModule({
  declarations: [
    CreateRecipeComponent,
    AllRecipesComponent,
    SingleRecipeComponent,
    RecipeDetailsComponent,
    SearchRecipeComponent,
    RecipeSearchResultsComponent,
    RecipeOrderComponent,
    RecipeOrderResultComponent,
    UpdateRecipeComponent,
    UpdateRecipeIngredientComponent,
    SingleRecipeIngredientComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot(),
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'all', component: AllRecipesComponent },
      { path: 'create', component: CreateRecipeComponent },
      { path: 'details/:id', component: RecipeDetailsComponent, resolve: { singleRecipe: RecipeDetailsResolver } },
      { path: 'results', component: RecipeSearchResultsComponent },
      { path: 'orderResults', component: RecipeOrderResultComponent },
      { path: 'update/:id', component: UpdateRecipeComponent, resolve: { singleRecipe: RecipeUpdateResolver } },
      { path: 'ingredients/:id', component: UpdateRecipeIngredientComponent }
    ]),
  ],
  providers: [
    CategoriesService
  ]
})
export class RecipeModule { }
