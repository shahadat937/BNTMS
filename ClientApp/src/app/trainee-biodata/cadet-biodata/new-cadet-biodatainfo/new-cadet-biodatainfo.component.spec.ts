import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewCadetBiodatainfoComponent } from './new-cadet-biodatainfo.component';

describe('NewCadetBiodatainfoComponent', () => {
  let component: NewCadetBiodatainfoComponent;
  let fixture: ComponentFixture<NewCadetBiodatainfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewCadetBiodatainfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewCadetBiodatainfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
