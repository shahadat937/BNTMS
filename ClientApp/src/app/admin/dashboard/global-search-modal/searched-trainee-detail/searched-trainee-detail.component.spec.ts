import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchedTraineeDetailComponent } from './searched-trainee-detail.component';

describe('SearchedTraineeDetailComponent', () => {
  let component: SearchedTraineeDetailComponent;
  let fixture: ComponentFixture<SearchedTraineeDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchedTraineeDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchedTraineeDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
