import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewISBiodatainfoComponent } from './new-i-s-biodatainfo.component';

describe('NewISBiodatainfoComponent', () => {
  let component: NewISBiodatainfoComponent;
  let fixture: ComponentFixture<NewISBiodatainfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewISBiodatainfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewISBiodatainfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
