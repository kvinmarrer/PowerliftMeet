import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({ providedIn: 'root' })
export class AthleteService {
    
  private apiUrl = `${environment.apiBaseUrl}/athlete`;

  constructor(private http: HttpClient) {}

  getAthletes() {
    return this.http.get<string[]>(this.apiUrl);
  }

}