import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelOfStudyFormComponent } from './model-of-study-form.component';

describe('ModelOfStudyFormComponent', () => {
  let component: ModelOfStudyFormComponent;
  let fixture: ComponentFixture<ModelOfStudyFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelOfStudyFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelOfStudyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
