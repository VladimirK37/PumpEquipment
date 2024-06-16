import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Motor, MotorRequest } from '../Dto/motor';

@Injectable({
  providedIn: 'root'
})
export class MotorService {
  private apiUrl = 'https://localhost:7005/motor';

  constructor(private http: HttpClient) { }

  getMotors() {
    return this.http.get<Motor[]>(this.apiUrl);
  }

  addMotor(motor: MotorRequest): Observable<void> {
    return this.http.post<void>(this.apiUrl, motor);
  }

  updateMotor(motor: Motor): Observable<void> {
    return this.http.put<void>(this.apiUrl, motor);
  }

  deleteMotor(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
