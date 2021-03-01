import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { FooterComponent } from './components/shared/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { JwtInterceptorService } from './core/interceptors/jwt-interceptor.service';
import { ResponseHandlerInterceptorService } from './core/interceptors/response-handler-interceptor.service';
import { LoginComponent } from './components/authentication/login/login.component';
import { RegisterComponent } from './components/authentication/register/register.component';
import { AuthService } from './core/services/auth.service';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RecipesService } from './core/services/recipes.service';
import { RecipeDetailsResolver } from './core/resolvers/recipe-details.resolver';
import { UserFavouriteRecipesComponent } from './components/user/user-favourite-recipes/user-favourite-recipes.component';
import { UserOwnRecipesComponent } from './components/user/user-own-recipes/user-own-recipes.component';
import { UsersService } from './core/services/users.service';
import { UserFavouriteSingleRecipeComponent } from './components/user/user-favourite-single-recipe/user-favourite-single-recipe.component';
import { UserOwnSingleRecipeComponent } from './components/user/user-own-single-recipe/user-own-single-recipe.component';
import { RecipeUpdateResolver } from './core/resolvers/recipe-update.resolver';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    UserFavouriteRecipesComponent,
    UserOwnRecipesComponent,
    UserFavouriteSingleRecipeComponent,
    UserOwnSingleRecipeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    AuthService,
    RecipesService,
    UsersService,
    RecipeDetailsResolver,
    RecipeUpdateResolver,
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ResponseHandlerInterceptorService, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
