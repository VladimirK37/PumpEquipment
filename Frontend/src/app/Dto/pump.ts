import { Material } from "./material";
import { Motor } from "./motor";

export interface Pump {
  id: string;
  name: string;
  maxPressure: number;
  temperature: number;
  weight: number;
  // motorId: number;
  motorEntity: Motor;
  impellerMaterial: Material;
  materialHull: Material;
  description: string;
  picture: string;
  price: number;
}

export interface PumpRequest {
  name: string;
  maxPressure: number;
  temperature: number;
  weight: number;
  motorId: string;
  description: string;
  picture: string;
  price: number;
  impellerMaterialId: string | null;
  materialHullId: string | null;
}
