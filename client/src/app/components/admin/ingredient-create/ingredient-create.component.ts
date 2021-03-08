import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';

const NAME_MIN_LEN = 3;
const NAME_MAX_LEN = 50;

@Component({
  selector: 'app-ingredient-create',
  templateUrl: './ingredient-create.component.html',
  styleUrls: ['./ingredient-create.component.css']
})
export class IngredientCreateComponent implements OnInit {
  public createForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private ingredientsService: IngredientsService,
    private router: Router
  ) { }

  ngOnInit() {
    this.createForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(NAME_MIN_LEN), Validators.maxLength(NAME_MAX_LEN)]],
    });
  }

  public create(): void {
    if (this.createForm.invalid) {
      return;
    }

    this.ingredientsService.create(this.createForm.value).subscribe((_) => {
      this.router.navigate(['/admin/ingredient/all']);
    });
  }

  public get f() {
    return this.createForm.controls;
  }
}
