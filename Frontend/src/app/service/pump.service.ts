import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Pump, PumpRequest} from '../Dto/pump';

@Injectable({
  providedIn: 'root'
})
export class PumpService {
  private apiUrl = 'https://localhost:****/pump';

  constructor(private http: HttpClient) { }

  getPumps() {
    return this.http.get<Pump[]>(this.apiUrl);
  }

  getPump(id: number): Observable<Pump> {
    return this.http.get<Pump>(`${this.apiUrl}/${id}`);
  }

  addPump(pump: PumpRequest): Observable<void> {
    return this.http.post<void>(this.apiUrl, pump);
  }

  updatePump( pump: Pump): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}`, pump);
  }

  deletePump(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
