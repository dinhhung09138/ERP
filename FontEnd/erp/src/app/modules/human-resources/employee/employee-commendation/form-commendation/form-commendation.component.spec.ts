import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormCommendationComponent } from './form-commendation.component';

describe('FormCommendationComponent', () => {
  let component: FormCommendationComponent;
  let fixture: ComponentFixture<FormCommendationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormCommendationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormCommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
