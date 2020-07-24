import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingCenterFormComponent } from './form.component';

describe('TrainingCenterFormComponent', () => {
  let component: TrainingCenterFormComponent;
  let fixture: ComponentFixture<TrainingCenterFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainingCenterFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainingCenterFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
