import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface Athlete {
  id: string;
  firstName: string;
  lastName: string;
  federationId: string;
  federationDto: {
    id: string;
    name: string;
    description: string;
  };
  weightClassId: string;
  weightClassDto: {
    id: string;
    weight: number;
  };
  dateOfBirth: string;
  gender: string;
}

export interface CreateAthleteRequest {
  firstName: string;
  lastName: string;
  federationId: string;
  weightClassId: string;
  dateOfBirth: string;
  gender: string;
}

export interface EditAthleteRequest {
  firstName: string;
  lastName: string;
  federationId: string;
  weightClassId: string;
  dateOfBirth: string;
  gender: string;
}

@Injectable({ providedIn: 'root' })
export class AthleteService {
    
  private apiUrl = `${environment.apiBaseUrl}/athlete`;

  constructor(private http: HttpClient) {}

  getAthletes(): Observable<Athlete[]> {
    return this.http.get<Athlete[]>(this.apiUrl);
  }

  addAthlete(request: CreateAthleteRequest): Observable<Athlete> {
    return this.http.post<Athlete>(this.apiUrl, request);
  }

  updateAthlete(id: string, request: EditAthleteRequest): Observable<Athlete> {
    return this.http.put<Athlete>(`${this.apiUrl}/${id}`, request);
  }

}