import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AllCategoriesComponent } from './all-categories/all-categories.component';
import { SingleCategoryComponent } from './single-category/single-category.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    AllCategoriesComponent,
    SingleCategoryComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'all', component: AllCategoriesComponent },
    ]),
  ]
})
export class CategoryModule { }
