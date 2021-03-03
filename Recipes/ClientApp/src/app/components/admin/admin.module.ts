import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CategoryCreateComponent } from './category-create/category-create.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CategoryAllComponent } from './category-all/category-all.component';
import { CategorySingleComponent } from './category-single/category-single.component';
import { CategoryUpdateComponent } from './category-update/category-update.component';
import { CategoryUpdateResolver } from '../../core/resolvers/category-update-resolver';

@NgModule({
  declarations: [
    AdminHomeComponent,
    CategoryCreateComponent,
    CategoryAllComponent,
    CategorySingleComponent,
    CategoryUpdateComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'administration', component: AdminHomeComponent },
      { path: 'category/all', component: CategoryAllComponent },
      { path: 'category/create', component: CategoryCreateComponent },
      { path: 'category/update/:id', component: CategoryUpdateComponent, resolve: { singleCategory: CategoryUpdateResolver } }
    ])
  ],
  providers: [
    CategoryUpdateResolver
  ]
})
export class AdminModule { }
