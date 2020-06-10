import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelOfStudyListComponent } from './model-of-study-list.component';

describe('ModelOfStudyListComponent', () => {
  let component: ModelOfStudyListComponent;
  let fixture: ComponentFixture<ModelOfStudyListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelOfStudyListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelOfStudyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
