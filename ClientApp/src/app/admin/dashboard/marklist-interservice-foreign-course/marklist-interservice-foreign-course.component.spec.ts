import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarklistInterserviceForeignCourseComponent } from './marklist-interservice-foreign-course.component';

describe('MarklistInterserviceForeignCourseComponent', () => {
  let component: MarklistInterserviceForeignCourseComponent;
  let fixture: ComponentFixture<MarklistInterserviceForeignCourseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarklistInterserviceForeignCourseComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarklistInterserviceForeignCourseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
