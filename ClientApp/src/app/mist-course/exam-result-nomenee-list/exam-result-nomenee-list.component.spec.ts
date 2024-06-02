import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExamResultNomeneeListComponent } from './exam-result-nomenee-list.component';

describe('ExamResultNomeneeListComponent', () => {
  let component: ExamResultNomeneeListComponent;
  let fixture: ComponentFixture<ExamResultNomeneeListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ExamResultNomeneeListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ExamResultNomeneeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
