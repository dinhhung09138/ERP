import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AppraiseComponent } from './appraise.component';

describe('AppraiseComponent', () => {
  let component: AppraiseComponent;
  let fixture: ComponentFixture<AppraiseComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AppraiseComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AppraiseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
