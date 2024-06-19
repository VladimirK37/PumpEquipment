import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Material } from 'src/app/Dto/material';
import { MaterialService } from 'src/app/service/material.service';

@Component({
  selector: 'app-edit-material',
  templateUrl: './edit-material.component.html',
  styleUrl: './edit-material.component.css'
})
export class EditMaterialComponent implements OnInit{
  material: Material = {
    id:'',
    name:'',
    description: '',
  };

  constructor( private materialservice: MaterialService, private router: Router,
    private route: ActivatedRoute){
  }

  ngOnInit(){
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
        if(id){
        this.materialservice.getMaterial(id).subscribe({
            next: (response) => {
              this.material = response;
            },
            error: err => {}
          });
        }
      }
    });
  }

  onFormSubmit(){
    this.materialservice.updateMaterial(this.material).subscribe({
      next: (response) => {
        this.router.navigate(['admin/materials']);
      },
      error: (err) => {}
    })

    document.getElementById('cancel')?.click();
  };
}
