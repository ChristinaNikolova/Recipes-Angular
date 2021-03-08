import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IngredientAllComponent } from './ingredient-all.component';

describe('IngredientAllComponent', () => {
  let component: IngredientAllComponent;
  let fixture: ComponentFixture<IngredientAllComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IngredientAllComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IngredientAllComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
