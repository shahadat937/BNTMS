import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CentralExamRoutineComponent } from './central-exam-routine.component';

describe('CentralExamRoutineComponent', () => {
  let component: CentralExamRoutineComponent;
  let fixture: ComponentFixture<CentralExamRoutineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CentralExamRoutineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CentralExamRoutineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
