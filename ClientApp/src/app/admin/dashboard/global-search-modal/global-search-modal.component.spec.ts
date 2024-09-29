import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GlobalSearchModalComponent } from './global-search-modal.component';

describe('GlobalSearchModalComponent', () => {
  let component: GlobalSearchModalComponent;
  let fixture: ComponentFixture<GlobalSearchModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GlobalSearchModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GlobalSearchModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
