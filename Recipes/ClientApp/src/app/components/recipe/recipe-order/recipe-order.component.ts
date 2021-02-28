import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recipe-order',
  templateUrl: './recipe-order.component.html',
  styleUrls: ['./recipe-order.component.css']
})
export class RecipeOrderComponent implements OnInit {
  public isShown: boolean;
  public criteria: string;

  constructor(
    private router: Router
  ) {
    this.isShown = false;
    this.criteria = '';
  }

  ngOnInit() {
  }

  public toogle() {
    this.isShown = !this.isShown;
  }

  public getOldest(): void {
    this.toogle();
    var criteria = 'old';
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }

  public getNewest(): void {
    this.toogle();
    var criteria = 'new';
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }

  public likes(): void {
    this.toogle();
    var criteria = 'likes';
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }
}
