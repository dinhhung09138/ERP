import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListCommendationComponent } from './list-commendation.component';

describe('ListCommendationComponent', () => {
  let component: ListCommendationComponent;
  let fixture: ComponentFixture<ListCommendationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListCommendationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListCommendationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
