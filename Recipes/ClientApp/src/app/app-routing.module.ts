import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/shared/not-found/not-found.component';
import { AdminGuard } from './core/guards/admin.guard';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'home' },
  { path: 'home', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'category', loadChildren: './components/category/category.module#CategoryModule' },
  { path: 'recipe', loadChildren: './components/recipe/recipe.module#RecipeModule', canActivate: [AuthGuard]},
  { path: 'comment', loadChildren: './components/comment/comment.module#CommentModule', canActivate: [AuthGuard] },
  { path: 'user', loadChildren: './components/user/user.module#UserModule', canActivate: [AuthGuard] },
  { path: 'admin', loadChildren: './components/admin/admin.module#AdminModule', canActivate: [AdminGuard] },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
