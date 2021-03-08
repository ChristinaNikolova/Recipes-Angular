import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserFavouriteSingleRecipeComponent } from './user-favourite-single-recipe.component';

describe('UserFavouriteSingleRecipeComponent', () => {
  let component: UserFavouriteSingleRecipeComponent;
  let fixture: ComponentFixture<UserFavouriteSingleRecipeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserFavouriteSingleRecipeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserFavouriteSingleRecipeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
