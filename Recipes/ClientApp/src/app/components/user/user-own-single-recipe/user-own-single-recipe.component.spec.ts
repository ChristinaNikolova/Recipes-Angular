import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOwnSingleRecipeComponent } from './user-own-single-recipe.component';

describe('UserOwnSingleRecipeComponent', () => {
  let component: UserOwnSingleRecipeComponent;
  let fixture: ComponentFixture<UserOwnSingleRecipeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserOwnSingleRecipeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOwnSingleRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
