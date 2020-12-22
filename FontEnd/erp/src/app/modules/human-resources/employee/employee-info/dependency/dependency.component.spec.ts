import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeDependencyComponent } from './dependency.component';

describe('EmployeeDependencyComponent', () => {
  let component: EmployeeDependencyComponent;
  let fixture: ComponentFixture<EmployeeDependencyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeDependencyComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeDependencyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
