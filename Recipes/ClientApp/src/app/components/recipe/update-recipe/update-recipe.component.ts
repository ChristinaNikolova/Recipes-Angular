import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { CategoriesService } from '../../../core/services/categories.service';
import { RecipesService } from '../../../core/services/recipes.service';
import IUpdateRecipe from '../../shared/models/recipes/IUpdateRecipe';

@Component({
  selector: 'app-update-recipe',
  templateUrl: './update-recipe.component.html',
  styleUrls: ['./update-recipe.component.css']
})
export class UpdateRecipeComponent implements OnInit {
  public categories$: Observable<Array<string>>;
  public form: FormGroup;
  public id: string;
  public recipe: IUpdateRecipe;

  constructor(
    private fb: FormBuilder,
    private categoriesService: CategoriesService,
    private recipesService: RecipesService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.recipe = this.route.snapshot.data['singleRecipe'];
    this.categories$ = this.categoriesService.getAllNames();

    this.form = this.fb.group({
      title: [this.recipe.title, [Validators.required, Validators.minLength(3), Validators.maxLength(50)]],
      content: [this.recipe.content, [Validators.required, Validators.minLength(3), Validators.maxLength(5000)]],
      picture: [this.recipe.picture, [Validators.required]],
      portions: [this.recipe.portions, [Validators.required, Validators.min(1)]],
      preparationTime: [this.recipe.preparationTime, [Validators.required, Validators.min(1)]],
      cookingTime: [this.recipe.cookingTime, [Validators.required, Validators.min(1)]],
      categoryName: [this.recipe.categoryName, [Validators.required]]
    });
  }

  public update(): void {
    if (this.form.invalid) {
      return;
    }

    this.recipesService.update(this.form.value, this.id).subscribe((_) => {
      this.router.navigate([`/recipe/details/${this.id}`]);
    });
  }

  public get f() {
    return this.form.controls;
  }
}
