import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriesService } from '../../../core/services/categories/categories.service';
import { RecipesService } from '../../../core/services/recipes/recipes.service';

const TITLE_MIN_LEN = 3;
const TITLE_MAX_LEN = 50;
const CONTENT_MIN_LEN = 3;
const CONTENT_MAX_LEN = 5000;
const PORTION_MIN = 1;
const PREP_MIN = 1;
const COOK_MIN = 1;

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent implements OnInit {
  public createForm: FormGroup;
  public ingredientsCount = 1;
  public categories$: Observable<Array<string>>;

  constructor(
    private fb: FormBuilder,
    private recipesService: RecipesService,
    private categoriesService: CategoriesService,
    private router: Router
  ) { }

  ngOnInit() {
    this.buildForm();
    this.categories$ = this.categoriesService.getAllNames();
  }

  public create(): void {
    if (this.createForm.invalid) {
      return;
    }

    this.recipesService.create(this.createForm.value).subscribe((_) => {
      this.router.navigate(['/recipe/all']);
    });
  }

  public get f() {
    return this.createForm.controls;
  }

  public get ingredients(): FormGroup {
    return this.createForm.get('ingredients') as FormGroup;
  }

  public addIngredient() {
    const currentFormValue = this.createForm.value;
    this.ingredientsCount++;
    this.buildForm();
    this.createForm.patchValue(currentFormValue);
  }

  private buildForm(): void {
    this.createForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(TITLE_MIN_LEN), Validators.maxLength(TITLE_MAX_LEN)]],
      content: ['', [Validators.required, Validators.minLength(CONTENT_MIN_LEN), Validators.maxLength(CONTENT_MAX_LEN)]],
      picture: ['', [Validators.required]],
      portions: ['', [Validators.required, Validators.min(PORTION_MIN)]],
      preparationTime: ['', [Validators.required, Validators.min(PREP_MIN)]],
      cookingTime: ['', [Validators.required, Validators.min(COOK_MIN)]],
      categoryName: ['', [Validators.required]],
      ingredients: this.fb.array(
        new Array(this.ingredientsCount).fill(null).map((_, index) => (this.fb.group({
          name: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
          quantity: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]]
        })))
      )
    });
  }
}
