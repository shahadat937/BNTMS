import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JsoExamMarkApproveListComponent } from './jso-exam-mark-approve-list.component';

describe('JsoExamMarkApproveListComponent', () => {
  let component: JsoExamMarkApproveListComponent;
  let fixture: ComponentFixture<JsoExamMarkApproveListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ JsoExamMarkApproveListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(JsoExamMarkApproveListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
