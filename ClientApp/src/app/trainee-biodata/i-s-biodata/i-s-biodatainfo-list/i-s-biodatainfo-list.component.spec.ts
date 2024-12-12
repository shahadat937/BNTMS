import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ISBiodatainfoListComponent } from './i-s-biodatainfo-list.component';

describe('ISBiodatainfoListComponent', () => {
  let component: ISBiodatainfoListComponent;
  let fixture: ComponentFixture<ISBiodatainfoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ISBiodatainfoListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ISBiodatainfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
