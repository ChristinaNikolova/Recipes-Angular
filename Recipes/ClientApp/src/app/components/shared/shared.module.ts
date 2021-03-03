import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllCommentsComponent } from '../comment/all-comments/all-comments.component';
import { SingleCommentComponent } from '../comment/single-comment/single-comment.component';
import { CreateCommentComponent } from '../comment/create-comment/create-comment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RecipeCurrentCategoryComponent } from '../recipe/recipe-current-category/recipe-current-category.component';
import { SingleRecipeComponent } from '../recipe/single-recipe/single-recipe.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    CreateCommentComponent,
    AllCommentsComponent,
    SingleCommentComponent,
    SingleRecipeComponent,
    RecipeCurrentCategoryComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    CreateCommentComponent,
    AllCommentsComponent,
    SingleCommentComponent,
    SingleRecipeComponent,
    RecipeCurrentCategoryComponent
  ]
})
export class SharedModule { }
