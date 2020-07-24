import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommendationComponent } from './commendation.component';

describe('CommendationComponent', () => {
  let component: CommendationComponent;
  let fixture: ComponentFixture<CommendationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CommendationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
