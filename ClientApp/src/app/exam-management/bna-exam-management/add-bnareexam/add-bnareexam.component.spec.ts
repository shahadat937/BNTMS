import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddBnareexamComponent } from './add-bnareexam.component';

describe('AddBnareexamComponent', () => {
  let component: AddBnareexamComponent;
  let fixture: ComponentFixture<AddBnareexamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddBnareexamComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddBnareexamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
