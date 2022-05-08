import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { TestBed, async, ComponentFixture } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        AppComponent
      ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA]
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should add user when addUser is called', () => {
    component.users = [0, 1, 2];
    component.addUser();
    expect(component.users.length).toEqual(4);
  });

  it('should remove user when RemoveUser is called', () => {
    const expected = [0, 1, 3];
    component.users = [0, 1, 2, 3];
    component.removeUser(2);
    expect(component.users).toEqual(expected);
  });

  it('should not remove a user below the min user limit', () => {
    component.minUsers = 3
    const expected = [0, 1, 2];
    component.users = [0, 1, 2];
    component.removeUser(2);
    expect(component.users).toEqual(expected);
  });

  it('should not add a user above the max user limit', () => {
    component.maxUsers = 5
    const expected = [0, 1, 2, 3, 4];
    component.users = [0, 1, 2, 3, 4];
    component.addUser();
    expect(component.users).toEqual(expected);
  });
});
