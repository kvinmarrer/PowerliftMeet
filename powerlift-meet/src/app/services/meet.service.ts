import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

export interface Meet {
  id: string;
  name: string;
  date: string;
  location: string;
}

export interface CreateMeetRequest {
  name: string;
  date: string;
  location: string;
  description: string;
}

@Injectable({ providedIn: 'root' })
export class MeetService {
  private apiUrl = `${environment.apiBaseUrl}/meet`;

  constructor(private http: HttpClient) {}

  getMeets() {
    return this.http.get<Meet[]>(this.apiUrl);
  }

  addMeet(request: CreateMeetRequest) {
    return this.http.post(this.apiUrl, request);
  }

  editMeet(meetId: string, request: CreateMeetRequest) {
    return this.http.put(`${this.apiUrl}/${meetId}`, request);
  }

  deleteMeet(meetId: string) {
    return this.http.delete(`${this.apiUrl}/${meetId}`);
  }
  
}