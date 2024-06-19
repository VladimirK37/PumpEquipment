import { MotorService } from 'src/app/service/motor.service';
import { Component, OnInit } from '@angular/core';
import { Pump } from 'src/app/Dto/pump';
import { Motor } from 'src/app/Dto/motor';
import { PumpService } from 'src/app/service/pump.service';
import { MaterialService } from 'src/app/service/material.service';
import { Material } from 'src/app/Dto/material';

@Component({
  selector: 'app-pump',
  templateUrl: './pump.component.html',
  styleUrls: ['./pump.component.css']
})
export class PumpComponent implements OnInit{

  pumps: Pump[] = [];
  motors: Motor[] = [];
  materials: Material[] = [];

  constructor(private pumpservice: PumpService, private motorservice: MotorService, private materialservice: MaterialService){

  }

  ngOnInit(){
    this.pumpservice.getPumps().subscribe({
      next: data => {
        this.pumps = data
        console.log(this.pumps)
      },
      error: err => {}
    });

    this.motorservice.getMotors().subscribe({
      next: data => {
        this.motors = data;
        console.log(this.motors)
      },
      error: err => {}
    });

    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials = data;
      },
      error: err => {}
    });
  }

  setDelete(pump: Pump){
    const index = this.pumps.findIndex((m) => m.id === pump.id);

    if (index !== -1) {
      this.pumps.splice(index, 1);
    }
    this.pumpservice.deletePump(pump.id).subscribe({
      error: err => {}
    });
  }
}
