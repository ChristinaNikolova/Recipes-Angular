import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CategoriesService } from '../../../core/services/categories/categories.service';
import ICategoryAdmin from '../../shared/models/categories/ICategoryAdmin';

@Component({
  selector: '[app-category-single]',
  templateUrl: './category-single.component.html',
  styleUrls: ['./category-single.component.css']
})
export class CategorySingleComponent implements OnInit {
  @Input() category: ICategoryAdmin;
  @Output() reloadEventEmitter = new EventEmitter<void>();

  constructor(
    private categoriesService: CategoriesService
  ) { }

  ngOnInit() {
  }

  public remove(id: string) {
    this.categoriesService.delete(id).subscribe((_) => {
      this.reloadEventEmitter.emit();
    });
  }
}
