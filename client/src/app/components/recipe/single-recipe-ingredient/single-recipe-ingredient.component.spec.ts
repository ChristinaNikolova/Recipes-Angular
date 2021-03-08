import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SingleRecipeIngredientComponent } from './single-recipe-ingredient.component';

describe('SingleRecipeIngredientComponent', () => {
  let component: SingleRecipeIngredientComponent;
  let fixture: ComponentFixture<SingleRecipeIngredientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SingleRecipeIngredientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SingleRecipeIngredientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
