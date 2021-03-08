import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CategoriesService } from '../../../core/services/categories/categories.service';
import ICategoryUpdate from '../../shared/models/categories/ICategoryUpdate';

const NAME_MIN_LEN = 3;
const NAME_MAX_LEN = 50;

@Component({
  selector: 'app-category-update',
  templateUrl: './category-update.component.html',
  styleUrls: ['./category-update.component.css']
})
export class CategoryUpdateComponent implements OnInit {
  public updateForm: FormGroup;
  public id: string;
  public category: ICategoryUpdate;

  constructor(
    private route: ActivatedRoute,
    private fb: FormBuilder,
    private router: Router,
    private categoriesService: CategoriesService
  ) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id');
    this.category = this.route.snapshot.data['singleCategory'];

    this.updateForm = this.fb.group({
      name: [this.category.name, [Validators.required, Validators.minLength(NAME_MIN_LEN), Validators.maxLength(NAME_MAX_LEN)]],
      picture: [this.category.picture, [Validators.required]]
    });
  }

  public update(): void {
    if (this.updateForm.invalid) {
      return;
    }

    this.categoriesService.update(this.updateForm.value, this.id).subscribe((_) => {
      this.router.navigate(['/admin/category/all']);
    });
  }

  public get f() {
    return this.updateForm.controls;
  }
}
