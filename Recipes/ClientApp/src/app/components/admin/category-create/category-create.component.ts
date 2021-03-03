import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { CategoriesService } from '../../../core/services/categories/categories.service';

const NAME_MIN_LEN = 3;
const NAME_MAX_LEN = 50;

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrls: ['./category-create.component.css']
})
export class CategoryCreateComponent implements OnInit {
  public createForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private categoriesService: CategoriesService,
    private router: Router
  ) { }

  ngOnInit() {
    this.createForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(NAME_MIN_LEN), Validators.maxLength(NAME_MAX_LEN)]],
      picture: ['', [Validators.required]]
    });
  }

  public create(): void {
    if (this.createForm.invalid) {
      return;
    }

    this.categoriesService.create(this.createForm.value).subscribe((_) => {
      //this.router.navigate(['/categories/all']);
      this.router.navigate(['/home']);
    });
  }

  public get f() {
    return this.createForm.controls;
  }
}
