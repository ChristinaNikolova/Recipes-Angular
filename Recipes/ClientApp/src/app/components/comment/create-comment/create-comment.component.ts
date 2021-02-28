import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CommentsService } from '../../../core/services/comments.service';

@Component({
  selector: 'app-create-comment',
  templateUrl: './create-comment.component.html',
  styleUrls: ['./create-comment.component.css']
})
export class CreateCommentComponent implements OnInit {
  @Input() recipeId: string;
  public form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private commentsService: CommentsService,
    private router: Router
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      content: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(500)]]
    });
  }

  public create(): void {
    this.commentsService.create(this.form.value, this.recipeId).subscribe((_) => {
      this.router.navigate([`/recipe/details/${this.recipeId}`]);
    });
  }

  public get f() {
    return this.form.controls;
  }
}
