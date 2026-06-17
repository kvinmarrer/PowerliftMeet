import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface WeightClass {
  id: string;
  weight: number;
}

@Injectable({ providedIn: 'root' })
export class WeightClassService {
    
  private apiUrl = `${environment.apiBaseUrl}/weightclass`;

  constructor(private http: HttpClient) {}

  getWeightClasses() {
    return this.http.get<WeightClass[]>(this.apiUrl);
  }

  getWeightClassesByAthleteGender(athleteId: string) {
    return this.http.get<WeightClass[]>(`${this.apiUrl}/by-athlete-gender/${athleteId}`);
  }

}