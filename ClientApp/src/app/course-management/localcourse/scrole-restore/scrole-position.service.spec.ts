import { TestBed } from '@angular/core/testing';

import { ScrolePositionService } from './scrole-position.service';

describe('ScrolePositionService', () => {
  let service: ScrolePositionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ScrolePositionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
