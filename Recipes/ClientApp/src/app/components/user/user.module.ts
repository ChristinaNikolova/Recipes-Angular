import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserFavouriteRecipesComponent } from './user-favourite-recipes/user-favourite-recipes.component';
import { UserOwnRecipesComponent } from './user-own-recipes/user-own-recipes.component';
import { UserFavouriteSingleRecipeComponent } from './user-favourite-single-recipe/user-favourite-single-recipe.component';
import { UserOwnSingleRecipeComponent } from './user-own-single-recipe/user-own-single-recipe.component';
import { RouterModule } from '@angular/router';
import { UsersService } from '../../core/services/users/users.service';

@NgModule({
  declarations: [
    UserFavouriteRecipesComponent,
    UserOwnRecipesComponent,
    UserFavouriteSingleRecipeComponent,
    UserOwnSingleRecipeComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'own', component: UserOwnRecipesComponent },
      { path: 'favourite', component: UserFavouriteRecipesComponent },
    ]),
  ],
  providers: [
    UsersService
  ]
})
export class UserModule { }
