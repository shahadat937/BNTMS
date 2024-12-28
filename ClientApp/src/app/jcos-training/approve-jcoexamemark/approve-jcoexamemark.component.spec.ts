import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveJcoexamemarkComponent } from './approve-jcoexamemark.component';

describe('ApproveJcoexamemarkComponent', () => {
  let component: ApproveJcoexamemarkComponent;
  let fixture: ComponentFixture<ApproveJcoexamemarkComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ApproveJcoexamemarkComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproveJcoexamemarkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
