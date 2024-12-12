import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CadetBiodatainfoListComponent } from './cadet-biodatainfo-list.component';

describe('CadetBiodatainfoListComponent', () => {
  let component: CadetBiodatainfoListComponent;
  let fixture: ComponentFixture<CadetBiodatainfoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CadetBiodatainfoListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CadetBiodatainfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
