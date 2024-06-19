import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Material, MaterialRequest } from '../Dto/material';

@Injectable({
  providedIn: 'root'
})
export class MaterialService {
  private apiUrl = 'https://localhost:7220/material';

  constructor(private http: HttpClient) { }

  getMaterials() {
    return this.http.get<Material[]>(this.apiUrl);
  }

  getMaterial(id: string): Observable<Material> {
    return this.http.get<Material>(`${this.apiUrl}/${id}`);
  }

  addMaterial(material: MaterialRequest): Observable<void> {
    return this.http.post<void>(this.apiUrl, material);
  }

  updateMaterial(material: Material): Observable<void> {
    return this.http.put<void>(this.apiUrl, material);
  }

  deleteMaterial(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
