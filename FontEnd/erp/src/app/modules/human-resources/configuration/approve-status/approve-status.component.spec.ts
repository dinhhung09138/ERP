import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ApproveStatusComponent } from './approve-status.component';

describe('ApproveStatusComponent', () => {
  let component: ApproveStatusComponent;
  let fixture: ComponentFixture<ApproveStatusComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ApproveStatusComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ApproveStatusComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
