import { Component, OnInit } from '@angular/core';
import { Motor } from 'src/app/Dto/motor';
import { MotorService } from 'src/app/service/motor.service';

@Component({
  selector: 'app-motor',
  templateUrl: './motor.component.html',
  styleUrls: ['./motor.component.css']
})

export class MotorComponent implements OnInit{

public isShowMotor = true;

  motors: Motor[] = [];
  motorEdit: Motor = {
    guid:'',
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
        console.log(data)
      },
      error: err => {console.log(err)}
    });
  }

  setUpdate(motor: Motor){
    this.isShowMotor = false;
    this.motorEdit = structuredClone(motor);
  }

  setEdit(motor: Motor){
    this.isShowMotor = true;
    // for (let key in motor) {
    //   var value = motor.key;
      // if (motor[key] === this.motorEdit[key]){

      // }
    // }
    // if(motor === this.motorEdit){
    //   console.log(motor);
    //   console.log(this.motorEdit);
    // }
    this.motorservice.updateMotor(motor).subscribe({
      error: err => {console.log(err)}
    });
  }

  setFlag(){
    this.isShowMotor = true;
  }

  setDelete(motor: Motor){
    const index = this.motors.findIndex((m) => m.guid === motor.guid);

    if (index !== -1) {
      this.motors.splice(index, 1);
    }
    this.motorservice.deleteMotor(motor.guid).subscribe({
      error: err => {console.log(err)}
    });
  }
}
