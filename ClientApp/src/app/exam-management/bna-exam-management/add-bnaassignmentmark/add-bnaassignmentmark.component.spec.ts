import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBnaassignmentmarkComponent } from './add-bnaassignmentmark.component';

describe('AddBnaassignmentmarkComponent', () => {
  let component: AddBnaassignmentmarkComponent;
  let fixture: ComponentFixture<AddBnaassignmentmarkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBnaassignmentmarkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBnaassignmentmarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
