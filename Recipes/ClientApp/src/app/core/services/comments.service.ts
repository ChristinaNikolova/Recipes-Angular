import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import IComment from '../../components/shared/models/comments/IComment';
import ICommentDetails from '../../components/shared/models/comments/ICommentDetails';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private readonly baseUrl = 'https://localhost:44309/api/comments/';
  private readonly createUrl = 'create';
  private readonly getAllCurrentRecipeUrl = 'all/';

  constructor(
    private http: HttpClient
  ) { }

  public create(data: IComment, recipeId: string) {
    data.recipeId = recipeId;
    return this.http.post(this.baseUrl + this.createUrl, data);
  }

  public getAllCurrentRecipe(recipeId: string): Observable<Array<ICommentDetails>> {
    return this.http.get<Array<ICommentDetails>>(this.baseUrl + this.getAllCurrentRecipeUrl + `${recipeId}`);
  }
}
