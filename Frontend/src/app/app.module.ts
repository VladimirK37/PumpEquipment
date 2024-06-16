import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavbarComponent } from './Component/navbar/navbar.component';
import { PumpComponent } from './Component/pump/pump.component';
import { AddPumpComponent } from './Component/add-pump/add-pump.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import {MatSelectModule} from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AddMotorComponent } from './Component/add-motor/add-motor.component';
import { MotorComponent } from './Component/motor/motor.component';
import { MaterialComponent } from './Component/material/material.component';
import { AddMaterialComponent } from './Component/add-material/add-material.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    PumpComponent,
    AddPumpComponent,
    AddMotorComponent,
    MotorComponent,
    MaterialComponent,
    AddMaterialComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    MatSelectModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

