import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDiciplineComponent } from './employee-dicipline.component';

describe('EmployeeDiciplineComponent', () => {
  let component: EmployeeDiciplineComponent;
  let fixture: ComponentFixture<EmployeeDiciplineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeDiciplineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDiciplineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
