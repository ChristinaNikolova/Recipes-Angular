import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import IFavouriteRecipe from '../../components/shared/models/user/IFavouriteRecipe';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  private readonly baseUrl = 'https://localhost:44309/api/users/';
  private readonly favouriteUrl = 'favourite';

  constructor(
    private http: HttpClient
  ) { }

  public getFavourite(): Observable<Array<IFavouriteRecipe>> {
    return this.http.get<Array<IFavouriteRecipe>>(this.baseUrl + this.favouriteUrl);
  }
}
