export interface Motor {
  guid: string;
  current: number;
  description: string;
  motor: string;
  name: string;
  power: number;
  nominalSpeed: number;
  price: number;
}

export interface MotorRequest {
  name: string;
  description: string;
  current: number;
  motor: string;
  power: number;
  nominalSpeed: number;
  price: number;
}
