import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CategoryCreateComponent } from './category-create/category-create.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryAllComponent } from './category-all/category-all.component';
import { CategorySingleComponent } from './category-single/category-single.component';
import { CategoryUpdateComponent } from './category-update/category-update.component';
import { CategoryUpdateResolver } from '../../core/resolvers/category-update-resolver';
import { IngredientCreateComponent } from './ingredient-create/ingredient-create.component';
import { IngredientAllComponent } from './ingredient-all/ingredient-all.component';
import { IngredientSingleComponent } from './ingredient-single/ingredient-single.component';
import { IngredientUpdateComponent } from './ingredient-update/ingredient-update.component';

@NgModule({
  declarations: [
    AdminHomeComponent,
    CategoryCreateComponent,
    CategoryAllComponent,
    CategorySingleComponent,
    CategoryUpdateComponent,
    IngredientCreateComponent,
    IngredientAllComponent,
    IngredientSingleComponent,
    IngredientUpdateComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'administration', component: AdminHomeComponent },
      { path: 'category/all', component: CategoryAllComponent },
      { path: 'category/create', component: CategoryCreateComponent },
      { path: 'category/update/:id', component: CategoryUpdateComponent, resolve: { singleCategory: CategoryUpdateResolver } },
      { path: 'ingredient/all', component: IngredientAllComponent },
      { path: 'ingredient/create', component: IngredientCreateComponent },
      //{ path: 'ingredient/update/:id', component: IngredientUpdateComponent, resolve: { singleIngredient: IngredientUpdateResolver } }
    ])
  ],
  providers: [
    CategoryUpdateResolver
  ]
})
export class AdminModule { }
