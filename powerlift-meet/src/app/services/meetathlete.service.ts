import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { WeightClass } from './weightclass.service';
import { Athlete } from './athlete.service';
import { Meet } from './meet.service';

export interface MeetAthlete {
  id: string;
  weightClassId: string;
  weightClassDto: WeightClass;
  athleteId: string;
  athleteDto: Athlete;
  meetId: string;
  meetDto: Meet;
  flightId: string;
  bodyWeight: number;
  lot: number;
  equipment: string;
}   

export interface CreateMeetAthleteRequest {
  weightClassId: string;
  athleteId: string;
  meetId: string;
  bodyWeight: number;
  lot: number;
}

@Injectable({ providedIn: 'root' })
export class MeetAthleteService {
    
  private apiUrl = `${environment.apiBaseUrl}/meetathlete`;

  constructor(private http: HttpClient) {}

  getMeetAthletes() {
    return this.http.get<MeetAthlete[]>(this.apiUrl);
  }

  getMeetAthletesByMeetId(meetId: string) {
    return this.http.get<MeetAthlete[]>(`${this.apiUrl}/meet/${meetId}`);
  }

  addMeetAthleteToMeet(meetId: string, meetAthlete: MeetAthlete) {
    return this.http.post<MeetAthlete>(`${this.apiUrl}/meet/${meetId}`, meetAthlete);
  }

}