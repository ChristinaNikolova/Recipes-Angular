import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { UserFavouriteRecipesComponent } from './components/user/user-favourite-recipes/user-favourite-recipes.component';
import { UserOwnRecipesComponent } from './components/user/user-own-recipes/user-own-recipes.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'recipe', loadChildren: './components/recipe/recipe.module#RecipeModule' }, //can activate
  { path: 'category', loadChildren: './components/category/category.module#CategoryModule' },
  { path: 'comment', loadChildren: './components/comment/comment.module#CommentModule' }, //even remove,
  { path: 'user/own', component: UserOwnRecipesComponent },
  { path: 'user/favourite', component: UserFavouriteRecipesComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
