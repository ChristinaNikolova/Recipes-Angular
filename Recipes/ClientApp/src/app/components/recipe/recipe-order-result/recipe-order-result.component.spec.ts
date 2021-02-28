import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeOrderResultComponent } from './recipe-order-result.component';

describe('RecipeOrderResultComponent', () => {
  let component: RecipeOrderResultComponent;
  let fixture: ComponentFixture<RecipeOrderResultComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeOrderResultComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeOrderResultComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
