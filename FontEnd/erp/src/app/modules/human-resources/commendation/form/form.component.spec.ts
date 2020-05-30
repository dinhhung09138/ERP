import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CommendationFormComponent } from './form.component';

describe('CommendationFormComponent', () => {
  let component: CommendationFormComponent;
  let fixture: ComponentFixture<CommendationFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [CommendationFormComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CommendationFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
