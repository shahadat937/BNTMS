import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewServiceInstructorBiodataComponent } from './new-service-instructor-biodata.component';

describe('NewServiceInstructorBiodataComponent', () => {
  let component: NewServiceInstructorBiodataComponent;
  let fixture: ComponentFixture<NewServiceInstructorBiodataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewServiceInstructorBiodataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewServiceInstructorBiodataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
