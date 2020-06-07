import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListEducationComponent } from './list-education.component';

describe('ListEducationComponent', () => {
  let component: ListEducationComponent;
  let fixture: ComponentFixture<ListEducationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListEducationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListEducationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
