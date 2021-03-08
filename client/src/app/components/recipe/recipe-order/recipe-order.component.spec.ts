import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeOrderComponent } from './recipe-order.component';

describe('RecipeOrderComponent', () => {
  let component: RecipeOrderComponent;
  let fixture: ComponentFixture<RecipeOrderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeOrderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeOrderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
