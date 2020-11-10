import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeCertificateFormComponent } from './form.component';

describe('EmployeeCertificateFormComponent', () => {
  let component: EmployeeCertificateFormComponent;
  let fixture: ComponentFixture<EmployeeCertificateFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmployeeCertificateFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeCertificateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
