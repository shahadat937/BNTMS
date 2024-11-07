import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewOnlineLibraryMetarialComponent } from './new-online-library-metarial.component';

describe('NewOnlineLibraryMetarialComponent', () => {
  let component: NewOnlineLibraryMetarialComponent;
  let fixture: ComponentFixture<NewOnlineLibraryMetarialComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewOnlineLibraryMetarialComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewOnlineLibraryMetarialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
