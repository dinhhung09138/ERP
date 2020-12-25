import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaveTypeFormComponent } from './form.component';

describe('LeaveTypeFormComponent', () => {
  let component: LeaveTypeFormComponent;
  let fixture: ComponentFixture<LeaveTypeFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaveTypeFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaveTypeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
