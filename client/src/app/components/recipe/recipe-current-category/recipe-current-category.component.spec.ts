import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecipeCurrentCategoryComponent } from './recipe-current-category.component';

describe('RecipeCurrentCategoryComponent', () => {
  let component: RecipeCurrentCategoryComponent;
  let fixture: ComponentFixture<RecipeCurrentCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecipeCurrentCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecipeCurrentCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
