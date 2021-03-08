import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserFavouriteRecipesComponent } from './user-favourite-recipes.component';

describe('UserFavouriteRecipesComponent', () => {
  let component: UserFavouriteRecipesComponent;
  let fixture: ComponentFixture<UserFavouriteRecipesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserFavouriteRecipesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserFavouriteRecipesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
