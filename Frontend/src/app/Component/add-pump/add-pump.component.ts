import { Motor } from 'src/app/Dto/motor';
import { MaterialService } from './../../service/material.service';
import { Component, OnInit } from '@angular/core';
import { PumpRequest } from 'src/app/Dto/pump';
import { MotorService } from 'src/app/service/motor.service';
import { PumpService } from 'src/app/service/pump.service';
import { Material } from 'src/app/Dto/material';
import { Router } from '@angular/router';


@Component({
  selector: 'app-add-pump',
  templateUrl: './add-pump.component.html',
  styleUrls: ['./add-pump.component.css'],
})
export class AddPumpComponent implements OnInit{

  pump: PumpRequest = {
    name: '',
    maxPressure: 0,
    temperature: 0,
    weight: 0,
    motorId: '',
    description: '',
    picture: '',
    price: 0,
    materialHullId: null,
    impellerMaterialId: null
  };


  motors: Motor[] = [ ];
  materials: Material[] = [ ];

  constructor(private pumpservice: PumpService, private motorservice: MotorService,
    private materialservice: MaterialService, private router: Router){

  }

  ngOnInit(){
    this.motorservice.getMotors().subscribe({
      next: data => {
        this.motors.push(...data);
      },
      error: err => {console.log(err)}
    });

    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials.push(...data);

      },
      error: err => {console.log(err)}
    });
  }

  onFormSubmit(){
    this.pump.picture = this.selectedFileBase64;
    this.pumpservice.addPump(this.pump).subscribe({
      next: (response) => {
        this.router.navigate(['admin/pumps']);
      },
      error: (err) => {}
    })

    document.getElementById('cancel')?.click();
  };

  selectedFile: File | null = null;
  selectedFileBase64: string = '';

  handleFileInput(event: any) {
    this.selectedFile = event.target.files[0];
    if (!this.isImageFileType(event.target.files[0].type))
    {
      alert('Only .jpg files are allowed');
      this.selectedFile = null;
      this.selectedFileBase64 = '';
    }
    else
    {
      const reader = new FileReader();
      reader.onload = (event: any) => {
        const base64String = event.target.result;
        this.selectedFileBase64 = base64String;
        };
        let res =  reader.readAsDataURL(event.target.files[0]);
    }
  };

  isImageFileType(type: string): boolean {
    return type === 'image/jpeg' || type === 'image/jpg';
  };
}
