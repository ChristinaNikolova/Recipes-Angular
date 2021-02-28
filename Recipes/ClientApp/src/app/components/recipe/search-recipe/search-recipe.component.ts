import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-search-recipe',
  templateUrl: './search-recipe.component.html',
  styleUrls: ['./search-recipe.component.css']
})
export class SearchRecipeComponent implements OnInit {
  public form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.form = this.fb.group({
      search: ['', [Validators.required, Validators.minLength(3)]]
    });
  }

  public search() {
    const query: string = this.form.value.search;
    this.clearSearchForm();
    this.router.navigate(['/recipe/results'], { queryParams: { query } });
  }

  public get f() {
    return this.form.controls;
  }

  public clear(): void {
    this.clearSearchForm();
    this.router.navigate(['/recipe/all']);
  }

  private clearSearchForm() {
    this.form.reset();
  }
}
