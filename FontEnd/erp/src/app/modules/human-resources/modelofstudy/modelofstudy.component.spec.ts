import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelofstudyComponent } from './modelofstudy.component';

describe('ModelofstudyComponent', () => {
  let component: ModelofstudyComponent;
  let fixture: ComponentFixture<ModelofstudyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelofstudyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelofstudyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
