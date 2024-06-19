import { Component } from '@angular/core';
import { MaterialService } from 'src/app/service/material.service';
import { OnInit } from '@angular/core';
import { Material } from 'src/app/Dto/material';

@Component({
  selector: 'app-material',
  templateUrl: './material.component.html',
  styleUrls: ['./material.component.css']
})
export class MaterialComponent implements OnInit{
  materials: Material[] = [];

  constructor(private materialservice: MaterialService){

  }
  ngOnInit(){
    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials = data;
      },
      error: err => {}
    });
  }

  setDelete(material: Material){
    const index = this.materials.findIndex((m) => m.id === material.id);

    if (index !== -1) {
      this.materials.splice(index, 1);
    }
    this.materialservice.deleteMaterial(material.id).subscribe({
      error: err => {}
    });
  };
}
