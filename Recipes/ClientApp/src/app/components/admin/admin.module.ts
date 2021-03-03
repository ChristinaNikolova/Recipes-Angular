import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CategoryCreateComponent } from './category-create/category-create.component';



@NgModule({
  declarations: [
    CategoryCreateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'category/create', component: CategoryCreateComponent }
    ])
  ]
})
export class AdminModule { }
