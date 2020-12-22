import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDependencyFormComponent } from './form.component';

describe('EmployeeDependencyFormComponent', () => {
  let component: EmployeeDependencyFormComponent;
  let fixture: ComponentFixture<EmployeeDependencyFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeDependencyFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDependencyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
