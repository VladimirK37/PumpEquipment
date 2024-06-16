import { Component } from '@angular/core';
import { MaterialRequest } from 'src/app/Dto/material';
import { MaterialService } from 'src/app/service/material.service';

@Component({
  selector: 'app-add-material',
  templateUrl: './add-material.component.html',
  styleUrls: ['./add-material.component.css']
})
export class AddMaterialComponent {
  material: MaterialRequest = {
    name: '',
    description: ''
  };

  constructor( private materialservice: MaterialService){

  }

  onFormSubmit(){
    this.materialservice.addMaterial(this.material).subscribe({
      next: (response) => {

      },
      error: (err) => {}
    });

    document.getElementById('cancel')?.click();
  }
}
