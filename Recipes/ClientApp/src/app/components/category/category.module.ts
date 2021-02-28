import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { SingleCategoryComponent } from './single-category/single-category.component';
import { RouterModule } from '@angular/router';


@NgModule({
  declarations: [
    AllCategoriesComponent,
    SingleCategoryComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'all', component: AllCategoriesComponent },
    ]),
  ]
})
export class CategoryModule { }
