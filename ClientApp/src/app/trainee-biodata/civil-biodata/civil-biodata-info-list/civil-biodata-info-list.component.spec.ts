import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CivilBiodataInfoListComponent } from './civil-biodata-info-list.component';

describe('CivilBiodataInfoListComponent', () => {
  let component: CivilBiodataInfoListComponent;
  let fixture: ComponentFixture<CivilBiodataInfoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CivilBiodataInfoListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CivilBiodataInfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
