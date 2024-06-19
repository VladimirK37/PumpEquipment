import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditMotorComponent } from './edit-motor.component';

describe('EditMotorComponent', () => {
  let component: EditMotorComponent;
  let fixture: ComponentFixture<EditMotorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditMotorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditMotorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
