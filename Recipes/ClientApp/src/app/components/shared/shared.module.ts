import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CommentModule } from '../comment/comment.module';
import { AllCommentsComponent } from '../comment/all-comments/all-comments.component';
import { SingleCommentComponent } from '../comment/single-comment/single-comment.component';
import { CreateCommentComponent } from '../comment/create-comment/create-comment.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    CreateCommentComponent,
    AllCommentsComponent,
    SingleCommentComponent

  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule
  ],
  exports: [
    CommonModule,
    CreateCommentComponent,
    AllCommentsComponent,
    SingleCommentComponent
  ]
})
export class SharedModule { }
