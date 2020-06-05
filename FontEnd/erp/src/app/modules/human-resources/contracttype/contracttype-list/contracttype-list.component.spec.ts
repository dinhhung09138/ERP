import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContracttypeListComponent } from './contracttype-list.component';

describe('ContracttypeListComponent', () => {
  let component: ContracttypeListComponent;
  let fixture: ComponentFixture<ContracttypeListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContracttypeListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContracttypeListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
