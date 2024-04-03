import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBnaClassattendanceComponent } from './add-bna-classattendance.component';

describe('AddBnaClassattendanceComponent', () => {
  let component: AddBnaClassattendanceComponent;
  let fixture: ComponentFixture<AddBnaClassattendanceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBnaClassattendanceComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBnaClassattendanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
