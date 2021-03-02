import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

const CRITERIA_OLD = 'old';
const CRITERIA_NEW = 'new';
const CRITERIA_LIKES_COUNT = 'likes';
const CRITERIA_COMMENTS_COUNT = 'comments';

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
    var criteria = CRITERIA_OLD;
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }

  public getNewest(): void {
    this.toogle();
    var criteria = CRITERIA_NEW;
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }

  public likes(): void {
    this.toogle();
    var criteria = CRITERIA_LIKES_COUNT;
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }

  public comments(): void {
    this.toogle();
    var criteria = CRITERIA_COMMENTS_COUNT;
    this.router.navigate(['/recipe/orderResults'], { queryParams: { criteria } });
  }
}
