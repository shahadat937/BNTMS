import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BnaexammarkapproveListComponent } from './bnaexammarkapprove-list.component';

describe('BnaexammarkapproveListComponent', () => {
  let component: BnaexammarkapproveListComponent;
  let fixture: ComponentFixture<BnaexammarkapproveListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BnaexammarkapproveListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BnaexammarkapproveListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
