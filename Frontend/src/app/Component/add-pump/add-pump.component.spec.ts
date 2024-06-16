import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddPumpComponent } from './add-pump.component';

describe('AddPumpComponent', () => {
  let component: AddPumpComponent;
  let fixture: ComponentFixture<AddPumpComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddPumpComponent]
    });
    fixture = TestBed.createComponent(AddPumpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
