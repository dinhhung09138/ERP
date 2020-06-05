import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ContracttypeFormComponent } from './contracttype-form.component';

describe('ContracttypeFormComponent', () => {
  let component: ContracttypeFormComponent;
  let fixture: ComponentFixture<ContracttypeFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ContracttypeFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ContracttypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
