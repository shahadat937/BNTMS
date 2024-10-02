import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchedCourseDetailComponent } from './searched-course-detail.component';

describe('SearchedCourseDetailComponent', () => {
  let component: SearchedCourseDetailComponent;
  let fixture: ComponentFixture<SearchedCourseDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchedCourseDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchedCourseDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
