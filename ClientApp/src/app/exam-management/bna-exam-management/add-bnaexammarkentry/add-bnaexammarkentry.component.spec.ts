import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBnaexammarkentryComponent } from './add-bnaexammarkentry.component';

describe('AddBnaexammarkentryComponent', () => {
  let component: AddBnaexammarkentryComponent;
  let fixture: ComponentFixture<AddBnaexammarkentryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBnaexammarkentryComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBnaexammarkentryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
