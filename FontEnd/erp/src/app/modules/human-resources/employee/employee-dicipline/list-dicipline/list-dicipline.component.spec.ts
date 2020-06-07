import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDiciplineComponent } from './list-dicipline.component';

describe('ListDiciplineComponent', () => {
  let component: ListDiciplineComponent;
  let fixture: ComponentFixture<ListDiciplineComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListDiciplineComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListDiciplineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
