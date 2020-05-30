import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommendationListComponent } from './list.component';

describe('CommendationListComponent', () => {
  let component: CommendationListComponent;
  let fixture: ComponentFixture<CommendationListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CommendationListComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommendationListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
