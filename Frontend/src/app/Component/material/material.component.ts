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
  public isShowMaterial = true;
  materials: Material[] = [];
  materialEdit: Material = {
    guid:'',
    name:'',
    description: '',
  };

  constructor(private materialservice: MaterialService){

  }
  ngOnInit(){
    this.materialservice.getMaterials().subscribe({
      next: data => {
        this.materials = data;
      },
      error: err => {console.log(err)}
    });
  }

  setUpdate(material: Material){
    this.isShowMaterial = false;
    this.materialEdit = structuredClone(material);
  }

  setEdit(material: Material){
    this.isShowMaterial = true;
    this.materialservice.updateMaterial(material).subscribe({
      error: err => {console.log(err)}
    });
  }

  setFlag(){
    this.isShowMaterial = true;
  }

  setDelete(material: Material){
    const index = this.materials.findIndex((m) => m.guid === material.guid);

    if (index !== -1) {
      this.materials.splice(index, 1);
    }
    this.materialservice.deleteMaterial(material.guid).subscribe({
      error: err => {console.log(err)}
    });
  }
}
