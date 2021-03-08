import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IngredientsService } from '../../../core/services/ingredients/ingredients.service';
import IUpdateIngredient from '../../shared/models/ingredients/IUpdateIngredient';

const NAME_MIN_LEN = 3;
const NAME_MAX_LEN = 50;

@Component({
  selector: 'app-ingredient-update',
  templateUrl: './ingredient-update.component.html',
  styleUrls: ['./ingredient-update.component.css']
})
export class IngredientUpdateComponent implements OnInit {
  public updateForm: FormGroup;
  public id: string;
  public ingredient: IUpdateIngredient;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private ingredientsService: IngredientsService
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.ingredient = this.route.snapshot.data['singleIngredient'];

    this.updateForm = this.fb.group({
      name: [this.ingredient.name, [Validators.required, Validators.minLength(NAME_MIN_LEN), Validators.maxLength(NAME_MAX_LEN)]],
    });
  }

  public update(): void {
    if (this.updateForm.invalid) {
      return;
    }

    this.ingredientsService.update(this.updateForm.value, this.id).subscribe((_) => {
      this.router.navigate(['/admin/ingredient/all']);
    });
  }

  public get f() {
    return this.updateForm.controls;
  }
}
