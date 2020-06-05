import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelofstudyFormComponent } from './modelofstudy-form.component';

describe('ModelofstudyFormComponent', () => {
  let component: ModelofstudyFormComponent;
  let fixture: ComponentFixture<ModelofstudyFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelofstudyFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelofstudyFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
