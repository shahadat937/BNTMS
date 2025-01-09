import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServiceInstructorBiodataListComponent } from './service-instructor-biodata-list.component';

describe('ServiceInstructorBiodataListComponent', () => {
  let component: ServiceInstructorBiodataListComponent;
  let fixture: ComponentFixture<ServiceInstructorBiodataListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServiceInstructorBiodataListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServiceInstructorBiodataListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
