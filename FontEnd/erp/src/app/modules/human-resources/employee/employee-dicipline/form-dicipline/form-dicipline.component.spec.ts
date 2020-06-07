import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormDiciplineComponent } from './form-dicipline.component';

describe('FormDiciplineComponent', () => {
  let component: FormDiciplineComponent;
  let fixture: ComponentFixture<FormDiciplineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormDiciplineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormDiciplineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
