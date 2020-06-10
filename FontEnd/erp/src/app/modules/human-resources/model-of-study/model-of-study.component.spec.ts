import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelOfStudyComponent } from './model-of-study.component';

describe('ModelOfStudyComponent', () => {
  let component: ModelOfStudyComponent;
  let fixture: ComponentFixture<ModelOfStudyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelOfStudyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelOfStudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
