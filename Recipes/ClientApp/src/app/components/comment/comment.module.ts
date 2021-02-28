import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentsService } from '../../core/services/comments.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule
  ],
  providers: [
    CommentsService
  ]
})
export class CommentModule { }
