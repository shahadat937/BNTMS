import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewBnaclassroutinesecondpartComponent } from './new-bnaclassroutinesecondpart.component';

describe('NewBnaclassroutinesecondpartComponent', () => {
  let component: NewBnaclassroutinesecondpartComponent;
  let fixture: ComponentFixture<NewBnaclassroutinesecondpartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NewBnaclassroutinesecondpartComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(NewBnaclassroutinesecondpartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
