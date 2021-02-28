import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateRecipeComponent } from './create-recipe/create-recipe.component';
import { AllRecipesComponent } from './all-recipes/all-recipes.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoriesService } from '../../core/services/categories.service';
import { SingleRecipeComponent } from './single-recipe/single-recipe.component';
import { RecipeDetailsComponent } from './recipe-details/recipe-details.component';
import { ToastrModule } from 'ngx-toastr';
import { RecipeDetailsResolver } from '../../core/resolvers/recipe-details.resolver';
import { SearchRecipeComponent } from './search-recipe/search-recipe.component';
import { RecipeSearchResultsComponent } from './recipe-search-results/recipe-search-results.component';
import { RecipeOrderComponent } from './recipe-order/recipe-order.component';
import { RecipeOrderResultComponent } from './recipe-order-result/recipe-order-result.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    CreateRecipeComponent,
    AllRecipesComponent,
    SingleRecipeComponent,
    RecipeDetailsComponent,
    SearchRecipeComponent,
    RecipeSearchResultsComponent,
    RecipeOrderComponent,
    RecipeOrderResultComponent
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
      { path: 'orderResults', component: RecipeOrderResultComponent }
    ]),
  ],
  providers: [
    CategoriesService]
})
export class RecipeModule { }
