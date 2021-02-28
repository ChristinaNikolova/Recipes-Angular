import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentsService } from '../../core/services/comments.service';

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    CommentsService
  ]
})
export class CommentModule { }
