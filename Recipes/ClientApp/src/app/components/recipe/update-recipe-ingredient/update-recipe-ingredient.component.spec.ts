import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRecipeIngredientComponent } from './update-recipe-ingredient.component';

describe('UpdateRecipeIngredientComponent', () => {
  let component: UpdateRecipeIngredientComponent;
  let fixture: ComponentFixture<UpdateRecipeIngredientComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdateRecipeIngredientComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdateRecipeIngredientComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
