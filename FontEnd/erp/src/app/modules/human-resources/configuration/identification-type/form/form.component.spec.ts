import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentificationTypeFormComponent } from './form.component';

describe('IdentificationTypeFormComponent', () => {
  let component: IdentificationTypeFormComponent;
  let fixture: ComponentFixture<IdentificationTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [IdentificationTypeFormComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentificationTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
