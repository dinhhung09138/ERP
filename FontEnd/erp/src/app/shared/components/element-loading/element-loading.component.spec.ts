import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ElementLoadingComponent } from './element-loading.component';

describe('ElementLoadingComponent', () => {
  let component: ElementLoadingComponent;
  let fixture: ComponentFixture<ElementLoadingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ElementLoadingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ElementLoadingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
