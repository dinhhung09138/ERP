import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainingTypeFormComponent } from './form.component';

describe('TrainingTypeFormComponent', () => {
  let component: TrainingTypeFormComponent;
  let fixture: ComponentFixture<TrainingTypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TrainingTypeFormComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainingTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
