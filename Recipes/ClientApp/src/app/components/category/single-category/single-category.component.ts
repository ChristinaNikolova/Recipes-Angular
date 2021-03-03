import { Component, Input, OnInit } from '@angular/core';
import ICategory from '../../shared/models/categories/ICategory';

@Component({
  selector: 'app-single-category',
  templateUrl: './single-category.component.html',
  styleUrls: ['./single-category.component.css']
})
export class SingleCategoryComponent implements OnInit {
  @Input() category: ICategory;

  constructor() { }

  ngOnInit() {
  }
}
