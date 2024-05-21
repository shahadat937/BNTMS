import { TestBed } from '@angular/core/testing';

import { CourseTermService } from './course-term.service';

describe('CourseTermService', () => {
  let service: CourseTermService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CourseTermService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
