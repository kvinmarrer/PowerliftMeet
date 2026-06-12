import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Athlete {
  id: number;
  firstName: string;
  lastName: string;
  weightClass: number;
  weightClassDto: {
    id: number;
    weight: number;
  };
  dateOfBirth: string;
  gender: string;
}

@Injectable({ providedIn: 'root' })
export class AthleteService {
    
  private apiUrl = `${environment.apiBaseUrl}/athlete`;

  constructor(private http: HttpClient) {}

  getAthletes() {
    return this.http.get<Athlete[]>(this.apiUrl);
  }

}