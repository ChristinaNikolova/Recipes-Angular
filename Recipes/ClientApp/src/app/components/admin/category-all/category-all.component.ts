import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesService } from '../../../core/services/categories/categories.service';
import ICategoryAdmin from '../../shared/models/categories/ICategoryAdmin';

@Component({
  selector: 'app-category-all',
  templateUrl: './category-all.component.html',
  styleUrls: ['./category-all.component.css']
})
export class CategoryAllComponent implements OnInit {
  public categories$: Observable<Array<ICategoryAdmin>>;

  constructor(
    private categoriesService: CategoriesService
  ) { }

  ngOnInit() {
    this.reload();
  }

  public reload(): void {
    this.categories$ = this.categoriesService.getAllForAdmin();
  }
}
