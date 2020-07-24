import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeWorkingStatusComponent } from './employee-working-status.component';

describe('EmployeeWorkingStatusComponent', () => {
  let component: EmployeeWorkingStatusComponent;
  let fixture: ComponentFixture<EmployeeWorkingStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeWorkingStatusComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeWorkingStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
