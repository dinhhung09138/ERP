import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEducationFormComponent } from './form.component';

describe('EmployeeEducationFormComponent', () => {
  let component: EmployeeEducationFormComponent;
  let fixture: ComponentFixture<EmployeeEducationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeEducationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEducationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
