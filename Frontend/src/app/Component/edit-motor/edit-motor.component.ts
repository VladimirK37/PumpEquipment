import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Motor } from 'src/app/Dto/motor';
import { MotorService } from 'src/app/service/motor.service';

@Component({
  selector: 'app-edit-motor',
  templateUrl: './edit-motor.component.html',
  styleUrl: './edit-motor.component.css'
})
export class EditMotorComponent implements OnInit{

  motor: Motor = {
    id:'',
    current: 0,
    description: '',
    motor: '',
    name: '',
    power: 0,
    nominalSpeed: 0,
    price: 0
  };

  constructor( private motorservice: MotorService, private router: Router,private route: ActivatedRoute){
  }

  ngOnInit(){
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
        this.motorservice.getMotor(id).subscribe({
            next: (response) => {
              this.motor = response;
            },
            error: err => {}
          });
        }
      }
    });
  }

  onFormSubmit(){
    this.motorservice.updateMotor(this.motor).subscribe({
      next: (response) => {
        this.router.navigate(['admin/motors']);
      },
      error: (err) => {}
    })

    document.getElementById('cancel')?.click();
  };

}
