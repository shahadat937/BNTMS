import { TestBed } from '@angular/core/testing';

import { OnlinelibraryService } from './onlinelibrary.service';

describe('OnlinelibraryService', () => {
  let service: OnlinelibraryService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(OnlinelibraryService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
