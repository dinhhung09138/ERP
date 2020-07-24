import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecializeFormComponent } from './form.component';

describe('SpecializeFormComponent', () => {
  let component: SpecializeFormComponent;
  let fixture: ComponentFixture<SpecializeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [SpecializeFormComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecializeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
