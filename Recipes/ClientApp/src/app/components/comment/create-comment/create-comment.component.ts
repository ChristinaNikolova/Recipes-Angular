import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommentsService } from '../../../core/services/comments/comments.service';

const CONTENT_MIN_LEN = 3;
const CONTENT_MAX_LEN = 500;

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {
  @Input() recipeId: string;
  @Output() postCommentEmitter = new EventEmitter<void>();
  public createForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private commentsService: CommentsService,
  ) { }

  ngOnInit() {
    this.createForm = this.fb.group({
      content: ['', [Validators.required, Validators.minLength(CONTENT_MIN_LEN), Validators.maxLength(CONTENT_MAX_LEN)]]
    });
  }

  public create(): void {
    this.commentsService.create(this.createForm.value, this.recipeId).subscribe((_) => {
      this.createForm.reset();
      this.postCommentEmitter.emit();
    });
  }

  public get f() {
    return this.createForm.controls;
  }
}
