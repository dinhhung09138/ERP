import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessionalQualificationFormComponent } from './professional-qualification-form.component';

describe('ProfessionalQualificationFormComponent', () => {
  let component: ProfessionalQualificationFormComponent;
  let fixture: ComponentFixture<ProfessionalQualificationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessionalQualificationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessionalQualificationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
