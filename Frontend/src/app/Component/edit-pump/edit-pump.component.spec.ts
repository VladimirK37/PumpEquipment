import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditPumpComponent } from './edit-pump.component';

describe('EditPumpComponent', () => {
  let component: EditPumpComponent;
  let fixture: ComponentFixture<EditPumpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EditPumpComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(EditPumpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
