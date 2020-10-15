import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeRelationshipFormComponent } from './form.component';

describe('FormComponent', () => {
  let component: EmployeeRelationshipFormComponent;
  let fixture: ComponentFixture<EmployeeRelationshipFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeRelationshipFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeRelationshipFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
