import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UsersService } from '../../../core/services/users/users.service';
import IFavouriteRecipe from '../../shared/models/user/IFavouriteRecipe';

@Component({
  selector: 'app-user-favourite-recipes',
  templateUrl: './user-favourite-recipes.component.html',
  styleUrls: ['./user-favourite-recipes.component.css']
})
export class UserFavouriteRecipesComponent implements OnInit {
  favouriteRecipes$: Observable<Array<IFavouriteRecipe>>;

  constructor(
    private usersService: UsersService
  ) { }

  ngOnInit() {
    this.reload();
  }

  public reload(): void {
    this.favouriteRecipes$ = this.usersService.getFavourite();
  }
}
