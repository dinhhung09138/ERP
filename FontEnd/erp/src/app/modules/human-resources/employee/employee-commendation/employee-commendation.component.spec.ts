import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeCommendationComponent } from './employee-commendation.component';

describe('EmployeeCommendationComponent', () => {
  let component: EmployeeCommendationComponent;
  let fixture: ComponentFixture<EmployeeCommendationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeCommendationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeCommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
