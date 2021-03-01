import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CommentsService } from '../../../core/services/comments.service';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {
  @Input() recipeId: string;
  @Output() postCommentEmitter = new EventEmitter<void>();
  public form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private commentsService: CommentsService,
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      content: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]]
    });
  }

  public create(): void {
    this.commentsService.create(this.form.value, this.recipeId).subscribe((_) => {
      this.form.reset();
      this.postCommentEmitter.emit();
    });
  }

  public get f() {
    return this.form.controls;
  }
}
