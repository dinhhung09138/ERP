import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfessionalQualificationListComponent } from './professional-qualification-list.component';

describe('ProfessionalQualificationListComponent', () => {
  let component: ProfessionalQualificationListComponent;
  let fixture: ComponentFixture<ProfessionalQualificationListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfessionalQualificationListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfessionalQualificationListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
