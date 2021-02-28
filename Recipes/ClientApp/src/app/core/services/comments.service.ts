import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import IComment from '../../components/shared/models/comments/IComment';

@Injectable({
  providedIn: 'root'
})
export class CommentsService {
  private readonly baseUrl = 'https://localhost:44309/api/comments/';
  private readonly createUrl = 'create';

  constructor(
    private http: HttpClient
  ) { }

  public create(data: IComment, recipeId: string) {
    data.recipeId = recipeId;
    return this.http.post(this.baseUrl + this.createUrl, data);
  }
}
