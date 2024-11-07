import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnlineLibraryMeterialListComponent } from './online-library-meterial-list.component';

describe('OnlineLibraryMeterialListComponent', () => {
  let component: OnlineLibraryMeterialListComponent;
  let fixture: ComponentFixture<OnlineLibraryMeterialListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OnlineLibraryMeterialListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OnlineLibraryMeterialListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
