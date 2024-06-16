import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddMotorComponent } from './add-motor.component';

describe('AddMotorComponent', () => {
  let component: AddMotorComponent;
  let fixture: ComponentFixture<AddMotorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddMotorComponent]
    });
    fixture = TestBed.createComponent(AddMotorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
