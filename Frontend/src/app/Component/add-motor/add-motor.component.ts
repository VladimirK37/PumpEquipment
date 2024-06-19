import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Motor, MotorRequest } from 'src/app/Dto/motor';
import { MotorService } from 'src/app/service/motor.service';

@Component({
  selector: 'app-add-motor',
  templateUrl: './add-motor.component.html',
  styleUrls: ['./add-motor.component.css']
})
export class AddMotorComponent {
  motor: MotorRequest = {
    current: 0,
    description: '',
    motor: '',
    name: '',
    power: 0,
    nominalSpeed: 0,
    price: 0
  };

  constructor( private motorservice: MotorService,private router: Router){

  }

  onFormSubmit(){
    this.motorservice.addMotor(this.motor).subscribe({
      next: (response) => {
        this.router.navigate(['admin/motors']);
      },
      error: (err) => {}
    })

    document.getElementById('cancel')?.click();
  }
}
