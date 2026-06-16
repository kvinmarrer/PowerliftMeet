import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

export interface Athlete {
  id: string;
  firstName: string;
  lastName: string;
  clubId: string;
  clubDto: {
    id: string;
    name: string;
    description: string;
  };
  gender: string;
  dateOfBirth: string;
}

export interface CreateAthleteRequest {
  firstName: string;
  lastName: string;
  clubId: string;
  gender: string;
  dateOfBirth: string;
}

export interface EditAthleteRequest {
  firstName: string;
  lastName: string;
  clubId: string;
  gender: string;
  dateOfBirth: string;
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

  deleteAthlete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }

}