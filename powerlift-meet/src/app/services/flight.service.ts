import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Meet } from './meet.service';
import { MeetAthlete } from './meetathlete.service';

export interface Flight {
    id: string;
    meetId: string;
    meetDto: Meet; 
    label: string;
    flightNumber: number;
    meetAthletes: MeetAthlete[];
}

export interface CreateFlightRequest {
  label: string;
  flightNumber: number;
  meetAthleteIds: string[];
}

@Injectable({ providedIn: 'root' })
export class FlightService {
  private apiUrl = `${environment.apiBaseUrl}/flight`;

  constructor(private http: HttpClient) {}

  getFlightsByMeetId(meetId: string) {
    return this.http.get<Flight[]>(`${this.apiUrl}/meet/${meetId}`);
  }

  addFlightToMeet(meetId: string, request: CreateFlightRequest) {
    return this.http.post(`${this.apiUrl}/meet/${meetId}`, request);
  }

  editFlight(flightId: string, request: CreateFlightRequest) {
    return this.http.put(`${this.apiUrl}/${flightId}`, request);
  }

  deleteFlight(flightId: string) {
    return this.http.delete(`${this.apiUrl}/${flightId}`);
  }
}