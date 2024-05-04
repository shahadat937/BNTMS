import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBnaabsentreexammarkComponent } from './add-bnaabsentreexammark.component';

describe('AddBnaabsentreexammarkComponent', () => {
  let component: AddBnaabsentreexammarkComponent;
  let fixture: ComponentFixture<AddBnaabsentreexammarkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBnaabsentreexammarkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBnaabsentreexammarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
