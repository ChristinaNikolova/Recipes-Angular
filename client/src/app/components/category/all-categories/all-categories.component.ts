import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoriesService } from '../../../core/services/categories/categories.service';
import ICategory from '../../shared/models/categories/ICategory';

@Component({
  selector: 'app-all-categories',
  templateUrl: './all-categories.component.html',
  styleUrls: ['./all-categories.component.css']
})
export class AllCategoriesComponent implements OnInit {
  public categories$: Observable<Array<ICategory>>

  constructor(
    private categoriesService: CategoriesService
  ) { }

  ngOnInit() {
    this.categories$ = this.categoriesService.getAll();
  }
}
