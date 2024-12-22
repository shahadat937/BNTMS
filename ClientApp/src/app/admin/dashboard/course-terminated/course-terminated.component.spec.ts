import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseTerminatedComponent } from './course-terminated.component';

describe('CourseTerminatedComponent', () => {
  let component: CourseTerminatedComponent;
  let fixture: ComponentFixture<CourseTerminatedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseTerminatedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseTerminatedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
