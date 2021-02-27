import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriesService } from '../../../core/services/categories.service';
import { RecipesService } from '../../../core/services/recipes.service';

@Component({
  selector: 'app-create-recipe',
  templateUrl: './create-recipe.component.html',
  styleUrls: ['./create-recipe.component.css']
})
export class CreateRecipeComponent implements OnInit {
  public form: FormGroup;
  public categories$: Observable<Array<string>>;

  constructor(
    private fb: FormBuilder,
    private recipesService: RecipesService,
    private categoriesService: CategoriesService,
    private router: Router
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      content: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(5000)]],
      picture: ['', [Validators.required]],
      portions: ['', [Validators.required, Validators.min(1)]],
      preparationTime: ['', [Validators.required, Validators.min(1)]],
      cookingTime: ['', [Validators.required, Validators.min(1)]],
      categoryName: ['', [Validators.required]]
    });
    
    this.categories$ = this.categoriesService.getAllNames();
  }

  public create(): void {
    this.recipesService.create(this.form.value).subscribe((data) => {
      this.router.navigate(['/recipe/all']);
    });
  }

  public get f() {
    return this.form.controls;
  }
}
