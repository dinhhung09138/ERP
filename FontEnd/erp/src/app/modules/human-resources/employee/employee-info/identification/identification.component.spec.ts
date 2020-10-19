import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeIdentificationComponent } from './identification.component';

describe('EmployeeIdentificationComponent', () => {
  let component: EmployeeIdentificationComponent;
  let fixture: ComponentFixture<EmployeeIdentificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeIdentificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeIdentificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
