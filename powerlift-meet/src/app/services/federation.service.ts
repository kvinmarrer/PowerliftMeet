import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Federation {
  id: string;
  name: string;
  description: string;
}

@Injectable({ providedIn: 'root' })
export class FederationService {
    
  private apiUrl = `${environment.apiBaseUrl}/federation`;

  constructor(private http: HttpClient) {}

  getFederations() {
    return this.http.get<Federation[]>(this.apiUrl);
  }

}