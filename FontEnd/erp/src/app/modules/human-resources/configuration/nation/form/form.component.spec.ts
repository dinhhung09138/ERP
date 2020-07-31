import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NationFormComponent } from './form.component';

describe('NationFormComponent', () => {
  let component: NationFormComponent;
  let fixture: ComponentFixture<NationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NationFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
