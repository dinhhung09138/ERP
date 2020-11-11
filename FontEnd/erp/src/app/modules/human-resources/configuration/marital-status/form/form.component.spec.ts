import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MaritalStatusFormComponent } from './form.component';

describe('MaritalStatusFormComponent', () => {
  let component: MaritalStatusFormComponent;
  let fixture: ComponentFixture<MaritalStatusFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MaritalStatusFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MaritalStatusFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
