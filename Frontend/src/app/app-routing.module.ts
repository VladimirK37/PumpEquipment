import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PumpComponent } from './Component/pump/pump.component';
import { AddPumpComponent } from './Component/add-pump/add-pump.component';
import { AddMotorComponent } from './Component/add-motor/add-motor.component';
import { MotorComponent } from './Component/motor/motor.component';
import { MaterialComponent } from './Component/material/material.component';
import { AddMaterialComponent } from './Component/add-material/add-material.component';
import { EditPumpComponent } from './Component/edit-pump/edit-pump.component';
import { EditMotorComponent } from './Component/edit-motor/edit-motor.component';
import { EditMaterialComponent } from './Component/edit-material/edit-material.component';

const routes: Routes = [
  {
    path: 'admin/pumps',
    component: PumpComponent
  },
  {
    path: 'admin/pumps/add',
    component: AddPumpComponent
  },
  {
    path: 'pumps/edit/:id',
    component: EditPumpComponent
  },
  {
    path: 'admin/motors',
    component: MotorComponent
  }
  ,
  {
    path: 'admin/motors/add',
    component:AddMotorComponent
  },
  {
    path: 'motors/edit/:id',
    component: EditMotorComponent
  },
  {
    path: 'admin/materials',
    component: MaterialComponent
  },
  {
    path: 'admin/materials/add',
    component: AddMaterialComponent
  },
  {
    path: 'materials/edit/:id',
    component: EditMaterialComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
