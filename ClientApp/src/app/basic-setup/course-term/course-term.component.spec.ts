import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseTermComponent } from './course-term.component';

describe('CourseTermComponent', () => {
  let component: CourseTermComponent;
  let fixture: ComponentFixture<CourseTermComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseTermComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseTermComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
