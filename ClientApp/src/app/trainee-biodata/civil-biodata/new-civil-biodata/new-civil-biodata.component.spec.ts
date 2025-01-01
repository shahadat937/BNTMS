import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCivilBiodataComponent } from './new-civil-biodata.component';

describe('NewCivilBiodataComponent', () => {
  let component: NewCivilBiodataComponent;
  let fixture: ComponentFixture<NewCivilBiodataComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewCivilBiodataComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCivilBiodataComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
