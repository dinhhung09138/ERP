import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeBankFormComponent } from './form.component';

describe('EmployeeBankFormComponent', () => {
  let component: EmployeeBankFormComponent;
  let fixture: ComponentFixture<EmployeeBankFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeBankFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeBankFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
