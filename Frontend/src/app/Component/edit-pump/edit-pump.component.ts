import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Material } from 'src/app/Dto/material';
import { Motor } from 'src/app/Dto/motor';
import { Pump } from 'src/app/Dto/pump';
import { MaterialService } from 'src/app/service/material.service';
import { MotorService } from 'src/app/service/motor.service';
import { PumpService } from 'src/app/service/pump.service';

@Component({
  selector: 'app-edit-pump',
  templateUrl: './edit-pump.component.html',
  styleUrl: './edit-pump.component.css'
})
export class EditPumpComponent implements OnInit{

  constructor(private pumpservice: PumpService, private motorservice: MotorService,
    private materialservice: MaterialService, private router: Router,private route: ActivatedRoute){

  }

  selectedFile: File | null = null;
  selectedFileBase64: string = '';

  motor: Motor = {
    id: '',
    current: 0,
    description: '',
    motor: '',
    name: '',
    power: 0,
    nominalSpeed: 0,
    price: 0
  };
  material: Material = {
    id:'',
    name: '',
    description: ''
  };

  pump: Pump = {
    id:'',
    name: '',
    maxPressure: 0,
    temperature: 0,
    weight: 0,
    motorEntity: this.motor,
    description: '',
    picture: '',
    price: 0,
    materialHull: this.material,
    impellerMaterial: this.material
  };
  motors: Motor[] = [ ];
  materials: Material[] = [ ];

  ngOnInit(){
    this.motorservice.getMotors().subscribe({
      next: data => {
        this.motors.push(...data);
      },
      error: err => {}
    });

    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials.push(...data);
      },
      error: err => {}
    });

    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        console.log(params)
        if(id){
        this.pumpservice.getPump(id).subscribe({
            next: (response) => {
              this.pump = response;

            },
            error: err => {console.log(err)}
          });
        }
      }
    })

  }

  onFormSubmit(){
    this.pump.picture = this.selectedFileBase64;
    console.log(this.pump);
    this.pumpservice.updatePump(this.pump).subscribe({
      next: (response) => {
        this.router.navigate(['admin/pumps']);
      },
      error: (err) => {}
    })

    document.getElementById('cancel')?.click();
  };

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
        reader.readAsDataURL(event.target.files[0]);
    }
  };

  isImageFileType(type: string): boolean {
    return type === 'image/jpeg' || type === 'image/jpg';
  };

}
