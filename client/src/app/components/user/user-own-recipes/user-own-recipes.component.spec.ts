import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UserOwnRecipesComponent } from './user-own-recipes.component';

describe('UserOwnRecipesComponent', () => {
  let component: UserOwnRecipesComponent;
  let fixture: ComponentFixture<UserOwnRecipesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UserOwnRecipesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UserOwnRecipesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
