import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LeaveStatusFormComponent } from './form.component';

describe('LeaveStatusFormComponent', () => {
  let component: LeaveStatusFormComponent;
  let fixture: ComponentFixture<LeaveStatusFormComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LeaveStatusFormComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LeaveStatusFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
