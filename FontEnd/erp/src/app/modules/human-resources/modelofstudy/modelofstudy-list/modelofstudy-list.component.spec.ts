import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModelofstudyListComponent } from './modelofstudy-list.component';

describe('ModelofstudyListComponent', () => {
  let component: ModelofstudyListComponent;
  let fixture: ComponentFixture<ModelofstudyListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModelofstudyListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModelofstudyListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
