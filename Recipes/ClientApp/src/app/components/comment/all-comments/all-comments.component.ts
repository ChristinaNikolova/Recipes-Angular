import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CommentsService } from '../../../core/services/comments.service';
import ICommentDetails from '../../shared/models/comments/ICommentDetails';

@Component({
  selector: 'app-all-comments',
  templateUrl: './all-comments.component.html',
  styleUrls: ['./all-comments.component.css']
})
export class AllCommentsComponent implements OnInit {
  @Input() recipeId: string;
  public comments$: Observable<Array<ICommentDetails>>;

  constructor(
    private commentsService: CommentsService
  ) { }

  ngOnInit() {
    this.comments$ = this.commentsService.getAllCurrentRecipe(this.recipeId);
  }
}
