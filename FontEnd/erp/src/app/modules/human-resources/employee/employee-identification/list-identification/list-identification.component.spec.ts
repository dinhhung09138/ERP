import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListIdentificationComponent } from './list-identification.component';

describe('ListIdentificationComponent', () => {
  let component: ListIdentificationComponent;
  let fixture: ComponentFixture<ListIdentificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ListIdentificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListIdentificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
