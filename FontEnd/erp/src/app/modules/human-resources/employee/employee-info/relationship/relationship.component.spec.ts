import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeRelationshipComponent } from './relationship.component';

describe('RelationshipComponent', () => {
  let component: EmployeeRelationshipComponent;
  let fixture: ComponentFixture<EmployeeRelationshipComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmployeeRelationshipComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeRelationshipComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
