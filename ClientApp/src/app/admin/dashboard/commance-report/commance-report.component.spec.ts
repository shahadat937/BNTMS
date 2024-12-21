import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommanceReportComponent } from './commance-report.component';

describe('CommanceReportComponent', () => {
  let component: CommanceReportComponent;
  let fixture: ComponentFixture<CommanceReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CommanceReportComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CommanceReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
