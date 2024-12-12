import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewMidbiodatainfoComponent } from './new-midbiodatainfo.component';

describe('NewMidbiodatainfoComponent', () => {
  let component: NewMidbiodatainfoComponent;
  let fixture: ComponentFixture<NewMidbiodatainfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewMidbiodatainfoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewMidbiodatainfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
