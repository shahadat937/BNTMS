import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MidbiodatainfoListComponent } from './midbiodatainfo-list.component';

describe('MidbiodatainfoListComponent', () => {
  let component: MidbiodatainfoListComponent;
  let fixture: ComponentFixture<MidbiodatainfoListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MidbiodatainfoListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MidbiodatainfoListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
