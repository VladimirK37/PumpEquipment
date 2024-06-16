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
  pump: Pump | undefined;
  id: string = '';
  public isShowPump = true;
  selectedFile: File | null = null;
  selectedFileBase64: any;

  constructor(private pumpservice: PumpService, private motorservice: MotorService, private materialservice: MaterialService){

  }

  ngOnInit(){
    this.pumpservice.getPumps().subscribe({
      next: data => {
        this.pumps = data
        console.log(data);
      },
      error: err => {console.log(err)}
    });

    this.motorservice.getMotors().subscribe({
      next: data => {
        this.motors = data;
      },
      error: err => {console.log(err)}
    });

    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials = data;
      },
      error: err => {console.log(err)}
    });
  }

  setUpdate(pump: Pump){
    this.isShowPump = false;
    this.id = pump.id;
    this.pump = pump;
  }

  setFlag(){
    this.isShowPump = true;
  }


  setEdit(pump: Pump){
    this.pumpservice.updatePump(pump).subscribe({
      next: data => {
      },
      error: err => {console.log(err)}
    });
    document.getElementById('cancel')?.click();
  }

  setDelete(pump: Pump){
    const index = this.pumps.findIndex((m) => m.id === pump.id);

    if (index !== -1) {
      this.pumps.splice(index, 1);
    }
    this.pumpservice.deletePump(pump.id).subscribe({
      error: err => {console.log(err)}
    });
  }

  handleFileInput(event:any){
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
