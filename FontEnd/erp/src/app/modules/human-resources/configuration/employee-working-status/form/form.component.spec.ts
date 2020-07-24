import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeWorkingStatusFormComponent } from './form.component';

describe('FormComponent', () => {
  let component: EmployeeWorkingStatusFormComponent;
  let fixture: ComponentFixture<EmployeeWorkingStatusFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [EmployeeWorkingStatusFormComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeWorkingStatusFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
