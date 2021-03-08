import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { UsersService } from '../../../core/services/users/users.service';
import IOwnRecipe from '../../shared/models/user/IOwnRecipe';

@Component({
  selector: 'app-user-own-recipes',
  templateUrl: './user-own-recipes.component.html',
  styleUrls: ['./user-own-recipes.component.css']
})
export class UserOwnRecipesComponent implements OnInit {
  ownRecipes$: Observable<Array<IOwnRecipe>>;

  constructor(
    private usersService: UsersService
  ) { }

  ngOnInit() {
    this.reload();
  }

  public reload(): void {
    this.ownRecipes$ = this.usersService.getOwn();
  }
}
