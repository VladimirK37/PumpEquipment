import { Component, OnInit } from '@angular/core';
import { Motor } from 'src/app/Dto/motor';
import { MotorService } from 'src/app/service/motor.service';

@Component({
  selector: 'app-motor',
  templateUrl: './motor.component.html',
  styleUrls: ['./motor.component.css']
})

export class MotorComponent implements OnInit{

  motors: Motor[] = [];
  motorEdit: Motor = {
    id:'',
    current: 0,
    description: '',
    motor: '',
    name: '',
    power: 0,
    nominalSpeed: 0,
    price: 0
  };

  constructor(private motorservice: MotorService){
  }

  ngOnInit(){
    this.motorservice.getMotors().subscribe({
      next: data => {
        this.motors = data;
      },
      error: err => {}
    });
  }

  setDelete(motor: Motor){
    const index = this.motors.findIndex((m) => m.id === motor.id);

    if (index !== -1) {
      this.motors.splice(index, 1);
    }
    this.motorservice.deleteMotor(motor.id).subscribe({
      error: err => {}
    });
  }
}
