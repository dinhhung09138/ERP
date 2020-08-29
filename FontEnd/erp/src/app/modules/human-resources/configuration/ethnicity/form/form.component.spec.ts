import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EthnicityFormComponent } from './form.component';

describe('EthnicityFormComponent', () => {
  let component: EthnicityFormComponent;
  let fixture: ComponentFixture<EthnicityFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EthnicityFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EthnicityFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
