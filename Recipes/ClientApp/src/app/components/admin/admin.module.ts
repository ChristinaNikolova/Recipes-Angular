import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CategoryCreateComponent } from './category-create/category-create.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';



@NgModule({
  declarations: [
    AdminHomeComponent,
    CategoryCreateComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: '', pathMatch: 'full', redirectTo: 'home' },
      { path: 'administration', component: AdminHomeComponent },
      { path: 'category/create', component: CategoryCreateComponent }
    ])
  ]
})
export class AdminModule { }
