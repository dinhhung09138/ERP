import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeIdentificationFormComponent } from './form.component';

describe('FormComponent', () => {
  let component: EmployeeIdentificationFormComponent;
  let fixture: ComponentFixture<EmployeeIdentificationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeIdentificationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeIdentificationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
